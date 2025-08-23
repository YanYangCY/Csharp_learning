using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Chapter_025
{
    /// <summary>
    /// 25.1 元数据和反射：使用 System.Reflection 命名空间
    ///     有关程序及其类型的数据被称为 元数据 ，保存在程序的程序集中。
    ///     程序在运行时，可以查看其他程序集或其本身的元数据的行为叫作 反射。
    /// 25.2 Type类
    ///     BLC声明了一个叫作Type的抽象类，被设计用来包含类型的特征
    ///     System.Type类的部分成员：
    ///     ---------------------------------------------------------
    ///         成员          成员类型       描述
    ///     ---------------------------------------------------------
    ///       Name              属性      返回类型的名字
    ///       Namespace         属性      返回包含类型声明的命名空间
    ///       Assembly          属性      返回声明类型的程序集。如果类型是泛型的，返回定义这个类型的程序集
    ///       GetFields         方法      返回类型的字段列表
    ///       GetProperties     方法      返回类型的属性列表
    ///       GetMethods        方法      返回类型的方法列表
    ///     ---------------------------------------------------------
    /// 25.3 获取Type对象
    ///     使用实例对象的 GetType 方法和 typeof 运算符和类名来获取 Type对象。
    /// 25.4 什么是特性
    ///     特性(attribute)是一种允许我们向程序的程序集添加元数据的语言结构。用于保存程序结构信息的特殊类型的类。
    ///     1.将应用了特性的程序结构(program construct)叫作 目标(target)。
    ///     2.设计用来获取和使用元数据的程序(比如说对象浏览器)叫作特性的 消费者。
    ///     3..NET预定了很多特性，我们也可以自定义特性。
    ///     特性名使用Pascal命名法，并以Attribute后缀结尾。当为目标应用特性时，可以不使用后缀。
    /// 25.5 应用特性     
    /// 25.6 预定义的保留特性
    ///     1. Obsolete 特性：可以将程序结构标注为“过时”，在代码编译的时显式有用的警告信息(可以在第二个参数输入bool类型来标记为错误)
    ///     2. Conditional 特性：是一个编译器条件开关，让方法调用只有在满足条件时才被编译，可以在一定程度上替代#if/#endif
    ///     3. 调用者信息特性：可以访问文件路径、代码行数、调用成员的名称等源代码信息。
    ///         CallerFilePath    CallerLineNumber    CallerMemberName
    ///         这些特性只能用于方法中的可选参数
    ///     4. DebuggerStepThrough 特性：告诉调试器在执行目标代码时不要进入该方法调试
    ///         位于 System.Diagnostics 命名空间
    ///         可用于类、结构、构造函数、方法或访问器
    ///     5. 其他预定义特性
    /// 25.7 关于应用特性的更多内容
    ///     多个特性，可以独立的特性片段彼此相叠；也可以写成单个特性片段，特性之间用逗号分隔
    /// 25.8 自定义特性
    ///     声明一个派生自System.Attribute的类
    ///     给他取一个以后缀Attribute结尾的名字
    ///     为安全起见，通常建议声明一个sealed的特性类
    ///     为安全起见，通常建议声明一个sealed的特性类
    /// 25.9 访问特性
    /// </summary>
    public class ReflectionAndFecture
    {
        public static void Main(string[] args)
        {
            var bc = new BaseClass();
            var dc = new DerivedClass();
            BaseClass[] bca = new BaseClass[] { bc, dc };
            foreach (var v in bca)
            {
                Type t = v.GetType();           // 获取类型
                Console.WriteLine($"Object type is : {t.Name}");

                FieldInfo[] fi = t.GetFields(); // 获取字段信息
                foreach (var f in fi)
                    Console.WriteLine($"                 {f.Name}");
                Console.WriteLine();
            }

            Type tbc = typeof(DerivedClass);    // 获取类型
            Console.WriteLine($"Object type is : {tbc.Name}");
            PrintOut("测试特性-Obsolete");
            MyTrace("测试调用者信息特性");
        }
        /* 测试 特性 Obsolete */
        [Obsolete("使用过时的程序结构")]  // 可以使用Obsolete("使用过时的程序结构", true)来标记为错误，而不是警告
        static void PrintOut(string input)
        {
            Console.WriteLine(input);
        }
        /* 测试 调用者信息特性 */
        public static void MyTrace(string message, [CallerFilePath]   string fileName = "",
                                                   [CallerLineNumber] int lineNumber = 0,
                                                   [CallerMemberName] string callingMember = "")
        {
            Console.WriteLine($"File:        {fileName}");
            Console.WriteLine($"Line:        {lineNumber}");
            Console.WriteLine($"Called From  {callingMember}");
            Console.WriteLine($"Message:     {message}");
        }
    }
    [Serializable]  // 序列化
    class BaseClass
    {
        public int BaseField = 0;
    }
    class DerivedClass : BaseClass
    {
        public int DerivedField = 0;
    }
}