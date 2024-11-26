namespace DebuggFeladat
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;

    class Program
    {
        // Kosár
        static List<string> vasarlolista = new List<string>();
        static List<int> mennyisegek = new List<int>();

        // Raktár
        static string[] raktarTermekek = new string[10];
        static int[] raktarMennyisegek = new int[10];
        static string[] asd = ["alma", "körte", "barack", "meggy", "banán", "cseresznye", "mangó", "szeder", "málna", "dinnye"];
        static int[] asdArak = [10, 20, 30, 40, 50, 60, 70, 80, 90, 100];

        static void Main()
        {

            Random r = new Random();

            for (int i = 0; i < raktarMennyisegek.Length; i++)
            {
                raktarTermekek[i] += asd[i].ToUpper();
                raktarMennyisegek[i] += r.Next(1, 10);
            }

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
                        Console.WriteLine("Raktárkészlet kezelése");
                        Console.WriteLine("1. Raktárkészlet");
                        Console.WriteLine("2. Legdrágább");
                        Console.WriteLine("3. Legolcsóbb");
                        Console.WriteLine("4. Új termék felvétele");
                        Console.Write("Válassz egy opciót: ");
                        int.TryParse(Console.ReadLine(), out int raktarOpcio);
                        switch (raktarOpcio)
                        {
                            case 1:
                                RaktarMegtekintes();
                                break;
                            case 2:
                                Legdragabb();
                                break;
                            case 3:
                                Legolcsobb();
                                break;
                            case 4:
                                RaktarTermekFelvetel();
                                break;
                            default:
                                Console.WriteLine("Érvénytelen opció!");
                                break;
                        }
                        
                        break;
                    case 2:
                        Console.WriteLine("Vásárlói kosár kezelése");
                        Console.WriteLine("1. Termék hozzáadása");
                        Console.WriteLine("2. Termék kivétele");
                        Console.WriteLine("3. Kosár tartalma");
                        Console.WriteLine("4. Kosár ürítése");
                        int.TryParse(Console.ReadLine(), out int kosarOpcio);

                        switch (kosarOpcio)
                        {
                            case 1:
                                Hozzaadas();
                                break;

                            case 2:
                                TermekTorlese();
                                break;

                            case 3:
                                ListaMegtekintes();
                                break;

                            case 4:
                                KosarUretes();
                                break;

                            default:
                                Console.WriteLine("Érvénytelen opció!");
                                break;
                        }
                        
                        break;
                    case 3:
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
                Console.WriteLine("Termék eltávolítva a bevásárlókosárból!");
            }
        }
        static void KosarUretes()
        {
            vasarlolista.Clear();
            Console.WriteLine("A lista kiürűlt!");
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
                    Console.WriteLine($"- {raktarTermekek[i]}: {asdArak[i]}Ft, {raktarMennyisegek[i]} db");
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
                int arak = asdArak[i];

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
                    Console.WriteLine($"Sikeresen megvásárolt: {termek}, {arak}Ft, {mennyiseg} db.");
                    vasarlolista.Clear();
                    mennyisegek.Clear();
                }
            }
            int total = asdArak.Sum(x => Convert.ToInt32(x));
            Console.WriteLine($"Az összérték: {total}");
        }
        static void Figyelmeztetes()
        {
             for (int i = 0; i < vasarlolista.Count; i++)
             {
                 string termek = vasarlolista[i];
                 if (raktarMennyisegek[i] < 5)
                 {
                     Console.WriteLine($"Kevesebb mint 5 {termek} van a raktárban!");
                 }

             }
        }

        static void Legdragabb()
        {
            int legnagyobb = mennyisegek.Max(x => Convert.ToInt32(x));
            Console.WriteLine($"A legdrágább termék, {legnagyobb}Ft-ba kerül.");
            int index = Array.IndexOf(asdArak, legnagyobb);
            for (int i = 0; i == raktarTermekek.Length-1; i++)
            {
                string termek = vasarlolista[i];
                if (index == i)
                {
                    Console.WriteLine($"Ez pedig a(z) {termek}");
                }

            }
        }

        static void Legolcsobb()
        {
            int legkisebb = mennyisegek.Min(x => Convert.ToInt32(x));
            Console.WriteLine($"A legolcsóbb termék, {legkisebb}Ft-ba kerül.");

            int index = Array.IndexOf(asdArak, legkisebb);
            for (int i = 0; i == raktarTermekek.Length-1; i++)
            {
                string termek = vasarlolista[i];
                if (index == i)
                {
                    Console.WriteLine($"Ez pedig a(z) {termek}");
                }

            }
        }

        static void RaktarTermekFelvetel()
{

            if (asd.Length == 10)
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
                Console.Write("Add meg az árat: ");
                string a = Convert.ToString(Console.ReadLine());
                if (a == "")
                {
                    Console.WriteLine("Az ár mező nem lehet üres");
                    return;
                }
                int ar = Convert.ToInt32(a);

                if (ar < 0)
                {
                    Console.WriteLine("Az ár nem lehet negatív!");
                    return;
                }

                asd.Append(termek);
                raktarMennyisegek.Append(mennyiseg);
                asdArak.Append(ar);
                Console.WriteLine("Termék hozzáadva a bevásárlókosárhoz!");
            }
            else {
                Console.WriteLine("A raktár betelt!");
                return;
            }

        }
        public static void Rendezes()
        {
            Console.WriteLine("\nSorted List");

            List<int> rendezett = new List<int>();

            rendezett =Array.Sort();

            foreach (int g in list1)
            {

                // Display sorted list 
                Console.WriteLine(g);
            }
        }

            
    }

}


