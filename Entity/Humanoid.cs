using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation_v1
{

    internal class Humanoid : Entity
    {
        public string firstName;


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
                    parentFather = GetMaleFatherEntity(random.Next(0, GetQuantityOfHumanoidsByGender(HumanoidGenders.Male)));
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

        protected Entity GetMaleFatherEntity(int index)
        {
            var currentHumanoids = Program.Entities.Where(o => o.gender == HumanoidGenders.Male);
            Humanoid father = currentHumanoids.ElementAt(index) as Humanoid;
            return father;
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
