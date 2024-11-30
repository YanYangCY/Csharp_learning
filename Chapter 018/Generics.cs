using System;
namespace Chapter_018
{
    /// <summary>
    /// 18.1 什么是泛型
    ///     重用性：通过泛型，你可以编写与类型无关的代码，从而避免了针对每种数据类型重复编写相同的代码。
    ///     类型安全：泛型允许在编译时检查类型，从而避免了在运行时出现类型不匹配的错误。
    ///     性能优化：泛型避免了装箱和拆箱操作，从而提高了性能。
    /// 18.2 C#中的泛型
    ///     泛型允许我们声明 类型参数化 的代码
    ///     类型是实例的模板；泛型是类型的模板
    ///     C#提供了五种泛型：类、结构、接口、委托、方法（前四种是类型，方法是成员）
    /// 18.3 泛型类
    ///     创建和使用：①声明泛型类型 ②通过（为占位符提供真实类型）创建“构造类型” ③从构造类型创建实例
    ///     18.3.1 声明泛型类
    ///         在类名后放置一组尖括号 <>
    ///         在尖括号中用逗号分隔的占位符字符串来表示需要提供的类型，叫作类型参数
    ///         在泛型类声明的主体中使用类型参数来表示替代类型
    ///         例：class SomeClass<T1, T2> {public T1 SomeVar; public T2 OtherVar;}
    ///     18.3.2 创建构造类型
    ///         
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    public class Generics
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
    class MyStack<T>    // 声明泛型类、在类名后放置类型占位符<T>
    {
        int StackPointer = -1; // 初始化栈指针为-1，表示栈为空
        T[] StackArray = new T[10]; // 假设初始容量为10

        public void Push(T x)
        {
            // 检查是否需要扩展栈容量
            if (StackPointer == StackArray.Length - 1)
            {
                Array.Resize(ref StackArray, StackArray.Length * 2);
            }
            StackArray[++StackPointer] = x; // 增加栈指针并压入元素
        }
        /// <summary>
        /// Pop 方法首先检查栈是否为空，如果为空则抛出异常。否则，它获取栈顶元素，减少 StackPointer，并返回该元素
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T Pop()
        {
            if (StackPointer == -1)
            {
                throw new InvalidOperationException("栈为空，无法执行Pop操作。");
            }
            T value = StackArray[StackPointer--]; // 获取栈顶元素并减少栈指针
                                                  // 可选：收缩数组以节省空间（但这里为了简单起见，不实现收缩逻辑）
            return value;
        }

        // 还可以添加其他方法，如Peek、IsEmpty等
    }
}

