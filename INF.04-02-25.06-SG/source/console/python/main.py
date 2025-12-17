def cipher(clear_text, key):
    # Jeśli klucz jest równy zero, to nie szyfrujemy :-)
    if key == 0:
        return clear_text
    
    # Tu będzie budowany wynik po przesunięciu znaków
    output = ""
    
    # Przelatujemy po każdym znaku tekstu
    for ch in clear_text:
        # Szyfrujemy tylko małe litery alfabetu
        if 'a' <= ch <= 'z':
            # Zamiana znaku na jego numer kodowy ASCII
            # Np. 'a' => 97
            #     'b' => 98
            #     'c' => 99
            #      i tak dalej..
            ord_num = ord(ch)
            
            # Przesunięcie względem 'a', żeby było 0-25
            # np 'a' - 'a' => 0, 
            #    'b' - 'a' => 1 
            #    'c' - 'a' => 2 
            #     i tak dalej..
            ord_num -= ord('a')

            # Dodanie klucza, zawijanie w zakresie alfabetu
            # przykłady dla key = 3
            #   'a':  (   0    +  3 ) % 26  => 3
            #   'c':  (   2    +  3 ) % 26  => 5
            #   'z':  (   25   +  3 ) % 26  => 2
            ord_num = (ord_num + key) % 26

            # Powrót do kodu ASCII małych liter
            ord_num += ord('a')

            # Zamiana na znak
            ch = chr(ord_num)

        # Dokładamy przetworzony znak do wyniku
        output += ch
    return output


def main():
    # Pobranie tekstu od użytkownika
    cl_text = input("Podaj jawny tekst: ")

    # Pobranie klucza (przesunięcia)
    k = int(input("Podaj klucz: "))

    # Szyfrowanie tekstu
    en_text = cipher(cl_text, k)

    # Wyświetlenie wyniku
    print("Zaszyfrowany tekst:", en_text)


if __name__ == "__main__":
    main()
