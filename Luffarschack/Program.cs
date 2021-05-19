using System;

namespace Luffarschack
{
    class Program
    {
        static void Main(string[] args)
        {
            char spelare = 'X';
            char[,] spelplan = new char[3, 3];
            initialisera(spelplan);
            int antalDrag = 0;
            string senasteVinnaren = "Ingen har vunnit än";

            Console.WriteLine("Välkommen till Luffarschack");

            string menyVal = "0";
            while (menyVal != "4")
            {
                initialisera(spelplan);

                // Skriv ut huvudmenyn
                Console.WriteLine("Välj ett alternativ");
                Console.WriteLine("1. Spela Luffarschack");
                Console.WriteLine("2. Visa senaste vinnaren");
                Console.WriteLine("3. Spelets regler");
                Console.WriteLine("4. Avsluta programmet");
                menyVal = Console.ReadLine();


                switch (menyVal)
                {
                    case "1":
                        // Spelet körs tills Vinst/Förlöst/Oavgjort
                        while (true)
                        {
                            Console.Clear();
                            skrivut(spelplan);

                            Console.Write(spelare + " Snälla ange en rad: ");
                            

                            int rad;
                            if (int.TryParse(Console.ReadLine(), out rad))
                            {
                                Console.WriteLine("Det funkade");
                            }
                            else
                            {
                                Console.WriteLine("försök igen");
                            }
                            Console.Write(spelare + " Snälla ange en kolumn: ");
                           

                            int kolumn;
                            if (int.TryParse(Console.ReadLine(), out kolumn))
                            {
                                Console.WriteLine("Det funkade");
                            }
                            else
                            {
                                Console.WriteLine("försök igen");
                            }


                            spelplan[rad, kolumn] = spelare;

                            // Kolla ifall vi vinner
                            if ((spelare == spelplan[0, 0] && spelare == spelplan[0, 1] && spelare == spelplan[0, 2]) ||
                            (spelare == spelplan[1, 0] && spelare == spelplan[1, 1] && spelare == spelplan[1, 2]) ||
                            (spelare == spelplan[2, 0] && spelare == spelplan[2, 1] && spelare == spelplan[2, 2]) ||
                            (spelare == spelplan[0, 0] && spelare == spelplan[1, 0] && spelare == spelplan[2, 0]) ||
                            (spelare == spelplan[0, 1] && spelare == spelplan[1, 1] && spelare == spelplan[2, 1]) ||
                            (spelare == spelplan[0, 2] && spelare == spelplan[1, 2] && spelare == spelplan[2, 2]) ||
                            (spelare == spelplan[0, 0] && spelare == spelplan[1, 1] && spelare == spelplan[2, 2]) ||
                            (spelare == spelplan[0, 2] && spelare == spelplan[1, 1] && spelare == spelplan[2, 0]))

                            {
                                Console.WriteLine(spelare + " har vunnit spelet!");
                                Console.WriteLine("Skriv in ditt namn");
                                senasteVinnaren = Console.ReadLine();
                                break;
                            }

                            antalDrag = antalDrag + 1;

                            if (antalDrag == 9)
                            {
                                Console.WriteLine("DRAW");
                                break;

                            }

                            spelare = Ändratur(spelare);



                        }
                        static char Ändratur(char nuvarandeSpelare)
                        {
                            if (nuvarandeSpelare == 'X')
                            {
                                return 'O';
                            }
                            else
                            {
                                return 'X';
                            }
                        }
                        break;

                    // Visa senaste vinnaren
                    case "2":
                        Console.WriteLine($"Senaste vinnaren: {senasteVinnaren}");
                        break;

                    // Visa spelets regler
                    case "3":
                        Console.WriteLine(" Tre-i-rad eller tripp trapp trull är en variant av luffarschack som spelas på en spelplan med endast 3*3 rutor, och syftet är sålunda att få tre lika i rad. ");
                        Console.WriteLine(" Det är ett mycket lättspelat spel och är ett av världens populäraste brädspel som kan spelas på ett papper med en spelplan med nio rutor i en kvadrat. ");
                        Console.WriteLine(" Spelet går ut på att ställa ut eller flytta sina tre markeringar (X eller O) så att man får tre i rad, antingen lodrätt, vågrätt, eller diagonalt. ");
                        Console.WriteLine(" För att spelet ska bli klurigare kan man spela med tidsbegränsningar, till exempel 10 sekunder per drag. ");
                        break;

                    // Gör ingenting (programmet avslutas)
                    case "4":
                        break;

                    default:
                        Console.WriteLine("Du valde inte ett giltigt alternativ");
                        break;

                }
            }

            /// <summary>
            /// initialisering av spelplan
            /// </summary>
            /// <param name="spelplan"></param>
            static void initialisera(char[,] spelplan)
            {
                for (int rad = 0; rad < 3; rad++)
                {
                    for (int kolumn = 0; kolumn < 3; kolumn++)
                    {
                        spelplan[rad, kolumn] = ' ';
                    }
                }
            }

            /// <summary>
            /// Skriver ut spelplan
            /// </summary>
            /// <param name="spelplan"></param>
            static void skrivut(char[,] spelplan)
            {
                Console.WriteLine("  | 0 | 1 | 2 |  ");
                for (int rad = 0; rad < 3; rad++)
                {
                    Console.Write(rad + " | ");
                    for (int kolumn = 0; kolumn < 3; kolumn++)
                    {
                        Console.Write(spelplan[rad, kolumn]);
                        Console.Write(" | ");
                    }
                    Console.WriteLine();
                }
            }




        }

    }
}
