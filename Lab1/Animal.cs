using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class Animal
    {
        string Name = "it hasn't name yet!";
        float Weight;
        bool HasFur;

        public virtual string Sound()
        {
            return Name;
        }

        public virtual string Trick()
        {
            return "Nie ma sztuczki!";
        }

        public virtual int CountLegs()
        {
            return 0;
        }
    }

    class Cat : Animal
    {
        string Color;

        public override string Sound()
        {
            return "Miau...";
        }

        public override string Trick()
        {
            return base.Trick();
        }

        public override int CountLegs()
        {
            return 4;
        }
    }

    class Pony : Animal
    {
        bool IsMagic;

        public Pony(Boolean IsMagic)
        {
            this.IsMagic = IsMagic;
        }

        public override string Sound()
        {
            return "Iiiaaa?...";
        }

        public override string Trick()
        {
            if (IsMagic)
                return "Jest magiczny!";
            else
                return "jje siano ";
        }

        public override int CountLegs()
        {
            return 4;
        }

    }

    class Ant : Animal
    {
        bool IsQueen;
    }

    class Elephant : Animal
    {

    }

    class Giraffe : Animal
    {

    }
}
