using System;
using System.Collections;

namespace Chapter_019   // 枚举器和迭代器
{
    /// <summary>
    /// 19.1 枚举器和可枚举类型
    ///     使用 foreach 遍历数组中的元素：
    ///         1.数组可以按需提供一个叫 枚举器 的对象，枚举器可以依次返回请求的数组中的元素。
    ///           枚举器"知道"项的次序并且跟踪它在序列中的位置，然后返回请求的当前项
    ///         2.对于有枚举器的类型来说，必须有一种方式来获取它，获取对象枚举器的方法是调用对象的GetEnumerator方法。
    ///           实现 GetEnumerator 方法的类型叫作 可枚举类型(enumerable type)；数组就是可枚举类型。
    ///         3.foreach结构设计用来和可枚举类型一起使用，只要给他的遍历对象是可枚举类型，它就会执行：
    ///             3.1通过调用GetEnumerator方法获取对象的枚举器
    ///             3.2从枚举器中请求每一项并且把它作为 迭代变量(iteration variable),代码可以读取该变量但是不能改变。
    ///             例：foreach(Type VarName in EnumerableObject){} //EnumerableObject必须是可枚举类型
    /// 19.2 IEnumerator接口
    ///     实现了IEnumerator接口的枚举器包含了3个函数成员：Current、MoveNext、Reset
    ///     1.Current是返回序列中当前位置项的属性
    ///         它是只读属性
    ///         它返回object类型的引用，所以可以返回任何类型的对象
    ///     2.MoveNext是把枚举器位置前进到集合中下一项的方法。它也返回布尔值，指示新的位置是有效位还是超出序列尾部
    ///         如果新的位置有效，返回ture；无效返回false
    ///         枚举器的原始位置在序列中的第一项之前，因此MoveNext必须在第一次使用Current之前调用
    ///     3.Reset是把位置重置为原始状态的方法
    /// 19.3 IEnumerable接口
    ///     可枚举类是指实现了IEnumerable接口的类。IEnumerable接口只有一个成员---GetEnumerator方法，它返回对象的枚举器。
    /// 19.4 泛型枚举接口        
    ///     目前描述的接口都是非泛型，大多数情况下会使用泛型版本IEnumberable<T>和IEnumerator<T>。
    /// 19.5 迭代器   
    ///     迭代器(iterator)提供了更简单的创建枚举器和可枚举类型的方式(实际上迭代器创建了它们)
    ///     19.5.1 迭代器块
    ///         迭代器块是有一个或多个yield语句的代码块。迭代器块：方法主体、访问器主体、运算符主体
    ///         迭代器块有两个特殊语句：
    ///             yield return 语句指定了序列中要返回的下一项；
    ///             yield break 语句指定在序列中没有其他项。
    ///     19.5.2 使用迭代器来创建枚举器
    ///     19.5.3 使用迭代器来创建可枚举类型
    /// 19.6 常见迭代器模式
    ///     1.枚举器的迭代器模式：使用迭代器来创建枚举器
    ///     2.可枚举类型的迭代器模式：使用迭代器来创建可枚举类型
    /// 19.7 产生多个可枚举类型
    ///     类中有方法返回可枚举类型，但是类如果没有实现GetEnumerator，那么类本身就不是可枚举类型
    /// 19.8 将迭代器作为属性
    ///     演示1.使用迭代器来产生具有两个枚举器的类
    ///     演示2.演示迭代器如何实现为属性
    /// 19.9 迭代器的实质
    ///     1.迭代器需要System.Collections.Generic命名空间，需要引入
    ///     2.在编译器生成的枚举器中，不支持Reset方法。
    ///     3.由编译器生成的枚举器类包含四个状态的状态机：Before、Running、Suspended、After
    /// </summary>
    public class Traversal
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("######使用foreach的示例##############");
            int[] arr1 = { 1, 2, 3 };   // 定义数组
            foreach (int i in arr1) // 枚举元素
                Console.Write($"{i} ");
            Console.WriteLine();
            Console.WriteLine("####################################");
            Console.WriteLine("######IEnumerator接口模仿遍历########");
            int[] arr2 = { 5, 7, 9 };   // 创建数组
            IEnumerator ie = arr2.GetEnumerator(); // 获取并存储枚举器
            while ( ie.MoveNext() ) // 移到下一项
            {
                int item = (int)ie.Current; // 获取当前项
                Console.WriteLine($"Item Value: {item}");
            }
            Console.WriteLine("####################################");
            Console.WriteLine("######可枚举类的示例#################");
            Specturm specturm = new Specturm();
            foreach (string color in specturm)
                Console.WriteLine(color);
            Console.WriteLine("####################################");
            Console.WriteLine("######使用迭代器来创建枚举器##########");
            IteratorCreateEnumerator iterator = new IteratorCreateEnumerator();
            foreach ( string data in iterator)
                Console.WriteLine(data);
            Console.WriteLine("####################################");
            Console.WriteLine("######使用迭代器来创建可枚举类型######");
            IteratorCreateEnumerationTypes iterable = new IteratorCreateEnumerationTypes();
            foreach ( string data in iterable)  // 使用类对象
                Console.WriteLine(data);
            foreach (string data in iterable.BlackAndWhite())   // 使用类枚举器方法
                Console.WriteLine(data);
            Console.WriteLine("####################################");
            Console.WriteLine("######产生多个可枚举类型##############");
            Sceptrum sceptrum = new Sceptrum();
            foreach (string color in sceptrum.UVtoIR())
                Console.Write($"{color} ");
            Console.WriteLine();
            foreach (string color in sceptrum.IRtoUV())
                Console.Write($"{color} ");
            Console.WriteLine();
            Console.WriteLine("####################################");
            Console.WriteLine("######将迭代器作为属性################");
            Specturm2 startUV = new Specturm2(true);
            Specturm2 startIR = new Specturm2(false);
            foreach (string color in startUV)
                Console.Write($"{color} ");
            Console.WriteLine();
            foreach (string color in startIR)
                Console.Write($"{color} ");
            Console.WriteLine();
            Console.WriteLine("####################################");
        }
    }
    #region 可枚举类的示例---使用IEnumerable和IEnumerator
    /// <summary>
    /// 定义一个ColorEnumerator类，它实现了IEnumerator接口，用于枚举颜色字符串数组
    /// </summary>
    class ColorEnumerator : IEnumerator
    {
        string[] colors;    // 私有字段，用于存储颜色字符串数组
        int position = -1;  // 私有字段，表示当前枚举器的位置，-1表示枚举器位于初始位置（即，尚未开始枚举）
        public ColorEnumerator(string[] theColors)  // 构造函数,接收一个颜色字符串数组作为参数，并将其赋值给colors字段
        {
            colors = new string[theColors.Length];
            for (int i = 0; i < theColors.Length; i++)
                colors[i] = theColors[i];
        }
        public object Current   // 实现Current,返回当前枚举的元素
        {
            get
            {
                if (position == -1) // 如果枚举器尚未开始枚举，则抛出InvalidOperationException异常
                    throw new InvalidOperationException();  
                if(position >= colors.Length)   // 如果枚举器已超出数组末尾，则也抛出InvalidOperationException异常
                    throw new InvalidOperationException();
                return colors[position];     // 返回当前位置的颜色字符串
            }
        }
        public bool MoveNext()  // 实现MoveNext，将枚举器推进到下一个元素
        {
            if (position < colors.Length - 1)   // 如果当前位置不是数组的最后一个元素，则将位置加1并返回true
            {
                position++;
                return true;
            }
            else     // 如果当前位置是数组的最后一个元素或已超出末尾，则返回false
                return false;
        }
        public void Reset() // 实现Reset，将枚举器重置到其初始位置
        {
            position = -1;  // 将位置重置为-1，表示枚举器尚未开始枚举
        }
    }
    class Specturm : IEnumerable    // 实现IEnumerable接口
    {
        string[] colors = { "Red", "Orange", "Yellow", "Green", "Cyan", "Blue", "Violet" };  // 私有字段，存储颜色字符串数组
        public IEnumerator GetEnumerator()  // 实现IEnumerable接口的GetEnumerator方法，返回一个用于枚举Specturm中颜色的枚举器
        {
            // 创建一个ColorEnumerator实例，并传入colors数组作为参数
            // 然后返回这个枚举器实例，以便外部代码可以使用它来枚举颜色
            return new ColorEnumerator(colors);
        }
    }
    #endregion

    #region 使用迭代器来创建枚举器
    class IteratorCreateEnumerator
    {
        public IEnumerator<string> GetEnumerator()
        {
            return BlackAndWhite(); // 返回枚举器
        }
        public IEnumerator<string> BlackAndWhite()  // 迭代器
        {
            yield return "Black";
            yield return "Gray";
            yield return "White";
        }
    }
    #endregion

    #region 使用迭代器来创建可枚举类型
    class IteratorCreateEnumerationTypes
    {
        public IEnumerator<string> GetEnumerator()
        {
            IEnumerable<string> myEnumerable = BlackAndWhite(); // 获取可枚举类型
            return myEnumerable.GetEnumerator();    // 获取枚举器
        }
        public IEnumerable<string> BlackAndWhite()  // IEnumerable<string>返回可枚举类型
        {
            yield return "BlackType";
            yield return "GrayType";
            yield return "WhiteType";
        }
    }
    #endregion

    #region 产生多个可枚举类型
    class Sceptrum
    {
        string[] colors = { "Violet", "Blue", "Cyan", "Green", "Yellow", "Orange", "Red" };
        public IEnumerable<string> UVtoIR() // 返回一个可枚举类型
        {
            for (int i = 0; i < colors.Length; i++) 
                yield return colors[i];
        }
        public IEnumerable<string> IRtoUV() // 返回一个可枚举类型
        {
            for(int i = colors.Length - 1; i >= 0; i--)
                yield return colors[i];
        }
    }
    #endregion

    #region 将迭代器作为属性
    class Specturm2
    {
        bool _listFromUVtoIR;
        string[] colors = { "Violet", "Blue", "Cyan", "Green", "Yellow", "Orange", "Red" };
        public Specturm2(bool listFromUVtoIR)
        {
            _listFromUVtoIR = listFromUVtoIR;
        }
        public IEnumerator<string> GetEnumerator()
        {
            return _listFromUVtoIR ? UVtoIR: IRtoUV;
        }
        public IEnumerator<string> UVtoIR   // 迭代器属性
        {
            get
            {
                for (int i = 0; i < colors.Length; i++)
                    yield return colors[i];
            }
        }
        public IEnumerator<string> IRtoUV   // 迭代器属性
        {
            get
            {
                for (int i = colors.Length - 1; i >= 0; i--)
                    yield return colors[i];
            }
        }

    }
    #endregion

}
