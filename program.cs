using System;
using System.Text;

class Program
{
    static void Main()
    {
        // === Базовая часть ===
        int number = 305419896;
        Console.WriteLine($"Число: {number}");
        Console.WriteLine($"В hex: 0x{number:X8}");
        Console.WriteLine($"Little-endian: {BitConverter.IsLittleEndian}");

        byte[] numberBytes = BitConverter.GetBytes(number);
        Console.WriteLine("Байты числа:");
        Console.WriteLine(BitConverter.ToString(numberBytes));

        string text = "Hello";
        Console.WriteLine();
        Console.WriteLine($"Текст: {text}");
        byte[] textBytes = Encoding.UTF8.GetBytes(text);
        Console.WriteLine("Байты текста UTF-8:");
        Console.WriteLine(BitConverter.ToString(textBytes));

        // === Исследование 1: Что находится внутри int ===
        Console.WriteLine("\n=== Исследование 1 ===");
        int[] testNumbers = { 1, 256, 65536 };
        foreach (int n in testNumbers)
        {
            byte[] b = BitConverter.GetBytes(n);
            Console.WriteLine($"{n} -> {BitConverter.ToString(b)}");
        }

        // === Исследование 3: Число и текст ===
        Console.WriteLine("\n=== Исследование 3 ===");
        string text2 = "ABC";
        byte[] text2Bytes = Encoding.UTF8.GetBytes(text2);
        Console.WriteLine($"Текст: {text2}");
        Console.WriteLine($"Количество символов: {text2.Length}");
        Console.WriteLine($"Количество байтов UTF-8: {text2Bytes.Length}");
        Console.WriteLine($"Байты: {BitConverter.ToString(text2Bytes)}");

        text2 = "Привет";
        text2Bytes = Encoding.UTF8.GetBytes(text2);
        Console.WriteLine();
        Console.WriteLine($"Текст: {text2}");
        Console.WriteLine($"Количество символов: {text2.Length}");
        Console.WriteLine($"Количество байтов UTF-8: {text2Bytes.Length}");
        Console.WriteLine($"Байты: {BitConverter.ToString(text2Bytes)}");

        // === Исследование 4: Английская и русская буква ===
        Console.WriteLine("\n=== Исследование 4 ===");
        string english = "A";
        string russian = "А";
        byte[] englishBytes = Encoding.UTF8.GetBytes(english);
        byte[] russianBytes = Encoding.UTF8.GetBytes(russian);
        Console.WriteLine($"Английская A: {BitConverter.ToString(englishBytes)}");
        Console.WriteLine($"Русская А: {BitConverter.ToString(russianBytes)}");

        // === Исследование 5: Обратное преобразование текста ===
        Console.WriteLine("\n=== Исследование 5 ===");
        string text3 = "Привет";
        byte[] bytes = Encoding.UTF8.GetBytes(text3);
        string restored = Encoding.UTF8.GetString(bytes);
        Console.WriteLine($"Исходная строка: {text3}");
        Console.WriteLine($"Восстановленная: {restored}");

        // === Исследование 6: Обратное преобразование числа ===
        Console.WriteLine("\n=== Исследование 6 ===");
        int number2 = 123456789;
        byte[] bytes2 = BitConverter.GetBytes(number2);
        int restored2 = BitConverter.ToInt32(bytes2, 0);
        Console.WriteLine($"Исходное число: {number2}");
        Console.WriteLine($"Восстановленное число: {restored2}");
        Console.WriteLine($"Байты: {BitConverter.ToString(bytes2)}");

        // === Эксперимент: Одни байты — разные смыслы ===
        Console.WriteLine("\n=== Эксперимент ===");
        byte[] data = { 0x41, 0x42, 0x43 };
        Console.WriteLine($"Байты: {BitConverter.ToString(data)}");
        Console.WriteLine($"Как текст UTF-8: {Encoding.UTF8.GetString(data)}");
    }
}
