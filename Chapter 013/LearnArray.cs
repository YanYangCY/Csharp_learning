﻿namespace Chapter_013
{
    /// <summary>
    /// 13.1 数组
    ///     数组实际上是由一个变量名称表示的一组同类型的数据元素。每个元素通过变量名称和方括号中的一个或多个索引进行访问
    ///     13.1.1 定义
    ///         元素：数组的独立数据项称为元素。数组的所有元素必须是相同类型的，或继承自相同的类型
    ///         秩/维度数：数组的维度数可以为任何正数。数组的维度数称为秩
    ///         维度长度：数组的每一个维度有长度，就是这个方向的位置个数
    ///         数组长度：数组的所有维度的元素总数称为数组的长度
    ///     13.1.2 重要细节
    ///         1.数组一旦创建，大小就固定了。C#不支持动态数组
    ///         2.数组的索引是从0开始的。如果维度长度是n,那么索引范围就是0~n-1
    /// 13.2 数组的类型
    ///     C#提供了两种类型的数组：一维数组、多维数组
    ///     1.一维数组：可以认为是单行元素或元素向量
    ///     2.多维数组：由主向量中的位置组成的，每一个位置本身又是一个数组，称为子数组。子数组向量中的位置本身又是一个子数组（嵌套）
    ///         2.1矩形数组（多维数组）：某个维度的所有子数组具有相同长度的多维数组
    ///                     不管多少个维度，总是使用一组方括号
    ///                     int x = myArray[4,6,1]; //三维数组，每个维度的长度都相同.
    ///         2.2交错数组（数组的数组）：每个子数组都是独立数组的多维数组
    ///                                  可以由不同长度的子数组
    /// 13.3 数组是对象
    ///     数组实例是从Sysytem.Array继承类型的对象。
    ///     由于数组从BCL基类派生，继承了BCL基类中的成员，如下：
    ///     Rank：返回数组维度数的属性     Length：返回数组长度的属性    etc
    ///     数组是引用类型；数组的元素既可以是值类型也可以是引用类型
    /// 13.4 一维数组和矩形数组
    ///     可以使用任意多个秩说明符
    ///     不能在数组类型区域中放数组维度长度。秩是数组类型的一部分，但是维度长度不是类型的一部分
    ///     数组声明后，维度数/秩 就是固定了；维度长度只有在数组实例化才会确定
    ///     与C、C++不同，C#的方括号在类型后面，C的方括号是在变量名称后
    ///         C：int number[10];   C++：int[] number;
    /// 13.5 实例化一维数组或矩形数组
    ///     实例化数组可以使用new关键字，示例：int[] arr = new int[4];
    ///                                    int[,,] mcArr = new int[3,6,2];
    /// 13.6 访问数组元素
    ///     在数组中使用整型值作为索引来访问数组元素
    ///     每个维度的索引从0开始
    /// 13.7 初始化数组
    ///     数组被创建后，每一个元素自动初始化为类型的默认值
    ///     整型：0    浮点型：0.0     布尔型：false   引用类型：null
    ///     13.7.1 显式初始化一维数组
    ///         初始值必须用逗号隔开，并封闭在一组大括号内
    ///         不必输入维度长度，编译器可以通过初始化值的个数来推断长度
    ///         int[] intArr = new int[]{10,20,30,40}；
    ///     13.7.2 显式初始化矩形数组
    ///         每一个初始值向量必须封闭在大括号内
    ///         每一个维度也必须嵌套并封闭在大括号内
    ///         除了初始值，每一个维度的初始化列表和组成部分也必须使用逗号分隔
    ///         int[,] intArr = new int[,]{{10,1},{2,10},{11,9}};
    ///     13.7.4 快捷语法
    ///         使用声明数组初始化创建时，可以省略语法的数组创建表达式部分
    ///         int[] arr = new int[3]{10,20,30};
    ///         int[] arr =           {10,20,30};   // 以上两种写法是等价的
    ///     13.7.5 隐式类型数组
    ///         可以使用Var关键字声明，等编译器根据初始化语句的类型推断数组类型
    ///     13.7.6 综合内容
    /// 13.8 交错数组
    ///     13.8.1 声明交错数组
    ///         交错数组声明要求每一个维度都有一对独立的方括号；方括号的数量决定了数组的秩
    ///         int[][] SomeArr; //秩为2      int[][][] SomeArr; //秩为3
    ///     13.8.2 快捷实例化
    ///         int[][] jagArr = new int[3][];  //3个子数组
    ///         int[][] jagArr = new int[3][4]; //编译错误；不能在声明语句中初始化顶层数组之外的数组
    ///     13.8.3 实例化交错数组
    ///         int[][] Arr = new int[3][]; //1.实例化顶层数组
    ///         Arr[0] = new int[]{10,20,30};   //2.实例化子数组
    ///         Arr[1] = new int[]{40,50,60,70};    //3.实例化子数组
    ///         Arr[2] = new int[]{80,90,100,110,120};  //4.实例化子数组
    ///     13.8.4 交错数组中的子数组
    ///         交错数组中的子数组本身就是数组，所以既可以是一维数组也可以是矩形数组
    /// 13.9 比较矩形数组和交错数组
    /// 13.10 foreach 语句
    ///     foreach 语句允许我们连续访问数组中的每一个元素
    ///         1.迭代变量是临时的，并且和数组中的元素是同一种类型
    ///         2.Type是数组中元素的类型；Identifier是迭代变量的名字；
    ///           ArrayName是要处理的数组名称；Statement是要为数组中每一个元素执行一次的单条语句或语句块
    ///         foreach(Type Identifier in ArrayName)   //显式类型迭代变量声明
    ///             Statement
    ///         foreach(Var Identifier in ArrayName)    //隐式类型迭代变量声明
    ///             Statement
    ///     13.10.1 迭代变量是只读的
    ///     13.10.2 foreach语句和多维数组
    /// 13.11 数组协变
    ///     值类型数组没有协变，只有引用类型
    ///     赋值的对象类型和数组基类型之间有隐式转换或显式转换
    /// 13.12 数组继承的有用成员    
    ///     派生自System.Array类
    ///     ——————————————————————————————————————————————————————————————————————————————————
    ///     成 员         类 型      生存期                             意义
    ///     ——————————————————————————————————————————————————————————————————————————————————
    ///     Rank          属性       实例          获取数组的维度数
    ///     Length        属性       实例          获取数组中所有维度的元素总数
    ///     GetLength     方法       实例          返回数组的指定维度的长度
    ///     Clear         方法       静态          将某一范围内的元素设置为0或null
    ///     Sort          方法       静态          在一维数组中对元素进行排序
    ///     BinarySearch  方法       静态          使用二进制搜索，搜索一维数组中的值(只能顺序查找)
    ///     Clone         方法       实例          进行数组的浅复制————对于值类型和引用类型数组，都只复制元素
    ///     IndexOf       方法       静态          返回一维数组中遇到的第一个值
    ///     Reverse       方法       静态          反转一维数组中某一范围内的元素
    ///     GetUpperBound 方法       实例          获取指定维度的上限
    ///     ——————————————————————————————————————————————————————————————————————————————————
    ///     注：BinarySearch不能对逆向排序的数组进行查找，不考虑性能的前提下，可以使用Array.FindIndex
    /// 13.13 比较数组类型
    ///     一维数组在CIL中有优化指令
    /// 13.14 数组与ref返回和ref局部变量
    /// </summary>
    public class LearnArray
    {
        static void Main(string[] args)
        {
            Console.WriteLine("######多维数组测试###################");
            int firstElement = rectangularArray[2,0];   //访问元素
            Console.WriteLine("矩形数组测试：{0}",firstElement);
            int firstElementInJagged = jaggedArray[0][0]; // 输出 1
            int thirdElementInSecondRow = jaggedArray[1][2]; // 输出 5
            Console.WriteLine("交错数组测试：{0}，{1}",firstElementInJagged,thirdElementInSecondRow);
            Console.WriteLine("####################################");
            Console.WriteLine("######13.7.6综合内容#################");
            var arr = new int[,] { {0, 1, 2}, {10, 11, 12} };
            for(int i = 0; i < 2; i++)
                for(int j = 0; j < 3; j++)
                    Console.WriteLine($"Element [{i},{j}] is {arr[i,j]}");           
            Console.WriteLine("####################################");
            Console.WriteLine("######交错数组中的子数组##############");
            int[][,] Arr = new int[3][,]; // 带有二维数组的交错数组并实例化
            Arr[0] = new int[,] { {10, 20},{100, 200} };
            Arr[1] = new int[,] { { 30, 40, 50 }, { 300, 400, 500 } };
            Arr[2] = new int[,] { { 60, 70, 80, 90 }, { 600, 700, 800, 900 } };
            for(int i = 0;i < Arr.GetLength(0);i++)
            {
                for(int j = 0;j < Arr[i].GetLength(0);j++)
                {
                    for (int k = 0; k < Arr[i].GetLength(1); k++)
                    {
                        Console.WriteLine($"[{i}][{j},{k}] = {Arr[i][j,k]}");
                    }
                }
            }
            Console.WriteLine("####################################");
            Console.WriteLine("######foreach迭代循环遍历数组#########");
            int[,] arrForeach = new int[,] { { 10,20,30},{ 20,30,40} };
            foreach(int x in arrForeach)
                Console.WriteLine($"Item Value:{x}");
            Console.WriteLine("####################################");
            Console.WriteLine("######数组协变#######################");
            A[] AArray1 = new A[3]; // 两个A[]类型的数组
            A[] AArray2 = new A[3];
            // 普通：将A类型的对象赋值给A类型的数组
            AArray1[0] = new A(); AArray1[1] = new A(); AArray1[2] = new A();
            // 协变：将B类型的对象赋值给A类型的数组
            AArray2[0] = new B(); AArray2[1] = new B(); AArray2[2] = new B();
            Console.WriteLine("####################################");
            Console.WriteLine("######数组继承的有用成员##############");
            int[] arrMethod = new int[] { 15, 20, 5, 25, 10 };
            PrintArray(arrMethod);
            // 在一维数组中对元素进行排序
            Array.Sort(arrMethod);
            PrintArray(arrMethod);
            // 反转一维数组中某一范围内的元素
            Array.Reverse(arrMethod);
            PrintArray(arrMethod);
            // Rank Length GetLength GetType
            Console.WriteLine($"Rank = {arrMethod.Rank}, Length = {arrMethod.Length}");
            Console.WriteLine($"GetLength(0) = {arrMethod.GetLength(0)}");
            Console.WriteLine($"GetType()    = {arrMethod.GetType()}");
            // 使用二进制搜索，搜索一维数组中的值
            // 注：数组必须是已经排序了的，且不能是逆向排序
            int index = Array.BinarySearch(arrMethod, 5);
            Console.WriteLine($"{index}");
            // clone方法:会产生两个独立数组；返回的是object类型的引用，必须进行强制转换
            // 克隆引用类型数组会产生指向相同对象的两个数组
            int[] arrMeehodClone = (int[])arrMethod.Clone();
            PrintArray(arrMeehodClone);
            Console.WriteLine("####################################"); 
            Console.WriteLine("######数组与ref返回和ref局部变量######");
            int[] scores = { 5, 80 };
            Console.WriteLine($"Beefore:{scores[0]},{scores[1]}");           
            ref int locationOfHigher = ref ArrayAndRef.PointerToHighestPositive(scores); // 静态方法不需要实例化类
            locationOfHigher = 0;
            Console.WriteLine($"After:{scores[0]},{scores[1]}");
            Console.WriteLine("####################################");

        }
        //矩形数组
        static int[,] rectangularArray = new int[3, 2]
        {
            {1, 2},
            {3, 4},
            {5, 6}
        };
        //交错数组
        static int[][] jaggedArray = new int[3][]
        {
            new int[2] {1, 2},
            new int[3] {3, 4, 5},
            new int[1] { 6 }
        };  
        public static void PrintArray(int[] a)
        {
            foreach (int x in a) Console.Write($"{x} ");
            Console.WriteLine("");
        }
    }
    // 数组协变
    class A { }
    class B : A { }
    // 数组与ref返回和ref局部变量
    class ArrayAndRef
    {
        public static ref int PointerToHighestPositive(int[] numbers)   // 最大正数
        {
            int highest = 0;
            int indexOfHighests = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > highest)
                {
                    indexOfHighests = i;
                    highest = numbers[indexOfHighests];
                }
            }
            return ref numbers[indexOfHighests];
        }
    }
}
