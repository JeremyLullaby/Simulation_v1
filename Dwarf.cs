﻿using System;
using System.Collections.Generic;
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


        public Dwarf()
        {
            age = 0;

            firstName = gender == HumanoidGenders.Male ?
                dwarfMaleFirstNames[random.Next(dwarfMaleFirstNames.Length)] :
                dwarfFemaleFirstNames[random.Next(dwarfFemaleFirstNames.Length)];

            surName = dwarfSurNames[random.Next(0, dwarfSurNames.Length)];
        }

        public override void Exist()
        {
            base.Exist();
            //any dwarf special things happening during the exist loop go here
        }

        public override void Action()
        {
            base.Action();

            //sends a string to the entity root function
            CreateNewMessage(this.ToString() + " digs a hole. gender: " + this.gender + " age: " + this.age);
        }

        
    }
}
