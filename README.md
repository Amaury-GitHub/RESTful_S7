# RESTful_S7
RESTful与S7交互的程序,让PLC支持RESTful通讯<br>

PLC给定控制字=1时,交互开始工作<br>

本例使用 https://official-joke-api.appspot.com/random_joke 进行测试<br>

每次会返回一个笑话,标准的json格式<br>

会将得到的json解析为多个字符串并写入到PLC<br>

进入子程序时会将控制字写为101<br>

RESTful请求完成后会将控制字写为102<br>

子程序完成后会将控制字写为103<br>

RESTful请求异常会将控制字写为104<br>

PLC可以根据控制字的值编写程序和报警<br>

![image](https://github.com/Amaury-GitHub/RESTful_S7/blob/main/README_IMG/IMG1.png)<br>
