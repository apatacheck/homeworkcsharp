using System;

// 14. Найти все самые короткие слова сообщения. 
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите строку:");
        String s = Console.ReadLine()!;
        char[] separator = { ' ', ',', '.', '\t', '\r', '\n', '?', '!', '-', ':', ';', '"', '(', ')', '[', ']', '{', '}' };
        int minLength = 10000;
        List<string> minWords = new List<string>();
        String[] words = s.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        foreach (string word in words)
        {
            int lenWord = word.Length;
            if (lenWord < minLength)
            {
                minLength = lenWord;
                minWords.Clear();         
                minWords.Add(word);        
            }
            else if (lenWord == minLength)
            {
                minWords.Add(word);
            }
         
        }
           Console.WriteLine("Слова минимальной длины:");
           foreach (string word in minWords)
            {
                Console.WriteLine(word);
            }
    }
}
