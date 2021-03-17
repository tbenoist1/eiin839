using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soap
{
    class Program
    {
        static void Main(string[] args)
        {
            MathsOperations.MathsOperationsClient c = new MathsOperations.MathsOperationsClient();
            Console.WriteLine(c.Add(14, 72));
            Console.ReadLine();
        }
    }
}
