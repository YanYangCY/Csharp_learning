using System;

namespace ClassGm
{
    /// <summary>
    /// 类成员-数据成员、函数成员
    /// 成员修饰符的顺序
    /// 实例类成员：各实例之间属于副本，互不影响
    /// 静态字段：类中的静态字段被类的所有实例共享，所有实例访问同一个内存位置。(访问静态变量只能使用类名)
    /// C#中没有全局常量
    /// 属性与字段类似，但是属性是函数成员，本质上是一个方法（属性是一组2个匹配的、命名的、称为访问器的方法）（set、get除了这两个访问器，属性不允许拥有其他方法）
    /// 属性会自动隐式调用，显式调用访问器会编译错误；个人理解为就是字段(成员变量)，不过就是另类的成员
    /// 属性正常会和私有字段联合使用
    /// C#6.0版本开始提供自动实现属性，不需要对字段赋值，int类型默认0，bool类型默认false,引用类型默认null；
    /// </summary>
    class ClassGm
    {
        static void Main(string[] args)
        {
            //实例字段和静态字段
            var D1 = new D();
            var D2 = new D();
            D1.Mem1 = 10;
            D2.Mem1 = 20;
            Console.WriteLine($"D1.Mem1 = {D1.Mem1}, D2.Mem1 = {D2.Mem1}");
            D.Mem2 = 30;
            Console.WriteLine($"{D.Mem2}");
            

            //静态字段的示例
            var E1 = new E();
            var E2 = new E();
            E1.SetVars(3, 4);
            E1.Display("E1");
            E2.SetVars(5, 6);
            E2.Display("E2");
            //这里的Mem4静态成员的值已经发生改变
            E1.Display("E1");

            //赋值，隐式调用set方法
            D1.MyValue = 10;
            //表达式，隐式调用get方法
            var YY = D1.MyValue;
            Console.WriteLine($"属性的使用：{YY}");

            //访问属性
            Console.WriteLine($"把属性当成字段使用：{D1.MyRealValue}");
            D1.MyRealValue = 101;
            Console.WriteLine($"赋值属性的值后：{D1.MyRealValue}");

            //访问静态属性
            Console.WriteLine($"类不需要实例化也可以访问：{D.MyStaticValue}");
            D.MyStaticValue = 10;
            Console.WriteLine($"静态属性赋值后，输出：{D.MyStaticValue}");

        }


    }

    class D
    {
        public int Mem1 = 1;
        public static int Mem2 = 2;
        public int MyValue  //创建公有属性，默认是私有
        {  get; set; }

        private int _theRealValue = 99; //创建私有字段
        public int MyRealValue  //创建公有属性去访问私有字段
        {
            set { _theRealValue = 100; }    //这个地方的100也可以设置为字段
            get { return _theRealValue; } 
        }
        //创建静态属性
        public static int MyStaticValue
        {  get; set; }
    }
    class E
    {
        int Mem3;
        static int Mem4;
        public void SetVars(int v1, int v2) //通过这种方式可以像访问实例字段一样访问静态字段
        {
            Mem3 = v1;
            Mem4 = v2;
        }
        public void Display(string str)
        {
            Console.WriteLine($"{str}: Mem3 = {Mem3}, Mem4 = {Mem4}");
        }
    }
}