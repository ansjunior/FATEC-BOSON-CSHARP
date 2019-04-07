using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperadoresLogicos
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Testando !:
            Console.WriteLine("Testando o operador '!'");
            bool valorLogico;
            valorLogico = true; // Mude para false
            Console.WriteLine("Valor do operador lógico antes da conversão: {0}", valorLogico.ToString());
            valorLogico = !valorLogico; // Invertendo valor
            Console.WriteLine("Valor do operador lógico depois da conversão: {0}", valorLogico.ToString()); */

            /* Testando &&
            Console.WriteLine("");
            int idade;
            bool idadeValida;
            Console.WriteLine("Digite sua idade: ");
            idade = int.Parse(Console.ReadLine());
            idadeValida = (idade > 0) && (idade <= 120); // Retorna true de idade estiver entre 0 e 120
            Console.WriteLine("O resultado é: {0}", idadeValida.ToString());*/

            // Testando ||
            Console.WriteLine("");
            int temperatura;
            bool temperaturaInvalida;
            Console.WriteLine("Digite a temperatura em graus Celsis para verificar se a água está em estado sólido ou gasoso: ");
            temperatura = int.Parse(Console.ReadLine());
            temperaturaInvalida = (temperatura < 0) || (temperatura > 100);
            Console.WriteLine(temperaturaInvalida.ToString());
            if (temperaturaInvalida == false)
                Console.WriteLine("A água está em estado líquido");
            else
                Console.WriteLine("A água está em estado gasoso ou sólido");
            
            


        }
    }
}
