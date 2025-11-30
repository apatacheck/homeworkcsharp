using System;
using System.IO;

// 14. Дан файл, компонентами которого являются символы. Создать новый файл таким
// образом, чтобы на четных местах у него стояли компоненты, стоящие на нечетных в
// первом файле, и наоборот. 
class Program
{
    static void Main()
    {
        string inputFile = "input.txt";
        string outputFile = "output.txt";

        string text = File.ReadAllText(inputFile);
        char[] chars = text.ToCharArray();

        for (int i = 0; i < chars.Length - 1; i += 2)
        {
            char temp = chars[i];
            chars[i] = chars[i + 1];
            chars[i + 1] = temp;
        }

        File.WriteAllText(outputFile, new string(chars));

        Console.WriteLine("Новый файл в output.txt");
    }
}
