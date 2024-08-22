using static Chapter_012.myEnum;
namespace Chapter_012
{
    /// <summary>
    /// 12.1 枚举
    ///     枚举是由程序员定义的类型，与类或结构一样
    ///     1.与结构一样，枚举是值类型，因此是直接存储它们的数据，而不是分开存储成引用和数据
    ///     2.枚举只有一种类型的成员：命名的整数值常量
    ///     例：  enum TrafficLight  // 关键字 +枚举名称
    ///          {  Green,           // 逗号分隔   0
    ///             Yellow,          // 1
    ///             Red    }         // 2
    ///     每个枚举类型都有一个底层整数类型，默认为int
    ///     1.每个枚举类型都被赋予一个底层类型的常量值
    ///     2.在默认情况下，编译器对第一个成员赋值为0，对每一个后续成员赋值都比前一个成员多1
    ///     12.1.1 设置底层类型和显式值
    ///         底层类型可以设置成任何整数类型
    ///         显式值：可以有重复的值（会违反枚举类型的安全性和清晰性）
    ///     12.1.2 隐式成员编号
    ///         如果某个成员显式的设置了编号，后面一个成员隐式编号是前一个显式编号+1
    /// 12.2 位标志
    ///     使用单个字的不同位作为表示一组开/关标志的紧凑方法，称为 "标志字（标志组合）" ，一般步骤如下：
    ///     1.确定需要多少位标志，并选择一种足够多位的无符号类型来保存
    ///     2.确定每个位位置代表什么，并给它们一个名称。声明一个选中的整数类型的枚举，每个成员由一个位位置表示
    ///     3.使用按位或（OR）运算符在持有该位标志的字中设置适当的位
    ///     4.使用按位与（AND）运算符或HasFlag方法检查是否设置了特定位标志
    ///     12.2.1 Flags特性
    ///         Flags特性不会改变计算结果，会通知编译器查看这段代码时声明该枚举成员不仅可用作单独的值，还可以组成位标志
    ///         如果不使用Flags，使用按位或组合位标志输出的将会是int数值，而不是两个位标志的名称
    ///     12.2.2 使用位标志的示例
    /// 12.3 关于枚举的更多内容
    ///     枚举只有单一的成员类型：声明的成员常量
    ///     1.不能对成员使用修饰符，它们都隐性的具有和枚举相同的可访问性
    ///     2.由于成员是静态的，即使在没有该枚举类型的变量时也可以访问它们
    ///         2.1可以使用 枚举名称.成员名 进行访问
    ///         2.2从C#6.0开始，可以使用Using static指令来避免每次使用时都包含类名，可以使代码更加简洁
    ///     枚举是一个独特的类型，比较不同枚举类型的成员会导致编译时错误
    ///     有用的静态方法：
    ///     1.GetName 方法以一个枚举类型对象和一个整数为参数，返回相应枚举成员的名称
    ///     2.GetNames 方法以一个枚举类型对象为参数，返回该枚举中所有成员的名称
    ///     3.使用typeof运算符来获取枚举类型对象
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("######枚举类型测试###################");
            //myEnum a1 = myEnum.Green; // 可以将枚举值赋给枚举类型变量
            Console.WriteLine($"枚举的第一个成员：{myEnum.Green}");
            Console.WriteLine($"转换为类型int：{(int)myEnum.Green}");
            Console.WriteLine("####################################");
            Console.WriteLine("######枚举显式设置值测试##############");
            Console.WriteLine($"myEnum3的XM：{(int)myEnum3.XV}");
            Console.WriteLine("####################################");
            Console.WriteLine("######位标志测试#####################");
            // 要创建一个带有适当的位标志的字，需要声明一个该枚举类型的变量，并使用按位或运算符设置需要的位
            CardDeckSettings ops = CardDeckSettings.SingleDeck 
                                  | CardDeckSettings.FancyNumbers 
                                  | CardDeckSettings.Animation;
            CardDeckSettings testFlags = CardDeckSettings.Animation | CardDeckSettings.LargePictures;
            bool useFancyNumbers1 = ops.HasFlag(CardDeckSettings.Animation);    // 检查ops标志字中是否设置了Animation
            bool useFancyNumbers2 = ops.HasFlag(testFlags);     // 使用HasFlag也可以检测多个位标志
            Console.WriteLine($"ops:{(uint)ops}\n" +
                $"useFancyNumbers1:{useFancyNumbers1}\nuseFancyNumbers2:{useFancyNumbers2}");
            bool useFancyNumbers3 = (ops & CardDeckSettings.FancyNumbers) == CardDeckSettings.FancyNumbers;
            Console.WriteLine($"useFancyNumbers3:{useFancyNumbers3}");
            Console.WriteLine("####################################");
            Console.WriteLine("######使用位标志示例#################");
            MyClass mc = new MyClass();
            CardDeckSettings ops1 = CardDeckSettings.SingleDeck | CardDeckSettings.FancyNumbers | CardDeckSettings.Animation;
            mc.SetOptions( ops1 );
            mc.PrintOptions();
            Console.WriteLine("######位标志测试#####################");
            Console.WriteLine($"{(int)Red}");

        }       
    }
    // 枚举类型示例
    enum myEnum
    {
        Green,  //默认0
        Yellow,
        Red
    }
    // 枚举设置底层类型
    enum myEnum2 : ulong
    {
    }
    // 枚举显式设置成员值
    enum myEnum3
    {
        XM = 180,
        XH = 150,
        XV = 150
    }
    // 位标志
    /// <summary>
    /// ——————————————————————————————————————
    ///               位编号   位名
    /// ——————————————————————————————————————
    /// 0 ... 0 0 0 1 = 1,  SingleDeck
    /// 0 ... 0 0 1 0 = 2,  LargePictures
    /// 0 ... 0 1 0 0 = 4,  FancyNumbers
    /// 0 ... 1 0 0 0 = 8,  Animation
    /// ——————————————————————————————————————
    /// </summary>
    [Flags]
    enum CardDeckSettings : uint
    {
        SingleDeck = 0x01,      // 位0
        LargePictures = 0x02,   // 位1
        FancyNumbers = 0x04,    // 位2
        Animation = 0x08        // 位3
    }
    // 使用位标志的示例
    class MyClass
    {
        bool UseSingleDeck               = false,
             UseBigPics                  = false,
             UseFancyNumbers             = false,
             UseAnimation                = false,
             UseAnimationAndFancyNumbers = false;
        public void SetOptions(CardDeckSettings ops)
        {
            UseSingleDeck   = ops.HasFlag(CardDeckSettings.SingleDeck);
            UseBigPics      = ops.HasFlag(CardDeckSettings.LargePictures);
            UseFancyNumbers = ops.HasFlag(CardDeckSettings.FancyNumbers);
            UseAnimation    = ops.HasFlag(CardDeckSettings.Animation);
            CardDeckSettings testFlags = CardDeckSettings.Animation | CardDeckSettings.FancyNumbers;
            UseAnimationAndFancyNumbers = ops.HasFlag(testFlags);
        }
        public void PrintOptions()
        {
            Console.WriteLine($"Option settings:");
            Console.WriteLine($"Use Single Deck                 - {UseSingleDeck}");
            Console.WriteLine($"Use Large Pictures              - {UseBigPics}");
            Console.WriteLine($"Use Fancy Numbers               - {UseFancyNumbers}");
            Console.WriteLine($"Show Animation                  - {UseAnimation}");
            Console.WriteLine($"Show Animation and FancyNumbers - {UseAnimationAndFancyNumbers}");
        }

    }
}
