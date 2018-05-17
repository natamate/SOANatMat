using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Circus : ICircus
    {
        List<Animal> Animals= new List<Animal>();
        string Name;

        public Circus()
        {
            Animals.Add(new Cat());
            Animals.Add(new Pony(true));
            Animals.Add(new Ant());
            Animals.Add(new Elephant());
            Animals.Add(new Giraffe());

        }

        public string AnimalsIntroduction()
        {
            StringBuilder result = new StringBuilder();

            Animals.ForEach(animal => result.Append(animal));

            return result.ToString();
        }

        public int Patter(int howMuch)
        {
            int result = 0;
            Animals.ForEach(animal => result += animal.CountLegs()*howMuch);
            return result;
        }

        public string Show()
        {
            StringBuilder result = new StringBuilder();

            Animals.ForEach(animal => result.Append(animal.Trick()));

            return result.ToString();
        }

        internal   void ShowPresentation()
        {
            Console.WriteLine("Prezentujemy zwierzeta: ");
            foreach (Animal a in Animals)
            {
                Console.WriteLine(a.Sound() + " " + a.ToString());
            }
        }
    }

    interface ICircus { 
        string AnimalsIntroduction();
        string Show();
        int Patter(int howMuch);
    }

    interface IZoo {
        string Sounds();
    }

}
