using Core.Utils;
using System;

namespace coa
{
    public class Program
    {
        static void Main(string[] args)
        {
            string document = string.Empty;
            string option = string.Empty;
            
            Console.WriteLine("===============================================================");
            Console.WriteLine("Sistema validar documento");
            Console.WriteLine("===============================================================");

            while (true)
            {
                Console.Write("Informe um documento: ");
                document = Console.ReadLine();

                menu:
                Console.WriteLine("Digite uma Opção:");
                Console.WriteLine("1 - Checar se o documento é válido");
                Console.WriteLine("2 - Calcular digito");
                Console.WriteLine("3 - Calcular e validar");
                Console.WriteLine("X - Sair");
                Console.Write("Opção:");
                option = Console.ReadLine();

                if (option == "1")
                    Console.WriteLine(new Document().CheckDocument(document));
                else if (option == "2")
                    Console.WriteLine($"O digito calculado é: {new Document().CalcDigit(document)}");
                else if (option == "3")
                {
                    Console.WriteLine(new Document().CheckDocument(document));
                    Console.WriteLine($"O digito calculado é: {new Document().CalcDigit(document)}");
                    Console.WriteLine($"O documento é: {document}");
                }
                else if (option == "X")
                {
                    Console.WriteLine("Fim!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Opção inválida");
                    Console.WriteLine("===============================================================");
                    goto menu;
                }

                Console.WriteLine();
            }
        }

    }
}