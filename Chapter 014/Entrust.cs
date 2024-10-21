namespace Chapter_014
{
    /// <summary>
    /// 14.1 什么是委托
    ///     委托主要用于实现回调函数、事件处理、多线程编程中的异步编程模式（如APM、EAP、TAP）、
    ///     以及LINQ中的查询处理等场景。
    ///     它们提供了一种灵活的机制，允许在运行时动态地指定方法的调用。
    /// 14.2 委托概述
    ///     1.声明一个委托类型 2.使用委托类型声明一个委托变量 3.创建一个委托类型的对象并赋值给委托变量
    ///     4.可以为委托对象添加其他方法 5.调用委托 
    ///     ※注:2、3步骤可以放在一步执行
    ///     ※第4步：委托支持多播，即可以将一个委托变量设置为引用多个方法，通常使用操作符 +=
    ///             委托变量必须已经引用了一个方法（或lambda表达式、匿名方法等），或者初始化为null
    ///             多播情况下，返回值非void类型，只有最后一个方法的返回值会被返回；
    ///                        void类型则会调用所有方法
    /// 14.3 声明委托类型
    ///      关键字      委托类型名称
    ///        ↓            ↓
    ///     delegate void MyDel( int x );
    ///               ↑   ——————————————签名
    ///            返回类型
    /// 14.4 创建委托对象
    ///     委托是引用类型，因此有引用和对象
    ///     委托类型 变量 = new 委托类型(实例方法/静态方法)   //创建委托并保存使用
    ///     也可以使用快捷语法：  委托类型 变量 = 实例方法/静态方法
    /// 14.5 给委托赋值
    ///     由于委托是引用类型，可以通过赋值来改变委托变量中的引用，旧的委托对象会被垃圾回收期回收
    /// 14.6 组合委托
    ///     委托可以用额外的运算符来“组合”
    ///     MyDel delA = myInstObj.MyM1;
    ///     MyDel delB = SClass.OtherM2;
    ///     Mydel delC = delA + delB; // 组合调用列表
    /// 14.7 为委托添加方法
    ///     使用 += 运算符
    /// 14.8 为委托移除方法
    ///     使用 -= 运算符；与委托添加方法一样，其实是创建了一个新的委托
    /// 14.9 调用委托
    ///     直接执行委托和使用Invoke方法执行委托功能上是等价的
    /// 14.10 委托的示例
    ///     在委托中添加同一个方法两次，则会执行两次
    /// 14.11 调用带返回值的委托
    ///     如果委托有返回值并且调用列表有多个方法：返回调用列表中最后一个方法的返回值，其他返回值都会忽略
    /// 14.12 调用带引用参数的委托
    /// 14.13 匿名方法
    ///     之前使用的静态方法或实例方法来实例化委托
    ///     如果方法只被使用一次，就可以使用匿名方法；匿名方法是在实例化委托时内联声明的方法
    ///     14.13.1 使用匿名方法
    ///         ※声明委托变量时作为初始化表达式
    ///         ※组合委托时在赋值语句的右边
    ///         ※为委托增加事件时在赋值语句的右边
    ///     14.13.2 匿名方法的语法
    ///         delegate (Parameters) { ImplementationCode }
    ///           关键字   参数列表         语句块
    ///         2.参数：除了数组参数，匿名方法的参数列表必须在3个方面和委托匹配：参数数量、参数类型及位置、修饰符
    ///         ※可以通过使圆括号为空或者省略圆括号来简化匿名方法的参数列表，但是必须满足：委托的参数列表不包含out参数、匿名方法不使用任何参数
    ///         3.params参数：params 关键字在C#中用于在方法定义中指定一个参数数组，它允许你向方法传递数量可变的参数列表
    ///             如果委托声明的参数列表包含了params参数，那么匿名方法的参数列表将忽略params关键字
    ///      14.13.3 变量和参数的作用域
    ///         参数以及声明在匿名方法内部的局部变量的作用域限制在实现代码的主体之内，匿名方法结束则失效
    ///         1.外部变量
    ///         与委托的具名方法不同，匿名方法可以访问它们外围作用域的局部变量和环境
    ///             外围作用域的变量叫作外部变量
    ///             用在匿名方法实现代码中的外部变量称为被方法捕获
    ///         2.捕获变量的生命周期的扩展
    ///         只要捕获方法是委托的一部分，即使变量已经离开了作用域，捕获的外部变量也会一直有效
    ///             委托中的匿名方法在它的环境中保留了外部变量
    /// 14.14 Lambda表达式         
    ///     C#2.0引入了匿名方法，但是它的语法较长；C#3.0引入了Lambda表达式，简化了匿名方法的语法
    ///     ※删除delegate关键字
    ///     ※在参数列表和匿名主体之间放置Lambda运算符 => ，读做“goes to”
    ///     Mydel del = delegate(int x)    { return x+1;};   //匿名方法    
    ///     Mydel le1 =         (int x) => { return x+1;};   //Lambda表达式 
    ///     Mydel le2 =             (x) => { return x+1;};   //Lambda表达式 
    ///     Mydel le3 =              x  => { return x+1;};   //Lambda表达式 
    ///     Mydel le4 =              x  =>   return x+1  ;   //Lambda表达式 
    ///     由于编译器可以从委托声明中知道委托参数的类型，使用可以简化编写
    ///     ※Labbda表达式参数列表中的参数必须在参数数量、类型和位置上与委托相匹配
    ///     ※表达式的参数列表中的参数正常可以使用隐式类型，除非委托有ref或out参数---此时必须显式注明类型
    ///     ※如果只有一个参数而且是隐式类型，则两端的圆括号可以省略，否则必须有括号
    ///     ※如果没有参数，必须使用一组空的圆括号
    /// </summary>
    
    //声明委托类型
    delegate void MyDel(int value);
    delegate int MyDle2(int x, int y);
    delegate void PrintFunction();
    delegate void MyAdd(ref int x);
    delegate int OtherMethod(int InParam);
    public class Entrust
    {
        static void Main(string[] args)
        {
            Console.WriteLine("######委托的使用#####################");
            Random rand = new Random();
            int randomValue = rand.Next(99);    // 生成0-99随机数
            MyDel del = randomValue < 50 ? Program.PrintLow : Program.PrintHigh; // 创建委托对象
            del(randomValue);   // 执行委托
            /* 方法一：直接调用委托
            if (del != null)
            { del(randomValue); }   */
            /* 方法二使用Invoke和空条件运算符
            del?.Invoke(randomValue);   */
            Console.WriteLine("####################################");
            Console.WriteLine("######处理委托的标准步骤##############");
            int Add(int x, int y) { return x + y; }
            MyDle2 sum = Add;   // 创建委托实例并赋值
            sum += (x, y) => x * y;
            int result = sum(1, 2);
            Console.WriteLine($"多播结果：{result}");
            Console.WriteLine("####################################");
            Console.WriteLine("######委托的示例#####################");
            Test t = new Test(); // 实例化测试类
            PrintFunction pf;   // 创建一个空委托   
            pf = t.Print1;  // 实例初始化委托
            pf += Test.Print2;
            pf += t.Print1;
            pf += Test.Print2;
            if (pf != null)
            {
                pf.Invoke();    // 调用委托
            }
            else
                Console.WriteLine("Delegate is empty");
            Console.WriteLine("####################################");
            Console.WriteLine("######调用带引用参数的委托############");
            MyClass myClass = new MyClass();
            MyAdd myAdd = myClass.Add2;
            myAdd += myClass.Add3;
            myAdd += myClass.Add2;
            int x = 5;
            myAdd(ref x);
            Console.WriteLine($"Value:{x}");
            Console.WriteLine("####################################");
            Console.WriteLine("######匿名方法#######################");
            OtherMethod oM = delegate (int x) { return x + 20; };
            Console.WriteLine($"{oM(5)}");
            Console.WriteLine($"{oM(6)}");
            Console.WriteLine("####################################");

        }
    }
    // 什么是委托
    class Program
    {
        public static void PrintLow(int value)
        {
            Console.WriteLine($"{value} - Low Value");
        }
        public static void PrintHigh(int value)
        { 
            Console.WriteLine($"{value} - High Value");
        }
    }
    // 委托的示例
    class Test
    {
        public void Print1()
        {
            Console.WriteLine("Print1 --- instance");
        }
        public static void Print2()
        {
            Console.WriteLine("Print2 --- static");
        }
    }
    // 调用带引用参数的委托
    class MyClass
    {
        public void Add2(ref int x)
        { x += 2; }
        public void Add3(ref int x)
        { x += 3; }
    }
}
