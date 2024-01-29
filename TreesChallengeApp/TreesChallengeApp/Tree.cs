
using System.Linq;

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

        public Tree()
        {
        }

        public string Parcel { get; set; }
        public string Species { get; set; }



        public List<string> species = new List<string>();

        public string SpeciesOnParcel
        {

            get
            {
                return this.species.ToList();
            }
        }

        public void AddSpecies(string speciesTree)
        {
            this.species.Add(speciesTree);
        }

        public Tree ShowSpecies(List<string> species)
        {
            var speciesTree = new Tree();

            foreach (var spec in species)
            {
                speciesTree.AddSpecies(spec);
            }

            return speciesTree;
        }
    }
}
