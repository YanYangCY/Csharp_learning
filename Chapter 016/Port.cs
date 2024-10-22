namespace Chapter_016
{
    /// <summary>
    /// 16.1 什么是接口
    /// 
    /// </summary>
    public class Port
    {
        static void PrintInfo(CA item)
        {
            Console.WriteLine($"Name:{item.Name},Age:{item.Age}!");
        }
        public static void Main(string[] args)
        {
            CA item = new CA() { Name ="YY" , Age = 26 };
            PrintInfo(item);
        }
    }
    class  CA
    {
        public string Name;
        public int Age;
    }
    class CB
    {
        public string First;
        public string Last;
        public double PersonsAge;
    }
}