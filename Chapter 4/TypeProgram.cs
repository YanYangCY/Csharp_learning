using System;


namespace Chapter4
{
    /// <summary>
    /// 1.与C和C++不同，C#中的数值类型不具有布尔意义
    /// 2.预定义类型(16)：简单类型（数值、非数值）、object、string、dynamic
    /// 3.自定义类型(6)：类（class）、结构（struct）、数组（array）、枚举（enum）、委托（delegate）、接口（interface）
    /// 4.预定义只需要实例化、自定义的需要声明和实例化
    /// 5.※4-8中的内存存放位置还有疑问，后面再看
    /// 6.局部变量需要初始化后才能使用，类字段、结构字段、数组元素是可以自动初始化的
    /// </summary>
    class Chapter4
    {
        static void Main()
        {
            Console.WriteLine("{0}", GlobalVariables.GlobalVariable);//调用静态类的静态成员
        }
    }
    /// <summary>
    /// 通过静态类和静态成员实现全局变量的效果
    /// 尽可能将数据封装到类的实例中，通过对象的方式进行操作和访问
    /// </summary>
    public static class GlobalVariables
    {
        public static int GlobalVariable = 10;
    }
}