using System;
using System.Collections.Generic;

namespace WarOfToCountries
{
    class Program
    {
        static void Main(string[] args)
        {
            Troop troopOne = new Troop(new List<Fighter>(){new Fighter1(), new Fighter2(), new Fighter1(), new Fighter3()});
            Troop troopTwo = new Troop(new List<Fighter>(){new Fighter1(), new Fighter3(), new Fighter3(), new Fighter2()});

            Console.WriteLine("У нас столкнулись два взвода по 5 человек. Кто же победит?");
            void Fight(Fighter fighterFirst, Fighter fighterSecond)
             {
                 int i = 0;
                Console.WriteLine("Да начнется битва!");
                while (fighterFirst.Health > 0 && fighterSecond.Health > 0)
                {
                    if (i % 2 == 0)
                    {
                        fighterSecond.Health -= fighterFirst.GetArmorValue(fighterSecond.Armor);
                    }
                    else
                    {
                        fighterFirst.Health -= fighterSecond.GetArmorValue(fighterFirst.Armor);
                    }
                    i++;
                    Console.WriteLine(fighterFirst.Health);
                    Console.WriteLine(fighterSecond.Health);
                }
                if (fighterFirst.Health != 0)
                {
                    troopTwo.RemoveFighter(fighterSecond);
                    Console.WriteLine("Победил - первый боец");
                }
                else if (fighterSecond.Health != 0)
                {
                    troopOne.RemoveFighter(fighterFirst);
                    Console.WriteLine("Победил - второй боец");
                }
            }

            while (true)
            {
                Fight(troopOne.GetFighter(), troopTwo.GetFighter());
            }
        }

    class Fighter
    {
        public int Health { get; set; }
        public int Damage { get; }
        public int Armor { get; }

        public Fighter()
        {
            Random rand = new Random();
            Health = rand.Next(50, 200);
            Damage = rand.Next(20, 50);
            Armor = rand.Next(5, 20);
        }
        public virtual int GetArmorValue(int armor)
        {
            return Damage - armor;
        }
        public virtual int GetHealfValue(int health)
        {
            return Health - health;
        }
        public virtual int GetDamageValue(int damage)
        {
            return Health - damage;
        }
    }

    class Fighter1 : Fighter
    {
        public override int GetArmorValue(int armor)
        {
            return Damage - armor / 2;
        }
    }

    class Fighter2 : Fighter
    {
        public override int GetHealfValue(int health)
        {
            return Health - health - 25;
        }
    }
    class Fighter3 : Fighter
    {
        public override int GetDamageValue(int damage)
        {
            return Health - damage - 15;
        }
    }

    class Troop
    {
        public List<Fighter> Fighters;

        public Troop(List<Fighter> fighters)
        {
            Fighters = fighters;
        }

        public void RemoveFighter(Fighter fighter)
        {
            Fighters.Remove(fighter);
        }

        public Fighter GetFighter()
        {
            return Fighters[0];
        }
    }
    }
}
