using System;

namespace ClassGm
{
    /// <summary>
    /// 类成员-数据成员、函数成员
    /// 成员修饰符的顺序
    /// 实例类成员：各实例之间属于副本，互不影响
    /// 静态字段：类中的静态字段被类的所有实例共享，所有实例访问同一个内存位置。(访问静态变量只能使用类名)
    /// </summary>
    class ClassGm
    {
        static void Main(string[] args)
        {
            //实例字段和静态字段
            var D1 = new D();
            var D2 = new D();
            D1.Mem1 = 10;
            D2.Mem1 = 20;
            Console.WriteLine($"D1.Mem1 = {D1.Mem1}, D2.Mem1 = {D2.Mem1}");
            D.Mem2 = 30;
            Console.WriteLine();

            //静态字段的示例
            var E1 = new E();
            var E2 = new E();
            E1.SetVars(3, 4);
            E1.Display("E1");
            E2.SetVars(5, 6);
            E2.Display("E2");
            //这里的Mem4静态成员的值已经发生改变
            E1.Display("E1");

        }

        
    }

    class D
    {
        public int Mem1 = 1;
        public static int Mem2 = 2;
    }
    class E
    {
        int Mem3;
        static int Mem4;
        public void SetVars(int v1, int v2) //通过这种方式可以像访问实例字段一样访问静态字段
        {
            Mem3 = v1;
            Mem4 = v2;
        }
        public void Display(string str)
        {
            Console.WriteLine($"{str}: Mem3 = {Mem3}, Mem4 = {Mem4}");
        }
    }
}