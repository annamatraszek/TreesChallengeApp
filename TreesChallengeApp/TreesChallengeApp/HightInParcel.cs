

using System.Linq;

namespace TreesChallengeApp
{
    public class HightInParcel : TreeBase
    {
        private const string fileName = "hight.txt";

        public override event HightAddedDelegate HightAdded;

        private string treeInParcel;
         

        public HightInParcel(string parcelNumber, string species)
            : base(parcelNumber, species)
        {
            treeInParcel = $"dz_{parcelNumber}_{fileName}";
        }

        public HightInParcel(string parcelNumber)
            : base(parcelNumber, "-")
        {
            treeInParcel = $"dz_{parcelNumber}_{fileName}";
        }



        public override void AddHight(int hight)
        {
            double value = hight;
            this.AddHight(value);
        }

        public override void AddHight(string hight)
        {
            if (double.TryParse(hight, out double result))
            {
                this.AddHight(result);
            }
            else
            {
                throw new Exception("Nieprawidłowy format danych!");
            }
        }

        public override void AddHight(float hight)
        {
            double value = hight;
            this.AddHight(value); ;
        }

        public override void AddHight(double hight)
        {
            if (hight > 0 && hight <= 60)
            {
                using (var writer = File.AppendText(treeInParcel))
                using (var writer2 = File.AppendText($"fullObject.txt"))
                {
                    writer.WriteLine(hight);
                    writer2.WriteLine($"{Parcel} - {Species} - {hight}     -  {DateTime.UtcNow}");
                }

                if (HightAdded != null)
                {
                    HightAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new Exception("Wartość poza dopuszczalnym zakresem!");
            }
        }

        public override void AddHight(char hight)
        {
            throw new NotImplementedException();
        }

        public override Statistics GetStatistics()
        {
            var hightFromFile = this.ReadHightFromFile();
            var result = this.CountStatistics(hightFromFile);
            return result;
        }

        private List<double> ReadHightFromFile()
        {
            var hight = new List<double>();

            if (File.Exists($"{treeInParcel}"))
            {
                using (var reader = File.OpenText($"{treeInParcel}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var h = double.Parse(line);
                        hight.Add(h);
                        line = reader.ReadLine();
                    }
                }
            }
            return hight;
        }

        private Statistics CountStatistics(List<double> hight)
        {
            var statistics = new Statistics();

            foreach (var h in hight)
            {
                statistics.AddHight(h);
            }

            return statistics;
        }

        //public List<string> species = new List<string>();

        //public string SpeciesOnParcel
        //{
        //    get
        //    {
        //        return species;
        //    }
        //}

        //public void AddSpecies(string speciesTree)
        //{
        //    this.species.Add(speciesTree);
        //}

        //public HightInParcel ShowSpecies(List<string> species)
        //{
        //    var speciesTree = new HightInParcel();

        //    foreach (var spec in species)
        //    {
        //       speciesTree.AddSpecies(spec);
        //    }

        //    return speciesTree;
        //}

      
    }
}
