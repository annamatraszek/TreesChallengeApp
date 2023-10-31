
namespace TreesChallengeApp
{
    public class Statistics
    {
        public double Min { get; private set; }
        public double Max { get; private set; }
        public double Sum { get; private set; }
        public int Count { get; private set; }
        public double Average
        {
            get
            {
                return Sum / Count;
            }
        }
        public string AverageAge
        {
            get
            {
                switch (this.Average)
                {
                    case var average when average >= 35:
                        return "powyżej 100 lat";
                    case var average when average >= 30:
                        return "100 lat";
                    case var average when average >= 28:
                        return "90 lat";
                    case var average when average >= 26:
                        return "80 lat";
                    case var average when average >= 24:
                        return "70 lat";
                    case var average when average >= 22:
                        return "60 lat";
                    case var average when average >= 20:
                        return "50 lat";
                    case var average when average >= 18:
                        return "40 lat";
                    case var average when average >= 16:
                        return "30 lat";
                    case var average when average >= 13:
                        return "20 lat";
                    case var average when average >= 10:
                        return "10 lat";
                    default:
                        return "poniżej 10 lat";
                }
            }
        }
        public Statistics()
        {
            this.Count = 0;
            this.Sum = 0;
            this.Max = double.MinValue;
            this.Min = double.MaxValue;
        }

        public void AddHight(double hight)
        {
            this.Count++;
            this.Sum += hight;
            this.Min = Math.Min(hight, this.Min);
            this.Max = Math.Max(hight, this.Max);
        }
    }
}

