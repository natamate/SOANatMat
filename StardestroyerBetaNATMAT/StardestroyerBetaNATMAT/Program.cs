using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using StardestroyerBetaNATMAT.ServiceReference1;

namespace StardestroyerBetaNATMAT
{
    class Program
    {
        private static ServiceReference1.IService1 channel;

        static void Main(string[] args)
        {
            ChannelFactory<ServiceReference1.IService1> cf = new ChannelFactory<ServiceReference1
                .IService1>("WSHttpBinding_IService");
            channel = cf.CreateChannel();

            try
            {
                char input = '0';


                while (input != '4')
                {
                    PrintMenu();
                    input = System.Console.ReadKey().KeyChar;
                    System.Console.WriteLine();

                    switch (input)
                    {
                        case '1':
                        {
                            System.Console.WriteLine("Podaj nazwe: " );
                            var name = System.Console.ReadLine();
                            System.Console.WriteLine("Podaj moc: ");
                            int power;
                            string inputt = System.Console.ReadLine();
                            while (!Int32.TryParse(inputt, out power))
                            {
                                System.Console.WriteLine("The amount is incorrect. Please put number: ");
                                inputt = System.Console.ReadLine();
                            }
                            System.Console.WriteLine("Podaj Shield: ");
                            int shield;
                            inputt = System.Console.ReadLine();
                            while (!Int32.TryParse(inputt, out shield))
                            {
                                System.Console.WriteLine("The amount is incorrect. Please put number: ");
                                inputt = System.Console.ReadLine();
                            }
                            channel.CreateWing(new Wing()
                                {
                                    Name = name,
                                    Power = power,
                                    Shield = shield
                                });
                            break;
                        }
                        case '2':
                        {
                            System.Console.WriteLine("Podaj nazwe: ");
                            var name = System.Console.ReadLine();
                            System.Console.WriteLine("Power: " + channel.GetWing(name).Power + "Shield" + channel.GetWing(name).Shield);
                            break;
                        }

                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
            }
        }

        private static void PrintMenu()
        {
            System.Console.WriteLine("Dodaj wiatr >>> 1");
            System.Console.WriteLine("Pobierz dane o wiatr >>> 2");
            System.Console.WriteLine("Zakończ grę >>> 4");
        }


    }
}
