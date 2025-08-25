using System;
using System.Threading;

namespace Chapter_021
{
    /// <summary>
    /// 多线程
    ///     线程的生命周期：开始于System.Threading.Thread类的对象被创建时，结束于线程被终止或完成执行时。
    ///     1.未启动状态 2.就绪状态 3.不可运行状态(sleep、Wait、I/O操作阻塞) 4.死亡状态
    /// 创建线程
    ///     通过拓展的Thread类调用Start()方法开始子线程的执行
    /// 
    /// 拓展：
    ///     Task.Run(() => { /* 你的代码 */ });
    ///     就是把花括号里的代码扔到线程池的一条工作线程上去执行，从而与当前线程并发/并行运行，效果上“相当于开了一个子线程”。
    ///     使用的是线程池线程，不是新建OS线程
    /// 
    /// </summary>
    public class MultiThread
    {
        public static async void Main(string[] args)
        {
            // ThreadStart 是一个无参数、无返回值的委托类型
            ThreadStart childref = new ThreadStart(CallToChildThread);
            Console.WriteLine("In Main : Creating the child thread");
            // 创建一个线程对象，指定它要运行的方法是 CallToChildThread。
            Thread childThread = new Thread(childref);
            // 启动线程
            childThread.Start();

            /***** 多线程写法 ******/
            // 1. Thread + ThreadStart
            Thread t = new Thread(new ThreadStart(CallToChildThread));  // 简写： new Thread(CallToChildThread).Start();
            t.Start();

            // 2. ThreadPool（QueueUserWorkItem）CLR 复用线程池里的线程，不用自己 new Thread。
            ThreadPool.QueueUserWorkItem(_ => CallToChildThread());

            // 3. Task （TPL，推荐）
            Task.Run(() => CallToChildThread());    // 默认用线程池
            // await Task.Factory.StartNew(CallToChildThread, TaskCreationOptions.LongRunning);    // 可新建一条真正的线程，但是方法必须是同步     

            // 4. async/await（语法糖，本质还是 ThreadPool）

        }

        public static void CallToChildThread()
        {
            Console.WriteLine( "Child thread is Start");
            //Thread.Sleep(5000); //线程暂停5000ms
        }
    }
}
