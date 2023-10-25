using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulation_v1
{
    internal class Dwarf : Humanoid
    {
        protected string[] dwarfMaleFirstNames =
{
            "Brakgread",
            "Thromnulir",
            "Rudmeth",
            "Thravaek",
            "Komneath",
            "Hassouck",
            "Thrarseac",
            "Ongruth",
            "Doumdatin",
            "Kostamli",
            "Toremreak",
            "Snarnig",
            "Lolmon",
            "Thistred",
            "Nolgom",
            "Yonur",
            "Broulgramli",
            "Khedeam",
            "Hesin",
            "Brasdrurim",
            "Dhuzael",
            "Nudgric",
            "Hanot",
            "Hezmuc",
            "Weraggon",
            "Kogrous",
            "Baful",
            "Duddarlug",
            "Thraluik",
            "Nudmur",
            "Heznerlug",
            "Lurserlum",
            "Hebot",
            "Grurdorlum",
            "Thrargruk",
            "Thralgrom",
            "Hounatir",
            "Lokkaic",
            "Gralgraeg",
            "Alfokhod"
        };
        protected string[] dwarfFemaleFirstNames =
        {
            "Hawaetrud",
            "Nerrostr",
            "Dandanelynn",
            "Ostuibelyn",
            "Khulgidrid",
            "Denagar",
            "Hatmutelyn",
            "Dalothugrett",
            "Grourdokara",
            "Gabrestr",
            "Fomrusli",
            "Thugnalyn",
            "Thrasdrihulda",
            "Dwozzestr",
            "Groordriwynn",
            "Jorgrena",
            "Bhawidrid",
            "Kondistr",
            "Maldreala",
            "Algabera",
            "Arabaeserd",
            "Thalmaetalyn",
            "Mudgrodeth",
            "Gitalynn",
            "Ruvilyn",
            "Barboure",
            "Thungrugar",
            "Desgritelyn",
            "Werarferra",
            "Werrudrid",
            "Fodmuhilde",
            "Badmubo",
            "Thrakdredrid",
            "Weratrebena",
            "Lorhorika",
            "Goggerika",
            "Grumnougret",
            "Thasaegit",
            "Thradraehilde",
            "Doramegit"
        };
        protected string[] dwarfSurNames =
        {
            "Noblemaker",
            "Shatterborn",
            "Harddigger",
            "Nobleblade",
            "Warmbasher",
            "Chaospike",
            "Bonecloak",
            "Bloodmace",
            "Largebrewer",
            "Greatbelt",
            "Longbuckle",
            "Bitterstone",
            "Wyvernfoot",
            "Frostchest",
            "Darkgut",
            "Bitterforge",
            "Bloodhead",
            "Anvilflayer",
            "Flintmaker",
            "Caverock",
            "Coalfeet",
            "Smeltbrewer",
            "Grayspine",
            "Bottleshaper",
            "Greatrock",
            "Goldenaxe",
            "Brownforged",
            "Cavebasher",
            "Anvilforge",
            "Flintriver",
            "Forgegrip",
            "Mountaincloa",
            "Minefall",
            "Blackforged",
            "Coppertank",
            "Bittertoe",
            "Twilightview",
            "Pebbledigger",
            "Largefury",
            "Grumbleaxe"
        };

        protected int maxOffspringQuantity;


        public Dwarf()
        {
            InitializeDwarf();
        }

        private void InitializeDwarf()
        {
            life = random.Next(1000, 1500);
            age = 0;

            firstName = gender == HumanoidGenders.Male ?
                dwarfMaleFirstNames[random.Next(dwarfMaleFirstNames.Length)] :
                dwarfFemaleFirstNames[random.Next(dwarfFemaleFirstNames.Length)];

            surName = dwarfSurNames[random.Next(0, dwarfSurNames.Length)];

            if (gender == HumanoidGenders.Male) this.CanCreateOffspring = false;
            maxOffspringQuantity = (gender == HumanoidGenders.Male) ? 0 : random.Next(0, 5);

        }

        public override void Exist()
        {
            base.Exist();

            
            if(this.offspringQuantity >= maxOffspringQuantity) { CanCreateOffspring = false; }
            //any dwarf special things happening during the exist loop go here
        }

        public override void Action()
        {
            base.Action();

            //sends a string to the entity root function
            CreateNewMessage(this.ToString() + DetermineAction() + " [blue]Gender: " + this.gender + "[/] [yellow]Age: " + this.age + "[/]" +
                ((life < 100) ? (" [red]Life: " + life + "[/]") : (" Life: " + life)));
        }

        private string DetermineAction()
        {
            string action = "";
            if (random.Next(0, 1000) >= 800)
            {
                switch (this.age)
                {
                    case < 5:
                        action = "plays with a toy.";
                        break;
                    case < 10:
                        action = "learns a new skill.";
                        break;
                    case < 20:
                        action = "gets into a fight.";
                        break;
                    case < 30:
                        action = "aches for adventure.";
                        break;
                    case < 40:
                        action = "thinks about loved ones.";
                        break;
                    case < 50:
                        action = "drinks ale.";
                        break;
                    case < 70:
                        action = "watches guard.";
                        break;
                    case < 90:
                        action = "feels eager for a fight.";
                        break;
                    case < 120:
                        action = "reminisces about childhood.";
                        break;
                    case < 160:
                        action = "complains about thier back.";
                        break;
                    case < 250:
                        action = "is tired.";
                        break;
                }
            }
            else
            {
                action = "digs a hole.";
            }

            return " " + action;
        }

        
    }
}
