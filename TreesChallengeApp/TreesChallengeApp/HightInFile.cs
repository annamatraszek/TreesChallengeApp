
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
            this.AddHight(hight);
        }

        public override void AddHight(int hight)
        {
            this.AddHight(hight);
        }

        public override void AddHight(char hight)
        {
            throw new NotImplementedException();
        }
    }
}
