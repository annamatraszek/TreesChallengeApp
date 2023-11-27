

namespace TreesChallengeApp
{
    public class HightInParcel : TreeBase
    {
        private const string fileName = "hight.txt";

        public override event HightAddedDelegate HightAdded;

        private string treeInParcel;
         

        //public void AddSpeciesTree();
        public List<string> speciesTrees = new List<string>();
        
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
        

        public void AddToListSpeciesTree()
        {
            this.speciesTrees.Add(Species);
        }

       



        //private List<string> ShowListSpeciesTree()
        //{
        //    var spec = new List<string>(speciesTrees);
        //    string result = null;
        //    foreach (var s in spec)
        //    {
        //        result += s;
        //        string t = result;
        //    }
                 
        //    return result;
        //}

        //var t = new HightInParcel.resultList; 

        //public HightInParcel ShowListSpeciesTrees(List<string> speciesTrees)
        //{
        //    var spec = new List<string>();
        //    //var result = this.specTrees(speciesTrees);
        //    //string result = null;
        //    foreach (var spec in speciesTrees)
        //    {
        //        Console.WriteLine(spec);
        //    }

        //this.speciesTrees = List<string> speciesTrees;
        //return specTrees;


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

        
    }
}
