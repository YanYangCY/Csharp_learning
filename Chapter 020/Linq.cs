using System;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Chapter_020
{
    /// <summary>
    /// 20.1 什么是LINQ
    ///     用于查询集合（如数组、列表、数据库等）的一组语言特性和API。它允许你使用类似SQL的语法来查询和操作这些数据集合。
    ///     重要高级特性：
    ///     1.LINQ代表 语言集成查询(Language Integrated Query)
    ///     2.LINQ是.NET框架的扩展，允许我们使用SQL查询数据库的类似方法来查询数据集合
    ///     3.使用LINQ，你可以从数据库、对象集合以及XML文档中查询数据
    /// 20.2 LINQ提供程序
    ///     LINQ可以查询各种类型的数据源，例如SQL数据库、XML文档 等等。
    ///     对于每一种数据源类型，一定有根据有根据该数据源类型实现LINQ查询的代码模块；这些代码模块叫作 LINQ提供程序（provider）
    ///     1.微软为常见的数据源类型提供了LINQ提供程序：Object、XML、SQL、Datasets。。。
    ///     3.第三方提供针对数据源的LINQ提供程序
    ///     ※匿名类型组成：new关键字、对象初始化语句；（对象初始化语句在一组大括号内包含了以逗号分隔的成员初始化语句列表）
    ///       匿名类型只能用于局部变量，不能用于类成员
    ///       由于匿名类型没有名字，必须使用var关键字作为变量类型
    ///       不能设置匿名类型对象的属性，编译器为匿名类型创建的属性是只读的
    ///       1.处理对象初始化语句的赋值形式，匿名类型的对象初始化语句还有两种形式：简单标识符、成员访问表达式（这两种叫作投影初始化语句）
    /// 20.3 方法语法和查询语法（编译器会将查询语法翻译为方法调用的形式，但两种没有性能上的差异）
    ///     1.查询语法：是声明式的，也就是查询描述的是你想返回的东西，但并没有指明如何执行这个查询。
    ///     2.方法语法：是命令式的，指明了查询方法调用的顺序
    /// 20.4 查询变量
    ///     LINQ查询可以返回两种类型的结果：枚举、标量
    ///     等号左边的变量叫查询变量
    ///     查询执行时间的差异总结：
    ///     1.如果查询表达式返回枚举，则查询一直到处理枚举时才会执行
    ///     2.如果枚举被处理多次，查询就会执行多次
    ///     3.如果在进行遍历之后、查询执行之前数据有改动，则查询会使用新的数据
    ///     4.如果查询表达式返回标量，查询立即执行，并且把结果保存在查询变量中
    /// 20.5 查询表达式的结构
    ///     查询表达式由from子句和查询主体组成
    ///     1.子句必须按照一定的顺序出现
    ///     2.from子句和select...group子句这两部分是必需的
    ///     3.其他子句是可选的
    ///     4.在LINQ查询表达式中，select子句在表达式最后
    ///     5.可以有任意多的from...let...where子句
    ///     20.5.1 from 子句    
    ///         指定了要作为数据源使用的数据集合，迭代变量逐个表示数据源的每一个元素
    ///         from Type Item in Items //Type Item为迭代变量声明
    ///     20.5.2 join子句
    ///         主要用于关联多个数据源，允许根据指定的键，将两个或多个集合中的元素进行匹配
    ///         join  Identifier in Collection2 on Field1 equals Field2
    ///     20.5.3 什么是联结
    ///         LINQ中的join接受两个集合，然后创建一个新的集合，其中每一个元素包含两个原始集合中的元素成员
    ///         正常的联结产生的结果是两个集合的元素之积
    ///     20.5.4 查询主体中的from...let...where片段
    ///         1.from子句:查询表达式必须从from子句开始，后面跟的是查询主体
    ///             var someInts = from a in groupA // 必需的第一个from子句
    ///                            from b in groupB // 查询主体的第一个子句
    ///                            where a > 4 && b < 5
    ///                            select new {a, b, sum = a + b}; // 匿名类型对象
    ///         2.let子句：接受一个表达式的运算并且把他赋值给一个需要在其他运算中使用的标识符
    ///             var someInts = from a in groupA 
    ///                            from b in groupB 
    ///                            let sum = a + b // 在新的变量中保存结果
    ///                            where sum == 12
    ///                            select new {a, b , sum};
    ///         3.where子句：根据之后的运算去除不符合指定条件的项
    ///             查询表达式可以有任意多个where子句
    ///             一个项必须满足所有where子句才能避免被去除
    ///             var someInts = from a in groupA 
    ///                            from b in groupB 
    ///                            let sum = a + b 
    ///                            where sum >= 12  // 条件1
    ///                            where a == 4     // 条件2
    ///                            select new {a, b, sum};
    ///     20.5.5 orderby子句：接受一个表达式并根据表达式按顺序返回结果项
    ///         例：orderby Expression ascending/descending
    ///         表达式通常是项的一个字段，字段不一定非得是数值字段，也可以是字符串这样的可排序类型
    ///         默认升序，可选ascending/descending关键字可以设置排序为升序或降序
    ///         Expression表达式可以是多个排序条件
    ///     20.5.6 select...group子句：由两种类型子句组成---select子句和group...by子句
    ///         1.select子句指定应该选择所选对象的哪些部分，可以是：整个数据项、数据项中的一个字段、数据项中几个字段组成的新对象
    ///         2.group...by子句是可选的，用来指定选择的项如何被分组
    ///     20.5.7 查询中的匿名类型：查询结果可以由原始集合的项、原始集合中项的字段或匿名类型组成
    ///         字段以逗号隔开，并以大括号包围来创建匿名类型
    ///     20.5.8 group子句
    ///         1.如果项包含在查询的结果中，它们就可以根据某个字段的值进行分组。作为分组依据的属性叫作 键(key)
    ///         2.group子句返回的不是原始数据源中项的枚举，而是返回可以枚举已经形成项的分组的可枚举类型
    ///         3.分组本身是可枚举类型，它们可以枚举实际的项
    ///     20.5.9 查询延续：into子句
    ///         可以接受查询的一部分的结果并赋予一个名字，从而可以在查询的另一部分中使用
    ///         var someInts = from a in groupA 
    ///                        join b in groupB on a equals b
    ///                        into groupAandB // 查询延续
    ///                        from c in groupAandB
    ///                        select c;
    /// 20.6 标准查询运算符
    ///     由一系列API方法组成，API能让我们查询任何.NET数组或集合。
    ///     1.标准查询运算符使用方法语法
    ///     2.一些运算符返回Ienumerable对象，而其他运算符返回标量。返回标量的运算符立即执行查询并返回一个值，而不是可枚举类型。
    ///     3.很多操作都是以一个谓词作为参数。谓词是一个方法，它以对象为参数，根据对象是否满足某个条件而返回true或false
    ///       被查询的集合对象叫作序列，它必须实现IEnumerable<T>接口，其中T为类型，包括List<>、Dictionary<>、Array等
    ///     20.6.1 标准查询运算符的签名
    ///         System.Linq.Enumerable类声明了标准查询运算符方法。
    ///         方法语法的调用和扩展语法的调用在语义上是完全相等的，只是语法不同
    ///             var count1 = Enumerable.Count(intArray);    //方法语法
    ///             var count2 = intArray.Count();  //扩展语法
    ///     20.6.2 查询表达式和标准查询运算符
    ///         查询表达式可以使用带有标准查询运算符的方法语法来编写
    ///         两种方式组合：
    ///         int howMany = (from n in nubmers
    ///                        where n < 7 
    ///                        select n).Count();
    ///     20.6.3 将委托作为参数
    ///     20.6.4 LINQ预定义的委托类型    
    ///         .NET框架定义了两套泛型委托类型来用于标准查询运算符，即 Func委托和Action委托，各19个成员
    ///     20.6.5 使用委托参数的示例
    ///     20.6.6 使用Lambda表达式参数的示例    
    /// 20.7 LINQ to XML
    ///     可扩展标记语言XML是存储和交换数据的重要方法。
    ///     20.7.1 标记语言
    ///         标记语言是文档中的一组标签
    ///     20.7.2 XML基础
    ///         XML文档中的数据包含在一个XML树中，XML树主要由嵌套元素组成
    ///         元素是XML树的基本要素，每一个元素都有名字并且包含数据，一些元素还可以包含其他嵌套元素
    ///         元素由开始和关闭标签进行划分<PhoneNumber> </PhoneNumber>
    ///         没有内容的元素可以由单个标签构成<PhoneNumber />
    ///         1.XML文档必须有一个根元素来包含所有其他元素
    ///         2.XML标签必须合理嵌套
    ///         3.与HTML标签不同，XML标签是区分大小写的
    ///         4.XML的特性是名/值对，它包含了元素的其他元数据；特性的值部分必须包含在引号内（单引号或双引号）
    ///         5.XML文档中的空格是有效的
    ///     20.7.3 XML类
    ///         LINQ to XML可以以两种方式用于XML：第一种是简化的XML操作API；第二种是LINQ查询工具
    ///         LINQ to XMLAPI由很多表示XML树组件的类组成，最重要的3个类：XElement、XAttribute、XDocument
    ///         1.创建、保存、加载和显式XML文档
    ///             using System.Xml.Linq;
    ///         2.创建XML树
    ///         3.使用XML树的值    
    ///             获取数据的主要方法：Nodes、Elements、Element、Descendants...
    ///         4.增加节点以及操作XML
    ///             可以使用Add方法为现有元素增加子元素,还有删除、设置等功能
    ///             Add\AddFirst、Remove、RemoveNodes...
    ///     20.7.4 使用XML特性
    ///         XAttribute主要用于表示 XML 元素的属性。通过XAttribute，可以方便地创建、读取和操作 XML 文档中的元素属性。
    /// 
    /// 
    /// 
    /// </summary>
    public class Linq
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("######简单使用LINQ示例###############");
            int[] numbers = { 1, 2, 15, 16 };   // 数据源
            IEnumerable<int> lowNums = from n in numbers // 定义并存储查询
                                       where n < 10 
                                       select n; 
            foreach (int n in lowNums)  // 执行查询
                Console.Write($"{n}, ");
            Console.WriteLine();
            Console.WriteLine("####################################");
            Console.WriteLine("######创建匿名类型###################");
            var student = new { Name = "JACK", Age = 18, Major = "History" }; // 前面变量必须使用var，后面大括号里面是匿名对象初始化语句
            Console.WriteLine($"{student.Name}，Age：{student.Age}， Major：{student.Major}");
            Console.WriteLine("####################################");
            Console.WriteLine("######方法语法和查询语法##############");
            int[] numbers2 = { 2, 5, 28, 31, 17, 16, 42 };   // 数据源
            var numsQuery = from n in numbers2 // 查询语法
                            where n < 20 
                            select n;    
            var numsMethod = numbers2.Where(N => N < 20);   // 方法语法
            int numsCount = (from n in numbers2 // 两种形式的组合，返回一个整数
                             where n<20 
                             select n).Count();
            foreach (int n in numsQuery)  // 执行查询
                Console.Write($"{n}, ");
            Console.WriteLine();
            foreach (int n in numsMethod)  // 执行查询
                Console.Write($"{n}, ");
            Console.WriteLine();
            Console.WriteLine(numsCount);
            Console.WriteLine("####################################");
            Console.WriteLine("######join子句######################");
            var students = new List<Student>()
            {
                new Student{ StudentId = 1, StudentName = "Alice"},
                new Student{ StudentId = 2, StudentName = "Bob"}
            };
            var courses = new List<Course>()
            {
                new Course { CourseId = 101, CourseName = "Math", StudentId = 1 },
                new Course { CourseId = 102, CourseName = "English", StudentId = 1 },
                new Course { CourseId = 103, CourseName = "Physics", StudentId = 2 }
            };
            var joinedQuery = from student1 in students
                              join course in courses on student1.StudentId equals course.StudentId
                              select new { student1.StudentName, course.CourseName, course.CourseId};  
            foreach(var s in joinedQuery)
                Console.WriteLine(s);
            Console.WriteLine("####################################");
            Console.WriteLine("######使用委托参数的示例##############");
            static bool IsOdd(int x)    // 委托对象使用的方法
            {
                return x % 2 == 1; // 如果奇数返回true
            }
            int[] intArray = new int[] { 3, 4, 5, 6, 7, 8, 9 };
            Func<int, bool> myDel = new Func<int, bool>(IsOdd); // 委托对象
            //Func<int, bool> myDel = delegate(int x) { return x % 2 == 1; }; // 等价匿名方法
            var countodd = intArray.Count(myDel);
            Console.WriteLine($"Count of odd numbers : {countodd}");
            Console.WriteLine("####################################");
            Console.WriteLine("######使用Lambda表达式参数的示例######");
            var countodd2 = intArray.Count(x => x % 2 == 0);
            Console.WriteLine($"Count of odd numbers : {countodd2}");
            Console.WriteLine("####################################");
            Console.WriteLine("######创建XML文档示例################");
            XDocument employees1 = 
                new XDocument(                  // 创建XML文档
                    new XElement("Employees",   // 创建根元素
                        new XElement("Employee",    // 第一个employee元素
                            new XElement("Name","Bob Smith"),   // 创建元素
                            new XElement("PhoneNumber","408-555-1000")),
                        new XElement("Employee",    // 第二个employee元素
                            new XElement("Name","Sally Jones"), // 创建元素
                            new XElement("PhoneNumber","408-555-2000"),
                            new XElement("PhoneNumber", "408-555-2001"))
                    )
                );
            employees1.Save("EmployeesFile.xml");   // 保存到文件
            // 将保存的文档加载到新变量中
            XDocument employees2 = XDocument.Load("EmployeesFile.xml");  // XDocument.Load是静态方法
            Console.WriteLine(employees2);   // 显式文档
            Console.WriteLine("####################################");
            Console.WriteLine("######获取XML值数据方法使用示例#######");
            XElement root = employees2.Element("Employees");
            IEnumerable<XElement> employees = root.Elements();
            foreach (XElement emp in employees)
            {
                XElement empNameNode = emp.Element("Name");
                Console.WriteLine(empNameNode.Value);
            }
            Console.WriteLine("####################################");
            Console.WriteLine("######获取XML值数据并增加元素#########");
            XElement rt = employees1.Element("Employees");
            rt.Add(new XElement("Second"));
            Console.WriteLine(employees1);
            Console.WriteLine("####################################");
        } // end Main
    } // end Class Linq
    #region join 子句示例
    class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
    }
    class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int StudentId { get; set; }
    }
    #endregion

    #region XML 示例
    /*
    <Employees>
        <Employee>
            <Name>Bob Smith </Name>
            <PhoneNumber>408-555-1000</PhoneNumber>
            <CellPhone />
        </Employee>
        <Employee>
            <Name>Sally Jone </Name>
            <PhoneNumber>408-555-2000</PhoneNumber>
            <PhoneNumber>408-555-2001</PhoneNumber>
        </Employee>
    </Employees>
    */
    #endregion
}