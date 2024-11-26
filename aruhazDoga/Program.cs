namespace DebuggFeladat
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        // Bevásárlólista
        static List<string> vasarlolista = new List<string>();
        static List<int> mennyisegek = new List<int>();

        // Raktár
        static string[] raktarTermekek = new string[10];
        List<int> raktarMennyisegek = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
        static string[] asd = ["alma", "körte", "barack", "meggy", "banán", "cseresznye", "mangó", "szeder", "málna", "dinnye"];

        static void Main()
        {
            bool fut = true;
            while (fut)
            {
                Console.WriteLine("Áruház Rendszer");
                Console.WriteLine("1. Raktárkészlet kezelése");
                Console.WriteLine("2. Vásárlói kosár kezelése");
                Console.WriteLine("3. Vásárlási műveletek szimulálása");
                Console.WriteLine("4. Statisztikák előállítása");
                Console.Write("Válassz egy opciót: ");

                int.TryParse(Console.ReadLine(), out int opcio);

                switch (opcio)
                {
                    case 1:
                        RaktarMegtekintes();
                        break;
                    case 2:
                        TermekTorlese();
                        break;
                    case 3:
                        RaktarFrissites();
                        break;
                    case 4:
                        ListaMegtekintes();
                        break;
                    case 5:
                        
                        break;
                    case 6:
                        Vasarlas();
                        break;
                    case 7:
                        Console.WriteLine("Kilépés...");
                        fut = false;
                        break;
                    default:
                        Console.WriteLine("Érvénytelen opció!");
                        break;
                }
            }
        }

        static void Hozzaadas()
        {
            Console.Write("Add meg a termék nevét: ");
            string termek = Console.ReadLine().ToUpper();
            if (termek == "")
            {
                Console.WriteLine("A termék neve nem lehet üres!");
                return;
            }
            Console.Write("Add meg a mennyiséget: ");
            string m = Convert.ToString(Console.ReadLine());
            if (m == "")
            {
                Console.WriteLine("A mennyiség mező nem lehet üres");
                return;
            }
            int mennyiseg = Convert.ToInt32(m);

            if (mennyiseg < 0)
            {
                Console.WriteLine("A mennyiség nem lehet negatív!");
                return;
            }

            vasarlolista.Add(termek);
            mennyisegek.Add(mennyiseg);
            Console.WriteLine("Termék hozzáadva a bevásárlókosárhoz!");

        }

        static void TermekTorlese()
        {
            Console.Write("Add meg a törölni kívánt termék nevét: ");
            string termek = Console.ReadLine().ToUpper();

            if (!vasarlolista.Contains(termek))
            {
                Console.WriteLine("Ez a termék nincs a listán!");
            }
            else
            {
                int index = vasarlolista.IndexOf(termek);
                vasarlolista.RemoveAt(index);
                mennyisegek.RemoveAt(index);
                Console.WriteLine("Termék eltávolítva a bevásárlólistáról!");
            }
        }

        static void RaktarFrissites()
        {
            Console.Write("Add meg a termék nevét: ");
            string termek = Console.ReadLine().ToUpper();

            int index = Array.IndexOf(raktarTermekek, termek);
            if (index == -1)
            {
                Console.WriteLine("Ez a termék nincs a raktárban!");
                return;
            }

            Console.Write("Add meg a frissítendő mennyiséget (pozitív/nem negatív szám): ");

            string m = Convert.ToString(Console.ReadLine());
            if (m == "")
            {
                Console.WriteLine("A mennyiség mező nem lehet üres");
                return;
            }
            int mennyiseg = Convert.ToInt32(m);

            if (mennyiseg < 0)
            {
                Console.WriteLine("Hiba: negatív mennyiséget nem adhatsz hozzá!");
                return;
            }

            raktarMennyisegek[index] += mennyiseg;
            Console.WriteLine("A raktárkészlet frissítve!");
        }

        static void ListaMegtekintes()
        {
            Console.WriteLine("Bevásárlólista:");
            for (int i = 0; i <= vasarlolista.Count - 1; i++)
            {
                Console.WriteLine($"- {vasarlolista[i]}: {mennyisegek[i]} db");
            }
        }

        static void RaktarMegtekintes()
        {
            Console.WriteLine("Raktárkészlet:");
            for (int i = 0; i < raktarTermekek.Length; i++)
            {
                if (raktarTermekek[i] == "")
                {
                    Console.WriteLine($"- Nincs termék a {i + 1}. helyen.");
                }
                else
                {
                    Console.WriteLine($"- {raktarTermekek[i]}: {raktarMennyisegek[i]} db");
                }
            }
        }

        static void Vasarlas()
        {
            Console.WriteLine("Bevásárlás folyamatban...");
            for (int i = 0; i < vasarlolista.Count; i++)
            {
                string termek = vasarlolista[i];
                int mennyiseg = mennyisegek[i];

                int index = Array.IndexOf(raktarTermekek, termek);
                if (index == -1)
                {
                    Console.WriteLine($"Nincs a raktárban: {termek}");
                    continue;
                }

                if (raktarMennyisegek[index] < mennyiseg)
                {
                    Console.WriteLine($"Nincs elég {termek} a raktárban!");
                }
                else
                {
                    raktarMennyisegek[index] -= mennyiseg;
                    Console.WriteLine($"Sikeresen megvásárolt: {termek}, {mennyiseg} db.");
                    vasarlolista.Clear();
                    mennyisegek.Clear();
                }
            }

        }
    }

}
