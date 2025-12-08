using System;

namespace CaesarCipher
{
    internal class Program
    {
        static string Cipher(string clearText, int key)
        {
            // Jeśli klucz jest równy zero, to nie szyfrujemy :-)
            if (key == 0) {
                return clearText;
            }

            // Tu będzie budowany wynik po przesunięciu znaków
            string output = "";

            // Przelatujemy po każdym znaku tekstu
            for (int i = 0; i < clearText.Length; i++)
            {
                char ch = clearText[i];
                // Szyfrujemy tylko małe litery alfabetu
                if (ch >= 'a' && ch <= 'z')
                {
                    // Zamiana znaku na jego numer kodowy
                    int ordNum = ch;

                    // Przesunięcie względem 'a', żeby było 0-25
                    // np 'a' - 'a' => 0, 
                    //    'b' - 'a' => 1 
                    //    'c' - 'a' => 2 
                    //     i tak dalej..
                    ordNum -= 'a';

                    // Dodanie klucza, zawijanie w zakresie alfabetu
                    // przykłady dla key = 3
                    // 'a':  (   0   +  3 ) % 26  => 3
                    // 'c':  (   2   +  3 ) % 26  => 5
                    // 'z':  (   25  +  3 ) % 26  => 2
                    ordNum = (ordNum + key) % 26;

                    // Obsługa ujemnego wyniku przy ujemnym kluczu
                    if (ordNum < 0)
                        ordNum = 26 + ordNum;

                    // Powrót do kodu ASCII małych liter
                    ordNum += 'a';

                    // Zamiana na znak
                    ch = (char)ordNum;
                }

                // Dokładamy przetworzony znak do wyniku
                output += ch;
            }

            return output;
        }

        static void Main(string[] args)
        {
            // Pobranie tekstu od użytkownika
            Console.Write("Podaj jawny tekst: ");
            string clText = Console.ReadLine();

            // Pobranie klucza (przesunięcia)
            Console.Write("Podaj klucz: ");
            int k = int.Parse(Console.ReadLine());

            // Szyfrowanie tekstu
            string enText = Cipher(clText, k);

            // Wyświetlenie wyniku
            Console.WriteLine($"Zaszyfrowany tekst: {enText}");
        }
    }
}
