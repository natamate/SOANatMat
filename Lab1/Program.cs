using System;

namespace Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Circus cyrk = new Circus();
            Zoo zoo = new Zoo();

            Console.WriteLine("Program ze zwierzatkami...");

            int number = 0;
            string input;

            while (number != 9)
            {
                Console.WriteLine("Prezentacja Zwierząt w cyrku >> 1");
                Console.WriteLine("Obejrzenie programu cyrku >>    2");
                Console.WriteLine("Posłuchanie dźwięków Zoo >>     3");
                Console.WriteLine("Wyświetla imię pierwszego znalezionego futrzaka w Zoo >> 4");
                Console.WriteLine(" wyświetla wszystkie imiona zwierząt w Cyrku >>          5");
                Console.WriteLine(" Jesli chcesz wyjść         >>                           9");

                input = Console.ReadLine();

                Int32.TryParse(input, out number);

                switch (number)
                {
                    case 1:
                        cyrk.ShowPresentation();
                        break;
                    case 2:
                        Console.WriteLine(cyrk.Show());
                        break;
                    case 3:
                        Console.WriteLine(zoo.Sounds());
                        break;
                    case 4:
                        Console.WriteLine("First animal is: " + zoo.FirstOrDefault());
                        break;
                    case 5:
                        Console.WriteLine(cyrk.AnimalsIntroduction());
                        break;

                }
            }
        }
    }
}
