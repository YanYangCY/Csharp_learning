namespace Chapter_014
{
    //声明委托类型
    delegate void MyDel(int value);
    delegate int MyDle2(int x, int y);
    delegate void PrintFunction();
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
    ///     
    /// 
    /// 
    ///     
    /// </summary>
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
}
