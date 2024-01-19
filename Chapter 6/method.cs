using System;

namespace Method
{
    /// <summary>
    /// 方法头：访问修饰符、静态修饰符、返回类型、方法名、形参(还有修饰符)
    /// 方法体：局部变量、控制流结构(条件、循环、跳转)、方法调用、内嵌的块、其他方法(局部函数)
    /// var关键字只能用于局部变量，不能用于字段(类、结构体的变量)；只能在变量声明中包含初始化时使用
    /// const关键字用于声明常量类型
    /// 在void声明的方法中，可以使用return;来退出方法
    /// </summary>
    class MethodTest
    {
        public void TestReturn()
        {
            int x = 1;
            int y = 2;
            if (x == 1) { Console.WriteLine("X: {0}", x); return; } //return语句后面的语句不会执行
            if (y == 2) { Console.WriteLine("Y: {0}", y); }
        }

        static void Main(string[] args)
        {
            var newMetod = new MethodTest();    //实例化对象，调用对象的方法

            int a = 1;
            a = (int)(double)a; //类型转换，必须先转换为double，再转换为int
            var b = (double)a; //自动推断类型，编译器会根据变量的赋值语句推断变量的类型
            Console.WriteLine("******************************");
            Console.WriteLine("{0}",a.GetType());
            Console.WriteLine("{0}", b.GetType());
            Console.WriteLine("******************************");

            newMetod.TestReturn();  //调用对象的方法
            Console.WriteLine("******************************");


        }
        
    }
}