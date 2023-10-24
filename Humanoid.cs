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
        protected int generation = 0;
        protected HumanoidGenders gender;

        protected Humanoid()
        {
            gender = random.Next(0, 2) < 1 ? HumanoidGenders.Male : HumanoidGenders.Female;
        }

        public override void Exist()
        {
            base.Exist();
            if (random.Next(0, 1000) >= 900)
            {
                CreateOffspring(); 
            }
        }




        public override string ToString()
        {
            return this.firstName + " " + this.surName;
        }
    }
}
