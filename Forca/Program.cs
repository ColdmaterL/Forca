using System;
using Forca.Entities;

namespace Forca
{
    class Program
    {
        static void Main(string[] args)
        {
            Palavra Pal;
            char Letra;

            Console.Write("Type the word to be discovered: ");
            Pal = new Palavra(Console.ReadLine().ToLower());
            Console.Clear();
            while(Pal.VerificaSeTerminou() != true)
            {
                try
                {
                    Pal.Situacao();
                    Console.WriteLine($"{Pal}");
                    Console.Write("Guess a letter: ");
                    Letra = char.Parse(Console.ReadLine().ToLower());
                    Pal.VerificaLetra(Letra);
                    Console.Clear();
                }
                catch(Exception e)
                {
                    Console.Clear();
                    Console.WriteLine(e.Message);
                }
            }
            Pal.Resultado();
        }
    }
}
