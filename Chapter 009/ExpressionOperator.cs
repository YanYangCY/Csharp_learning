﻿using System.Reflection;
using System.Runtime.CompilerServices;

namespace Chapter_9
{
    /// <summary>
    /// 9.1 表达式
    ///     表达式：由运算符(符号)和操作数(数据元素)组合而成
    /// 9.2 字面量
    ///     字面量：代码中键入的数字或字符串，表示一个指定类型的明确的、固定的值
    ///         bool两个字面量：true和false （小写）
    ///         对于引用类型变量，字面量null表示变量没有指向内存中的数据
    ///     9.2.1 整数字面量
    ///         正常使用十进制；十六进制以0X、0x开头；二进制以0B、0b开头
    ///         ---------------------------------------------------------
    ///             后缀                          整数类型
    ///         ---------------------------------------------------------
    ///         无                               int、uint、long、ulong
    ///         U、u                             uint、ulong
    ///         L、l                             long、ulong
    ///         ul、uL、Ul、UL、lu、Lu、lU、LU    ulong
    ///         ---------------------------------------------------------
    ///     9.2.2 实数字面量
    ///         C#有三种实数数据类：float、double、decimal；分别对应32位、64位、128位精度，都是浮点型数据类型
    ///         实数字面量的组成：十进制数字、一个可选的小数点、一个可选的指数部分(e、E)、一个可选的后缀
    ///         ---------------------------------------------------------
    ///             后缀                          实数类型
    ///         ---------------------------------------------------------
    ///             无                             double
    ///            F、f                            float
    ///            D、d                            double
    ///            M、m                            decimal
    ///         ---------------------------------------------------------
    ///     9.2.3 字符字面量
    ///         组成：两个单引号内的字符组成；单个字符、一个简单转义序列、一个十六进制转义序列、一个Unicode转义序列
    ///     9.2.4 字符串字面量
    ///         1.常规字符串字面量
    ///             组成：字符、简单转义序列、十六进制和Unicode转义序列
    ///         2.逐字字符串字面量
    ///             使用 @ 字符作为前缀
    ///             输出原始字符串不会被转义
    /// 9.3 求值顺序
    ///     表达式可以由许多嵌套的子表达式构成，子表达式的求值顺序可以使表达式的最终值发生变化
    ///     9.3.1 优先级   ---运算符优先级：从高到低
    ///         -----------------------------------------------------------------------------------------------
    ///              分   类                                     运   算   符
    ///         -----------------------------------------------------------------------------------------------
    ///             初级运算符                        a.x、f(x)、a[x]、x++、x--、new、typeof、checked、unchecked       
    ///             一元运算符                        +、-、|、~、++x、--x、(T)x
    ///             乘法                              *、/、%
    ///             加法                              +、-
    ///             移位                              <<、>>
    ///             关系和类型                        <、>、<=、>=、is、as
    ///             相等                              ==、!=
    ///             位与                              &
    ///             位异或                            ^
    ///             位或                              |
    ///             条件与                            &&
    ///             条件或                            ||
    ///             条件选择                          ?:
    ///             赋值运算符                        =、*=、/=、%=、+=、-=、<<=、>>=、&=、^=、|=
    ///         -----------------------------------------------------------------------------------------------
    ///     9.3.2 结合性
    ///         使用圆括号显式的设定子表达式的求值顺序
    ///         1.左结合运算符从左往右求值：其他二元运算符
    ///         2.右结合运算符从右往左求值：赋值运算符、条件运算符(三元)
    /// 9.4 简单算术运算符
    ///     +、-、*、/
    /// 9.5 求余运算符
    ///     结果 = 被除数 % 除数   （除数不为0）
    /// 9.6 关系比较运算符和相等比较运算符
    ///     <、>、<=、>=、==、!=
    ///     C#中，0和1不具有bool意义，Bool类型只有true和false
    /// 9.7 递增运算符和递减运算符
    /// 9.8 条件逻辑运算符
    ///     &&、||、！
    /// 9.9 逻辑运算符
    ///     &、|、^、~
    /// 9.10 移位运算符
    ///     <<、>>
    ///     将数据转换位二进制进行移位计算
    /// 9.11 赋值运算符
    ///     赋值运算符是二元右结合运算符
    ///     =、*=、/=、%=、+=、-=、<<=、>>=、&=、^=、|=
    /// 9.12 条件运算符
    ///     返回true或false
    ///     例： x<y?5:10 //如果x<y,输出5,否则输出10
    /// 9.13 一元算术运算符
    ///     +、-
    /// 9.14 用户定义的类型转换
    ///     隐式转换和显式转换
    /// 9.15 运算符重载
    ///     运算符重载只能用于类和结构
    ///     使用关键字operator进行重载
    ///     1.声明必须同时使用public和static修饰符
    ///     2.运算符必须是要操作的类或结构的成员
    ///     可重载的一元运算符：+、-、!、~、++、--、true、false
    ///            二元运算符：+、-、*、/、%、&、|、^、<<、>>、==、!=、>、<、>=、<=
    /// 9.16 typeof运算符
    ///     返回作为其参数的任何类型的System.Type对象
    ///     using System.Reflection //使用反射命名空间来全面利用检测类型信息的功能
    ///     Type t = typeof(xxx)
    /// 9.17 nameof运算符
    ///     用于获取变量、类型或成员的名称作为字符串
    ///     nameof 运算符在编译时求值，而不是在运行时。这样可以在代码重构时自动更新名称字符串，而无需手动修改
    ///     有助于减少错误和提高代码的可维护性,可以避免拼写错误和重构时的问题
    /// 9.18 其他运算符
    /// </summary>
    public class ExpressionOperator
    {
        static void Main(string[] args)
        {
            // 字面量
            Literal myLiteral = new Literal();
            // 移位运算符
            int a, b, x = 14;
            a = x << 3; // 左移   1110 ---> 01110000
            b = x >> 3; // 右移   1110 ---> 0001
            Console.WriteLine($"#####移位运算符########\n{x} << 3 = {a} \n{x} >> 3 = {b} \n#######################");
            // 运算符重载
            Vector v1 = new Vector(1,2);
            Vector v2 = new Vector(3,4);
            Vector v3 = v1 + v2;
            Console.WriteLine("#####运算符重载########\n"+v3+ "\n#######################");  //Console.WriteLine 会隐式调用对象的 ToString() 方法
            // typeof运算符
            Type t = typeof(Vector);
            FieldInfo[] fi = t.GetFields(); // 获取 Vector 类型中所有的字段信息
            MethodInfo[] mi = t.GetMethods();   // 获取 Vector 类型中所有的方法信息
            Console.WriteLine("#####typeof运算符######");
            foreach (FieldInfo f in fi)     Console.WriteLine($"Field:{f.Name}");
            foreach (MethodInfo m in mi)    Console.WriteLine($"Method:{m.Name}");
            Console.WriteLine("#######################");
        }       
    }
    // 字面量
    public class Literal
    {
        public Literal()
        {
            Console.WriteLine("#####字面量############");
            Console.WriteLine("{0}", 1024);     //整数字面量1024
            Console.WriteLine("{0}", 3.1416);   //双精度型字面量double
            Console.WriteLine("{0}", 3.1416F);  //浮点型字面量float
            Console.WriteLine("{0}", true);     //布尔型字面量
            Console.WriteLine("{0}", 'x');      //字符型字面量
            Console.WriteLine("{0}", "Hello!"); //字符串字面量
            Console.WriteLine("#######################");
        }
    }
    // 运算符的重载
    public class Vector
    {
        public int X { get; }
        public int Y { get; }
        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }
        // 重载 '+' 运算符
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y);
        }
        // 重载 Tostring 方法用于显示
        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}//END namespace
