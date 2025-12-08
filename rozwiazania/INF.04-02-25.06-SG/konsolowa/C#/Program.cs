using System;

namespace CaesarCipher
{
    internal class Program
    {
        static string Cipher(string clearText, int key)
        {
            string output = "";
            for (int i = 0; i < clearText.Length; i++)
            {
                char ch = clearText[i];
                if (ch >= 'a' && ch <= 'z')
                {
                    int ordNum = ch;
                    ordNum -= 'a';
                    ordNum += key;
                    ordNum = ordNum % 26;
                    if (ordNum < 0)
                        ordNum = 26 + ordNum;
                    ordNum += 'a';
                    ch = (char)ordNum;
                }
                output += ch;
            }
            return output;
        }

        static void Main(string[] args)
        {
            Console.Write("Podaj jawny tekst: ");
            string clText = Console.ReadLine();
            Console.Write("Podaj klucz: ");
            int k = int.Parse(Console.ReadLine());

            string enText = Cipher(clText, k);
            Console.WriteLine($"Zaszyfrowany tekst: {enText}");
        }
    }
}
