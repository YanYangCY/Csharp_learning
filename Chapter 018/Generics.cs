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
    ///         一旦声明了泛型类型，我们就需要告诉编译器能使用哪些真实类型来替代占位符（类型参数）
    ///         编译器获取这些真实类型并创建构造类型
    ///         替代类型参数的真实类型叫作 类型实参：SomeClass<short, int>
    ///     18.3.3 创建变量和实例
    ///         SomeClass<short, int> mySc1 = new SomeClass<short, int>();
    ///         var                   mySc2 = new SomeClass<short, int>();
    ///     18.3.4 使用泛型的栈的示例
    ///         C#中自带泛类型Stack用于操作栈
    ///         // 使用 ToArray 方法将栈元素转换为一个数组，以便在不修改栈的情况下遍历它们
    ///            int[] stackArray = stack.ToArray();
    ///     18.3.5 比较泛型和非泛型栈
    ///         泛型：源代码更小、可执行文件只会出现由构造类型的类型、易于维护  （比较难写，因为更抽象）
    /// 18.4 类型参数的约束
    ///     在泛类型栈的示例中，栈除了保存和弹出它包含的一些项之外没有做任何事。它不会尝试添加、比较项，也不会
    ///     做任何其他需要用到项本身的运算符的事情。（这是因为泛型栈不知道它们保存的项的类型是什么，所以也不会知道这些类型实现的成员）
    ///     符合约束的类型参数叫作未绑定的类型参数。
    ///     我们需要提供额外的信息让编译器知道参数可以接受哪些类型，这些额外的信息叫作 约束。
    ///     18.4.1 Where子句
    ///         约束使用where子句列出
    ///             每一个有约束的类型参数都有自己的where子句
    ///             如果形参有多个约束，它们在where子句中使用逗号分隔
    ///             例： where TypeParam : constraint, constraint, ...
    ///             关于where子句：
    ///             1.在类型参数列表的关闭尖括号之后列出
    ///             2.它们子句之间不使用逗号或其他符号分隔
    ///             3.可以以任何次序列出
    ///             4.where是上下文关键字，所以可以在其他上下文中使用
    ///     18.4.2 约束类型和次序
    ///     ——————————————————————————————————————————————————————————————————————————
    ///         约束类型                        描述
    ///     ——————————————————————————————————————————————————————————————————————————
    ///          类名         只有这个类型的类或从它派生的类才能用作类型实参
    ///          class        任何引用类型，包括类、数组、委托和接口都可以用作类型实参
    ///          struct       任何值类型都可以用作类型实参
    ///          接口名       只有这个接口或者实现这个接口的类型才能用作类型实参
    ///          new()        任何带有无参公共构造函数的类型都可以用作类型实参。这叫作构造函数约束   
    ///     ——————————————————————————————————————————————————————————————————————————
    ///         where子句可以以任何次序列出，但是子句中的约束必须有特定的顺序
    ///             最多只能有一个主约束，而且必须放在第一位
    ///             可以有任意多的接口名称约束
    ///             如果存在构造函数约束，则必须放在最后
    ///               主约束           次约束            构造函数约束 
    ///             （0或1个）       （0或多个）          （0或1个）
    ///             {ClassName}   { InterfaceName }     { new() }
    ///             {  class  }
    ///             {  struct }
    /// 18.5 泛型方法
    ///     和其他泛型不同，方法是成员，不是类型。
    ///     泛型方法可以在泛型和非泛型类以及结构和接口中声明
    ///     18.5.1 声明泛型方法
    ///         泛型方法具有类型参数列表和可选的约束
    ///         1.泛型方法有两个参数列表
    ///             封闭的尖括号内的 类型参数 列表
    ///             封闭的圆括号内的 方法参数 列表
    ///         2.要声明泛型方法，需要：
    ///             在方法名称之后和方法参数参数列表之前放置类型参数列表
    ///             在方法参数列表之后放置可选的约束子句
    ///             例：public void PrintData<S, T>(S p, T t) where S: Person
    ///     18.5.2 调用泛型方法
    ///         要调用泛型方法，应该在方法调用时提供类型实参。例：MyMethod<short, int>();
    ///         由于编译器可以从方法参数中推断类型参数，可以省略类型参数和调用中的的尖括号。例：MyMethod(myInt);
    ///     18.5.3 泛型方法的示例
    ///         在方法参数已经声明的情况下，泛型方法调用是可以通过编译器本身的推断来得到类型参数和方法参数
    /// 18.6 扩展方法和泛型类    
    ///     和非泛型类一样，泛型类的扩展方法：
    ///         必须声明为static
    ///         必须是静态类的成员
    ///         第一个参数类型中必须有关键字this，后面是扩展的泛型类的名字
    /// 18.7 泛型结构
    ///     泛型结构的规则和条件是和泛型类一样的
    /// 18.8 泛型委托
    ///     泛型委托和非泛型委托非常相似，不过类型参数决定了能接受什么样的方法
    ///         1.要声明泛型委托，在委托名称之后、委托参数列表之前的尖括号中放置类型参数列表。
    ///             例：delegate R MyDelegate<T, R>(T value);
    ///         2.如上例子中所示，有两个参数列表：类型参数列表、委托形参列表
    ///         3.类型参数的范围包括：返回类型、形参列表、约束子句
    /// 18.9 泛型接口
    ///     泛型接口允许编写形参与接口成员返回类型是泛型类型参数的接口。
    ///     18.9.1 使用泛型接口的实例
    ///         与其他泛型相似，用不同类型参数实例化的泛型接口的实例是不同的接口
    ///         可以在非泛型类型中实现泛型接口
    ///     18.9.2 泛型接口的实现必须唯一
    ///         实现泛型类型接口时，必须保证类型实参的组合不会在类型中产生两个重复的接口。
    ///         第一个是构造类型，使用int类型进行实例化；第二个有一个类型参数，但不是实参
    ///         （存在一个潜在的问题，如果用int类型实参替代第二个接口S的话，就会有两个相同的接口，这是错误的）
    ///         例： class Simple<S> : IMyIfc<int>, IMyIfc<S> 
    ///         注：泛型接口的名字是不会和非泛型冲突的
    /// 18.10 协变和逆变
    ///     可变性 分为三种：协变、逆变、不变
    ///     18.10.1 协变
    ///         ：在泛型类型的使用中，允许将某个类型参数替换为该参数的派生类。
    ///         创建一个派生类型对象，将它赋值给基类类型的变量；
    ///         泛型委托中创建委托对象派生类，再将其赋值给基类委托对象是不成立的；因为Dog是Animal派生的，但是委托Factory<Dog>没有从Factory<Animal>派生
    ///         仅将派生类型用作输出值与构造委托有效性之间的常数关系叫作协变，必须使用out关键字标记委托声明中的类型参数
    ///         协变关系允许程度更高的派生类别处于返回及输出位置
    ///         例：定义一个协变的委托 public delegate T AnimalDelegate<out T>();，然后可以将一个返回 Dog 类型的委托赋值给返回 Animal 类型的委托。
    ///     18.10.2 逆变
    ///         ：在泛型类型的使用中，允许将某个类型参数替换为该参数的基类。
    ///         逆变关键字 in
    ///         在期望传入基类时允许传入派生对象的特性叫作逆变。
    ///         例：定义一个逆变的委托 public delegate void AnimalAction<in T>(T animal);，然后可以将一个接受 Animal 类型的委托赋值给接受 Dog 类型的委托。
    ///     18.10.3 协变和逆变的不同
    ///         协变：允许将派生类类型替换为基类类型，主要用于返回值。
    ///         逆变：允许将基类类型替换为派生类类型，主要用于方法参数。
    ///         协变和逆变只支持引用类型，不支持值类型
    ///     18.10.4 接口的协变和逆变
    ///         
    ///     18.10.5 关于可变性的更多内容
    ///         目前不需要去了解，这部分感觉用处不大
    /// 
    /// </summary>
    public class Generics
    {
        static void Main()//string[] args
        {
            Console.WriteLine("######创建构造类型、实例#############");
            var first = new SomeClass<short, int>();    // 构造的类型
            var second = new SomeClass<int, long>();    // 构造的类型
            Console.WriteLine("####################################");
            Console.WriteLine("######使用泛型的栈的示例##############");
            var one = new MyStack<int>();
            var two = new MyStack<string>();
            one.Push(1);
            one.Push(2);
            one.Push(3);
            one.Pop();
            one.Pop();
            one.Pop();
            //one.Pop();
            one.Print();
            two.Push("nb");
            two.Push("nvcc");
            two.Print();
            Console.WriteLine("####################################");
            Console.WriteLine("######使用泛型方法的示例##############");
            //Simple simple = new(); //因为ReverseAndPrint方法是static的，所以不需要实例化类
            int[] intArray = new int[] { 3, 5, 7, 9, 11};
            string[] stringArray = new string[] { "first", "second", "third" };
            double[] doubleArray = new double[] { 3.567, 7.891, 2.345 };
            Simple.ReverseAndPrint<int>(intArray);
            Simple.ReverseAndPrint(intArray);   // 推断类型并调用，这里的intArray已经声明了自己是int类型
            Simple.ReverseAndPrint(stringArray);
            Simple.ReverseAndPrint(doubleArray);
            Console.WriteLine("####################################");
            Console.WriteLine("######扩展方法和泛型类################");
            Holder<int> intHolder = new Holder<int>(3, 7, 9);
            intHolder.Print();
            Console.WriteLine("####################################");
            Console.WriteLine("######泛型结构#######################");
            PieceOfData<int> intData = new PieceOfData<int>(10);
            Console.WriteLine($"intData = {intData.Data}");
            Console.WriteLine("####################################");
            Console.WriteLine("######泛型委托#######################");
            //var myDel = new MyDelegate<string>(SimpleDelegate.PrintString); // 创建委托实例
            MyDelegate<string> myDel = SimpleDelegate.PrintString;  // 创建委托实例
            myDel += SimpleDelegate.PrintUpperString;    // 添加方法
            myDel("Hi There!"); // 调用委托
            Console.WriteLine("####################################");
            Console.WriteLine("######泛型接口#######################");
            SimpleInterface<int> trivInt = new SimpleInterface<int>();
            var trivString = new SimpleInterface<string >();
            Console.WriteLine($"泛型接口Int：{trivInt.ReturnIt(5)}");
            Console.WriteLine($"泛型接口String：{trivString.ReturnIt("Hi there.")}");

            SimpleNor simpleNor = new SimpleNor();
            Console.WriteLine($"非泛型类中调用泛型接口：Int {simpleNor.ReturnIt(6)}, String {simpleNor.ReturnIt("HaHa.")}");
            Console.WriteLine("####################################");
            Console.WriteLine("######协变示例#######################");
            Factory<Dog> dogMaker = Program.MakeDog;    // 创建委托对象
            Factory<Animal> animalMaker = dogMaker;     // 尝试赋值委托变量
            Console.WriteLine($"Animal's Legs : { animalMaker().Legs}");
            Console.WriteLine("####################################");
            Console.WriteLine("######逆变示例#######################");
            Action<Animal> act1 = Program1.ActOnAnimal;// 创建委托对象
            Action<Dog> dog1 = act1;
            dog1(new Dog());
            Console.WriteLine("####################################");
            Console.WriteLine("######接口的协变示例#################");
            SimpleReturn<Dog> dogReturner = new SimpleReturn<Dog>();
            dogReturner.items[0] = new Dog() { Name = "XiaoBai"};
            IMyIfc2<Animal> animalReturner = dogReturner;
            Program2.DoSomething(dogReturner);
            Console.WriteLine("####################################");
        }
    }
    #region 创建泛类型示例
    /// <summary>
    /// 创建泛类型示例
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    class SomeClass<T1, T2>
        //where T1 : struct
        //where T2 : struct
    {
        public T1 SomeVar;
        public T2 OtherVar;
    }
    #endregion 

    #region 泛型类MyStack
    /// <summary>
    /// 声明一个泛型类MyStack，其中T是类型占位符，表示栈中可以存储的任意类型
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyStack<T>
    {
        T[] StackArray; // 声明一个泛型数组StackArray，用于存储栈中的元素
        int StackPointer = 0; // 声明一个栈指针StackPointer，用于跟踪栈顶元素的位置;初始化栈指针为0,表示栈为空时，没有元素被压入栈中

        const int MaxStack = 10;    // 声明一个常量MaxStack，表示栈的最大容量
        /// <summary>
        /// 构造函数，用于初始化栈数组
        /// </summary>
        public MyStack()
        {
            StackArray = new T[MaxStack];
        }
        /// <summary>
        /// 声明一个只读属性IsStackFull，用于检查栈是否已满
        /// 当StackPointer大于等于MaxStack时，栈已满,返回True；否则返回false
        /// </summary>
        bool IsStackFull { get { return StackPointer >= MaxStack; } }
        /// <summary>
        /// 声明一个只读属性IsStackEmpty，用于检查栈是否空了
        /// 当StackPointer小于等于0时，栈已空,返回True；否则返回false
        /// </summary>
        bool IsStackEmpty { get { return StackPointer <= 0; } }
        /// <summary>
        /// 判断如果栈没有满，增加栈指针并将元素存储在数组中
        /// 如果栈已满，不进行任何操作
        /// </summary>
        /// <param name="x">要压入栈中的元素</param>
        public void Push(T x)
        {
            if (!IsStackFull)
            {
                StackArray[StackPointer++] = x;
            }
        }
        /// <summary>
        /// 从栈中弹出栈顶元素
        /// 如果栈不空，则减少栈指针并返回栈顶元素
        /// 如果栈为空，则返回数组的第一个元素（可能会导致未定义行为，在典型栈实现中，栈为空应该抛出一个异常或者返回特殊值）
        /// </summary>
        /// <returns>弹出栈顶元素</returns>
        public T Pop()
        {
            //return (!IsStackEmpty) ? StackArray[--StackPointer] : StackArray[0];
            return (!IsStackEmpty) ? StackArray[--StackPointer] : throw new InvalidOperationException("栈为空，无法执行Pop操作！");
        }
        /// <summary>
        /// 打印栈中所有的元素，从栈底到栈顶
        /// </summary>        
        public void Print()
        {
            for (int i = StackPointer - 1; i >= 0; i--)
                Console.WriteLine($"    Value: {StackArray[i]}");
        }
    }
    #endregion 泛型类MyStack 

    #region 泛型方法的示例
    /// <summary>
    /// 在非泛型类中声明泛型方法
    /// </summary>
    class Simple
    {
        static public void ReverseAndPrint<T>(T[] arr)  // 泛型方法
        {
            Array.Reverse(arr); // 反转数组元素，只能用于一维数组
            foreach (T item in arr)
                Console.Write($"{ item.ToString() }, ");
            Console.WriteLine("");
        }
    }
    #endregion

    #region 扩展方法和泛型类
    /// <summary>
    /// 泛型类：构造函数 、 GetValues方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class Holder<T>
    {
        T[] Vals = new T[3];
        public Holder(T v0, T v1, T v2) { Vals[0] = v0; Vals[1] = v1; Vals[2] = v2; }
        public T[] GetValues() { return Vals; }
    }
    /// <summary>
    /// 静态类
    /// 扩展方法：Print
    /// 扩展了Holder泛型类
    /// </summary>
    static class ExtendHolder
    {
        public static void Print<T> (this Holder<T> h)
        {
            T[] vals = h.GetValues();
            Console.WriteLine($"Vals: {vals[0]}, {vals[1]}, {vals[2]}");
        }
    }
    #endregion

    #region 泛型结构
    /// <summary>
    /// 泛型结构
    /// - `_data` 是一个私有字段，用于存储泛型类型 `T` 的数据。
    /// - 构造函数 `PieceOfData(T data)` 允许在创建 `PieceOfData` 实例时初始化 `_data` 字段。
    /// - `Data` 是一个公共属性，提供对 `_data` 字段的读取和写入访问。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    struct PieceOfData<T>
    {
        private T _data;
        public PieceOfData(T data) { _data = data; }
        public T Data { get { return _data; } set { _data = value; } }
    }
    #endregion

    #region 泛型委托
    delegate void MyDelegate<T>(T value);   // 声明泛型委托类型
    class SimpleDelegate
    {
        static public void PrintString(string s)    // 方法匹配委托：无返回值，string变量
            { Console.WriteLine(s); }
        static public void PrintUpperString(string s)   // 方法匹配委托
            { Console.WriteLine($"{s.ToUpper()}"); }
    }
    #endregion

    #region 泛型接口
    interface IMyIfc<T> // 泛型接口
    {
        T ReturnIt(T inValue);
    }
    class SimpleInterface<S> : IMyIfc<S>    // 泛型类
    {
        public S ReturnIt(S inValue)    // 实现泛型接口
            { return inValue; }
    }
    class SimpleNor : IMyIfc<int>, IMyIfc<string>   // 非泛型类
    {
        public int ReturnIt(int inValue) { return inValue; }    // 实现int类型接口
        public string ReturnIt(string inValue) { return inValue; }   // 实现string类型接口
    }
    #endregion

    #region 协变-委托
    class Animal { public int Legs = 4; public string Name; }   // 基类
    class Dog : Animal { public int tail = 1; } // 派生类
    delegate T Factory<out T>();    // Factory委托-out关键字指定了类型参数的协变
    class Program
    {
        static public Dog MakeDog() // 匹配Factory委托的方法
        { return new Dog(); }
    }
    #endregion

    #region 逆变-委托
    delegate void Action<in T>(T a);    //   逆变关键字in
    class Program1
    {
        static public void ActOnAnimal(Animal a) { Console.WriteLine($"逆变：{a.Legs}"); }
    }
    #endregion

    #region 接口的协变和逆变
    interface IMyIfc2<out T>    // 声明接口
    {
        T GetFirst();
    }
    class SimpleReturn<T> : IMyIfc2<T>  // 调用接口
    {
        public T[] items = new T[2];
        public T GetFirst() { return items[0]; }
    }
    class Program2
    {
        public static void DoSomething(IMyIfc2<Animal> returner)
        {
            Console.WriteLine($"接口的协变：{returner.GetFirst().Name}");
        }
    }
    #endregion
}
