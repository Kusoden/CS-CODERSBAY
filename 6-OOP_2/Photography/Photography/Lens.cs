namespace Photography
{
    public class Lens
    {

        int minFocalLengths;
        int maxFocalLengths;

        public Lens(int minFocalLength, int maxFocalLength)
        {
            if (minFocalLength < maxFocalLength)
            {
                this.minFocalLengths = minFocalLength;
                this.maxFocalLengths = maxFocalLength;
            }
            else
                Console.WriteLine("Maximum FocalLength must be always higher than the Minimum FocalLength!!");
        }

        public void SetMinFocalLength(int minBrennweite)
        {
            if (minBrennweite < maxFocalLengths)
                this.minFocalLengths = minBrennweite;
            else
                Console.WriteLine("Minimum FocalLength must be lower than the Maximum FocalLength! maximum FocalLength: " + maxFocalLengths);

        }

        public void SetMaxFocalLength(int maxBrennweite)
        {
            if (maxBrennweite > minFocalLengths)
                this.maxFocalLengths = maxBrennweite;
            else
                Console.WriteLine("Maximum FocalLength must be always higher than the Minimum FocalLength! Minimum FocalLength: " + minFocalLengths);

        }

        public int GetMinFocalLength()
        {
            Console.WriteLine(minFocalLengths);
            return minFocalLengths;
        }

        public int GetMaxFocalLength()
        {
            Console.WriteLine(maxFocalLengths);
            return maxFocalLengths;
        }


        public override string ToString() => "Lens Minimum FocalLength: " + minFocalLengths + ", Maximum FocalLength " + maxFocalLengths;
    }
}