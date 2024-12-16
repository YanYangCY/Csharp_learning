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
    /// 19.3        
    ///         
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
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

        }
    }
}
