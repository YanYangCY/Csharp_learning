using System;
using System.IO.Pipes;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Chapter_017
{
    /// <summary>
    /// 17.1 什么是转换
    ///     转换是接受一个类型的值并将它用作另一个类型的等价值的过程
    ///     转换后的值和源值一样，但其类型为目标类型 
    /// 17.2 隐式转换
    ///     语言会自动做这些转换的叫作隐式转换
    ///     从位数更少的类型转换为位数更多的目标类型，多出来的位需要用0或1填充
    ///     当从更小的无符号类型转换为更大的无符号类型时，目标类型多出来的最高位都以0进行填充，叫作零拓展
    /// 17.3 显式转换和强制转换
    ///     例：short类型强制转换为sbyte类型（因为short的范围大于sbyte，可能会丢失数据）
    ///     使用圆括号+目标类型进行转换  （目标类型）var1；
    /// 17.4 转换的类型
    ///     除了标准转换，还可以为用户自定义类型定义隐式转换和显式转换
    ///     有一个预定义的转换类型，叫作装箱，它可以将任何值类型转换为：object类型、System.ValueType类型
    ///     拆箱可以将一个装箱的值转换为原始类型
    /// 17.5 数字的转换
    ///     任何数字类型都可以转换为其他数字类型，一些是显式一些是隐式
    ///     17.5.1 隐式数字转换
    ///     17.5.2 溢出检测上下文
    ///         显式转换可能会丢失数据，对于整数类型，C#允许我们选择运行时进行类型转换时检测结果溢出，使用checked运算符和checked语句来实现
    ///         代码片段是否被检查称为溢出检测上下文
    ///         默认的溢出检测上下文是不检查
    ///         1.checked和unchecked运算符
    ///             checked会抛出异常，unchecked会忽略溢出;(默认为unchecked)
    ///         2.checked语句和unchecked语句
    ///             可以嵌套在任意层次
    ///     17.5.3 显式数字转换
    /// 17.6 引用转换
    ///     引用类型对象由内存中两部分组成：引用和数据
    ///     17.6.1 隐式引用转换
    ///         所有引用类型都可以被隐式转换为object类型
    ///         任何接口可以隐式转换为它继承的接口
    ///     17.6.2 显式引用转换
    ///         从object到任何引用类型的转换；
    ///         从基类到派生自它的类的转换；
    ///     17.6.3 有效显式引用转换
    ///         1.显式转换是没有必要的
    ///             从派生类到姐的转换总是隐式转换
    ///         2.源引用是null
    ///         3.由源引用指向的实际数据可以安全的进行隐式转换
    /// 17.7 装箱转换
    ///     装箱:值类型转换为引用类型
    ///     拆箱:引用类型转换为值类型
    ///     17.7.1 装箱是创建副本
    ///         装箱之后，值类型数据和引用类型数据是分开的，可以单独操作
    ///     17.7.2 装箱转换
    ///         任何值类型ValueTypes都可以被隐式转换为object、System.ValueTyp或InterfaceT类型
    /// 17.8 拆箱转换
    ///     拆箱是显式转换
    ///     尝试将值拆箱为非原始类型时会抛出异常InvalidCastException
    /// 17.9 用户自定义转换
    ///     除了标准转换，还可以为类和结构定义隐式和显式转换
    ///     除了implicit、explicit关键字之外，隐式转换和显式转换的声明语法是一样的；需要public、static修饰符
    ///     17.9.1 用户自定义转换的约束
    ///         只可以为类和结构定义用户自定义转换
    ///         不能重定义标准隐式或显式转换
    ///         对于源类型S和目标类型T，必须符合以下规则：
    ///             S和T必须是不同类型
    ///             S和T不能通过继承关联
    ///             S和T不能是接口类型或object类型
    ///             转换运算符必须是S或T的成员
    ///         对于相同的源类型和目标类型，不能声明两种转换，一个是隐式转换另一个是显式转换
    ///     17.9.2 用户自定义转换的示例
    ///     17.9.3 评估用户自定义转换
    ///     17.9.4 多步用户自定义转换的示例   
    /// 17.10 is运算符
    ///     Expr is TargetType  // 返回bool
    ///     如果Expr是引用转换、装箱转换、拆箱转换 ，运算符会返回true
    ///     is运算符不能用于用户自定义转换
    /// 17.11 as运算符
    ///     Expr as TargetType  // 返回引用；失败不抛出异常，返回null
    ///     只能用于引用转换、装箱转换，不能用于用户自定义转换
    /// </summary>
    public class Transformation
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("######数字的转换-溢出检测上下文#######");
            ushort sh = 2000;   // 16位 0-65535
            byte sb;    // 8位 0-255
            sb = (byte)sh;  // 丢失数据
            Console.WriteLine($"sb: {sb}");

            //sb = checked((byte)sh); // 抛出OverflowException异常
            //Console.WriteLine($"sb: {sb}");
            Console.WriteLine("####################################");
            Console.WriteLine("######装箱转换#######################");
            int i = 7;
            object oi = null;
            oi = i;
            Console.WriteLine($"操作前   i：{i}  oi: {oi}");
            i += 2;
            oi = 100;
            Console.WriteLine($"操作后   i：{i}  oi: {oi}");
            Console.WriteLine("####################################");
            Console.WriteLine("######拆箱转换#######################");
            int m = 10;
            object oi2 = null;
            oi2 = m;
            int j = (int)oi2;
            Console.WriteLine($"值类型 m：{m}  装箱 oi2: {oi2}  拆箱 j：{j}");
            Console.WriteLine("####################################");
            Console.WriteLine("######用户自定义转换#################");
            Person bill = new Person("bill",25);
            int age = (int)bill;
            Console.WriteLine($"显式转换：Name-{bill.Name} Age-{age}");
            Person anao = 35;
            Console.WriteLine($"隐式转换：Name-{anao.Name} Age-{anao.Age}");
            Console.WriteLine("####################################");
        }
    }
    /// <summary>
    /// 用户自定义转换的示例
    /// </summary>
    public class Person
    {
        public string Name;
        public int Age;
        //int Gender;
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            //Gender = gender;
        }
        public static implicit operator Person(int i)   // 将int类型隐式转换为person
        {
            return new Person("Nemo", i);
        }
        public static explicit  operator int(Person p)  // 将Person类型显式转换为int类型
        {
            return p.Age;
        }
        /* 对于相同的源类型和目标类型，不能声明两种转换
        public static explicit operator int(Person p2)
        {
            return (int)p2.Age;
        }*/
    }


    /* 17.6.3-1
    class A { public int Field1; }
    class B: A { public int Field2; }
    B myVar1 = new B();
    A myVar2 = (A)myVar1;
    */
    /* 17.6.3-2
    class A { public int Field1; }
    class B: A { public int Field2; }
    A myVar1 = null;
    B myVar2 = (B)myVar1;
    */
}