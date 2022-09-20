using System;
using System.Globalization;
using System.Text;

namespace Sibenice
{
    class Program
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

            while (Hra() == ConsoleKey.Enter);
        }

        static ConsoleKey Hra()
        {
            string[] slova = new string[6];
            slova[0] = "zola";
            slova[1] = "shakespeare";
            slova[2] = "nemcova";
            slova[3] = "capek";
            slova[4] = "macha";
            slova[5] = "salinger";


            Random random = new Random();
            int zvolenyIndex = random.Next(0, slova.Length);

            string zvoleneSlovo = slova[zvolenyIndex];

            int delkaSlova = zvoleneSlovo.Length;

            Console.WriteLine("Vítejte ve hře Šibenice!\nJiž na Vás čeká slovo: ");


            string odhaleno = new String('*', delkaSlova);
            Console.WriteLine(odhaleno);
            int zivoty = 6;
            Console.WriteLine("Nyní máte {0} životů.", zivoty);

            int pocetSpatnychPokusu = 0;

            while (pocetSpatnychPokusu < zivoty && odhaleno.Contains('*')) //&& zvoleneSlovo.Contains(pismeno))
            {
                Console.Write("Zadejte písmeno pro uhodnutí slova:");
                ConsoleKey uzivatelZadal = Console.ReadKey().Key;

                string pismeno = uzivatelZadal.ToString().ToLower();

                Console.WriteLine("\n Zvolili jste " + pismeno);

                if (zvoleneSlovo.Contains(pismeno))
                {
                    for (int i = 0; i < delkaSlova; i++)
                    {
                        int indexPismene = zvoleneSlovo.IndexOf(pismeno, i, delkaSlova - i); // -1
                        if (indexPismene == -1)
                        {
                            break;
                        }
                        Console.WriteLine(indexPismene);
                        Console.WriteLine("Uhodl jsi písmeno:");
                        // replace v odhaleno na pozici indexPismene za pismeno
                        StringBuilder sb = new StringBuilder(odhaleno);
                        sb[indexPismene] = Convert.ToChar(pismeno);
                        odhaleno = sb.ToString();
                        Console.WriteLine(odhaleno);
                        i = indexPismene;
                    }

                }
                else
                {
                    Console.WriteLine("Toto písmeno ve slově bohužel není.");
                    pocetSpatnychPokusu++;


                    //musím počítat životy podle pokusů hádání
                    //počítat pokusy
                }
            }
            if (pocetSpatnychPokusu >= zivoty)
            {
                Console.WriteLine("Prohrál jsi. Zkus to znovu.");

            }
            else
            {
                Console.WriteLine("Vyhrál jsi!");

            }
            Console.Write("Pro další hru stiskněte enter. Pro ukončení mezerník. ");
            return Console.ReadKey().Key;
        }
    }
}