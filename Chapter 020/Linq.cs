using System;

namespace Chapter_020
{
    /// <summary>
    /// 20.1 什么是LINQ
    ///     用于查询集合（如数组、列表、数据库等）的一组语言特性和API。它允许你使用类似SQL的语法来查询和操作这些数据集合。
    ///     重要高级特性：
    ///     1.LINQ代表 语言集成查询(Language Integrated Query)
    ///     2.LINQ是.NET框架的扩展，允许我们使用SQL查询数据库的类似方法来查询数据集合
    ///     3.使用LINQ，你可以从数据库、对象集合以及XML文档中查询数据
    /// 20.2 LINQ提供程序
    ///     LINQ可以查询各种类型的数据源，例如SQL数据库、XML文档 等等。
    ///     对于每一种数据源类型，一定有根据有根据该数据源类型实现LINQ查询的代码模块；这些代码模块叫作 LINQ提供程序（provider）
    ///     1.微软为常见的数据源类型提供了LINQ提供程序：Object、XML、SQL、Datasets。。。
    ///     3.第三方提供针对数据源的LINQ提供程序
    ///     ※匿名类型组成：new关键字、对象初始化语句；（对象初始化语句在一组大括号内包含了以逗号分隔的成员初始化语句列表）
    ///       匿名类型只能用于局部变量，不能用于类成员
    ///       由于匿名类型没有名字，必须使用var关键字作为变量类型
    ///       不能设置匿名类型对象的属性，编译器为匿名类型创建的属性是只读的
    ///       1.处理对象初始化语句的赋值形式，匿名类型的对象初始化语句还有两种形式：简单标识符、成员访问表达式（这两种叫作投影初始化语句）
    /// 20.3 方法语法和查询语法（编译器会将查询语法翻译为方法调用的形式，但两种没有性能上的差异）
    ///     1.查询语法：是声明式的，也就是查询描述的是你想返回的东西，但并没有指明如何执行这个查询。
    ///     2.方法语法：是命令式的，指明了查询方法调用的顺序
    /// 20.4 查询变量
    ///     LINQ查询可以返回两种类型的结果：枚举、标量
    ///     等号左边的变量叫查询变量
    ///     查询执行时间的差异总结：
    ///     1.如果查询表达式返回枚举，则查询一直到处理枚举时才会执行
    ///     2.如果枚举被处理多次，查询就会执行多次
    ///     3.如果在进行遍历之后、查询执行之前数据有改动，则查询会使用新的数据
    ///     4.如果查询表达式返回标量，查询立即执行，并且把结果保存在查询变量中
    /// 20.5 查询表达式的结构
    ///     查询表达式由from子句和查询主体组成
    ///     1.子句必须按照一定的顺序出现
    ///     
    /// 
    /// </summary>
    public class Linq
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("######简单使用LINQ示例###############");
            int[] numbers = { 1, 2, 15, 16 };   // 数据源
            IEnumerable<int> lowNums = from n in numbers // 定义并存储查询
                                       where n < 10 
                                       select n; 
            foreach (int n in lowNums)  // 执行查询
                Console.Write($"{n}, ");
            Console.WriteLine();
            Console.WriteLine("####################################");
            Console.WriteLine("######创建匿名类型###################");
            var student = new { Name = "JACK", Age = 18, Major = "History" }; // 前面变量必须使用var，后面大括号里面是匿名对象初始化语句
            Console.WriteLine($"{student.Name}，Age：{student.Age}， Major：{student.Major}");
            Console.WriteLine("####################################");
            Console.WriteLine("######方法语法和查询语法##############");
            int[] numbers2 = { 2, 5, 28, 31, 17, 16, 42 };   // 数据源
            var numsQuery = from n in numbers2 // 查询语法
                            where n < 20 
                            select n;    
            var numsMethod = numbers2.Where(N => N < 20);   // 方法语法
            int numsCount = (from n in numbers2 // 两种形式的组合，返回一个整数
                             where n<20 
                             select n).Count();
            foreach (int n in numsQuery)  // 执行查询
                Console.Write($"{n}, ");
            Console.WriteLine();
            foreach (int n in numsMethod)  // 执行查询
                Console.Write($"{n}, ");
            Console.WriteLine();
            Console.WriteLine(numsCount);
            Console.WriteLine("####################################");
        }
    }
}