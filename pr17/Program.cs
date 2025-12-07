using System;
using System.Collections.Generic;
using System.IO;

class Money
{
    private int banknote;
    private int count;
    private int[] par = { 5, 10, 50, 100, 200, 500, 1000, 2000, 5000 };

    //5. Свойства 
    //позволяющее получать доступ к закрытым полям класса (доступное для чтения и записи с допустимыми значениями);
    public int Banknote
    {
        get { return banknote; }
        set
        {
            if (!IsValid(value))
                throw new Exception("Недопустимый номинал купюры");
            banknote = value;
        }
    }

    public int Count
    {
        get { return count; }
        set
        {
            if (value < 0)
                throw new Exception("Количество не может быть отрицательным!");
            count = value;
        }
    }


    private bool IsValid(int v) //проверка на правильный номинал купюры
    {
        foreach (int n in par)
            if (n == v) return true;
        return false;
    }

    //позволяющее расчитатать сумму денег (доступное только для чтения)
    public int Total
    {
        get { return banknote * count; }
    }


    //2.Конструкторы

    public Money() //со значениями полей по умолчанию;
    {
        banknote = 100;
        count = 1;
    }

    public Money(int banknote, int count) //с заданными значениями (допустимыми);
    {
        if (!IsValid(banknote))
            throw new Exception("Недопустимый номинал!");

        if (count < 0)
            throw new Exception("Количество < 0!");

        this.banknote = banknote;
        this.count = count;
    }

    public Money(Money m) //на основе существующего экземпляра класса(конструктор копирования)
    {
        banknote = m.banknote;
        count = m.count;
    }

    //3.Методы 

    //хватит ли денежных средств на покупку товара на сумму N рублей
    public bool CanBuy(int price)
    {
        return Total >= price;
    }

    //сколько штук товара стоимости n рублей можно купить на имеющиеся денежные средства
    public int HowManyItems(int itemPrice)
    {
        if (itemPrice <= 0) return 0;
        return Total / itemPrice;
    }

    //4.Перегрузка Object 
    public override string ToString()
    {
        return $"Money: номинал={banknote}, количество={count}, сумма={Total}";
    }

    public override int GetHashCode()
    {
        return banknote ^ count;
    }

    public override bool Equals(object obj)
    {
        if (obj is Money m)
        {
            return banknote == m.banknote && count == m.count;
        }
        return false;
    }

    //6. Индексатор,позволяющий по индексу 0 обращаться к полю banknote, по индексу 1 – к
    //полю count, при других значениях индекса выдается сообщение об ошибке
    public int this[int index]
    {
        get
        {
            if (index == 0) return banknote;
            if (index == 1) return count;
            throw new Exception("Неверный индекс! Допустимо 0, 1");
        }
        set
        {
            if (index == 0) Banknote = value;
            else if (index == 1) Count = value;
            else throw new Exception("Неверный индекс! Допустимо 0, 1");
        }
    }

    //7. Перегрузка 

    public static Money operator ++(Money m) //увеличивает поле count;
    {
        m.count++;
        return m;
    }

    public static Money operator --(Money m) //уменьшает поле count;
    {
        if (m.count > 0) m.count--;
        return m;
    }

    //операции !: возвращает значение true, если поле count не нулевое, иначе false;
    public static bool operator !(Money m) 
    {
        return m.count != 0;
    }

    //операции бинарный +: добавляет к значению поля count значение скаляра
    public static Money operator +(Money m, int value)
    {
        m.count += value;
        if (m.count < 0) m.count = 0;
        return m;
    }
}



class Program
{
    static void Main()
    {
        List<Money> list = new List<Money>();

        // Чтение объектов из файла
        string[] lines = File.ReadAllLines("test.txt");
        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue; 
            string[] p = line.Split();
            int b = int.Parse(p[0]);
            int c = int.Parse(p[1]);

            list.Add(new Money(b, c));
        }
        list.Add(new Money());              

        using (StreamWriter file = new StreamWriter("output.txt"))
        {
            foreach (Money m in list)
            {
                file.WriteLine("ToString(): " + m.ToString());
              

                file.WriteLine("Можно ли купить товар за 1200? " + m.CanBuy(1200));
                file.WriteLine("Сколько можно купить товаров по 150? " + m.HowManyItems(150));

                file.WriteLine($"Свойства: Banknote = {m.Banknote}, Count = {m.Count}");
                file.WriteLine("Индексатор [0] = " + m[0] + ", [1] = " + m[1]);

                Money tmp = new Money(m);
                tmp++;
                file.WriteLine("После ++: " + tmp);
                tmp--;
                file.WriteLine("После --: " + tmp);

               
                file.WriteLine("Оператор ! : " + (!tmp));
                tmp = tmp + 3;
                file.WriteLine("После +3: " + tmp);
                tmp.Banknote = 1000;
                tmp.Count = 10;
                file.WriteLine("Изменение по свойствам: " + tmp.ToString());

                Money copy = new Money(m);
                file.WriteLine("Equals с копией: " + m.Equals(copy));
                file.WriteLine("Equals не с копией: " + m.Equals(tmp));
                file.WriteLine("GetHashCode: " + m.GetHashCode());
                file.WriteLine("GetType: " + m.GetType());


                file.WriteLine();
            }
        }

        Console.WriteLine("Результат в output.txt");
    }
}

