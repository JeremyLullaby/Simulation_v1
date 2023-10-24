using System.Net;

namespace Simulation_v1
{
    internal class Program
    {
        private static int dayCounter = 0;
        public static int DayCounter { get { return dayCounter; } }

        static List<Entity> Entities = new();
        static List<string> EventMessages = new();


        static void Main(string[] args)
        {
            Console.Clear();
            for (int i = 0; i < 2; i++)
            {
                AddEntity(new Dwarf());
            }

            while (true)
            {
                dayCounter++;
                Console.WriteLine("A new day begins!");


                List<Entity> tempEnts = new List<Entity>(Entities);
                foreach (Entity ent in tempEnts)
                {
                    ent.Exist();
                }


                List<string> tempEventMessages = new List<string>(EventMessages);
                foreach (var item in tempEventMessages)
                {
                    Console.WriteLine(item);
                    Thread.Sleep(300);
                }
                lock (EventMessages)
                {
                    EventMessages.Clear(); 
                }



                Thread.Sleep(500);
            }

        }



        public static void AddEntity(Entity entity)
        {
            lock (Entities)
            {
                Entities.Add(entity);
            }
        }

        public static void RemoveEntity(Entity entity)
        {
            lock (Entities)
            {
                Entities.Remove(entity);
            }
        }

        public static void AddEventMessage(string message)
        {
            lock (EventMessages)
            {
                EventMessages.Add(message);
            }
        }
    }
}