﻿using System;


namespace pHaz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Emelet> emeletek = new();


            using StreamReader sr = new StreamReader(
                path: @"..\..\..\src\parkolohaz.txt",
                encoding: System.Text.Encoding.UTF8
                );
            while (!sr.EndOfStream)
            {
                emeletek.Add(new Emelet(sr.ReadLine()));
            }


            for (int i = 0; i < emeletek.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {emeletek[i].ToString()}");
            }


            Console.WriteLine("8.feladat");
            minimum(emeletek);


            Console.WriteLine("\n9.feladat");
            kilencedik(emeletek);


            Console.WriteLine("\n10.feladat");
            tizes(emeletek);


            Console.WriteLine("\n11.feladat");
            tizenegyes(emeletek);


            Console.WriteLine("\n12.feladat");
            Console.WriteLine(tizenketto(emeletek));


            Console.WriteLine("\n13.feladat és a 14. feladat");
            tizenharom(emeletek);

        }
        static void minimum(List<Emelet> emeletek)
        {


            List<int> valami = new List<int>();
            for (int i = 0; i < emeletek.Count; i++)
            {
                valami.Add(emeletek[i].szektorSzam.Sum());
            }


            int min = valami[0];
            int index = 0;


            for (int i = 0; i < valami.Count; i++)
            {
                if (valami[i] < min)
                {
                    min = valami[i];
                    index = i;
                }
            }
            Console.WriteLine($"{emeletek[index].Nev}");
        }


        static void kilencedik(List<Emelet> emeletek)
        {
            int index = 0;
            for (int i = 0; i < emeletek.Count; i++)
            {
                for (int j = 0; j < emeletek[i].szektorSzam.Count; j++)
                {
                    index = i;
                    if (emeletek[i].szektorSzam[j] == 0)
                    {
                        Console.WriteLine($"Az {index + 1} szinten és {emeletek[i].Nev} szektor ");
                    }
                }
            }
        }


        static void tizes(List<Emelet> emeletek)
        {
            List<int> valami = new List<int>();
            for (int i = 0; i < emeletek.Count; i++)
            {
                valami.Add(emeletek[i].szektorSzam.Sum());
            }


            double atlag = 0;
            foreach (var item in valami)
            {
                atlag += item;
            }
            atlag = Math.Round(atlag / (12 * 6), 2);
            Console.WriteLine($"átlag: {atlag}");

            int db = 0;
            for (int i = 0; i < emeletek.Count; i++)
            {
                for (int j = 0; j < emeletek[i].szektorSzam.Count; j++)
                {
                    if (emeletek[i].szektorSzam[j] == atlag)
                    {
                        db++;
                    }
                }
            }
            Console.WriteLine($"ugyan annyi, mint atlag: {db}");


            db = 0;
            for (int i = 0; i < emeletek.Count; i++)
            {
                for (int j = 0; j < emeletek[i].szektorSzam.Count; j++)
                {
                    if (emeletek[i].szektorSzam[j] > atlag)
                    {
                        db++;
                    }
                }
            }
            Console.WriteLine($"nagyobb, mint az átlag: {db}");


            db = 0;
            for (int i = 0; i < emeletek.Count; i++)
            {
                for (int j = 0; j < emeletek[i].szektorSzam.Count; j++)
                {
                    if (emeletek[i].szektorSzam[j] < atlag)
                    {
                        db++;
                    }
                }
            }
            Console.WriteLine($"kisebb, mint az átlag: {db}");
        }


        static void tizenegyes(List<Emelet> emeletek)
        {
            using (var sw = new StreamWriter(path: @"..\..\..\src\tizenegy.txt"))
            {
                for (int i = 0; i < emeletek.Count; i++)
                {
                    for (int j = 0; j < emeletek[i].szektorSzam.Count; j++)
                    {
                        if (emeletek[i].szektorSzam[j] == 1)
                        {
                            sw.WriteLine($"{emeletek[i].Nev} - {j + 1}");
                        }
                    }
                }
            }
            Console.WriteLine("file létre hozva");
        }


        static string tizenketto(List<Emelet> emeletek)
        {
            List<int> valami = new List<int>();
            for (int i = 0; i < emeletek.Count; i++)
            {
                valami.Add(emeletek[i].szektorSzam.Sum());
            }

            int max = valami.Max();
            if (max == valami[0])
            {
                return "igaz";
            }
            else
            {
                return "nem igaz";
            }
        }


        static void tizenharom(List<Emelet> emeletek)
        {
            List<string> lista = new();
            using (var sw = new StreamWriter(path: @"..\..\..\src\tizenegy.txt", append: true)) 
            {
                sw.WriteLine("13.feladat\n");
                const int maxHely = 15;
                int kocsi = 0;
                for (int i = 0; i < emeletek.Count; i++)
                {
                    for (int j = 0; j < emeletek[i].szektorSzam.Count; j++)
                    {
                        kocsi += maxHely - emeletek[i].szektorSzam[j];
                    }
                    Console.WriteLine($"{kocsi} szabad hely van");
                    lista.Add($"{i + 1}.szint - {kocsi}");
                    kocsi = 0;

                }

                foreach (var item in lista)
                {
                    sw.WriteLine(item);
                    
                }
            }

        }


    }
}
