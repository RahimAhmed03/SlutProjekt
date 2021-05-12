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

            // Spelet körs tills Vinst/Förlöst/Oavgjort
            while (true)
            {
                Console.Clear();
                skrivut(spelplan);

                Console.Write("Snälla ange en rad: ");
                int rad = Convert.ToInt32(Console.ReadLine());
                Console.Write("Snälla ange en kolumn: ");
                int kolumn = Convert.ToInt32(Console.ReadLine());

                spelplan[rad, kolumn] = spelare;

                // Kolla ifall vi vinner
                if (spelare == spelplan[0,0] && spelare == spelplan[0,1] && spelare == spelplan[0,2])
                {
                    Console.WriteLine(spelare + " har vunnit spelet!");
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

        }

        static char Ändratur(char nuvarandeSpelare)
        {
            if (nuvarandeSpelare == 'X')
            {
                return 'O';
            }
            else
            {
                return   'X';
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
