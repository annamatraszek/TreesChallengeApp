
namespace TreesChallengeApp
{
    public class Tree 
    {
        public Tree(string parcelNumber, string species)
        {
            this.Parcel = parcelNumber;
            this.Species = species;
        }

        public Tree(string species)
        {
            this.Species = species;
        }
        //public Tree(string species)
        //{
        //    this.Species = species;
        //}

        //public Tree(string parcelNumber)
        // {
        //     this.Parcel = parcelNumber;
        //     //this.Species = "-";
        // } 

        public string Parcel { get; set; }
        public string Species { get; set; }

    }
}
