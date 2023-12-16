using System;

namespace Simple    //命名空间
{
    class SimpleProgram   //声明一个类
    {
        static void Main()
        {
            int var1 = 500;
            double myDouble = 12.345678;
            Console.WriteLine("Hi theree!");

            Console.WriteLine("Two sample integers are {0} and {1}.", 3, 6);

            Console.WriteLine("There integers are {1}, {0} and {1}.", 3, 6);    //替代标记可以不按顺序,不限数量

            //Console.WriteLine("Two sample integers are {0} and {2}.", 3, 6);    //超出索引，不会产生编译错误，会产生运行错误（异常）

            // C#6.0引入语法:字符串插值$
            Console.WriteLine($"{var1}");

            //数字格式化成货币
            Console.WriteLine("The value is {0}.", 500);    //输出数字
            Console.WriteLine("The value is {0:C}.", 500);  //格式化为货币

            //对齐说明符
            Console.WriteLine("|{0, 10}|", var1);   //右对齐
            Console.WriteLine("|{0, -10}|", var1);  //左对齐

            //标准数字格式说明符
            Console.WriteLine("{0, -10:G} -- General", myDouble);   //定点或科学计数法
            Console.WriteLine("{0, -10} -- Default", myDouble);   //默认就是Gneral
            Console.WriteLine("{0, -10:F4} -- Fixed Point", myDouble);   //十进制保留4位
            Console.WriteLine("{0, -10:C} -- Currency", myDouble);   //电脑所在区域的货币符号
            Console.WriteLine("{0, -10:E3} -- Sci.Notation", myDouble);   //指数科学计数法
            Console.WriteLine("{0, -10:x} -- Hexdecimal integer", 180026);   //十六进制

        }
    }
}
