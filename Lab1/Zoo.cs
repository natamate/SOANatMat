using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab1
{
    class Zoo : IZoo
    {
        List<Animal> Animals = new List<Animal>();
        string Name;

        public Zoo()
        {
            Animals.Add(new Cat());
            Animals.Add(new Pony(true));
            Animals.Add(new Ant());
            Animals.Add(new Elephant());
            Animals.Add(new Giraffe());
        }

        public string Sounds()
        {
            StringBuilder result = new StringBuilder();
            Animals.ForEach(animal => result.Append(animal.Sound()));
            
            return result.ToString();
        }

        public string FirstOrDefault()
        {
            return Animals.FirstOrDefault().ToString();
        }
    }
}
