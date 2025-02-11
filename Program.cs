using System.Diagnostics;
using System.Reflection.PortableExecutable;

namespace 口算_
{
    internal class kouSuan
    {
        static void Main(string[] args)
        {
            bool shaobing = true;
            while (shaobing)
            {
                var current_Time = DateTime.Now;
                string saveDate_path = "savedate.txt";
                if (File.Exists(saveDate_path))
                {
                    string username = null;
                    using (StreamReader reader = new StreamReader(saveDate_path))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            // 检查行是否以"username: "开头
                            if (line.StartsWith("username_"))
                            {
                                // 提取"username: "后面的部分
                                username = line.Substring("username_".Length).Trim();
                                break; // 找到后退出循环
                            }
                            else { }
                        }
                    }

                    // 输出提取的用户名
                    if (username != null)
                    {
                        Console.WriteLine("你好" + username);
                    }
                    else
                    {

                    }
                }
                else
                {
                    using (var writer = new StreamWriter(saveDate_path, append: true))
                    {
                    name_frist_creat:
                        string Name;
                        Console.Write("第一次使用请输入用户名：");
                        Name = Console.ReadLine();
                        writer.WriteLine($"username_{Name}");
                    }
                }
                // while (shaobing)
                {
                    string ShaShiZi;
                    string true_ShaShiZi = "未知";
                    int int_ShaShiZi = 1145;
                    Console.WriteLine("口算");
                    Thread.Sleep(250);
                    Console.WriteLine("版本0.2");
                    Thread.Sleep(250);
                    Console.WriteLine("你要选择练习那个类型？每种类型有十道题");
                    Console.WriteLine("加法输入0");
                    Console.WriteLine("减法输入1");
                    Console.WriteLine("乘法输入2");
                    Console.WriteLine("除法输入3");
                tiaozuan1:
                    Console.Write("请输入：");
                    ShaShiZi = Console.ReadLine();
                    if (ShaShiZi == "xiaojun")
                    {
                        using (var duqu = new StreamReader(saveDate_path))
                        {
                            Console.WriteLine("进入后台调试模式");
                            string line;
                            string username = null;
                            while ((line = duqu.ReadLine()) != null)
                            {
                                // 检查行是否以"username: "开头
                                if (line.StartsWith("username_"))
                                {
                                    // 提取"username_"后面的部分
                                    username = line.Substring("username_".Length).Trim();
                                    break; // 找到后退出循环
                                }
                            }
                            if (username != null)
                            {
                                Thread.Sleep(1000);
                                Console.WriteLine($"查找到用户{username}的数据：");
                                while ((line = duqu.ReadLine()) != null)
                                {
                                    // 检查行是否以"username: "开头
                                    if (line.StartsWith("时间"))
                                    {
                                        Console.WriteLine(line);
                                        // 提取"username_"后面的部分
                                        // 找到后退出循环
                                    }
                                    else { Console.WriteLine("暂时无数据！"); }
                                }
                            }
                        }
                    }
                    try
                    {
                        int_ShaShiZi = int.Parse(ShaShiZi);
                        if (int_ShaShiZi < 0 || int_ShaShiZi > 3)
                        {
                            throw new OverflowException("你没有输入一个有效的选项！！！");
                            goto tiaozuan1;
                        }
                    }
                    catch (FormatException ex) { Console.WriteLine("你输入的不是一个数字"); goto tiaozuan1; }
                    catch (OverflowException ex) { Console.WriteLine(ex.Message); goto tiaozuan1; }
                    catch (Exception ex) { Console.WriteLine($"发生了未知错误：{ex.Message}"); goto tiaozuan1; }
                    if (ShaShiZi == "0") { true_ShaShiZi = "加法"; }
                    else if (ShaShiZi == "1") { true_ShaShiZi = "减法"; }
                    else if (ShaShiZi == "2") { true_ShaShiZi = "乘法"; }
                    else if (ShaShiZi == "3") { true_ShaShiZi = "除法"; }
                    // var text = new kousuan();
                    float jifen = panduan(int_ShaShiZi);
                    Console.WriteLine($"正确率是{jifen * 10}%");
                    Console.Write("评价是：");
                    jiesuan(jifen * 10);
                    Console.Write("如果要退出，请按t,否则任意按键：");
                    string o = Console.ReadLine();
                    if (o == "t" || o == "T") shaobing = false;
                    using (var writer = new StreamWriter(saveDate_path, append: true))
                    {
                        writer.WriteLine($"时间：{current_Time}，积分：{jifen}分，模式：{true_ShaShiZi}");
                    }
                }
            }
        }

        private static void jiesuan(float v)
        {
            if (v <= 30) Console.WriteLine("纯纯的飞舞");
            else if (v <= 50) Console.WriteLine("一般，入坤水平");
            else if (v <= 70) Console.WriteLine("及格，但也就这样了");
            else if (v <= 90) Console.WriteLine("口算题做成这样还得练");
            else Console.WriteLine("马马虎虎的全对");
        }

        static float panduan(int a) 
        {
            var jishiqi = new Stopwatch();
            jishiqi.Start();
            float jifen = 0;
            for (float i = 1; i < 11; i++) //十道题
            {
                //Console.WriteLine(jifen);
                var HandleNumbe = new Random();
                int shu1 = HandleNumbe.Next(1, 100);
                int shu2 = HandleNumbe.Next(1, 100);
                int JianChu_numble = HandleNumbe.Next(1,100);
                switch (a) //用户已经选择了！这是主！体！
                {
                    case 0: //加法部分处理
                        int true_result = shu1 + shu2;
                        int user_result;
                        string user_result_string;
                        zheli:
                        Console.Write($"{shu1}+{shu2}=");
                        user_result_string = Console.ReadLine();
                        try { user_result = int.Parse(user_result_string); }
                        catch (Exception ex) { Console.WriteLine($"有错误发生，但真的懒得写纠错代码了直接看报错描述吧：{ex.Message}");goto zheli; }
                        if (user_result == true_result)
                        {
                            Console.WriteLine("正确，积一分");
                            jifen++;
                            Console.WriteLine($"当前正确率为{(jifen / i) * 100}%");

                        }
                        else { Console.WriteLine($"错了！正确答案是{true_result}!"); Console.WriteLine($"当前正确率为{(jifen / i)*100}%"); }
                    break;
                    case 1: //减法处理
                        int jtrue_result = JianChu_numble;//直接作为得数
                        int juser_result;
                        string juser_result_string;
                        shu1 = jtrue_result+shu2;   //让结果为变量juser_result
                        ezheli:
                        Console.Write($"{shu1}-{shu2}=");
                        juser_result_string = Console.ReadLine();
                        try { juser_result = int.Parse(juser_result_string); }
                        catch (Exception ex) { Console.WriteLine($"有错误发生，但真的懒得写纠错代码了直接看报错描述吧：{ex.Message}"); goto ezheli; }
                        if (juser_result == jtrue_result)
                        {
                            Console.WriteLine("正确，积一分");
                            jifen++;
                            Console.WriteLine($"当前正确率为{(jifen / i) * 100}%");
                        }
                        else { Console.WriteLine($"错了！正确答案是{jtrue_result}!"); Console.WriteLine($"当前正确率为{(jifen / i) * 100}%"); }
                    break;
                    case 2: //乘法处理
                        int cheng_ringht = HandleNumbe.Next(1,10);
                        int cheng_left = HandleNumbe.Next(10,21);
                        int ctrue_result = cheng_left*cheng_ringht;
                        int cuser_result;
                        string cuser_result_string;
                        //shu1 = jtrue_result + shu2;   //让结果为变量juser_result
                    czheli:
                        Console.Write($"{cheng_ringht}*{cheng_left}=");
                        cuser_result_string = Console.ReadLine();
                        try { cuser_result = int.Parse(cuser_result_string); }
                        catch (Exception ex) { Console.WriteLine($"有错误发生，但真的懒得写纠错代码了直接看报错描述吧：{ex.Message}"); goto czheli; }
                        if (cuser_result == ctrue_result)
                        {
                            Console.WriteLine("正确，积一分");
                            jifen++;
                            Console.WriteLine($"当前正确率为{(jifen / i) * 100}%");
                        }
                        else { Console.WriteLine($"错了！正确答案是{ctrue_result}!"); Console.WriteLine($"当前正确率为{(jifen / i) * 100}%"); }
                        break;
                        case 3: //除法处理
                        int chushu = HandleNumbe.Next(1, 20);
                        int outcome = HandleNumbe.Next(1,10);
                        int bei_chushu = chushu*outcome;
                        int cutrue_result = outcome;
                        int cuuser_result;
                        string cuuser_result_string;
                    //shu1 = jtrue_result + shu2;   //让结果为变量juser_result
                    cuzheli:
                        Console.Write($"{bei_chushu}/{chushu}=");
                        cuuser_result_string = Console.ReadLine();
                        try { cuuser_result = int.Parse(cuuser_result_string); }
                        catch (Exception ex) { Console.WriteLine($"有错误发生，但真的懒得写纠错代码了直接看报错描述吧：{ex.Message}"); goto cuzheli; }
                        if (cuuser_result == cutrue_result)
                        {
                            Console.WriteLine("正确，积一分");
                            jifen++;
                            Console.WriteLine($"当前正确率为{(jifen / i) * 100}%");
                        }
                        else { Console.WriteLine($"错了！正确答案是{cutrue_result}!"); Console.WriteLine($"当前正确率为{(jifen / i) * 100}%"); }
                        break;
                        //Console.WriteLine("测试成功代码，在正式发行版本看到这行证明出现bug");
                }
            }
            jishiqi.Stop();
            TimeSpan second = jishiqi.Elapsed;
            Thread.Sleep(500);
            Console.WriteLine($"已完成全部题目！共用时{second.TotalSeconds}秒");
            return jifen;
        }
        static int Max(int a,int b)
        {
            int result;
            if (a < b)
                result = b;
            else
                result = a;
            return result;
        }
    }
}
