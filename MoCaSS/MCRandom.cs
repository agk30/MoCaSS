using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MoCaSS
{
    internal class MCRandom
    {
        private Random rand;

        public MCRandom()
        {
            rand = new Random();
        }
        public struct Vect
        {
            public double x;

            public double y;

            public double z;
        }
        public double RandomFloat()
        {
            var num = rand.NextSingle();
            return num;
        }

        public Vect RandomCosineVector(double cosinePower)
        {
            double rand1 = rand.NextSingle();
            double rand2 = rand.NextSingle();
            double phi, theta, x;
            Vect newVector;
            
            phi = rand1 * 2 * Math.PI;

            x = Math.Pow(rand2, (1/(cosinePower+1)));

            theta = Math.Cos(x);

            newVector.x = Math.Sin(theta)*Math.Cos(phi);
            newVector.y = Math.Sin(theta)*Math.Sin(phi);
            newVector.z = Math.Cos(theta);

            return newVector;
        }
    }
}