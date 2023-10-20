
namespace TreesChallengeApp
{
    public abstract class TreeBase : ITrees
    {
        public delegate void HightAddedDelegate(object sender, EventArgs args);

        public abstract event HightAddedDelegate HightAdded;

        public TreeBase(string speciesName)
        {
            this.Species = speciesName;
        }
        

        public string Species { get; private set; }

       
        public abstract void AddHight(int hight);

        public abstract void AddHight(string hight);

        public abstract void AddHight(float hight);

        public abstract void AddHight(double hight);

        public abstract void AddHight(char hight);

        public abstract Statistics GetStatistics()
        
    }
}
