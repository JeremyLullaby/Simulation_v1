using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation_v1
{
    public enum HumanoidGenders { Male, Female }


    public class Entity
    {
        protected Random random= new Random();

        public int Life { get { return life; } }
        protected int life;

        public int Age { get { return age; } }
        protected int age = 0;

        public Entity parentMother;
        public Entity parentFather;
        public string surName;

        protected int generation = 0;

        public HumanoidGenders gender;


        protected bool CanCreateOffspring = true;
        protected int offspringQuantity = 0;




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
            this.OnDeath += Entity_OnDeath;
        }



        private void Entity_OnMessage(Entity sender, string message)
        {
            Program.AddEventMessage(message);
        }

        private void Entity_OnBirth(Entity sender, Entity offspring)
        {
            Program.AddEntity(offspring);
            CreateNewMessage("[yellow]" + sender.ToString() + " gave birth to [green]" + offspring.ToString() + "[/]" +
                "\n - " + ((offspring as Humanoid).gender == HumanoidGenders.Male ? "His" : "Her") + " father is " + parentFather + "." +
                "[/]");
        }

        private void Entity_OnDeath(Entity sender)
        {
            Program.RemoveEntity(sender);
            CreateNewMessage("[red]" + sender.ToString() + " has died.[/]");
        }

        protected void CreateNewMessage(string message)
        {
            //Fires the OnMessage event to all listeners when CreateNewMessage() is called.
            if (OnMessage != null) OnMessage(this, message);
        }





        public virtual void Exist()
        {
            if(Program.DayCounter % 5 == 0)
            {
                age++;
            }

            life--;
            if(life <= 0)
            {
                Entity_OnDeath(this);
            }

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
            if (CanCreateOffspring == false)
            {
                if (this.gender == HumanoidGenders.Male) return;
                CreateNewMessage("[underline]" + this.ToString() + " tries to have a child, but can not.[/]");
                return;
            }
            Entity offspring = (Entity)Activator.CreateInstance(DetermineOffspringType());
            offspring.parentMother = this;
            offspring.surName = parentFather.surName;
            offspring.generation = generation + 1;
            this.offspringQuantity++;

            if(OnBirth != null) OnBirth(this, offspring);
        }

        public void SetAge(int age)
        {
            this.age = age;
        }
    }
}
