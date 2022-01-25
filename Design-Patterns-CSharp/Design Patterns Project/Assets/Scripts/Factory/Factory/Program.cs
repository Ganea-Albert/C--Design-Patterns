using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethod
{
    class MainApp
    {
        static void Main()
        {
            Attack[] attacks = new Attack[2];

            attacks[0] = new Physical();
            attacks[1] = new Magical();

            // Display amount of attacks

            foreach (Attack attack in attacks)
            {
                Console.WriteLine("\n" + attacks.GetType().Name + "--");
                foreach(Skill skill in attack.Skills)
                {
                    Console.WriteLine(" " + skill.GetType().Name);
                }
            }

            Console.ReadKey();
        }
    }


    abstract class Skill
    {
    }

    class PhysicalRanged : Skill
    {
    }

    class PhysicalMelee : Skill
    {
    }

    class PhysicalBuffs : Skill
    {
    }

    class MagicalAttacks : Skill
    {
    }

    class MagicalSupportBuffs : Skill
    {
    }

    class MagicalHealing : Skill
    {
    }

    abstract class Attack
    {
        private List<Skill> _skills = new List<Skill>();

        public Attack()
        {
            this.CreateSkills();
        }

        public List<Skill> Skills
        {
            get { return _skills;  }
        }

        public abstract void CreateSkills();
    }

    class Physical : Attack
    {
        public override void CreateSkills()
        {
            Skills.Add(new PhysicalRanged());
            Skills.Add(new PhysicalMelee());
            Skills.Add(new PhysicalBuffs());
        }
    }
    class Magical : Attack
    {
        public override void CreateSkills()
        {
            Skills.Add(new MagicalAttacks());
            Skills.Add(new MagicalHealing());
            Skills.Add(new MagicalSupportBuffs());
        }
    }

}
