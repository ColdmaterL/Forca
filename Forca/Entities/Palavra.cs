using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Forca.Entities.Exceptions;

namespace Forca.Entities
{
    class Palavra
    {
        public string Word { get; private set; }
        public string Hang { get; private set; }
        public string WrongLetters { get; private set; }
        public int TrysLeft { get; private set; }

        public Palavra(string word)
        {
            WrongLetters = "              ";
            TrysLeft = 7;
            Word = word;
            Hang = word;
            for (int i = 0; i < Word.Length; i++)
            {
                Hang = Hang.Remove(i, 1);
                if (Word[i] == ' ')
                {
                    Hang = Hang.Insert(i, "-");
                }
                else
                {
                    Hang = Hang.Insert(i, "_");
                }

            }
        }

        public void Situacao()
        {
            switch (TrysLeft)
            {
                case 7:
                    Console.WriteLine("------  ");
                    Console.WriteLine("|    |  ");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("_");
                    break;
                case 6:
                    Console.WriteLine("------  ");
                    Console.WriteLine("|    |  ");
                    Console.WriteLine("|    O  ");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("_");
                    break;
                case 5:
                    Console.WriteLine("------  ");
                    Console.WriteLine("|    |  ");
                    Console.WriteLine("|    O  ");
                    Console.WriteLine("|    |  ");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("_");
                    break;
                case 4:
                    Console.WriteLine("------  ");
                    Console.WriteLine("|    |  ");
                    Console.WriteLine("|    O  ");
                    Console.WriteLine("|    |  ");
                    Console.WriteLine("|   -| ");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("_");
                    break;
                case 3:
                    Console.WriteLine("------  ");
                    Console.WriteLine("|    |  ");
                    Console.WriteLine("|    O  ");
                    Console.WriteLine("|    |  ");
                    Console.WriteLine("|   -|- ");
                    Console.WriteLine("|");
                    Console.WriteLine("|");
                    Console.WriteLine("_");
                    break;
                case 2:
                    Console.WriteLine("------  ");
                    Console.WriteLine("|    |  ");
                    Console.WriteLine("|    O  ");
                    Console.WriteLine("|    |  ");
                    Console.WriteLine("|   -|- ");
                    Console.WriteLine("|    |  ");
                    Console.WriteLine("|");
                    Console.WriteLine("_");
                    break;
                case 1:
                    Console.WriteLine("------  ");
                    Console.WriteLine("|    |  ");
                    Console.WriteLine("|    O  ");
                    Console.WriteLine("|    |  ");
                    Console.WriteLine("|   -|- ");
                    Console.WriteLine("|    |  ");
                    Console.WriteLine("|   /   ");
                    Console.WriteLine("_");
                    break;
                case 0:
                    Console.WriteLine("------  ");
                    Console.WriteLine("|    |  ");
                    Console.WriteLine("|    O  ");
                    Console.WriteLine("|    |  ");
                    Console.WriteLine("|   -|- ");
                    Console.WriteLine("|    |  ");
                    Console.WriteLine("|   /\\ ");
                    Console.WriteLine("_");
                    break;
            }
        }

        public void VerificaLetra(char c)
        {
            int verificacao = -1, i;
            for (i = 0; i < Word.Length; i++)
            {
                if (Hang[i] == c)
                {
                    throw new ForcaException("Letra já escolhida");
                }
                if (i < WrongLetters.Length)
                {
                    if (WrongLetters[i] == c)
                    {
                        throw new ForcaException("Letra já escolhida");
                    }
                }
                if (Word[i] == c)
                {
                    Hang = Hang.Remove(i, 1);
                    Hang = Hang.Insert(i, c.ToString());
                    verificacao = 1;
                }
            }
            if (verificacao == -1)
            {
                WrongLetters = WrongLetters.Insert(14 - (TrysLeft * 2), c.ToString());
                TrysLeft--;
            }
        }

        public bool VerificaSeTerminou()
        {
            if (TrysLeft == 0)
            {
                return true;
            }
            for (int i = 0; i < Word.Length; i++)
            {
                if (Hang[i] == '_')  // Se achar alguma letra ainda não encontrada
                {
                    return false;
                }
            }
            return true;  // Se não achar letras ainda não encontradas
        }

        public void Resultado()
        {
            if (VerificaSeTerminou() == true)
            {
                if (TrysLeft != 0)  // Vitoria
                {
                    Console.Clear();
                    int dance = 0;
                    while (dance != 10)
                    {
                        Console.WriteLine("Vitoria!");
                        Console.WriteLine("    O  ");
                        Console.WriteLine("    |  ");
                        Console.WriteLine("   /|\\ ");
                        Console.WriteLine("    |  ");
                        Console.WriteLine("    /\\ ");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Vitoria!");
                        Console.WriteLine("    O  ");
                        Console.WriteLine("    |  ");
                        Console.WriteLine("   \\|/ ");
                        Console.WriteLine("    |  ");
                        Console.WriteLine("    /\\ ");
                        Thread.Sleep(1000);
                        Console.Clear();
                        dance++;
                    }
                }
                else  // Derrota
                {
                    Console.Clear();
                    Console.WriteLine("------  ");
                    Console.WriteLine("|    |  ");
                    Console.WriteLine("|    X  ");
                    Console.WriteLine("|    |  ");
                    Console.WriteLine("|   -|- ");
                    Console.WriteLine("|    |  ");
                    Console.WriteLine("|   /\\ ");
                    Console.WriteLine("_");
                    Console.WriteLine($"A palavra era: {Word}");
                }
            }
            else
            {
                Console.WriteLine("Jogo ainda não terminado.");
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"TrysLeft: {TrysLeft}");
            for (int i = 0; i < Word.Length; i++)
            {
                sb.Append($"{Hang[i]} ");
            }
            sb.AppendLine();
            sb.AppendLine($"Wrong Letters: {WrongLetters}");
            return $"{sb}";
        }
    }
}
