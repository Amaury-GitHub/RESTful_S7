using RestSharp;
using Newtonsoft.Json.Linq;
using S7.Net;
using Newtonsoft.Json;

namespace RESTful_S7
{
    public partial class Form1 : Form
    {
        // ����PLC���Ӳ���
        private readonly Plc plc = new(CpuType.S71200, "192.168.0.1", 0, 1);
        //����ѭ��ֹͣ�Ŀ��Ʊ���
        private bool LoopStop = false;
        public Form1()
        {
            InitializeComponent();
        }
        // UI�����¼�
        private void Form1_Load(object sender, EventArgs e)
        {
            // ����һ�����߳�
            Thread NewThead = new(() =>
            {
                PlcConnect();
            });
            // �������߳�
            NewThead.Start();
        }
        // UI�ر��¼�
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // �رմ���ǰֹͣѭ��
            LoopStop = true;
            // �Ͽ���PLC������
            plc.Close();

        }
        private void PlcConnect()
        {
            while (!LoopStop)
            {
                try
                {
                    // ��������PLC
                    plc.Open();
                    this.Invoke((Action)(() => LinkStatus.Checked = true));
                    this.Invoke((Action)(() => LinkStatus.Text = "Link OK"));
                    // ����ѭ��
                    while (!LoopStop)
                    {
                        // ��ȡ������
                        short controlword = ((ushort)plc.Read("DB1.DBW0")).ConvertToShort();
                        // UI��ʾ������
                        this.Invoke((Action)(() => controlwordTextBox.Text = controlword.ToString()));
                        // ������=1ʱ��������
                        if (controlword == 1)
                        {
                            // ����ʼִ��
                            plc.Write("DB1.DBW0", (short)(controlword + 100));
                            // �������RESTfulͨѶ�ĵ�ַ
                            var client = new RestClient("https://official-joke-api.appspot.com/");
                            // ����Get����
                            var request = new RestRequest("random_joke", Method.Get);
                            // ����õ��ظ������ɱ���
                            var response = client.Execute(request);
                            // ��Ӧ�ɹ�����
                            if (response.IsSuccessful)
                            {
                                // RESTful�ɹ�ִ��
                                plc.Write("DB1.DBW0", (short)(controlword + 101));
                                // UI��ʾ�ظ�������
                                this.Invoke((Action)(() => responseTextBox.Text = (response.Content)));
                                // ��ȡ�ظ�������
                                var json = response.Content;
                                // ��ʽ����ȡ������
                                JObject obj = JsonConvert.DeserializeObject<JObject>(json);
                                // ����key����
                                List<string> keys = new();
                                // ѭ����ȡkey�����ݲ���˳��ŵ�������
                                foreach (JProperty property in obj.Properties())
                                {
                                    keys.Add(property.Name);
                                }
                                // UI��ʾkey��value
                                this.Invoke((Action)(() => key_1.Text = keys[0]));
                                this.Invoke((Action)(() => value_1.Text = obj[keys[0]].ToString()));
                                this.Invoke((Action)(() => key_2.Text = keys[1]));
                                this.Invoke((Action)(() => value_2.Text = obj[keys[1]].ToString()));
                                this.Invoke((Action)(() => key_3.Text = keys[2]));
                                this.Invoke((Action)(() => value_3.Text = obj[keys[2]].ToString()));
                                this.Invoke((Action)(() => key_4.Text = keys[3]));
                                this.Invoke((Action)(() => value_4.Text = obj[keys[3]].ToString()));
                                // �������ݵ�PLC
                                PutString(1, 100, key_1.Text);
                                PutString(1, 200, value_1.Text);
                                PutString(1, 300, key_2.Text);
                                PutString(1, 400, value_2.Text);
                                PutString(1, 500, key_3.Text);
                                PutString(1, 600, value_3.Text);
                                PutString(1, 700, key_4.Text);
                                PutString(1, 800, value_4.Text);
                                // ����ִ�����
                                plc.Write("DB1.DBW0", (short)(controlword + 102));
                            }
                            else
                            {
                                // RESTfulִ��ʧ��
                                plc.Write("DB1.DBW0", (short)(controlword + 103));
                            }
                        }
                        // �ȴ�100ms��ѭ��ִ��
                        Task.Delay(100).Wait();
                    }
                }
                catch (Exception ex)
                {
                    if (!LoopStop)
                    {
                        this.Invoke((Action)(() => LinkStatus.Checked = false));
                        this.Invoke((Action)(() => LinkStatus.Text = "Link NG"));
                        MessageBox.Show("����PLCʱ���ִ���" + ex.Message);
                    }
                }
            }
        }
        private void PutString(int db, int addr, string data)
        {
            byte len = Convert.ToByte(data.Length);
            string addr1 = "DB" + db.ToString() + ".DBB" + (addr + 1).ToString();
            plc.Write(addr1, len);
            char[] single = data.ToCharArray();
            for (int i = 0; i < data.Length; i++)
            {
                string addr2 = "DB" + db.ToString() + ".DBB" + (addr + 2 + i).ToString();
                plc.Write(addr2, single[i].ToString());
            }
        }
    }
}