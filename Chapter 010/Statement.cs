namespace Chapter_10
{
    /// <summary>
    /// 10.1 什么是语句
    ///     1.声明语句：声明类型或变量
    ///     2.嵌入语句：执行动作或管理控制流
    ///     3.标签语句：控制跳转
    /// 10.2 表达式语句
    /// 10.3 控制流语句
    ///     1.条件执行依据一个条件执行或跳过一个代码片段。条件执行语句如下：
    ///         if
    ///         if...else
    ///         switch
    ///     2.循环语句重复执行一个代码片段。循环语句如下：
    ///         while
    ///         do
    ///         for
    ///         foreach
    ///     3.跳转语句把控制流从一个代码片段改变到另一个代码片段中的指定语句。跳转语句如下：
    ///         break
    ///         continue
    ///         return
    ///         goto
    ///         throw
    /// 10.4 if语句
    ///     if(TestExpr) Statement  //TestExpr必须计算成bool型值；如果TestExpr求值为true，执行Statement；如果求值为false，则跳过Statement
    /// 10.5 if...else语句
    ///     if(TestExpr) Statement1 else Statement2  //TestExpr必须计算成bool型值；如果TestExpr求值为true，执行Statement1；如果求值为false，则执行Statement2
    /// 10.6 while循环
    ///     while(TestExpr) Statement   //如果TestExpr求值为true，执行Statement；如果求值为false，则执行while循环结束之后的语句
    /// 10.7 do循环
    ///     do statement while(TestExpr);   //先执行statement；在对TestExpr求值，如果是true，继续执行statement；如果返回false，则执行while循环结束之后的语句
    ///     do循环的特征是循环体statement至少执行一次；在测试表达式的关闭圆括号之后需要以分号结束
    /// 10.8 for循环
    ///     for(Initializer;TestExpr;IterationExpr) statement
    ///     //循环开始执行一次Initializer；
    ///     //对TestExpr求值，如果返回true执行statement，接着执行IterationExpr，然后继续对TestExpr求值；
    ///     //一旦TestExpr返回false，就继续执行statement之后的语句
    ///     //Initializer、TestExpr、IterationExpr都是可选的，它们的位置可以空着；如果TestExpr位置是空着，就会返回true，就会陷入死循环
    ///     10.8.1 for语句中变量的作用域
    ///         例如for(int i = 0;i<10;i++)这里的i是在循环体内部声明的，所以只能在for语句内部使用
    ///     10.8.2 初始化和迭代表达式中的多表达式
    ///         例：for(int i = 0, j =10; i < 5; i++, j += 10)    //可以包含多个表达式，只需要用逗号隔开
    /// 10.9 switch语句
    ///     switch中的参数通常被称为测试表达式或匹配表达式；必须是以下数据类型：char、string、bool、integer、enum（C#7.0开始允许测试表达式为任何类型）
    ///     switch语句包含0个或多个分支块
    ///     每个分支块以一个或多个分支标签开头(见测试代码)，每个分支标签后面跟着一个模式表达式
    ///     goto跳转语句不能和非常量switch表达式一起使用
    ///     10.9.2 其他类型的模式表达式
    ///     10.9.3 switch语句的补充    
    ///         switch语句可以有任意数目的分支，也可以没有分支
    /// 10.10 跳转语句
    ///     break、continue、return、goto、throw
    /// 10.11 break语句    
    ///     可在switch、for、foreach、while、do语句类型中使用
    ///     break可以在这些语句中跳出"最内层封装语句"
    /// 10.12 continue语句
    ///     可以在while、do、for、foreach中执行转到循环的最内层封装语句的顶端
    /// 10.13 标签语句
    ///     在C#中，标签语句（Label Statement）的主要作用是提供一个目标点，该目标点可以被goto语句引用以改变程序的正常执行流程。
    /// 10.14 goto语句
    ///     goto语句无条件地将控制转移到一个标签语句
    ///     goto语句也可以在switch语句内部使用去转移到对应标签
    /// 10.15 using语句（比较高级，暂时不了解）
    ///     using语句不同于using指令
    ///     只有那些实现了IDisposable接口，并且在其Dispose方法中执行了非托管资源释放逻辑的对象，才应该被放在using语句中。
    ///     对于那些仅仅占用托管资源的对象（即由.NET垃圾回收器自动管理的资源），则不需要显式地使用using语句。
    ///     例：  using (Font font1 = new Font("Arial", 10.0f))
    ///           { // 使用font1对象  }   // font1对象超出了using块的作用域，因此它会被自动释放
    ///     10.15.1 包装资源的使用
    ///     10.15.2 using语句的示例
    ///     10.15.3 多个资源和嵌套
    ///     10.15.4 using语句的另一种形式
    /// 10.16 其他语句
    ///     ————————————————————————————————————————————————————————————————————
    ///         语 句                 描   述                       相关章节
    ///     ————————————————————————————————————————————————————————————————————
    ///     checked、unchecked       控制溢出检查上下文               第17章
    ///     foreach                  遍历一个集合的每个成员           第13、19章
    ///     try、throw、finally      处理异常                        第23章
    ///     return                   将控制返回到调用函数的成员，并返回值     第6章
    ///     yield                    用于迭代                        第19章
    ///     ————————————————————————————————————————————————————————————————————
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("######switch语句功能测试#############");
            for (int i = 0; i < 10; i++)
            {
                switch(i)
                {
                    case 3:
                        Console.WriteLine($"I is {i} --In case 3");
                        break;
                    case 7:
                    case 9:
                        Console.WriteLine($"I is {i} --In case 7,9");
                        break;
                    default:
                        Console.WriteLine($"I is {i} --In default case!");
                        break;
                }
            }
            Console.WriteLine("####################################");
            Console.WriteLine("######continue语句功能测试###########");
            for(int i = 0;i < 5;i++)    // 执行5次循环
            {
                if(i < 3)   // 执行3次
                    continue;   // 直接跳过下面的输出语句，回到循环开始处
                // 当x≥3时执行下面的语句
                Console.WriteLine($"Value of i is {i}");
            }
            Console.WriteLine("####################################");
            Console.WriteLine("######标签语句功能测试###############");
            bool shouldBreak = false;   // 如果不设置bool变量，这里的goto会造成死循环
            outerLoop: // 标签定义
            for (int i = 0; i < 5 && !shouldBreak; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == 3 && j == 3)
                    {
                        // 当i和j都等于5时，使用goto跳转到标签处
                        shouldBreak = true;
                        goto outerLoop; // 这将跳过当前迭代的剩余部分，并继续外层循环的下一个迭代
                    }
                    Console.WriteLine($"i = {i}, j = {j}");
                }
                // 注意：由于goto语句，当i和j都等于3时，内层循环的剩余部分将不会被执行
            }
            Console.WriteLine("####################################");

        }
    }
}
