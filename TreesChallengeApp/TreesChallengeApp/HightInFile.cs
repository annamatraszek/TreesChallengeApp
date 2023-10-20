
using System.Diagnostics;

namespace TreesChallengeApp 
{
    public class HightInFile : TreeBase
    {
        private const string fileName = "Wysokosci_drzew.txt";

        public override event HightAddedDelegate HightAdded;

        public HightInFile(string speciesName) 
            : base(speciesName)
        {
        }

       
        public override void AddHight(double hight)
        {
            if (hight > 0 && hight <= 60)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(hight);
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

        public override void AddHight(int hight)
        {
            double value = hight;   
            this.AddHight(value);
        }

        public override void AddHight(char hight)
        {
            throw new NotImplementedException();
        }

        //public override Statistics GetStatistics()
        //{
        //    var hightFromFile = this.ReadHightFromFile();
        //    var result = this.CountStatistics(hightFromFile);
        //    return result;
        //}


        private List<double> ReadHightFromFile()
        {
            var hight = new List<double>();

            if (File.Exists($"{fileName}"))
            {
                using (var reader = File.OpenText($"{fileName}"))
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

        public override Statistics GetStatistics()
        {
            var hightFromFile = this.ReadHightFromFile();
            var result = this.CountStatistics(hightFromFile);
            return result;
        }
    }
}
