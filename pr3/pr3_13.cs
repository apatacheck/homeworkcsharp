using System;
class Practice3_13
{
    static void Main()
    {
        for (int i = 10; i <= 99; i++)
        {
            if ((i / 10) != (i % 10))
            {
                Console.WriteLine(i);
            }
        }
    }
}



