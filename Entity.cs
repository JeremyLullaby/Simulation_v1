using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation_v1
{
    public class Entity
    {
        protected Random random= new Random();


        protected int age = 0;
        public int Age { get { return age; } }
        public string surName;



        public delegate void Birth(Entity sender, Entity offspring);
        public event Birth OnBirth;

        public delegate void Death(Entity sender);
        public event Death OnDeath;

        public delegate void Message(Entity sender, string message);
        public event Message OnMessage;




        public Entity()
        {
            //subscribes this entity's Entity_OnMessage() function as a subscriber to the OnMessage event
            this.OnMessage += Entity_OnMessage;
            this.OnBirth += Entity_OnBirth;
        }



        private void Entity_OnMessage(Entity sender, string message)
        {
            Program.AddEventMessage(message);
        }

        private void Entity_OnBirth(Entity sender, Entity offspring)
        {
            Program.AddEntity(offspring);
            CreateNewMessage(sender.ToString() + " gave birth to " + offspring.ToString());
        }

        protected void CreateNewMessage(string message)
        {
            //Fires the OnMessage event to all listeners when CreateNewMessage() is called.
            if (OnMessage != null) OnMessage(this, message);
        }





        public virtual void Exist()
        {
            age++;
            Action();
        }

        public virtual void Action()
        {
        }

        public virtual Type DetermineOffspringType()
        {
            return this.GetType();
        }

        public virtual void CreateOffspring()
        {
            Entity offspring = (Entity)Activator.CreateInstance(DetermineOffspringType());
            offspring.surName = surName;

            if(OnBirth != null) OnBirth(this, offspring);
        }
    }
}
