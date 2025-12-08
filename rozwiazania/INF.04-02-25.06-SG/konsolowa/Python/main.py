def cipher(clear_text, key):
    if key == 0:
        return clear_text
    enc_text = ""
    for char in clear_text:
        if 'a' <= char <= 'z':
            nr = ord(char)
            nr -= ord('a')
            nr = (nr + key) % 26
            nr += ord('a')
            char = chr(nr)
        enc_text += char
    return enc_text


def main():
    cl_text = input("Podaj jawny tekst: ")
    k = int(input("Podaj klucz: "))
    en_text = cipher(cl_text, k)
    print("Zaszyfrowany tekst:", en_text)


if __name__ == "__main__":
    main()