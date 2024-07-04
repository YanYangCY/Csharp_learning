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
    /// 析构函数：执行在类的实例被销毁之前需要的清理或释放非托管资源的行为。
    /// readonly 是一个修饰符，用于声明只读字段或只读静态字段。
    ///     使用 readonly 修饰符的字段只能在声明时或者在构造函数内部进行赋值，之后无法再修改其值。
    ///     这使得 readonly 字段在需要保持不变性或者在多线程环境下使用时非常有用。
    /// this关键字：使用场景》字段和方法的形参名称相同，可以在方法体中使用this调用字段
    /// 索引器：索引器是一组set和get访问器(自动调用)，与属性类似（属性正常表示单个数据成员，索引器正常表示多个数据成员）
    /// 访问器的访问修饰符---1.属性或者索引器同时有set和get两个访问器时才可以使用访问修饰符
    ///                 ---2.虽然两个访问器必须同时出现，但只能有一个访问修饰符
    ///                 ---3.访问器的访问修饰符限制必须比成员的访问级别更严格
    /// 分部类(partial)：分部类允许将一个类的定义分成多个部分，每个部分可以在不同的文件中实现。
    ///        这种功能在大型项目中特别有用，可以让多个开发者同时工作在同一个类的不同部分上，而无需频繁地合并代码。
    /// 分部结构：分部结构与分部类类似，但用于结构（struct）。
    ///          结构是一种值类型，用于存储数据。分部结构的使用场景与分部类类似，允许将结构的定义分散在多个文件中。
    /// 分布方法
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

            //索引器的使用
            Employee employee = new Employee();
            employee[0] = "yang";
            employee[1] = "yan";
            employee[2] = "TZ";
            Console.WriteLine($"名字：{employee[1]} {employee[0]} ;出生地：{employee[2]}");
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

    //索引器示例
    public class Employee
    {
        public string LastName;     //调用字段0
        public string FirstName;    //调用字段1
        public string CityOfBirth;  //调用字段2
        public string this[int index]   //索引器声明
        {
            set 
            {
                switch (index) 
                {
                    case 0:LastName = value; break;
                    case 1:FirstName = value; break;
                    case 2:CityOfBirth = value; break;
                    default:throw new ArgumentOutOfRangeException("index"); //抛出异常
                }
                
            }
            get 
            {
                switch (index) 
                {
                    case 0:return LastName;
                    case 1:return FirstName;
                    case 2:return CityOfBirth;
                    default:throw new ArgumentOutOfRangeException("index");
                }
            }
        }
    }
}