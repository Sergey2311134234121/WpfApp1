using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public abstract class OperModelBase
    {
        protected abstract double[][] VremOper { get; set; }
        protected abstract double[] DiamSpis { get; set; }
        protected abstract double[] GlubSpis { get; set; }
        public double Diam;
        public double Glub;
        private int DiamIndex()
        {
            for (int i = 0; i < DiamSpis.Length; i++)
            {
                if (Diam <= DiamSpis[i])
                {
                    return i;
                }
            }
            return -1;
        }
        private int GlubIndex()
        {

            for (int i = 0; i < GlubSpis.Length; i++)
            {
                if (Glub <= GlubSpis[i])
                {
                    return i;
                }
            }

            return -1;
        }
        public double MaxGlub()
        {
            for (int i = 0; i < GlubSpis.Length; i++)
            {
                if (Diam != 0 & VremOper[DiamIndex()][i] == 0)
                {
                    if (i==0)
                    {
                        return GlubSpis[i];
                    }
                    else
                        return GlubSpis[i - 1];
                }
            }
            return -1;
        }
        public double Vremya()
        {
            return VremOper[DiamIndex()][GlubIndex()];
        }
    }
    public abstract class OperModelBaseForRassv
    {
        protected abstract double[][][] VremOper { get; set; }
        protected abstract double[] DiamSpis { get; set; }
        protected abstract double[] GlubSpis { get; set; }
        protected abstract double[][] GlubRezs { get; set; }
        public double Diam;
        public double Glub;
        public double GlubRez;
        private int DiamIndex()
        {
            for (int i = 0; i < DiamSpis.Length; i++)
            {
                if (Diam <= DiamSpis[i])
                {
                    return i;
                }
            }

            return -1;
        }
        private int GlubIndex()
        {

            for (int i = 0; i < GlubSpis.Length; i++)
            {
                if (Glub <= GlubSpis[i])
                {
                    return i;
                }
            }

            return -1;
        }
        private int GlubRezIndex()
        {
            var GlubRezPoDiam = GlubRezs[DiamIndex()];

            for (int i = 0; i < GlubRezPoDiam.Length; i++)
            {
                if ((Diam - GlubRez) <= GlubRezPoDiam[i])
                {
                    return i;
                }
            }
            return -1;
        }
        public double MaxGlub()
        {
            for (int i = 0; i < GlubSpis.Length; i++)
            {
                if (Diam != 0 & VremOper[DiamIndex()][GlubRezIndex()][i] == 0)
                {
                    return GlubSpis[i - 1];
                }
            }
            return -1;
        }
        public double Vremya()
        {
            return VremOper[DiamIndex()][GlubRezIndex()][GlubIndex()];
        }
    }
    public abstract class OperModelBaseForRazvKon
    {
        protected abstract double[][][] VremOper { get; set; }
        protected abstract double[] DiamSpis { get; set; }
        protected abstract string[] GlubSpis { get; set; } 
        protected abstract double[][] GlubRezs { get; set; }
        public double Diam;
        public string GlubStr;
        public double GlubRez;
        private int DiamIndex()
        {
            for (int i = 0; i < DiamSpis.Length; i++)
            {
                if (Diam <= DiamSpis[i])
                {
                    return i;
                }
            }

            return -1;
        }
        private int GlubIndex()
        {

            for (int i = 0; i < GlubSpis.Length; i++)
            {
                if (GlubStr == GlubSpis[i])
                {
                    return i;
                }
            }

            return -1;
        }
        private int GlubRezIndex()
        {
            var GlubRezPoDiam = GlubRezs[DiamIndex()];

            for (int i = 0; i < GlubRezPoDiam.Length; i++)
            {
                if (GlubRez <= GlubRezPoDiam[i])
                {
                    return i;
                }
            }
            return -1;
        }
        public double Vremya()
        {
            return VremOper[DiamIndex()][GlubRezIndex()][GlubIndex()];
        }
    }
    public abstract class OperModelBaseForRezb
    {
        protected abstract double[][][] VremOper { get; set; }
        protected abstract double[] DiamSpis { get; set; }
        protected abstract double[] GlubSpis { get; set; }
        protected abstract double[][] StepsRezb { get; set; }
        public int Diam;
        public double Glub;
        public double Step;
        private int DiamIndex()
        {
            for (int i = 0; i < DiamSpis.Length; i++)
            {
                if (Diam == DiamSpis[i])
                {
                    return i;
                }
            }

            return -1;
        }
        private int GlubIndex()
        {
            for (int i = 0; i < GlubSpis.Length; i++)
            {
                if (Glub <= GlubSpis[i])
                {
                    return i;
                }
            }
            return -1;
        }
        private int StepRezIndex()
        {
            var StepRezPoDiam = StepsRezb[DiamIndex()];

            for (int i = 0; i < StepRezPoDiam.Length; i++)
            {
                if (Step == StepRezPoDiam[i])
                {
                    return i;
                }
            }
            return -1;
        }
        public double MaxGlub()
        {
            for (int i = 0; i < GlubSpis.Length; i++)
            {
                if (Diam != 0 & VremOper[DiamIndex()][StepRezIndex()][i] == 0)
                {
                    return GlubSpis[i - 1];
                }
            }
            return -1;
        }
        public double Vremya()
        {
            return VremOper[DiamIndex()][StepRezIndex()][GlubIndex()];
        }
    }
    
}
