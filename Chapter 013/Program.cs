namespace Chapter_013
{
    /// <summary>
    /// 13.1 数组
    ///     数组实际上是由一个变量名称表示的一组同类型的数据元素。每个元素通过变量名称和方括号中的一个或多个索引进行访问
    ///     13.1.1 定义
    ///         元素：数组的独立数据项称为元素。数组的所有元素必须是相同类型的，或继承自相同的类型
    ///         秩/维度：数组的维度数可以为任何正数。数组的维度数称为秩
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
    /// 
    /// 
    /// 
    /// 
    /// 
    /// 
    /// </summary>
    public class Program
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
            new int[1] {6}
        };
    }
}
