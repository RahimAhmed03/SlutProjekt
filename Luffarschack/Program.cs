using System;

namespace Luffarschack
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] spelplan = new char[3,3];
            spelplan[0, 0] = 'X';
            spelplan[2, 2] = 'O'; 
            
            for (int row = 0; row < 3; row++)
            {
                for (int kolumn = 0; kolumn < 3; kolumn++)
                {
                    Console.Write("|   | X |   |");
                }
                Console.WriteLine();
            }
        }
    }
}
