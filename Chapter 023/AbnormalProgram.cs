using System;

namespace Chapter_023
{
    /// <summary>
    /// 23.1 什么是异常
    ///     异常是程序中运行时的错误，违反了系统约束或应用程序约束。如果没有处理异常的情况，应用程序就会停止(或者崩溃)。
    /// 23.2 try语句：try语句用来指明为了避免出现异常而被保护的代码段
    ///     包含三部分：
    ///         try 块：包含为避免异常而被保护的代码
    ///         catch 子句：含有一个或多个catch子句，也称异常处理程序
    ///         finally 块：含有所有情况下都要被执行的代码，无论有没有异常发生
    /// 23.3 异常类
    ///     所有的异常类都派生自System.Exeception类
    ///                         ---SystemException：所有预定义系统异常的基类
    ///                         ---ApplicationExcetion：所有非致命的应用程序定义的异常的基类
    /// 23.4 catch子句
    ///     有四种形式，允许不同级别的处理
    /// 23.5 异常过滤器
    ///     过滤器的when子句可以在catch中采取对应的行动
    /// 23.6 catch子句段
    ///     catch子句的顺序排列要求
    /// 23.7 finally块
    ///     无论try、catch怎么执行，finally语句块一定执行
    /// 23.8 为异常寻找处理程序
    /// 23.9 进一步搜索
    /// 
    /// 23.10 抛出异常
    ///     可以使用throw语句使代码显式的抛出异常
    /// 23.11 不带异常对象的抛出
    /// 
    /// </summary>
    public class AbnormalProgram
    {
        public static void Main(string[] args)
        {
            int x = 10;

            try 
            {
                int y = 0;
                x /= y;
            }
            catch
            {
                Console.WriteLine("Handling all exceptions - Keep on Running");
            }
        }
    }
}