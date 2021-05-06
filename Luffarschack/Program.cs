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

            spelplan[0, 0] = spelare;
            spelare = 'O';
            spelplan[2, 2] = spelare;
            spelare = 'X';

            while (true)
            {
                Console.Clear();
                skrivut(spelplan);

                Console.Write("Snälla ange en rad: ");
                int rad = Convert.ToInt32(Console.ReadLine());
                Console.Write("Snälla ange en kolumn: ");
                int kolumn = Convert.ToInt32(Console.ReadLine());

                spelplan[rad, kolumn] = spelare;

                if (spelare == 'X')
                {
                    spelare = 'O';
                }
                else
                {
                    spelare = 'X';
                }

            }

        }

        /// <summary>
        /// initialisering av spelplanet
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
        /// Skriver ut spelplanet
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
