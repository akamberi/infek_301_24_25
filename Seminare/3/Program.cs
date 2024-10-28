public class Program
{
    static bool IThjeshte(int nr)
    {
        for (int i = 2; i < nr; i++)
        {
            if (nr % i == 0)
                return false;
        }
        return true;
    }

    static void Rendit(int[] numra)
    {
        for (int i = 0; i < numra.Length; i++)
        {
            for (int j = 0; j < numra.Length; j++)
            {
                if (numra[i] > numra[j])
                {
                    var tmp = numra[i];
                    numra[i] = numra[j];
                    numra[j] = tmp;
                }
            }
        }
    }

    static void AfishoVektor(int[] numra)
    {
        Console.WriteLine("Elementet e vektorit: ");
        //for (int i = 0; i < numra.Length; i++)
        foreach (var i in numra)
        {
            Console.Write($"{numra[i]}\t");
        }
        Console.WriteLine();
    }

    static void Ushtrimi1()
    {
        Console.Write("Jep nje numer: ");
        int nrElemente = int.Parse(Console.ReadLine());
        var nrThjeshte = new int[nrElemente];
        int i = 2;
        int gjetur = 0;
        while (gjetur < nrElemente)
        {
            if (IThjeshte(i))
            {
                nrThjeshte[gjetur] = i;
                gjetur++;
            }
            i++;
        }
        Rendit(nrThjeshte);
        AfishoVektor(nrThjeshte);
    }

    static int[] GjeneroFib(int nr)
    {
        var numrat = new int[nr];
        int k1 = 1;
        int k2 = 1;
        int k, gjetur = 2;
        numrat[0] = k1;
        numrat[1] = k2;
        while (gjetur < nr)
        {
            k = k1 + k2;
            numrat[gjetur] = k;
            gjetur += 1;
            k1 = k2;
            k2 = k;
        }
        return numrat;
    }

    static int ShumaVektorit(int[] numrat)
    {
        int shuma = 0;
        foreach (var nr in numrat)
        {
            shuma = shuma + nr;
        }
        return shuma;
    }

    static void Ushtrimi2()
    {
        Console.Write("Jep nje numer: ");
        int nrElemente = int.Parse(Console.ReadLine());
        var numrat = GjeneroFib(nrElemente);
        var shuma = ShumaVektorit(numrat);
        Console.WriteLine("shuma e elementeve te serise fibonaci:  " + shuma);
    }

    static int GjejNrPerseritje(int[] numrat, int nr)
    {
        int nrPerseritje = 0;
        foreach (var el in numrat)
        {
            if (el == nr)
            {
                nrPerseritje++;
            }
        }
        return nrPerseritje;
    }

    static void Ushtrimi3()
    {
        var numrat = new int[] { 2, 4, 9, 6, 4, 2, 1, 8, 4 };
        var nrPerseritje = new Dictionary<int, int>();
        foreach (var nr in numrat)
        {
            if (!nrPerseritje.ContainsKey(nr))
            {
                nrPerseritje.Add(nr, GjejNrPerseritje(numrat, nr));
            }
        }
        foreach (var key in nrPerseritje.Keys)
        {
            Console.WriteLine($"{key}: {nrPerseritje[key]}");
        }


    }

    public static void Main(string[] args)
    {
        //Ushtrimi1();
        //Ushtrimi2();
        Ushtrimi3();
    }
}
