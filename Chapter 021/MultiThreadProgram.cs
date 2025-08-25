using System;
using System.Threading;

namespace Chapter_021
{
    /// <summary>
    /// ���߳�
    ///     �̵߳��������ڣ���ʼ��System.Threading.Thread��Ķ��󱻴���ʱ���������̱߳���ֹ�����ִ��ʱ��
    ///     1.δ����״̬ 2.����״̬ 3.��������״̬(sleep��Wait��I/O��������) 4.����״̬
    /// �����߳�
    ///     ͨ����չ��Thread�����Start()������ʼ���̵߳�ִ��
    /// 
    /// ��չ��
    ///     Task.Run(() => { /* ��Ĵ��� */ });
    ///     ���ǰѻ�������Ĵ����ӵ��̳߳ص�һ�������߳���ȥִ�У��Ӷ��뵱ǰ�̲߳���/�������У�Ч���ϡ��൱�ڿ���һ�����̡߳���
    ///     ʹ�õ����̳߳��̣߳������½�OS�߳�
    /// 
    /// </summary>
    public class MultiThread
    {
        public static async void Main(string[] args)
        {
            // ThreadStart ��һ���޲������޷���ֵ��ί������
            ThreadStart childref = new ThreadStart(CallToChildThread);
            Console.WriteLine("In Main : Creating the child thread");
            // ����һ���̶߳���ָ����Ҫ���еķ����� CallToChildThread��
            Thread childThread = new Thread(childref);
            // �����߳�
            childThread.Start();

            /***** ���߳�д�� ******/
            // 1. Thread + ThreadStart
            Thread t = new Thread(new ThreadStart(CallToChildThread));  // ��д�� new Thread(CallToChildThread).Start();
            t.Start();

            // 2. ThreadPool��QueueUserWorkItem��CLR �����̳߳�����̣߳������Լ� new Thread��
            ThreadPool.QueueUserWorkItem(_ => CallToChildThread());

            // 3. Task ��TPL���Ƽ���
            Task.Run(() => CallToChildThread());    // Ĭ�����̳߳�
            // await Task.Factory.StartNew(CallToChildThread, TaskCreationOptions.LongRunning);    // ���½�һ���������̣߳����Ƿ���������ͬ��     

            // 4. async/await���﷨�ǣ����ʻ��� ThreadPool��

        }

        public static void CallToChildThread()
        {
            Console.WriteLine( "Child thread is Start");
            //Thread.Sleep(5000); //�߳���ͣ5000ms
        }
    }
}
