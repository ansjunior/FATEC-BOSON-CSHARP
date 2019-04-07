using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Variaveis
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 90;
            bool a = false;
            int y;
            y = x;

            Console.WriteLine("O número é " + x.ToString());
            Console.WriteLine($"E o valor lógico é: {a}");
            Console.WriteLine($"O número é: {y}");
        }
    }
}
