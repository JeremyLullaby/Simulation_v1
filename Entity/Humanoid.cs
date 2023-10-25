using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation_v1
{
    public enum HumanoidGenders { Male, Female }

    internal class Humanoid : Entity
    {
        protected string firstName;
        protected HumanoidGenders gender;


        protected Humanoid()
        {
            gender = random.Next(0, 2) < 1 ? HumanoidGenders.Male : HumanoidGenders.Female;
        }

        public override void Exist()
        {
            base.Exist();

            if (age > 25)
            {
                if (GetQuantityOfHumanoidsByGender(HumanoidGenders.Male) >= 1)
                {
                    if (random.Next(0, 1000) >= 900)
                    {
                        CreateOffspring();
                    }   
                }
            }
        }

        public override string ToString()
        {
            return this.firstName + " " + this.surName;
        }

        protected List<Humanoid> GetCurrentListOfHumanoidEntites()
        {
            List<Entity> list = Program.Entities;
            return list.OfType<Humanoid>().ToList();
        }

        protected int GetQuantityOfHumanoidsByGender(HumanoidGenders gender)
        {
            int quantity = 0;
            foreach(Humanoid humanoid in GetCurrentListOfHumanoidEntites())
            {
                if(humanoid.gender == gender)
                    quantity++;
            }
            return quantity;
        }

    }
}
