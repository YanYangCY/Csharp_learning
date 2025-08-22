using System;
using System.Diagnostics;
using System.Net;
using System.Security.Cryptography;

namespace Chapter_021
{
    /// <summary>
    /// 21.1 什么是异步
    ///     启动程序时，系统会在内存中创建一个新的进程；在进程内部，系统会创建一个称为线程的内核(kernel)对象。
    /// 21.2 async/await特性的结构
    ///     调用方法---异步(async)方法---await表达式
    /// 21.3 什么是异步方法
    ///     方法头包含async方法修饰符
    ///     包含一个或多个await表达式
    ///     必须具备3种返回类型之一：void 、 Task、 Task<T>/ValueTask<T>
    ///     任何具有公开可访问的GetAwaiter方法的类型
    ///     异步方法的形参可以为任意类型、任意数量，但不能为out或ref参数
    ///     按照约定，异步方法的名称应该以Async为后缀
    ///     除了方法之外，Lambda表达式和匿名方法也可以作为异步对象
    ///     ※如何编写自己的方法作为await的表达式的任务
    ///         使用Task.Run方法来创建一个Task，Func<TReturn>是一个预定义的委托
    ///         取消一个异步操作：CancellationToken和CancellationTokenSource
    ///         Task.Delay方法用于延时线程处理
    /// 21.4 GUI程序中的异步操作
    /// 21.7 BackgroundWorker 后台线程
    /// 21.11 计时器
    ///     计时器提供了另外一种定期重复运行异步方法的方式
    /// 
    /// </summary>
    public class AsyncProgram
    {
        /*
        public static void Main(string[] args)
        {
            MyDownloadString ds = new MyDownloadString();
            ds.DoRun();
        }*/
    }
    /// <summary>
    /// 网络请求耗时操作类
    /// </summary>
    //public class MyDownloadString
    //{
    //    // 高精度计时器，用于测量操作耗时
    //    Stopwatch sw = new Stopwatch();
    //    // 主要测试流程
    //    public void DoRun()
    //    {
    //        const int LargeNumber = 6_000_000;  // 循环次数，模拟CPU密集型操作
    //        sw.Start(); // 启动计时器
    //        // 同步执行网络请求（会阻塞线程）
    //        int t1 = CountCharacters(1, "http://www.microsoft.com");
    //        int t2 = CountCharacters(2, "http://illustratedcsharp.com");
    //        // 同步执行4次CPU密集型操作（顺序执行）
    //        CountToALargeNumber(1, LargeNumber);
    //        CountToALargeNumber(2, LargeNumber);
    //        CountToALargeNumber(3, LargeNumber);
    //        CountToALargeNumber(4, LargeNumber);
    //        // 输出结果
    //        Console.WriteLine($"Chars in http://www.microsoft.com     : {t1}");
    //        Console.WriteLine($"Chars in http://illustratedcsharp.com : {t2}");
    //        sw.Stop();
    //    }
    //    // 统计网站内容的字符数量
    //    public int CountCharacters(int id, string uriString)
    //    {
    //        WebClient wc1 = new();
    //        Console.WriteLine("Starting call {0}   :   {1,4:N0} ms",
    //            id, sw.Elapsed.TotalMilliseconds);  // 记录开始时间
    //        string result = wc1.DownloadString(new Uri(uriString));
    //        Console.WriteLine("Call {0} completed  :   {1,4:N0} ms",
    //            id, sw.Elapsed.TotalMilliseconds);  // 记录结束时间
    //        return result.Length;
    //    }
    //    // 模拟CPU密集型操作（空循环计数）
    //    public void CountToALargeNumber(int id, int value)
    //    {
    //        for (long i = 0; i < value; i++)
    //            ;
    //        Console.WriteLine("End counting {0} : {1,4:N0} ms",
    //            id, sw.Elapsed.TotalMilliseconds);
    //    }
    //}

    /// <summary>
    /// 网络请求耗时操作类----异步操作
    /// </summary>
    public class MyDownloadString
    {
        // 创建高精度计时对象
        Stopwatch sw = new Stopwatch();
    public void DoRun()
    {
        const int LargeNumber = 6_000_000;
        sw.Start(); // 开始计时
        Task<int> t1 = CountCharactersAsync(1, "http://www.microsoft.com");
        Task<int> t2 = CountCharactersAsync(2, "http://illustratedcsharp.com");

        // 同步执行4次CPU密集型操作（顺序执行）
        CountToALargeNumber(1, LargeNumber);
        CountToALargeNumber(2, LargeNumber);
        CountToALargeNumber(3, LargeNumber);
        CountToALargeNumber(4, LargeNumber);

        // 输出结果
        Console.WriteLine($"Chars in http://www.microsoft.com     : {t1.Result}");
        Console.WriteLine($"Chars in http://illustratedcsharp.com : {t2.Result}");
    }
    // 统计网站内容的字符数量-这里的async是给编译器的通行证，Task<int>是一个将来会产生int的异步任务
    public async Task<int> CountCharactersAsync(int id, string uriString)
    {
        WebClient wc1 = new();
        Console.WriteLine("Starting call {0}   :   {1,4:N0} ms",
            id, sw.Elapsed.TotalMilliseconds);  // 记录开始时间
                                                // 真正的异步行为-await异步操作
        string result = await wc1.DownloadStringTaskAsync(new Uri(uriString));
        Console.WriteLine("Call {0} completed  :   {1,4:N0} ms",
            id, sw.Elapsed.TotalMilliseconds);  // 记录结束时间
        return result.Length;
    }
    // 模拟同步CPU密集型操作（空循环计数）
    public void CountToALargeNumber(int id, int value)
    {
        for (long i = 0; i < value; i++)
            ;
        Console.WriteLine("End counting {0} : {1,4:N0} ms",
            id, sw.Elapsed.TotalMilliseconds);
    }
}

}