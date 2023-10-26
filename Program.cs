using System.Net;
using Spectre.Console;

namespace Simulation_v1
{
    internal class Program
    {
        private const int NumberOfRows = 60;
        public static int DayCounter { get { return dayCounter; } }
        private static int dayCounter = 0;

        public static int DepthCounter = 0;

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

            Random rnd = new Random();
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
                        table.AddRow("[grey]Day number:[/] [yellow]" + dayCounter + "[/]");

                        List<Entity> tempEnts = new List<Entity>(Entities);
                        foreach (Entity ent in tempEnts)
                        {
                            ent.Exist();
                        }

                        if (Entities.Count > 0)
                        {
                            DepthCounter += rnd.Next(0, 5);
                            DepthCounter += Entities.Count;
                            if (dayCounter % 5 == 0)
                            {
                                GlobalDepthEventMessage();
                            }
                        }
                        else
                        {
                            if (rnd.Next(0, 1000) > 990)
                            {
                                Dwarf dwarf = new Dwarf();
                                dwarf.SetAge(rnd.Next(20, 100));
                                //dwarf.gender = HumanoidGenders.Male;

                                Dwarf dwarf1 = new Dwarf();
                                dwarf1.SetAge(rnd.Next(20, 100));
                                //dwarf1.gender = HumanoidGenders.Female;

                                AddEntity(dwarf);
                                AddEntity(dwarf1);
                                AddEventMessage("[darkslategray2]- Two vagrant dwarves have discovered your fortress.[/]");
                            }
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

        public static void GlobalDepthEventMessage()
        {
            Random random = new();
            string msg = "";

            if (random.Next(0, 1000) >= 500)
            {
                switch (DepthCounter)
                {
                    case < 50:
                        msg = "The Dwarves are digging a hole that seems small even for children.";
                        break;
                    case < 100:
                        msg = "Maybe if the Dwarves weren't playing with their toys so often, the hole they're digging would be deeper.";
                        break;
                    case < 250:
                        msg = "The Dwarves sure are taking a long time for what should be a [italic]simple[/] task.";
                        break;
                    case < 500:
                        msg = "I thought Dwarves are supposed to be good at digging.";
                        break;
                    case < 1000:
                        msg = "These Dwarves must be half-elf with this quality of hole.";
                        break;
                    case < 1500:
                        msg = "I'm going to be honest with you. It doesn't seem like this hole is going to happen.";
                        break;
                    case < 2500:
                        msg = "Okay, I actually spawned two defective dwarves just to mess with you. I didn't expect them to actually try to dig a hole.";
                        break;
                    case < 6000:
                        msg = "This hole is actually starting to become a tripping hazard.";
                        break;
                    case < 7000:
                        msg = "A goblin tripped and fell into the hole. Congratulations.";
                        break;
                    case < 8000:
                        msg = "The shape of this hole seems familiar.\nThis is my hole! It was made for me!";
                        break;
                    case < 9000:
                        msg = "This hole is getting out of hand.";
                        break;
                    case < 10000:
                        msg = "This hole is becoming a real concern.";
                        break;
                    case < 11000:
                        msg = "Some of the dwarves seem to have gotten lost in the hole.";
                        //call a function to remove some dwarves
                        break;
                }
                msg += "\n-";
            }
            //else
            {
                msg += "The depth counter is: " + DepthCounter;
            }

            AddEventMessage("[bold][rapidblink][darkslategray2]" + msg + "[/][/][/]");
        }
    }
}