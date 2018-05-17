using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.ServiceReference1;

namespace ConsoleApp1
{
    class Program
    {
        List<Starship> _starships = new List<Starship>();
        static bool _anySystem = true;
        static int _gold = 900;
        static int _imperiumMoneyAskCount = 5;
        private static ServiceReference1.IService1 channel;
        private static ServiceReference2.Service1Client firstOrder;

        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(ServiceReference1.Service1Client));

            ChannelFactory<ServiceReference1.IService1> cf = new ChannelFactory<ServiceReference1
            .IService1>("WSHttpBinding_IService");
            //    .IService1>("BasicHttpBinding_IService");
            channel = cf.CreateChannel();

            firstOrder = new ServiceReference2.
            //Service1Client("WSHttpBinding_IService1");
               Service1Client("BasicHttpBinding_IService11");
            int moneu = firstOrder.GetMoneyFromImperium();
            channel.InitializeGame();

            try
            {
                char input = '0';
                Program p = new Program();

                while (input != '4')
                {
                    p.PrintMenu();
                    input = System.Console.ReadKey().KeyChar;
                    System.Console.WriteLine();

                    switch (input)
                    {
                        case '1':
                            {
                                p.AskImperiumAboutGold();
                                break;
                            }
                        case '2':
                            {
                                p.BuyShipForGold();
                                break;
                            }
                        case '3':
                            {
                                p.SendShip();
                                break;
                            }
                        case '4':
                            {
                                if (_anySystem == false)
                                    System.Console.WriteLine("Victory!");
                                else
                                {
                                    System.Console.WriteLine("You lose");
                                }

                                break;
                            }

                    }
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                host.Abort();
            }
        }

        private void PrintMenu()
        {
            System.Console.WriteLine("Gold: " + _gold);
            System.Console.WriteLine("Amount of ask to imperium: " + _imperiumMoneyAskCount);
            if (_imperiumMoneyAskCount > 0)
                System.Console.WriteLine("Poproś imperium o złoto >>> 1");
            System.Console.WriteLine("Kup statek za złoto >>> 2");
            System.Console.WriteLine("Wyślij statek do systemu >>> 3");
            System.Console.WriteLine("Zakończ grę >>> 4");
        }

        private void AskImperiumAboutGold()
        {
            if (_imperiumMoneyAskCount > 0)
            {
                _gold += firstOrder.GetMoneyFromImperium();
                _imperiumMoneyAskCount -= 1;
            }
            else
            {
                System.Console.WriteLine("Ask is disabled");
            }
        }

        private void BuyShipForGold()
        {
            System.Console.WriteLine("Current gold: {0} Put how much you want to pay for ship ? ", _gold);
            int number;
            string input = System.Console.ReadLine();
            while (!Int32.TryParse(input, out number))
            {
                System.Console.WriteLine("The amount is incorrect. Please put number: ");
                input = System.Console.ReadLine();
            }

            if (number < 0 || number > _gold)
            {
                System.Console.WriteLine("The amount is not allowed. Transaction cancelled");
                return;
            }

            _starships.Add(channel.GetStarship(number));
            _gold -= number;
            System.Console.WriteLine("Transaction succesfully");
        }

        private void SendShip()
        {
            SpaceSystem system = channel.GetSystem();

            if (system == null)
            {
                _anySystem = false;
                return;
            }

            if (_starships.Count == 0)
            {
                return;
            }

            System.Console.WriteLine("System {0}, distance {1}", system.Name,
                system.BaseDistance);
            if (_starships.Count == 0)
            {
                return;
            }

            System.Console.WriteLine("Count of ships which are ready for trip: {0}", _starships.Count);

            System.Console.WriteLine("Choose ship: put number or if you want to exit press e ");
            System.Console.WriteLine();
            int counter = 0;
            List<Person> crew;
            foreach (var ship in _starships)
            {
                System.Console.WriteLine(counter++ + ". " + ship.ShipPower + " ");
                crew = ship.Crew.ToList();
                foreach (var person in crew)
                {
                    System.Console.Write(person.Name + " " + person.Nick + " " + person.Age + " ");
                }

                System.Console.WriteLine();
                System.Console.WriteLine();
            }

            char input = System.Console.ReadKey().KeyChar;
            if (input == 'e')
                return;
            int number;

            if (Int32.TryParse(input.ToString(), out number) && number >= 0 && number < _starships.Count)
            {
               Console.WriteLine("_Starsips " + _starships[number].ShipPower + " " + _starships[number].Gold);
                Starship newShip = channel.SendStarship(_starships[number], system.Name);
                _starships.RemoveAt(number);
                if (newShip.Gold != 0)

                {
                    _gold += newShip.Gold;
                    newShip.Gold = 0;

                }

                if (newShip.Crew.Length > 0)
                    _starships.Add(newShip);
            }
        }
    }
}
