using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WpfApp1.Model.OperModelBase;

namespace WpfApp1.Model
{
    public abstract class RezbModel : OperModelBaseForRezb
    {

    }
    public class RezbChug : RezbModel
    {
        protected override double[][][] VremOper { get; set; } = new double[][][]
        {
            // M4: P = 0.7
            new double[][]
            {
                new double[] { 0.37, 0.40, 0.44, 0.00, 0.00, 0.00, 0.00 }
            },
            // M5: P = 0.8
            new double[][]
            {
                new double[] { 0.39, 0.40, 0.46, 0.00, 0.00, 0.00, 0.00 }
            },
            // M6: P = 1.0
            new double[][]
            {
                new double[] { 0.38, 0.40, 0.43, 0.46, 0.00, 0.00, 0.00 }
            },
            // M8: P = 1.25
            new double[][]
            {
                new double[] { 0.38, 0.40, 0.43, 0.46, 0.00, 0.00, 0.00 }
            },
            // M10: P = 1.5
            new double[][]
            {
                new double[] { 0.38, 0.40, 0.43, 0.45, 0.00, 0.00, 0.00 }
            },
            // M12: P = {1.75, 1.5, 1.25}
            new double[][]
            {
                // P = 1.75
                new double[] { 0.39, 0.41, 0.44, 0.46, 0.48, 0.00, 0.00 },
                // P = 1.50
                new double[] { 0.39, 0.43, 0.45, 0.48, 0.50, 0.00, 0.00 },
                // P = 1.25
                new double[] { 0.43, 0.46, 0.49, 0.52, 0.56, 0.00, 0.00 }
            },
            // M16: P = {2.0, 1.5}
            new double[][]
            {
                // P = 2.00
                new double[] { 0.43, 0.46, 0.48, 0.50, 0.53, 0.59, 0.00 },
                // P = 1.50
                new double[] { 0.45, 0.48, 0.51, 0.56, 0.59, 0.66, 0.00 }
            },
            // d = 20 mm: P = {2.5, 2.0, 1.5}
            new double[][]
            {
                new double[] { 0.43, 0.46, 0.48, 0.50, 0.52, 0.58, 0.62 },  // P=2.5
                new double[] { 0.43, 0.46, 0.48, 0.51, 0.55, 0.60, 0.65 },  // P=2.0
                new double[] { 0.45, 0.48, 0.52, 0.56, 0.60, 0.68, 0.74 },  // P=1.5

            },
            // d = 24 mm: P = {3.0, 2.0, 1.5}
            new double[][]
            {
                new double[] { 0.46, 0.49, 0.51, 0.55, 0.57, 0.62, 0.68 },  // P=3.0
                new double[] { 0.47, 0.50, 0.53, 0.57, 0.60, 0.66, 0.73 },  // P=2.0
                new double[] { 0.49, 0.53, 0.58, 0.62, 0.66, 0.76, 0.85 }   // P=1.5

            },
            // d = 30 mm: P = {3.5, 2.0, 1.5}
            new double[][]
            {
                new double[] { 0.48, 0.50, 0.53, 0.56, 0.58, 0.63, 0.68 },  // P=3.5
                new double[] { 0.50, 0.56, 0.60, 0.64, 0.69, 0.77, 0.86 },  // P=2.0
                new double[] { 0.51, 0.57, 0.62, 0.68, 0.72, 0.83, 0.93 },  // P=1.5
            },
            // d = 36 mm: P = {4.0, 3.0, 2.0}
            new double[][]
            {
                new double[] { 0.52, 0.56, 0.58, 0.60, 0.63, 0.69, 0.74 },  // P=4.0
                new double[] { 0.55, 0.58, 0.61, 0.65, 0.69, 0.76, 0.83 },  // P=3.0
                new double[] { 0.58, 0.63, 0.69, 0.74, 0.80, 0.90, 1.01 }   // P=2.0
            },
            // d = 42 mm: P = {3.0, 2.0}
            new double[][]
            {
                new double[] { 0.57, 0.61, 0.65, 0.70, 0.73, 0.82, 0.89 },  // P=3.0
                new double[] { 0.61, 0.68, 0.73, 0.80, 0.85, 0.97, 1.10 }   // P=2.0
            },
            // d = 48 mm: P = {3.0, 2.0}
            new double[][]
            {
                new double[] { 0.57, 0.65, 0.70, 0.74, 0.78, 0.88, 0.97 },  // P=3.0
                new double[] { 0.65, 0.72, 0.78, 0.86, 0.93, 1.06, 1.20 }   // P=2.0
            }
        };
        protected override double[] GlubSpis { get; set; } = new double[] { 10, 15, 20, 15, 30, 40, 50 };
        protected override double[] DiamSpis { get; set; } = new double[] { 4, 5, 6, 8, 10, 12, 16, 20, 24, 30, 36, 42, 48 };
        protected override double[][] StepsRezb { get; set; } = new double[][]
        {
            new double[] {0.7},
            new double[] {0.8},
            new double[] {1},
            new double[] {1.25},
            new double[] {1.5},
            new double[] {1.75, 1.5, 1.25},
            new double[] {2, 1.5},
            new double[] {2.5, 2, 1.5},
            new double[] {3, 2, 1.5},
            new double[] {3.5, 2, 1.5},
            new double[] {4, 3, 2},
            new double[] {3, 2},
            new double[] {3, 2},
        };
        public RezbChug( double glub, int NomDiam, double StepRezb)
        {
            Diam = NomDiam;
            Glub = glub;
            Step = StepRezb;
        }
    }
    public class RezbStKonstr : RezbModel
    {
        protected override double[][][] VremOper { get; set; } = new double[][][]
        {
            // M4 (d=4), P = 0.7
            new double[][]
            {
                new double[] { 0.35, 0.38, 0.40, 0.00, 0.00, 0.00, 0.00 }
            },
            // M5 (d=5), P = 0.8
            new double[][]
            {
                new double[] { 0.37, 0.39, 0.43, 0.00, 0.00, 0.00, 0.00 }
            },
            // M6 (d=6), P = 1.0
            new double[][]
            {
                new double[] { 0.34, 0.36, 0.37, 0.39, 0.00, 0.00, 0.00 }
            },
            // M8 (d=8), P = 1.25
            new double[][]
            {
                new double[] { 0.37, 0.38, 0.40, 0.43, 0.46, 0.50, 0.00 }
            },
            // M10 (d=10), P = 1.5
            new double[][]
            {
                new double[] { 0.37, 0.39, 0.41, 0.44, 0.46, 0.51, 0.00 }
            },
            // M12 (d=12), P = {1.75, 1.5, 1.25}
            new double[][]
            {
                // P = 1.75
                new double[] { 0.37, 0.39, 0.41, 0.44, 0.46, 0.51, 0.00 },
                // P = 1.5
                new double[] { 0.38, 0.44, 0.43, 0.45, 0.47, 0.52, 0.00 },
                // P = 1.25
                new double[] { 0.40, 0.44, 0.47, 0.50, 0.53, 0.00, 0.00 }
            },
            // M16 (d=16), P = {2.0, 1.5}
            new double[][]
            {
                // P = 2.0
                new double[] { 0.40, 0.44, 0.47, 0.50, 0.53, 0.60, 0.66 },
                // P = 1.5
                new double[] { 0.43, 0.46, 0.49, 0.52, 0.56, 0.62, 0.69 }
            },
            // d = 20 mm
            new double[][]
            {
                // P = 2.5
                new double[] { 0.40, 0.44, 0.46, 0.48, 0.50, 0.56, 0.60 },
                // P = 2.0
                new double[] { 0.40, 0.44, 0.46, 0.48, 0.50, 0.56, 0.60 },
                // P = 1.5
                new double[] { 0.43, 0.46, 0.49, 0.52, 0.56, 0.62, 0.69 },

            },
            // d = 24 mm
            new double[][]
            {
                // P = 3.0
                new double[] { 0.44, 0.46, 0.49, 0.51, 0.53, 0.58, 0.62 },
                // P = 2.0
                new double[] { 0.45, 0.47, 0.50, 0.53, 0.57, 0.62, 0.69 },
                // P = 1.5
                new double[] { 0.46, 0.50, 0.55, 0.59, 0.62, 0.71, 0.78 },

            },
            // d = 30 mm
            new double[][]
            {
                // P = 3.5
                new double[] { 0.46, 0.48, 0.50, 0.52, 0.55, 0.59, 0.63 },
                // P = 2.0
                new double[] { 0.49, 0.53, 0.57, 0.61, 0.64, 0.72, 0.81 },
                // P = 1.5
                new double[] { 0.49, 0.53, 0.58, 0.62, 0.66, 0.76, 0.85 },

            },
            // d = 36 mm
            new double[][]
            {
                // P = 4.0
                new double[] { 0.50, 0.51, 0.55, 0.57, 0.59, 0.64, 0.69 },
                // P = 3.0
                new double[] { 0.51, 0.52, 0.55, 0.58, 0.60, 0.66, 0.72 },
                // P = 2.0
                new double[] { 0.53, 0.56, 0.60, 0.64, 0.69, 0.77, 0.86 }
            },
            // d = 42 mm
            new double[][]
            {
                // P = 3.0
                new double[] { 0.55, 0.58, 0.61, 0.65, 0.69, 0.76, 0.83 },
                // P = 2.0
                new double[] { 0.58, 0.63, 0.69, 0.74, 0.80, 0.90, 1.01 }
            },
            // d = 48 mm
            new double[][]
            {
                // P = 3.0
                new double[] { 0.57, 0.61, 0.65, 0.70, 0.73, 0.82, 0.89 },
                // P = 2.0
                new double[] { 0.61, 0.68, 0.73, 0.80, 0.85, 0.97, 1.10 }
            }
        };
        protected override double[] GlubSpis { get; set; } = new double[] { 10, 15, 20, 15, 30, 40, 50 };
        protected override double[] DiamSpis { get; set; } = new double[] { 4, 5, 6, 8, 10, 12, 16, 20, 24, 30, 36, 42, 48 };
        protected override double[][] StepsRezb { get; set; } = new double[][]
        {
            new double[] {0.7},
            new double[] {0.8},
            new double[] {1},
            new double[] {1.25},
            new double[] {1.5},
            new double[] {1.75, 1.5, 1.25},
            new double[] {2, 1.5},
            new double[] {2.5, 2, 1.5},
            new double[] {3, 2, 1.5},
            new double[] {3.5, 2, 1.5},
            new double[] {4, 3, 2},
            new double[] {3, 2},
            new double[] {3, 2},
        };
        public RezbStKonstr( double glub, int NomDiam, double StepRezb)
        {
            Diam = NomDiam;
            Glub = glub;
            Step = StepRezb;
        }
    }
    public class RezbModelFactory
    {
        public static RezbModel Create(string mat, double glub, int NomDiam, double StepRezb)
        {
            if (mat == "Чугун")
                return new RezbChug( glub, NomDiam, StepRezb);
            else if (mat == "Сталь углеродистая")
                return new RezbStKonstr( glub, NomDiam, StepRezb);
            else
                throw new ArgumentException("Неподдерживаемая комбинация");
        }
    }
}
