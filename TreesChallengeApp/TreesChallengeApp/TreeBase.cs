﻿
namespace TreesChallengeApp
{
    public abstract class TreeBase : Tree,  ITrees
    {
        public delegate void HightAddedDelegate(object sender, EventArgs args);

        public abstract event HightAddedDelegate HightAdded;

        public TreeBase(string parcelNumber, string species)
            : base(parcelNumber, species)
        { 

        }

        public TreeBase(string parcelNumber)
            : base(parcelNumber, "-")
        {

        }

       


        public abstract void AddHight(int hight);

        public abstract void AddHight(string hight);

        public abstract void AddHight(float hight);

        public abstract void AddHight(double hight);

        public abstract void AddHight(char hight);

        //public abstract void ShowListSpeciesTrees();

        public abstract Statistics GetStatistics();

        

    }
}
