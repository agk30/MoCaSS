using System.Drawing.Drawing2D;
using System.Net.Security;

namespace MoCaSS
{
    internal class Molecule
    {
        public readonly double massAMU;
        public readonly double massKG;
        private double speed;
        private Structures.Vect direction;
        private Structures.Vect startPoint;
        private Structures.Vect startTime;
        private MCRandom mcInstance;

        public double Speed
        {
            get { return speed;  }
            set { speed = value; }
        }
        public Structures.Vect Direction
        {
            get { return direction; }
            set { direction = value; }
        }
        public Structures.Vect StartPoint
        {
            get { return startPoint; }
            set { startPoint = value; }
        }
        public Structures.Vect StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        public Molecule(double mass, ref MCRandom rand)
        { 
            massAMU = mass;
            massKG = massAMU * Constants.AMUtoKg;

            speed = 0.0;
            direction = new Structures.Vect();
            startPoint = new Structures.Vect();

            mcInstance = rand;
        }

        public void GenerateStartPoint(int directionType, double valveRad, double valvePos, double skimRad, double skimPos, double colRad, double colPos)
        {
            bool hit = false;
            int counter = 0;

            while (!hit)
            {
                if (counter > 1000) return;

                Structures.Vect valve = mcInstance.DiscPick(valveRad, valvePos);
                Structures.Vect skimmer = mcInstance.DiscPick(skimRad, skimPos);

                (double gradientx, double interceptx) = mcInstance.FitLine(valve.x, valve.y, skimmer.x, skimmer.y);
                (double gradienty, double intercepty) = mcInstance.FitLine(valve.x, valve.y, skimmer.x, skimmer.y);

                Structures.Vect collimator = new Structures.Vect();

                collimator.x = (gradientx * colPos) + interceptx;
                collimator.y = (gradienty * colPos) + intercepty;
                collimator.z = colPos;

                double hyp = Math.Sqrt(Math.Pow(collimator.x, 2) + Math.Pow(collimator.y, 2));

                if (hyp < colRad)
                {
                    hit = true;

                    Structures.Vect newVector = new Structures.Vect();

                    newVector.x = skimmer.x = valve.x;
                    newVector.y = skimmer.y = valve.y;
                    newVector.z = skimmer.z = valve.z;

                    direction = mcInstance.UnitVector(newVector);
                    startPoint = valve;
                }
                counter++;
            }
        }
    }
}
