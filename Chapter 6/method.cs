using System;
using System.Runtime.CompilerServices;

namespace Method
{
    /// <summary>
    /// 方法头：访问修饰符、静态修饰符、返回类型、方法名、形参(还有修饰符)
    /// 方法体：局部变量、控制流结构(条件、循环、跳转)、方法调用、内嵌的块、其他方法(局部函数)
    /// var关键字只能用于局部变量，不能用于字段(类、结构体的变量)；只能在变量声明中包含初始化时使用
    /// const关键字用于声明常量类型
    /// 在void声明的方法中，可以使用return;来退出方法
    /// 使用ref修饰符传递方法参数，方法接收到的都是直接内存引用；方法的声明和调用上都需要使用ref
    /// 使用out修饰符，在方法内部给输出参数赋值之后才能读取它
    /// </summary>
    class MethodTest
    {
        public int Val = 10;
        public void TestReturn()
        {
            int x = 1;
            int y = 2;
            if (x == 1) { Console.WriteLine("X: {0}", x); return; } //return语句后面的语句不会执行
            if (y == 2) { Console.WriteLine("Y: {0}", y); }
        }

        public void MyMethod(ref MethodTest f1, ref int f2) //方法使用引用参数
        {
            f1.Val = f1.Val + 10;
            f2 = f2 + 5;
            Console.WriteLine($"f1.Val:{f1.Val}, f2:{f2}");
        }

        public void ListInts(params int[] inVals)
        {
            if((inVals != null) && (inVals.Length != 0))
                for (int i = 0; i < inVals.Length; i++)
                {
                    inVals[i] = inVals[i] * 10;
                    Console.WriteLine($"{inVals[i]}");
                }
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

            newMetod.MyMethod(ref newMetod, ref a); //调用对象的方法，使用ref关键字，将方法的参数传递为引用类型
            Console.WriteLine($"newMetod.Val:{newMetod.Val}, a:{a}");
            Console.WriteLine("******************************");

            //将值类型的数据作为数组参数，值被复制，实参在方法内部不受影响
            int first = 5, second = 6, third = 7;
            var listMethod = new MethodTest();
            listMethod.ListInts(first, second, third);
            Console.WriteLine($"{first},{second},{third}");
            //将数组作为实参，编译器会使用数组，而不是重新创建
            int[] myArr = new int[] {5, 6, 7};
            var listMethod2 = new MethodTest();
            listMethod2.ListInts(myArr);
            foreach (int x in myArr)
                Console.WriteLine($"{ x }");
            Console.WriteLine("******************************");
        }
        
    }
}