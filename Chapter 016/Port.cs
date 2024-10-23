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
    /// </summary>
    /// 
    public class Port
    {
        static void PrintInfo(IInfo item)
        {
            Console.WriteLine("Name:{0},Age:{1}!",item.GetName(),item.GetAge()) ;
        }
        static void PrintOut(string s, MyClass[] mc)
        {
            Console.Write(s);
            foreach(var m in mc)
                Console.Write($"{m.TheValue} ");
            Console.WriteLine("");
        }
        public static void Main(string[] args)
        {           
            Console.WriteLine("######接口的用法#####################");
            CA cA = new CA() { Name = "CA", Age = 26};
            CB cB = new CB() { First = "C", Last = "B", PersonsAge = 25};
            PrintInfo(cA);
            PrintInfo(cB);
            Console.WriteLine("####################################");
            Console.WriteLine("######使用IComparable接口的示例######");
            var myInt = new[] { 20,4,16,9,2};
            /*Array.Sort(myInt);  // 使用Array类的静态Sort方法对元素排序
            foreach(var i in myInt)
                Console.Write($"{i} ");
            Console.WriteLine();*/
            MyClass[] myClasses = new MyClass[5];   // 创建MyClass对象的数组
            for(int i = 0; i < myInt.Length; i++)   // 初始化数组
            {
                myClasses[i] = new MyClass();
                myClasses[i].TheValue = myInt[i];
            }
            PrintOut("Initial Order: ", myClasses);
            Array.Sort(myClasses);  // 数组排序
            PrintOut("Sorted  Order: ",myClasses);
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
            if(this.TheValue < mc.TheValue) return -1;
            if(this.TheValue > mc.TheValue) return 1;
            return 0;
        }
    }
    public class Myclass : IMyInterface1   // 实现接口
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