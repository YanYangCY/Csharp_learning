#define DEBUG
#undef TEST

using System;


namespace Chapter_024
{
    /// <summary>
    /// 24.1 什么是预处理指令
    ///     源代码指定了程序的定义。预处理指令指示编译器如何处理源代码。
    /// 24.2 基本规则
    ///     预处理指令必须和C#代码在不同行
    ///     与C#语句不同，预处理指令不需要以分号结尾
    ///     包含预处理指令的每一行必须以 # 字符开始
    ///         在 # 字符前可以有空格
    ///         在 # 字符和指令之间可以有空格
    ///     允许行尾注释  --->   //
    ///     在预处理指令所在的行不允许有分隔符注释  --->   /*  */
    /// 24.3 #define 和 #undef 指令
    ///     必须放在文件的开头
    ///     主要用于条件编译
    /// 24.4 条件编译：条件是一个返回true、false的简单表达式
    ///     #if    #else    #elif    #endif
    /// 24.5 条件编译结构
    /// 24.6 诊断指令
    ///     #warning    #error
    /// 24.7 行号指令
    /// 
    /// </summary>
    public class ProcessingDirective
    {
        public static void Main(string[] args)
        {
            #if DEBUG
                Console.WriteLine("DEBUG 已经定义！\n");
            #elif TEST
                Console.WriteLine("TEST 已经定义！\n");  // 不会执行
            #endif
        }
    }
}