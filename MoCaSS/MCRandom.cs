
namespace MoCaSS
{
    // Random number and geometry methods
    internal class MCRandom
    {
        private Random rand;

        public MCRandom()
        {
            rand = new Random();
        }

        public double RandomFloat()
        {
            var num = rand.NextSingle();
            return num;
        }

        public Structures.Vect RandomCosineVector(double cosinePower)
        {
            double rand1 = rand.NextSingle();
            double rand2 = rand.NextSingle();
            double phi, theta, x;
            
            Structures.Vect newVector;
            
            phi = rand1 * 2 * Math.PI;

            x = Math.Pow(rand2, (1/(cosinePower+1)));

            theta = Math.Cos(x);

            newVector.x = Math.Sin(theta)*Math.Cos(phi);
            newVector.y = Math.Sin(theta)*Math.Sin(phi);
            newVector.z = Math.Cos(theta);

            return newVector;
        }

        public Structures.Vect RandomCosineNumber(double cosinePower)
        {
            double rand1 = rand.NextSingle();
            double rand2 = rand.NextSingle();
            double phi, theta, x;

            Structures.Vect newVector;

            phi = rand1 * 2 * Math.PI;

            x = Math.Pow(rand2, (1 / (cosinePower + 1)));

            theta = Math.Cos(x);

            newVector.x = Math.Sin(theta) * Math.Cos(phi);
            newVector.y = Math.Sin(theta) * Math.Sin(phi);
            newVector.z = Math.Cos(theta);

            return newVector;
        }

        public double RandomDouble()
        {
            return rand.NextDouble();
        }

        public Structures.Vect DiscPick(double radius, double z)
        {
            double rand1 = rand.NextDouble();
            double rand2 = rand.NextDouble();
            Structures.Vect newVector = new Structures.Vect();
           
            rand1 = Math.Sqrt(rand1) * radius;
            rand2 = 2 * Math.PI * rand2;

            newVector.x = rand1*Math.Cos(rand2);
            newVector.y = rand1*Math.Sin(rand2);
            newVector.z = z;

            return newVector;
        }

        public (double, double) FitLine(double y2, double x2, double y1, double x1)
        {
            double gradient = (y2 - y1) / (x2 - x1);
            double intercept = y2 - (gradient * x2);

            return (gradient, intercept);
        }

        public Structures.Vect UnitVector(Structures.Vect vector)
        {
            double magnitude = Math.Sqrt(Math.Pow(vector.x, 2) + Math.Pow(vector.y, 2) + Math.Pow(vector.z, 2));

            vector.x = vector.x / magnitude;
            vector.y = vector.y / magnitude;
            vector.z = vector.z / magnitude;

            return vector;
        }
    }
}