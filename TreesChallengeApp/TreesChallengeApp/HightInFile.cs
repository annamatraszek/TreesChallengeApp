
namespace TreesChallengeApp 
{
    public class HightInFile : TreeBase
    {
        private const string fileName = "Wysokosci_drzew.txt";


        //public HightInFile(int hight) : base(hight)
        //{
        //}

        public HightInFile(string speciesName) 
            : base(speciesName)
        {
        }

        //public int Hight { get; private set; }

      // public string Species { get; set; }

        //public override void AddSpecies(string species)
        //{
        //    throw new NotImplementedException();
        //}

        public override void AddHight(int hight)
        {
            if (hight > 0 && hight <= 60)
            {
                using (var writer = File.AppendText(fileName))
                {
                    writer.WriteLine(hight);
                }

                //if (HightAdded != null)
                //{
                //    HightAdded(this, new EventArgs());
                //}
            }
            else
            {
                throw new Exception("Nieprawidłowa wartość! Proszę podać wysokość w zaokrągleniu do 1 m.");
            }
        }

        public override void AddHight(string hight)
        {
            if (int.TryParse(hight, out int result))
            {
                this.AddHight(result);
            }
            else
            {
                throw new Exception("Nieprawidłowy format danych!");
            }
        }


    }
}
