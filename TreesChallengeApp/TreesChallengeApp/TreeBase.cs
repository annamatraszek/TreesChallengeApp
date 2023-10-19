
namespace TreesChallengeApp
{
    public abstract class TreeBase : ITrees
    {
        public TreeBase(string speciesName)
        {
            this.Species = speciesName;
        }
        //public TreeBase(int hight)
        //{
        //    this.Hight = hight;
        //}

        public string Species { get; private set; }

        //public int Hight { get; private set; }

        public abstract void AddHight(int hight);

        public abstract void AddHight(string hight);
        
        // public abstract void AddSpecies(string species);

    }
}
