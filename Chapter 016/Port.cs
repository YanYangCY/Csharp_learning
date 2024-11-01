using System.Runtime.InteropServices;

namespace Chapter_016
{
    /// <summary>
    /// 16.1 什么是接口:接口定义了行为，而继承则用于代码复用和拓展
    ///     使用interface声明接口
    ///     使用IComparable接口的示例
    ///         注：Array类的sort类依赖于IComparable接口，声明在BCL中，包含唯一的方法ComparaTO
    /// 16.2 声明接口
    ///     1.接口声明不能包含以下成员：数据成员（类的实例（对象）所拥有的成员）、静态成员（包括静态字段、静态属性、静态方法等）
    ///     2.接口声明只能包含如下非静态成员函数的声明：方法、属性、事件、索引器 
    ///         2.1这些函数成员的声明不能包含任何实现代码，必须用分号代替每一个成员声明的主体
    ///         2.2按照惯例，接口名称必须从大写的 I 开始（例如ISaveable）
    ///         2.3与类和结构一样，接口声明也可以分隔成分部接口声明Partial
    ///         2.4接口声明可以有任何的访问修饰符：public、protected、internal、private
    ///         2.5接口成员是隐式的public，不允许有任何访问修饰符
    /// 16.3 实现接口：只有类和结构才能实现接口
    ///     要实现接口，类和结构必须：1.在基类列表中包括接口名称；2.为每一个接口成员提供实现
    ///         1.如果类实现了接口，它必须实现接口的所有成员
    ///         2.如果类派生自基类并实现接口，基类列表中的基类名称必须放在所有接口之前
    /// 16.4 接口是引用类型
    ///     通过把类对象引用强制转换为接口类型来获取指向接口的引用
    /// 16.5 接口和as运算符
    ///     尝试将类对象引用强制转换为类未实现的接口的引用，强制转换操作会抛出一个异常，可以通过as运算符避免
    /// 16.6 实现多个接口
    ///     1.类和结构可以实现任意数量的接口
    ///     2.所有实现的接口必须列在基类的列表中并以逗号分隔（如果有基类名称，接口在基类之后）
    /// 16.7 实现具有重复成员的接口
    ///     1.如果一个类实现了多个接口，且接口中具有相同的签名和返回类型，那么类可以实现单个成员满足所有包含重复成员的接口
    ///     2.如果只是成员名称重复，但是方法重载的话就不干涉，且实现两个接口就需要在类中 实现两个成员方法
    /// 16.8 多个接口的引用
    ///     从之前调用接口的类对象引用可以强制转换为接口类型，来获取一个指向接口的引用；
    ///     如果类实现了多个接口，可以获取每一个接口的独立引用
    /// 16.9 派生成员作为实现（派生成员：从基类继承的成员）
    ///     接口中的方法声明和一个基类中的方法声明相匹配，如果一个类继承了这个基类且实现了前面的接口，那就不需要在主体中声明接口中的方法
    ///     
    /// </summary>
    /// 
    public class Port
    {
        static void PrintInfo(IInfo item)
        {
            Console.WriteLine("Name:{0},Age:{1}!", item.GetName(), item.GetAge());
        }
        static void PrintOut(string s, MyClass[] mc)
        {
            Console.Write(s);
            foreach (var m in mc)
                Console.Write($"{m.TheValue} ");
            Console.WriteLine("");
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("######接口的用法#####################");
            CA cA = new CA() { Name = "CA", Age = 26 };
            CB cB = new CB() { First = "C", Last = "B", PersonsAge = 25 };
            PrintInfo(cA);
            PrintInfo(cB);
            Console.WriteLine("####################################");
            Console.WriteLine("######使用IComparable接口的示例######");
            var myInt = new[] { 20, 4, 16, 9, 2 };
            /*Array.Sort(myInt);  // 使用Array类的静态Sort方法对元素排序
            foreach(var i in myInt)
                Console.Write($"{i} ");
            Console.WriteLine();*/
            MyClass[] myClasses = new MyClass[5];   // 创建MyClass对象的数组
            for (int i = 0; i < myInt.Length; i++)   // 初始化数组
            {
                myClasses[i] = new MyClass();
                myClasses[i].TheValue = myInt[i];
            }
            PrintOut("Initial Order: ", myClasses);
            Array.Sort(myClasses);  // 数组排序
            PrintOut("Sorted  Order: ", myClasses);
            Console.WriteLine("####################################");
            Console.WriteLine("######接口是引用类型#################");
            MyClass2 myClass = new MyClass2();  // 创建类对象
            myClass.PrintOut("object"); // 调用类对象的实现方法
            IIfc1 ifc1 = (IIfc1)myClass;    // 将类对象的引用转换为接口类型的引用
            ifc1.PrintOut("interface"); // 调用接口方法
            Console.WriteLine("####################################");
            Console.WriteLine("######as运算符######################");
            MyClass2 myClass2 = new MyClass2();
            myClass2.PrintOut("object");
            IIfc1 ifc2 = myClass2 as IIfc1;
            if (ifc2 != null)
                ifc2.PrintOut("as is ok!");
            IInfo ifc3 = myClass2 as IInfo;
            if (ifc3 != null)
                Console.WriteLine("asok!");
            else
                Console.WriteLine("asng!");
            Console.WriteLine("####################################");
            Console.WriteLine("######实现多个接口###################");
            MyData myData = new MyData();
            // myData.SetData(379);
            Console.WriteLine($"The SetData is : {myData.GetData()} !");
            Console.WriteLine("####################################");
            Console.WriteLine("######实现具有重复成员的接口##########");
            MyRepateInterface myRepateInterface = new MyRepateInterface();
            myRepateInterface.PrintOut("object");
            Console.WriteLine("####################################");
            Console.WriteLine("######多个接口的引用#################");
            MyRepateInterface repateCite = new MyRepateInterface();
            IIfc1 ifc11 = repateCite as IIfc1;  // IIfc1 ifc11 = (IIfc1)repateCite;都属于强制转换，但是as可以抛出异常
            IIfc2 ifc22 = repateCite as IIfc2;
            repateCite.PrintOut("object");
            ifc11.PrintOut("interface 1");
            ifc22.PrintOut("interface 2");
            Console.WriteLine("####################################");
            Console.WriteLine("######派生成员作为实现###############");
            DeriverRealize myDeriver = new DeriverRealize();
            myDeriver.PrintOut("object");
            Console.WriteLine("####################################");


        }
    }
    interface IInfo // 声明接口
    {
        string GetName();
        string GetAge();
    }
    interface IMyInterface1
    {
        int DoStuff(int nVar1, long lVar2); // 分号代替了主体
        double DoOtherStuff(string s, long x);
    }
    interface IIfc1
    {
        void PrintOut(string s);
    }
    interface IDataRetrieve
    {
        int GetData();
    }
    interface IDataStore
    {
        void SetData(int x);
    }
    interface IIfc2 // 与接口IIfc1具有相同的方法 
    {
        void PrintOut(string t);
    }
    public class CA : IInfo // CA调用接口
    {
        public string Name;
        public int Age;
        public string GetName()
        { return Name; }
        public string GetAge()
        { return Age.ToString(); }
    }
    public class CB : IInfo // CB调用接口
    {
        public string First;
        public string Last;
        public double PersonsAge;
        public string GetName()
        { return First + "" + Last; }
        public string GetAge()
        { return PersonsAge.ToString(); }
    }
    class MyClass : IComparable // 类实现接口
    {
        public int TheValue;
        public int CompareTo(Object obj)    // 实现方法
        {
            MyClass mc = (MyClass)obj;
            if (this.TheValue < mc.TheValue) return -1;
            if (this.TheValue > mc.TheValue) return 1;
            return 0;
        }
    }
    public class MyClass1 : IMyInterface1   // 实现接口
    {
        public int DoStuff(int nVar1, long lVar2)
        {
            return 0;
        }
        public double DoOtherStuff(string s, long x)
        {
            return 0;
        }
    }
    public class MyClass2 : IIfc1
    {
        public void PrintOut(string s)
        {
            Console.WriteLine($"Calling through: {s}");
        }
    }
    public class MyData : IDataRetrieve, IDataStore
    {
        int Mem1;   // 声明字段,类的字段如果没有显式初始化，会自动设置为默认值

        public int GetData()
        {
            return Mem1;
        }
        public void SetData(int x)
        {
            Mem1 = x;
        }
    }
    public class MyRepateInterface : IIfc1, IIfc2
    {
        public void PrintOut(string s)
        {
            Console.WriteLine($"Calling through : { s }");
        }
    }
    public class MyBaseClass    // 声明一个基类
    {
        public void PrintOut(string s)
        {
            Console.WriteLine($"Calling through : {s}");
        }
    }
    public class DeriverRealize : MyBaseClass, IIfc1
    {
        // 从基类中派生获取到PrintOut方法，所以是派生成员实现了接口，这里不需要重复实现
    }



    /*
    public class Port
    {
        static void PrintInfo(CA item)
        {
            Console.WriteLine($"Name:{item.Name},Age:{item.Age}!");
        }
        public static void Main(string[] args)
        {
            CA item = new CA() { Name ="YY" , Age = 26 };
            PrintInfo(item);
        }
    }
    class  CA
    {
        public string Name;
        public int Age;
    }
    class CB
    {
        public string First;
        public string Last;
        public double PersonsAge;
    }
    */
}