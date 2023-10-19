
using static TreesChallengeApp.TreeBase;

namespace TreesChallengeApp
{
    public interface ITrees
    {
     
        public string Species { get;}
    
        void AddHight(int hight);
        void AddHight(string hight);
        void AddHight(float hight);
        void AddHight(double hight);
        void AddHight(char hight);

        event HightAddedDelegate HightAdded;

        //Statistics GetStatistics();
    }
}
