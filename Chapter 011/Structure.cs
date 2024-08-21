namespace Chapter_011
{
    /// <summary>
    /// 11.1 什么是结构
    ///     结构是程序员定义的数据类型：有数据成员和函数成员；与类相似
    ///     1.类是引用类型，而结构是值类型
    ///     2.结构是隐式密封的，这意味着不能从它们派生其他结构
    ///     使用关键字struct声明
    /// 11.2 结构是值类型
    ///     和所有值类型一样，结构类型变量含有自己的数据
    ///     1.结构类型的变量不能直接赋值为null
    ///     2.两个结构变量不能引用同一对象（这里的对象是指一个结构变量赋值给另一个结构变量时，实际是值的复制而不是同一个内存位置）
    /// 11.3 对结构赋值
    ///     把一个结构赋值给另一个结构，就是把一个结构的值复制给另一个结构。复制类变量只复制引用
    /// 11.4 构造函数和析构函数
    ///     结构可以有实例构造函数和静态构造函数，但不允许有析构函数
    ///     11.4.1 实例构造函数
    ///         语言隐式地为每个结构提供一个无参数的构造函数。
    ///         这个构造函数把结构的每个成员设置为该类型的默认值。值成员设置成它们的默认值，引用成员设置成nu11。
    ///         调用一个构造函数，包括隐式的无参数构造函数，要使用new关键字
    ///         如果没有用new关键字创建实例，必须先显式的设置数据成员的值再读取
    ///     11.4.2 静态构造函数
    ///         与类相似，结构的静态构造函数创建并初始化静态数据成员，而且不能引用实例成员
    ///     11.4.3 构造函数和析构函数小结
    /// 11.5 属性和字段初始化语句
    ///     声明结构体时，不允许使用实例属性和字段初始化语句（静态属性和静态字段可以在声明结构体时进行初始化）
    /// 11.6 结构是密封的
    ///     结构总是隐式密封的，所以不能从它们派生其他结构
    ///     不能用于结构的修饰符：protected、protected internal、abstract、sealed、virtual
    ///     结构本身派生自System.ValueType,System.ValueType派生自object
    /// 11.7 装箱和拆箱
    ///     如同其他值类型数据，如果想将一个结构实例作为引用类型对象，必须创建装箱(boxing)的副本。
    ///     装箱的过程就是制作值类型变量的！用类型副本。装箱和拆箱（unboxing)将在第17章阐述。
    /// 11.8 结构作为返回值和参数
    ///     结构可以用作返回值和参数
    ///     ※（常用）返回值：当结构体作为返回值时，将创建它的副本并从函数成员返回
    ///     参数：当结构被用作值参数时，将创建实参结构的副本。该副本用于方法的执行中。
    ///     ref和out参数：
    /// 11.9 关于结构的更多内容
    /// 
    /// 
    ///   
    ///     
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    public class Structure
    {
        static void Main(string[] args)
        {
            Console.WriteLine("######结构功能测试###################");
            Point first, second, third;
            first.X = 10; first.Y = 10;
            second.X = 20; second.Y = 20;
            third.X = first.X + second.X;
            third.Y = first.Y + second.Y;
            Console.WriteLine($"first:{first.X},{first.Y}\nsecond:{second.X},{second.Y}\nthird:{third.X},{third.Y}");
            Console.WriteLine("####################################");
            Console.WriteLine("######对结构赋值测试#################");
            CSimple cs1 = new CSimple(), cs2 = null;    // 类实例
            Point ss1 = new Point(), ss2 = new Point(); // 结构实例
            cs1.X = ss1.X = 5;
            cs1.Y = ss1.Y = 10;
            cs2 = cs1;  // 赋值类实例
            ss2 = ss1;  // 赋值结构实例
            Console.WriteLine($"cs1:{cs1.X},{cs1.Y}\ncs2:{cs2.X},{cs2.Y}\n" +
                $"ss1:{ss1.X},{ss1.Y}\nss2:{ss2.X},{ss2.Y}");
            Console.WriteLine("####################################");
            Console.WriteLine("######结构的实例构造函数测试##########");
            Point s2 = new Point(); // 使用new关键字隐式构造函数会将值成员设置成默认值
            Point s3 = new Point(3,4);
            Console.WriteLine($"s2:{s2.X},{s2.Y}");
            Console.WriteLine($"s3:{s3.X},{s3.Y}");
            Console.WriteLine("####################################");
            Console.WriteLine("######结构体作为返回值使用测试########");
            Geometry geometry = new Geometry();
            Point p1 = new Point(0, 0);
            Point p2 = new Point(10, 10);
            Point midPoint = geometry.GetMidPoint(p1, p2);
            Console.WriteLine($"MidPoint: X={midPoint.X}, Y={midPoint.Y}");
            Console.WriteLine("####################################");

        }
    }
    // 声明Point结构：两个公有字段
    public struct Point
    {
        public int X=10;
        public int Y;
        public Point(int a, int b)
        {
            X = a;
            Y = b;
        }
    }
    // 结构赋值演示-class
    class CSimple
    {
        public int X;
        public int Y;
    }
    // 结构作为返回值使用
    public class Geometry
    {
        public Point GetMidPoint(Point p1, Point p2)
        {
            int midX = (p1.X + p2.X) / 2;
            int midY = (p1.Y + p2.Y) / 2;
            return new Point(midX, midY);  // 返回一个结构体实例
        }
    }
}
