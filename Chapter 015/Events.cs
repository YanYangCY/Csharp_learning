namespace Chapter_015
{
    /// <summary>
    /// 15.1 发布者和订阅者
    ///     ※很多程序都有一个共同的需求，即当一个特定的程序事件发生时，程序的其他部分可以得到该事件已经发生的通知。
    ///     发布者(publisher)：发布某个事件的类或结构，其他类可以在该事件发生时得到通知
    ///         1.发布者定义了事件成员    2.当发布者触发事件时，所有列表中的处理程序都会被调用
    ///     订阅者(subscriber)：注册并在事件发生时得到通知的类或结构
    ///         1.订阅者注册在事件成员被触发时要调用的回调方法（事件处理程序）
    /// 15.2 源代码组件概览
    ///     委托类型声明、事件注册、发布者类{事件声明(创建并发布)、订阅者类{事件处理(订阅事件)
    ///                                  {触发事件的代码               {程序声明
    /// 15.3 声明事件
    ///     事件是成员：1.不能在可执行代码中声明事件 2.必须声明在类或结构中 3.隐式自动初始化为null
    /// 15.4 订阅事件：订阅者向事件添加事件处理程序
    ///     1.使用+=运算符来为事件添加事件处理程序
    ///     2.事件处理程序的规范可以是以下任意一种：实例方法的名称；静态方法的名称；匿名方法；Lambda表达式
    /// 15.5 触发事件
    /// 15.6 标准事件的用法
    ///     15.6.1 通过拓展EventArgs来传递数据
    ///         EventArgs不能传递数据，必须声明一个派生自EventArgs的类，然后在类中使用合适的字段
    ///     15.6.2 移除事件处理程序
    ///         在用完事件处理程序之后，可以从事件中把它移除，使用-=运算符
    /// 15.7 事件访问器
    ///     两个访问器：add和remove
    /// 
    /// </summary>
    
    public delegate void Handler(); // 声明一个无参数、无返回值的委托
    public class Events
    {
        static void Main(string[] args)
        {
            Incrementer incrementer = new Incrementer();
            Dozens dozensCounter = new Dozens(incrementer);
            incrementer.DoCount();
            Console.WriteLine("Number of dozens = {0}",dozensCounter.DozensCount);
        }
    }
    // 声明事件
    public class Incrementer
    {   
        // 初始化一个空的委托实例作为事件的初始值
        //private static readonly EventHandler EmptyEventHandler = (sender, e) => { };
        // EventHandler是委托类型，CountedADozen是事件名
        //public event EventHandler CountedADozen = EmptyEventHandler;
        // 可以通过逗号分隔在声明语句中声明一个以上的事件
        public event EventHandler MyEvent1, MyEvent2, OtherEvent;
        // 通过使用static关键字让事件变成静态的
        public static  event EventHandler CountedADozen2;
        // Handler是委托类型，CountedADozen是事件名
        // public event Handler CountedADozen; // 声明一个事件，该事件使用Handler委托
        // 使用泛型委托
        public event EventHandler<IncrementerEventArgs> CountedADozen;
        public void DoCount()
        {
            IncrementerEventArgs args = new IncrementerEventArgs(); // 自定义类对象
            for (int i = 1; i <= 100; i++)
                if (i % 10 == 0 && CountedADozen != null)
                {
                    args.IterationCount = i;
                    CountedADozen(this, args);    // 触发事件
                }
        }
    }
    //订阅者
    public class Dozens
    {
        
        public int DozensCount { get; private set; }
        public Dozens(Incrementer incrementer)
        {
            DozensCount = 0;
            incrementer.CountedADozen += IncrementDozensCount;  //订阅事件
        }
        void IncrementDozensCount(object source, IncrementerEventArgs e) // 声明事件处理程序
        {
            Console.WriteLine($"Incremented at iteration:{e.IterationCount} in {source.ToString()}");
            DozensCount++;
        }
    }
    // 拓展EventArgs来传递参数
    public class IncrementerEventArgs : EventArgs
    {
        public int IterationCount { get; set; } // 存储一个整数
    }
    

    /*
    // 移除事件处理程序示例
    public class Events
    {
        static void Main(string[] args)
        { 
            Publisher p = new Publisher();
            Subscriber s = new Subscriber();
            p.SimpleEvent += s.MethodA;
            p.SimpleEvent += s.MethodB;
            p.RaiseTheEvent();
            Console.WriteLine("\r\nRemove MethodB!");
            p.SimpleEvent -= s.MethodB;
            p.RaiseTheEvent();
        }
    }
    // 发布者
    public class Publisher
    {
        public event EventHandler SimpleEvent;  // 声明事件
        // 触发事件
        public void RaiseTheEvent()
        {
            SimpleEvent(this,null);
        }
    }
    // 订阅者
    public class Subscriber
    {
        public void MethodA(object o, EventArgs e) { Console.WriteLine("AAA"); }
        public void MethodB(object o, EventArgs e) { Console.WriteLine("BBB"); }
    }
    */
}




    
