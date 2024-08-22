using System;
using System.Runtime.CompilerServices;

namespace ClassInherit
{
    /// <summary>
    /// 8.1 类继承
    ///     类继承是面向对象编程的核心概念之一。
    ///     它允许你创建一个新的类，这个新类（派生类或子类）可以继承一个已有类（基类或父类）的成员（字段、属性、方法等）。
    ///     这样可以重用已有类的代码，并且允许在派生类中扩展或修改功能。
    /// 8.2 访问继承的成员
    /// 8.3 所有类都派生自object类
    ///     除了特殊的类object，所有的类都隐式的派生自object类
    /// 8.4 屏蔽基类的成员
    ///     使用new修饰符
    ///     要屏蔽一个继承的数据成员，需要声明一个新的相同类型的成员，并使用相同的名称
    /// 8.5 基类访问
    ///     如果派生类必须访问被隐藏的继承成员，可以使用基类访问表达式
    ///     使用关键字base后面跟一个点和成员的名称组成
    /// 8.6 使用基类的引用
    ///     如果有一个派生类对象的引用，就可以获取该对象基类部分的引用(使用类型转换运算符把该引用类型转换为基类类型)
    ///     派生类对象强制转换为基类对象的作用是产生的变量只能访问基类的成员
    ///     8.6.1 虚方法和覆写方法
    ///         虚方法可以使基类的引用访问"升至"派生类内
    ///         virtual 关键字用于基类中，声明虚方法，允许派生类重写该方法
    ///         override 关键字用于派生类中，重写基类中的虚方法，提供特定于派生类的实现
    ///         覆写和被覆写的方法必须与相同的可访问性，不能覆写static方法或非虚方法
    ///     8.6.2 覆写标记为override的方法
    ///         覆写方法可以在继承的任何层次出现
    ///         方法的调用会调用派生层次上到最高派生的版本
    ///     8.6.3 覆写其他成员类型
    /// 8.7 构造函数的执行
    ///     继承层次链中的每个类在执行它自己的构造函数体之前执行它的基类构造函数
    ///     ※ 不建议在构造函数中调用虚方法
    ///     构造函数是一个特殊的方法，其名称与类名相同，没有返回类型，用来初始化新创建的对象
    ///     初始化语句可以在构造函数的主体中执行，也可以在构造函数的声明中使用初始化器来完成
    ///     1.在构造函数主体中初始化 2.使用初始化器 3.初始化列表
    ///     8.7.1 构造函数初始化语句
    ///         由于构造函数可以重载，所有如果派生类使用一个指定的基类构造函数而不是无参数构造函数，必须在构造函数初始化语句中指定
    ///         1.使用关键字base并指明使用哪一个基类构造函数
    ///         2.使用关键字this并指明应该使用当前类的哪一个构造函数
    ///     8.7.2 类访问修饰符
    ///         类的可访问性有两个级别：public和internal
    ///         public的类可以被系统内任何程序集中的代码访问
    ///         internal的类只能被它自己所在的程序集内的类看到
    /// 8.8 程序集间的继承
    ///     要在不同程序集中定义的基类派生类，必须具备
    ///     1.基类必须声明为public
    ///     2.必须在VS工程中的References节点中添加对包含该基类的程序集的引用
    /// 8.9 成员访问修饰符///////////////(未细看)
    ///     -public -private -protected -internal -protected internal
    /// 8.10 抽象成员
    ///     抽象成员是指设计为被覆写的函数成员
    ///     1.必须是一个函数成员，字段和常量不能为抽象成员
    ///     2.必须用abstract修饰符标记
    ///     3.不能有实现代码块，用分号表示
    ///     4.抽象成员只能在抽象类中声明
    ///     5.抽象成员有方法、属性、事件、索引器
    ///     6.抽象成员必须被覆写
    /// 8.11 抽象类
    ///     抽象类是指设计为被继承的类，抽象类只能被用作其他类的基类
    ///     1.不能创建抽象类的实例
    ///     2.抽象类使用abstract修饰符声明
    ///     3.抽象类可以包含抽象成员和普通的非抽象成员
    ///     4.抽象类自己可以派生自另一个抽象类
    ///     5.任何派生自抽象类的类必须使用override关键字实现该类的所有的抽象成员，除非派生类自己也是抽象类
    /// 8.12 密封类
    ///     密封类和抽象类相反，密封类只能被用作独立的类，不能被用作基类
    ///     密封类使用sealed修饰符标注
    /// 8.13 静态类
    ///     静态类中所有成员都是静态的
    ///     常见用途：创建一个包含一组数学方法和值的数学库
    ///     1.类本身必须标记为static
    ///     2.类的所有成员必须是静态的
    ///     3.类可以有一个静态构造函数，但不能有实例构造函数，因为不能创建该类的实例
    ///     4.静态类是隐式密封的，不能继承静态类
    ///     5.可以使用类名和成员名访问静态类的成员；C#6.0开始也可以使用using static来访问
    /// 8.14 扩展方法
    ///     ExtendMyData.Average(md)    //静态调用形式
    ///     md.Average();               //实例调用形式
    /// 8.15 命名约定
    ///</summary>
    ///
    class ClassInterit
    {
        static void Main(string[] args)
        {
            //创建一个Dog对象
            Dog myDog = new Dog();
            myDog.Name = "Buddy";
            myDog.Breed = "Golden Retriever";
            //调用基类的方法
            myDog.Eat();
            myDog.Sleep();
            //调用派生类的方法
            myDog.Bark();
            //输出属性值
            Console.WriteLine($"Name:{myDog.Name},Breed:{myDog.Breed}");
            //使用初始化器语法在构造函数的声明中初始化对象的字段或属性
            Person  myPerson = new Person("YY",27);
        }
    }
    // 定义一个基类
    public class Animal
    {
        // 基类的字段
        public string Name { get; set; }
        // 基类的方法
        public void Eat()
        {
            Console.WriteLine($"{Name} is eating.");
        }
        // 基类的方法
        public void Sleep()
        {
            Console.WriteLine($"{Name} is sleeping.");
        }
    }
    // 定义一个派生类
    public class Dog : Animal
    {
        // 派生类的字段
        public string Breed { get; set; }
        // 派生类的方法
        public void Bark()
        {
            Console.WriteLine($"{Name} is barking.");
        }
        /*可以屏蔽基类中的Sleep方法
        new public void Sleep()
        {
            Console.WriteLine($"New {Name} is sleeping.");
        }
        */
    }
    public class Person
    {
        public string Name;
        public int Age;

        // 构造函数
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}//END namespace