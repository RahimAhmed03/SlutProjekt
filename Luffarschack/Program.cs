using System;

namespace Luffarschack
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] spelplan = new char[3, 3];
            
            // initialisering av bordet

            for (int rad = 0; rad < 3; rad++)
            {
                for (int kolumn = 0; kolumn < 3; kolumn++)
                {
                    spelplan[rad, kolumn] = ' ';
                }
            }
            spelplan[0, 0] = 'X';
            spelplan[2, 2] = 'O'; 
            
            // Skriver ut bordet
            for (int rad = 0; rad < 3; rad++)
            {
                Console.Write("| ");
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
