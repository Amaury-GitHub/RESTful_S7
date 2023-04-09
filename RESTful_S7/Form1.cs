using RestSharp;
using Newtonsoft.Json.Linq;
using S7.Net;
using Newtonsoft.Json;

namespace RESTful_S7
{
    public partial class Form1 : Form
    {
        // 定义PLC连接参数
        private readonly Plc plc = new(CpuType.S71200, "192.168.0.1", 0, 1);
        //定义循环停止的控制变量
        private bool LoopStop = false;
        public Form1()
        {
            InitializeComponent();
        }
        // UI加载事件
        private void Form1_Load(object sender, EventArgs e)
        {
            // 创建一个新线程
            Thread NewThead = new(() =>
            {
                PlcConnect();
            });
            // 启动新线程
            NewThead.Start();
        }
        // UI关闭事件
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 关闭窗口前停止循环
            LoopStop = true;
            // 断开与PLC的连接
            plc.Close();

        }
        private void PlcConnect()
        {
            while (!LoopStop)
            {
                try
                {
                    // 尝试连接PLC
                    plc.Open();
                    this.Invoke((Action)(() => LinkStatus.Checked = true));
                    this.Invoke((Action)(() => LinkStatus.Text = "Link OK"));
                    // 创建循环
                    while (!LoopStop)
                    {
                        // 读取控制字
                        short controlword = ((ushort)plc.Read("DB1.DBW0")).ConvertToShort();
                        // UI显示控制字
                        this.Invoke((Action)(() => controlwordTextBox.Text = controlword.ToString()));
                        // 控制字=1时触发任务
                        if (controlword == 1)
                        {
                            // 任务开始执行
                            plc.Write("DB1.DBW0", (short)(controlword + 100));
                            // 定义进行RESTful通讯的地址
                            var client = new RestClient("https://official-joke-api.appspot.com/");
                            // 进行Get请求
                            var request = new RestRequest("random_joke", Method.Get);
                            // 请求得到回复创建成变量
                            var response = client.Execute(request);
                            // 响应成功继续
                            if (response.IsSuccessful)
                            {
                                // RESTful成功执行
                                plc.Write("DB1.DBW0", (short)(controlword + 101));
                                // UI显示回复的数据
                                this.Invoke((Action)(() => responseTextBox.Text = (response.Content)));
                                // 提取回复的数据
                                var json = response.Content;
                                // 格式化提取的数据
                                JObject obj = JsonConvert.DeserializeObject<JObject>(json);
                                // 创建key数组
                                List<string> keys = new();
                                // 循环读取key的数据并按顺序放到数组中
                                foreach (JProperty property in obj.Properties())
                                {
                                    keys.Add(property.Name);
                                }
                                // UI显示key与value
                                this.Invoke((Action)(() => key_1.Text = keys[0]));
                                this.Invoke((Action)(() => value_1.Text = obj[keys[0]].ToString()));
                                this.Invoke((Action)(() => key_2.Text = keys[1]));
                                this.Invoke((Action)(() => value_2.Text = obj[keys[1]].ToString()));
                                this.Invoke((Action)(() => key_3.Text = keys[2]));
                                this.Invoke((Action)(() => value_3.Text = obj[keys[2]].ToString()));
                                this.Invoke((Action)(() => key_4.Text = keys[3]));
                                this.Invoke((Action)(() => value_4.Text = obj[keys[3]].ToString()));
                                // 发送数据到PLC
                                PutString(1, 100, key_1.Text);
                                PutString(1, 200, value_1.Text);
                                PutString(1, 300, key_2.Text);
                                PutString(1, 400, value_2.Text);
                                PutString(1, 500, key_3.Text);
                                PutString(1, 600, value_3.Text);
                                PutString(1, 700, key_4.Text);
                                PutString(1, 800, value_4.Text);
                                // 任务执行完成
                                plc.Write("DB1.DBW0", (short)(controlword + 102));
                            }
                            else
                            {
                                // RESTful执行失败
                                plc.Write("DB1.DBW0", (short)(controlword + 103));
                            }
                        }
                        // 等待100ms后循环执行
                        Task.Delay(100).Wait();
                    }
                }
                catch (Exception ex)
                {
                    if (!LoopStop)
                    {
                        this.Invoke((Action)(() => LinkStatus.Checked = false));
                        this.Invoke((Action)(() => LinkStatus.Text = "Link NG"));
                        MessageBox.Show("连接PLC时出现错误：" + ex.Message);
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