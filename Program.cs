using System.Net;
using Spectre.Console;

namespace Simulation_v1
{
    internal class Program
    {
        private const int NumberOfRows = 40;
        public static int DayCounter { get { return dayCounter; } }
        private static int dayCounter = 0;

        public static List<Entity> Entities = new();
        public static List<string> EventMessages = new();

        private static ConsoleKeyInfo PauseKeyInfo;



        static void Main(string[] args)
        {
            Console.Clear();
            for (int i = 0; i < 2; i++)
            {
                AddEntity(new Dwarf());
            }

            var table = new Table().LeftAligned().Expand();

            AnsiConsole.Live(table)
                .AutoClear(false)
                .Overflow(VerticalOverflow.Ellipsis)
                .Cropping(VerticalOverflowCropping.Top)
                .Start(ctx =>
                {
                    table.AddColumn("[blue]World Events[/] - Press [yellow]SPACE[/] to simulate!");
                    ctx.Refresh();
                    do
                    {
                        PauseKeyInfo = Console.ReadKey(true);
                        dayCounter++;
                        table.AddRow("[grey]A new day begins![/]");

                        List<Entity> tempEnts = new List<Entity>(Entities);
                        foreach (Entity ent in tempEnts)
                        {
                            ent.Exist();
                        }


                        //TODO - figure out a way to make all messages earn a rating depending on whatever.
                        //as the global rating gets higher (too many messages), it becomes harder for
                        //messages to meet rank requirements, therefore only the most important messages get 
                        //added to the event list.
                        List<string> tempEventMessages = new List<string>(EventMessages);
                        foreach (var item in tempEventMessages)
                        {
                            table.AddRow("-" + item);
                        }
                        table.AddEmptyRow();

                        lock (EventMessages)
                        {
                            EventMessages.Clear();
                        }

                        while (table.Rows.Count > NumberOfRows)
                        {
                            table.RemoveRow(0);
                        }

                        ctx.Refresh();

                        Thread.Sleep(0);
                    }
                    while (PauseKeyInfo.Key == ConsoleKey.Spacebar);
                });

            
        }

        public static List<Entity> GetCurrentEntitiesList()
        {
            return Entities;
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