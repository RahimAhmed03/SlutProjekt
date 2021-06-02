using System;

namespace Luffarschack
{
    class Program
    {

        public static char[,] spelplan = new char[3, 3];
        static void Main(string[] args)
        {
            Menu();
        }

        static void Menu()
        {


            char spelare = 'X';
            Initialisera(spelplan);
            int antalDrag = 0;
            string senasteVinnaren = "Ingen har vunnit än";

            Console.WriteLine("Välkommen till Luffarschack och Välja Pjäsen");

            string menyVal = "0";
            while (menyVal != "5")
            {
                Initialisera(spelplan);

                // Skriv ut huvudmenyn
                Console.WriteLine("Välj ett alternativ");
                Console.WriteLine("1. Spela Luffarschack");
                Console.WriteLine("2. Välj Pjäsen");
                Console.WriteLine("3. Visa senaste vinnaren");
                Console.WriteLine("4. Spelets regler");
                Console.WriteLine("5. Avsluta programmet");
                menyVal = Console.ReadLine();


                switch (menyVal)
                {
                    case "1":
                        // Spelet körs tills Vinst/Förlöst/Oavgjort
                        while (true)
                        {
                            Console.Clear();
                            SkrivUtSpelplan(spelplan);
                            SpelarDrag(spelare, spelplan);

                            // Kolla ifall användaren vinner
                            if ((spelare == spelplan[0, 0] && spelare == spelplan[0, 1] && spelare == spelplan[0, 2]) ||
                            (spelare == spelplan[1, 0] && spelare == spelplan[1, 1] && spelare == spelplan[1, 2]) ||
                            (spelare == spelplan[2, 0] && spelare == spelplan[2, 1] && spelare == spelplan[2, 2]) ||
                            (spelare == spelplan[0, 0] && spelare == spelplan[1, 0] && spelare == spelplan[2, 0]) ||
                            (spelare == spelplan[0, 1] && spelare == spelplan[1, 1] && spelare == spelplan[2, 1]) ||
                            (spelare == spelplan[0, 2] && spelare == spelplan[1, 2] && spelare == spelplan[2, 2]) ||
                            (spelare == spelplan[0, 0] && spelare == spelplan[1, 1] && spelare == spelplan[2, 2]) ||
                            (spelare == spelplan[0, 2] && spelare == spelplan[1, 1] && spelare == spelplan[2, 0]))

                            {
                                // konsolen kommer bli rensad och sista spelplanen skrivs ut och därefter kommer det en vinsttext och användaren blir frågad om att skriva in ens namn
                                Console.Clear();
                                SkrivUtSpelplan(spelplan);
                                Random rnd = new Random();
                                string[] Vinst = { "Grattis för vinsten du förtjänar en paus", "Du är ju grym, Du borde gå med i proffs turnering", "Det är omöjligt du hackar!" };
                                int slumpMässig = rnd.Next(0, 3);
                                string VinstText = Vinst[slumpMässig];
                                Console.WriteLine(VinstText);
                                Console.WriteLine(spelare + " har vunnit spelet!");
                                Console.WriteLine("Skriv in ditt namn");
                                senasteVinnaren = Console.ReadLine();
                                break;

                            }

                            antalDrag = antalDrag + 1;

                            // ifall det blir 9 drag så har det blivit oavgjort och då får de börja om ifall de vill
                            if (antalDrag == 9)
                            {
                                Console.Clear();
                                SkrivUtSpelplan(spelplan);
                                Console.WriteLine("Oavgjort");
                                break;

                            }
                            // tur ändras efter varje drag
                            spelare = ÄndraTur(spelare);



                        }


                        break;


                    case "2":
                        // Ställer fråga
                        Fråga(pjäser);
                        break;




                    // Visa senaste vinnaren
                    case "3":
                        Console.WriteLine($"Senaste vinnaren: {senasteVinnaren}");
                        break;

                    // Visa spelets regler
                    case "4":
                        SkrivUtSpelregler();
                        break;

                    // Gör ingenting (programmet avslutas)
                    case "5":
                        break;

                    // ifall användaren inte väljer ett giltigt val så får de börja om
                    default:
                        Console.WriteLine("Du valde inte ett giltigt alternativ");
                        break;

                }
            }
        }

        public static string[] pjäser = FåPjäser();
        public static string[] Fråga(string[] array)
        {
            Console.WriteLine("Välj en av dessa pjäser");
            // Loopar igenom Arrayen
            for (int i = 0; i < pjäser.Length; i++)
            {
                Console.WriteLine(i + 1 + "." + pjäser[i]);
            }

            // Gör svaret till en int som blir int arrayIndex
            int ArrayIndex;
            while (!int.TryParse(Console.ReadLine(), out ArrayIndex) || ArrayIndex < 0 || ArrayIndex > 6)
            {
                Console.WriteLine("Du skrev inte ett tal mellan 1-6- Försök igen!");
            }


            return array;
        }
        public static int ArrayIndex(int arrayIndex)
        {
            // Skriver ut vilken pjäs so användaren valde
            string pjäs = pjäser[arrayIndex - 1];
            Console.WriteLine($"Du har valt {pjäs}");
            return arrayIndex;
        }
        static string[] FåPjäser()
        {
            // Returneras arrayen
            return new[] { "Kung", "Dam", "Torn", "Löpare", "Springare", "Bonde" };
        }








        /// <summary>
        /// initialisering av spelplan
        /// </summary>
        /// <param name="spelplan"></param>
        static void Initialisera(char[,] spelplan)
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
        static void SkrivUtSpelplan(char[,] spelplan)
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
        /// <summary>
        /// spelare ändras ifall det inte har vunnit eller blivit oavgjort
        /// </summary>
        /// <param name="nuvarandeSpelare"></param>
        /// <returns> antingen returneras X eller O </returns>
        static char ÄndraTur(char nuvarandeSpelare)
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
        /// <summary>
        /// Spelare frågas om en rad att välja sedan en kolumn och då placeras antingen X eller O
        /// </summary>
        /// <param name="spelare"></param>
        /// <param name="spelplan"></param>
        static void SpelarDrag(char spelare, char[,] spelplan)
        {


            Console.Write(spelare + " Snälla ange en rad: ");

            int rad;
            while (!int.TryParse(Console.ReadLine(), out rad) || rad < 0 || rad > 2)
            {
                Console.WriteLine("Du skrev inte tal mellan 0-2. Försök igen!");
            }

            Console.Write(spelare + " Snälla ange en kolumn: ");

            int kolumn;
            while (!int.TryParse(Console.ReadLine(), out kolumn) || kolumn < 0 || kolumn > 2)
            {
                Console.WriteLine("Du skrev inte tal mellan 0-2 försök igen!");
            }



            spelplan[rad, kolumn] = spelare;

        }

        // Skriver ut spelreglerna för luffarschack
        static void SkrivUtSpelregler()
        {
            Console.WriteLine(" Tre-i-rad eller tripp trapp trull är en variant av luffarschack som spelas på en spelplan med endast 3*3 rutor, och syftet är sålunda att få tre lika i rad. ");
            Console.WriteLine(" Det är ett mycket lättspelat spel och är ett av världens populäraste brädspel som kan spelas på ett papper med en spelplan med nio rutor i en kvadrat. ");
            Console.WriteLine(" Spelet går ut på att ställa ut sina tre markeringar (X eller O) så att man får tre i rad, antingen lodrätt, vågrätt, eller diagonalt. ");
            Console.WriteLine(" För att spelet ska bli klurigare kan man spela med tidsbegränsningar, till exempel 10 sekunder per drag. ");

        }
    }
}

