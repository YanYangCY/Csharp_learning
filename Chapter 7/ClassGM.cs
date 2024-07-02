using System;
using System.Runtime.CompilerServices;

namespace ClassGm
{
    /// <summary>
    /// 类成员-数据成员、函数成员
    /// 成员修饰符的顺序
    /// 实例类成员：各实例之间属于副本，互不影响
    /// 静态字段：类中的静态字段被类的所有实例共享，所有实例访问同一个内存位置。(访问静态变量只能使用类名)
    /// C#中没有全局常量
    /// 属性与字段类似，但是属性是函数成员，本质上是一个方法（属性是一组2个匹配的、命名的、称为访问器的方法）（set、get除了这两个访问器，属性不允许拥有其他方法）
    /// 属性会自动隐式调用，显式调用访问器会编译错误；个人理解为就是字段(成员变量)，不过就是另类的成员
    /// 属性正常会和私有字段联合使用
    /// C#6.0版本开始提供自动实现属性，不需要对字段赋值，int类型默认0，bool类型默认false,引用类型默认null；
    /// 静态属性和方法可以在不实例化类的情况下直接调用
    /// 实例构造函数---一种特殊的方法，在创建每个类的新实例的时候执行（1.构造函数的名称与类名相同；2.构造函数不能有返回值；3.构造函数用于初始化类实例的状态）
    /// 带参数的构造函数---1.可以带参数；2.可以被重载
    /// 如果类声明中没有显示的创建构造函数，编译器会提供默认构造函数---没有参数、方法体为空（如果声明了任意构造函数、则不会自动生成无参数的默认构造函数）
    /// 静态构造函数（不能有访问修饰符）---通常静态构造函数初始化类的静态字段
    /// 对象初始化语句---创建新的对象时，初始化字段以及属性的值；（不能对构造函数使用）
    /// 
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
            Console.WriteLine($"{D.Mem2}");
            

            //静态字段的示例
            var E1 = new E();
            var E2 = new E();
            E1.SetVars(3, 4);
            E1.Display("E1");
            E2.SetVars(5, 6);
            E2.Display("E2");
            //这里的Mem4静态成员的值已经发生改变
            E1.Display("E1");

            //赋值，隐式调用set方法
            D1.MyValue = 10;
            //表达式，隐式调用get方法
            var YY = D1.MyValue;
            Console.WriteLine($"属性的使用：{YY}");

            //访问属性
            Console.WriteLine($"把属性当成字段使用：{D1.MyRealValue}");
            D1.MyRealValue = 101;
            Console.WriteLine($"赋值属性的值后：{D1.MyRealValue}");

            //访问静态属性
            Console.WriteLine($"类不需要实例化也可以访问：{D.MyStaticValue}");
            D.MyStaticValue = 10;
            Console.WriteLine($"静态属性赋值后，输出：{D.MyStaticValue}");


            // 构造函数的使用
            MyClass obj1 = new MyClass();   //创建一个 MyClass 的实例          
            obj1.DisplayInstantiationTime();    //调用方法显示实例化时间            
            MyClass obj2 = new MyClass();   //创建另一个 MyClass 的实例           
            obj2.DisplayInstantiationTime();    //调用方法显示另一个实例化时间

            //构造函数带参数及重载的测试
            MyClass2 obj3 = new MyClass2();
            MyClass2 obj4 = new MyClass2("YY");
            MyClass2 obj5 = new MyClass2("CY",25);
            Console.WriteLine($"obj3: Name={obj3.Name}, Age={obj3.Age}");
            Console.WriteLine($"obj4: Name={obj4.Name}, Age={obj4.Age}");
            Console.WriteLine($"obj5: Name={obj5.Name}, Age={obj5.Age}");

            //初始化对象
            MyPeople people1 = new MyPeople { Name = "YY", Age = 26 };
            //集合初始化调用
            List<MyPeople> myPeoples = new List<MyPeople> 
            { 
                new MyPeople {Name="CQH",Age=25 },
                new MyPeople {Name="DJ", Age=24 }
            };
            Console.WriteLine($"Name:{myPeoples[0].Name},Age:{myPeoples[1].Age}");
            //嵌套对象的初始化
            MyPeople peopleHome = new MyPeople { Name ="YY",Age=25,Address = new MyPeopleHome { Nation = "China", City= "TaiZhou"} };
            Console.WriteLine($"Nation:{peopleHome.Address.Nation}, CITY:{peopleHome.Address.City}");
        }


    }

    class D
    {
        public int Mem1 = 1;
        public static int Mem2 = 2;
        public int MyValue  //创建公有属性，默认是私有
        {  get; set; }

        private int _theRealValue = 99; //创建私有字段
        public int MyRealValue  //创建公有属性去访问私有字段
        {
            set { _theRealValue = 100; }    //这个地方的100也可以设置为字段
            get { return _theRealValue; } 
        }
        //创建静态属性
        public static int MyStaticValue
        {  get; set; }
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
    //在类中使用构造函数初始化其字段
    class MyClass
    {
        DateTime TimeOfInstantiation;
        public  MyClass() //构造函数
        { 
            TimeOfInstantiation = DateTime.Now; //初始化字段
        }
        // 方法：获取实例化时间
        public void DisplayInstantiationTime()
        {
            Console.WriteLine($"This instance of MyClass was created at: {TimeOfInstantiation.ToString("yyyy-MM-dd HH:mm:ss.fff")}");   //精确到毫秒
        }
    }
    //构造函数带参数及重载情况分析
    class MyClass2
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public MyClass2()   //默认构造函数
        {
            Name = "Unknown";
            Age = 0;
        }
        public MyClass2(string name)    //带一个参数的构造函数重载
        {
            Name = name;
            Age = 0;
        }
        public MyClass2(string name, int age)  ////带两个参数的构造函数重载
        {
            Name = name;
            Age = age;
        }
    }
    //对象初始化测试
    public class MyPeople
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public MyPeopleHome Address { get; set; }
    }
    public class MyPeopleHome //嵌套使用
    {
        public string Nation { get; set; }
        public string City {  get; set; }

    }
}