using System;
using System.Collections.Generic;
using System.Text;

namespace NikosPetShop.Core.Entity
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Species TypeOfSpecies { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime SoldDate { get; set; }
        public string Color { get; set; }
        public string PreviousOwner { get; set; }
        public double Price { get; set; }
    }

    public enum Species {Dog, Cat, Tarantula, Cobra, Mouse,
        Hamster, Rabbit, Chinchillas, Guinea_Pig, Piglet}
}
