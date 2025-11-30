class Program
{
    static void Stroka(int n) 
    {
        for (int i = n; i >= 1; i--)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }
    static void F_Rec(int n, int i) 
    {
        if (i <= n) 
        {
            Stroka(i);
            F_Rec(n, i + 1);
            Stroka(i); 
        
        }
    }
    static void Main()
    {
        Console.Write("Количество строк n:");
        int n = Math.Abs(int.Parse(Console.ReadLine()!));
        const int i = 1; //первая строка
        F_Rec(n, i);
    }
}
