using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operadores___atrinuicao__incremento_e_decremento
{
    class Program
    {
        static void Main(string[] args)
        {
            // Operadores de atribuição
            // =, +=, -=. *=, /=

            int var01 = 50;

            Console.WriteLine("Atribuição: {0}", var01);
            var01 += 20;
            Console.WriteLine("Acumulando: {0}", var01);
            var01 -= 20;
            Console.WriteLine("Subtraindo: {0}", var01);
            var01 *= 2;
            Console.WriteLine("Multiplicando: {0}", var01);


            // Operadores de incremento e decremento

            // Incremento e decremento pré-fixos:
            // ++variável  |  variável = variável + 1 | variável += 1
            // --variável  |  variável = variável -1  | variável -= 1

            // Incremento e decremento pós-fixos:
            // variável++ |  variável = variável + 1 | variável += 1
            // variável-- |  variável = variável -1  | variável -= 1

            int contador = 50;
            Console.WriteLine(contador);
            Console.WriteLine(contador++);
            Console.WriteLine(contador);
            Console.WriteLine(++contador);

        }
    }
}
