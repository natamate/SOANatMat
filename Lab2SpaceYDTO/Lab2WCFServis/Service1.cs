using System;
using System.Collections.Generic;
using System.ServiceModel;
using Lab2SpaceYDTO;

namespace Lab2WCFServis
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        private List<SpaceSystem> _systems = new List<SpaceSystem>(1);

        public void InitializeGame()
        {
            _systems = new List<SpaceSystem>();
            Random rnd = new Random();
            for (int i = 0; i < 4; i++)
            {
                SpaceSystem spaceSystem = new SpaceSystem();
                spaceSystem.MinShipPower = rnd.Next(10, 40);
                spaceSystem.BaseDistance = rnd.Next(20, 120);
                spaceSystem.Gold = rnd.Next(3000, 7000);
                spaceSystem.Name = "system no. " + i;

                _systems.Add(spaceSystem);
            }
        }

        public Starship SendStarship(Starship starship, string systemName)
        {
            foreach (var system in _systems)
            {
                if (system.Name == systemName)
                {
                    if (starship.ShipPower <= 20)
                    {
                        foreach (Person person in starship.Crew)
                        {
                            person.Age = person.Age + (2 * system.BaseDistance) / 12;
                            if (person.Age > 90)
                                starship.Crew.Remove(person);
                        }
                    }
                    else if (starship.ShipPower > 20 && starship.ShipPower <= 30)
                    {
                        foreach (Person person in starship.Crew)
                        {
                            person.Age = person.Age + (2 * system.BaseDistance) / 6;
                            if (person.Age > 90)
                                starship.Crew.Remove(person);
                        }
                    }
                    else if (starship.ShipPower > 30)
                    {
                        foreach (Person person in starship.Crew)
                        {
                            person.Age = person.Age + (2 * system.BaseDistance) / 4;
                            if (person.Age > 90)
                                starship.Crew.Remove(person);
                        }
                    }

                    if (starship.ShipPower >= system.MinShipPower)
                    {
                        starship.Gold = system.Gold;
                        _systems.Remove(system);
                    }

                    return starship;

                }
                else
                {
                    starship.Crew.Clear();
                    return starship;
                }
            }

            return starship;
        }

        public SpaceSystem GetSystem()
        {
            if (_systems != null)
                foreach (var system in _systems)
                {
                    return system;
                }

            return null;
        }

        public Starship GetStarship(int money)
        {

            Starship ship = new Starship();

            List<Person> crew = new List<Person>();
            for (int i = 0; i < 4; i++)
            {
                Person p = new Person();
                p.Age = 20;
                p.Name = "no. " + i;
                p.Nick = i.ToString();

                crew.Add(p);
            }

            ship.Crew = crew;
            Random random = new Random();

            if (money > 1000 && money <= 3000)
                ship.ShipPower = random.Next(10, 25);
            else if (money > 3001 && money <= 10000)
                ship.ShipPower = random.Next(20, 35);
            else if (money > 10000)
                ship.ShipPower = random.Next(35, 60);

            ship.Gold = 0;
            return ship;

        }
    }
}
