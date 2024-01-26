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
    /// 使用ref作为返回使用功能，ref关键字要在方法的返回类型声明和return调用上都使用
    /// ref的返回类型不能是void；ref return不能返回空值、常量、枚举成员、类或者结构体的属性、指向只读位置的指针
    /// 方法重载，相同名称的方法，区分它们的签名有：方法的名称、参数的数目、参数的数据类型和顺序(只有顺序是不行的)、参数的修饰符
    /// 方法重载中，返回类型是不能作为区分的签名，形参的名称也不是签名的依据,方法体不同也不行
    /// 位置参数：每一个实参的位置必须和相应的形参位置对应
    /// 命名参数：方法声明不变，方法的调用中包含参数名，就可以不按顺序调用
    /// 位置参数和命名参数同时使用时，所有位置参数必须先列出
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

            //ref局部变量（变量别名）
            int localA = 2; //局部变量
            ref int localB = ref localA;    //局部变量的引用localB是localA的别名
            Console.WriteLine($"localA:{localA},localB:{localB}");
            localB = 10;
            Console.WriteLine($"localA:{localA},localB:{localB}");
            //ref返回
            var refAlias = new RefAliases();
            refAlias.DisplayScore();
            ref int v1Outside = ref refAlias.RefToValuce(); //ref返回
            v1Outside = 10; refAlias.DisplayScore();    //在调用域外(Main)修改值，值也是会改变的
            //ref返回示例2
            var v1 = 10; var v2 = 20;
            Console.WriteLine("v1:{0}, v2:{1}", v1, v2);
            ref int max = ref RefAliases.Max(ref v1, ref v2);
            Console.WriteLine("max:{0}", max);
            max++;
            Console.WriteLine("v1:{0}, v2:{1}, max:{2}", v1, v2, max);
            Console.WriteLine("******************************");

            //命名参数
            var namePara = new AliasMethod();
            var nameResult = namePara.AddValues(b:20, a:10);
            Console.WriteLine($"nameResult:{nameResult}");
            Console.WriteLine("******************************");

        }
        
    }
    class RefAliases    //ref局部变量和返回
    {
        private int Score = 5;
        public ref int RefToValuce()
        {
            int a = 5;
            return ref Score;
        }
        public void DisplayScore()
        {
            Console.WriteLine($"Score:{Score}");
        }

        public static ref int Max(ref int a, ref int b)    //成员“Max”不访问实例数据，可标记为 static
        {
            if (a > b)
                return ref a;   //ref返回引用，而不是返回值
            else
                return ref b;
        }
    }
    class AliasMethod   //方法重载
    {
        public long AddValues(int a, int b) => a + b;
        //long AddValues(long b, int a) => a + b;  //形参的类型相同，参数的顺序不同，不是重载
        long AddValues(int c, int d, int e) => c + d + e;   //参数的数目
        long AddValues(float f, float g) => (long)(f+g);    //参数的数据类型
        long AddValues(long h, long m) => h + m;    //参数的数据类型
    }
}