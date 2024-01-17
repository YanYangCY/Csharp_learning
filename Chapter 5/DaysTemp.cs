using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter_5
{
    class DaysTemp  
    {
        public int High, Low;   //成员变量
        public int Average()    //成员方法
        {
            return (High + Low) / 2;    //返回平均值
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DaysTemp t1 = new DaysTemp();
            DaysTemp t2 = new DaysTemp();

            t1.High = 76;   t1.Low = 57;
            t2.High = 75;   t2.Low = 53;

            Console.WriteLine("t1: {0} {1} - AVE: {2}", t1.High, t1.Low, t1.Average());
            Console.WriteLine("t2: {0} {1} - AVE: {2}", t2.High, t2.Low, t2.Average());
        }
    }
}
