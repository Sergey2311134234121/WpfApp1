using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;
using static WpfApp1.Model.OperModelBase;

namespace WpfApp1.Model
{
    public abstract class RassverlModel : OperModelBaseForRassv
    {
        protected override double[] GlubSpis { get; set; } = new double[] { 15, 20, 25,30, 40, 50, 60, 80, 100, 125, 150, 175, 200, 225, 250, 300 };
    }
    public class RassverlChugР6М5 : RassverlModel
    {
        protected override double[][][] VremOper { get; set; } = new double[][][]
        {           
            new double[][] // D = 25
            {
                new double[] {0.21, 0.25, 0.26, 0.29, 0.34, 0.38, 0.45, 0.51, 0.57, 0, 0, 0, 0, 0, 0, 0},
                new double[] {0.17, 0.20, 0.23, 0.23, 0.25, 0.31, 0.34, 0.39, 0.45, 0, 0, 0, 0, 0, 0, 0}
            },
            new double[][] // D = 30
            {
                new double[] {0.20, 0.24, 0.26, 0.29, 0.34, 0.41, 0.46, 0.53, 0.63, 0, 0, 0, 0, 0, 0, 0},
                new double[] {0.20, 0.23, 0.25, 0.27, 0.31, 0.38, 0.42, 0.48, 0.57, 0, 0, 0, 0, 0, 0, 0},
                new double[] {0.18, 0.22, 0.24, 0.26, 0.30, 0.35, 0.41, 0.46, 0.56, 0, 0, 0, 0, 0, 0, 0}
            },
            new double[][] // D = 40
            {
                new double[] {0.30, 0.40, 0.42, 0.50, 0.60, 0.70, 0.80, 0.90, 1.10, 1.30, 1.50, 0, 0, 0, 0, 0},
                new double[] {0.25, 0.30, 0.38, 0.40, 0.50, 0.60, 0.68, 0.75, 0.90, 1.10, 1.25, 0, 0, 0, 0, 0},
                new double[] {0.20, 0.25, 0.31, 0.36, 0.40, 0.45, 0.51, 0.60, 0.72, 0.85, 1.00, 0, 0, 0, 0, 0}
            },
            new double[][] // D = 50
            {
                new double[] {0.29, 0.35, 0.42, 0.44, 0.52, 0.63, 0.71, 0.83, 1.00, 1.20, 1.40, 1.60, 1.80, 2.00, 2.20, 2.80},
                new double[] {0.25, 0.31, 0.38, 0.39, 0.46, 0.56, 0.63, 0.74, 0.86, 1.05, 1.25, 1.36, 1.60, 1.80, 2.00, 2.40},
                new double[] {0.23, 0.28, 0.31, 0.35, 0.41, 0.47, 0.57, 0.66, 0.84, 1.00, 1.20, 1.34, 1.50, 1.69, 1.86, 2.35}
            },
            new double[][] // D = 60
            {
                new double[] {0.45, 0.55, 0.63, 0.65, 0.80, 0.90, 1.00, 1.32, 1.45, 1.70, 2.00, 2.30, 2.60, 2.90, 3.20, 3.80},
                new double[] {0.40, 0.50, 0.56, 0.60, 0.70, 0.80, 0.90, 1.20, 1.30, 1.50, 1.80, 2.20, 2.30, 2.60, 2.90, 3.40},
                new double[] {0.30, 0.40, 0.45, 0.50, 0.55, 0.65, 0.76, 0.85, 1.00, 1.20, 1.35, 1.53, 1.80, 2.00, 2.20, 2.60}
            }        
        };
        protected override double[] DiamSpis { get; set; } = new double[] { 25, 30, 40, 50, 60};
        protected override double[][] GlubRezs { get; set; } = new double[][]
        {
            new double[] {10,15},
            new double[] {10,15,20},
            new double[] {15,20,30},
            new double[] {20,30,40},
            new double[] {30,40,50},
        };
        public RassverlChugР6М5(double diam, double glub, double glubrez)
        {
            Diam = diam;
            Glub = glub;
            GlubRez = glubrez;
        }
    }
    public class RassverlStKorozionnoStР6М5 : RassverlModel
    {
        protected override double[][][] VremOper { get; set; } = new double[][][]
        {
            new double[][] // D = 25
            {
                new double[] {0.22, 0.25, 0.29, 0.30, 0.36, 0.40, 0.46, 0.52, 0.60, 0, 0, 0, 0, 0, 0, 0},
                new double[] {0.19, 0.21, 0.24, 0.26, 0.30, 0.34, 0.38, 0.42, 0.50, 0, 0, 0, 0, 0, 0, 0}
            },
            new double[][] // D = 30
            {
                new double[] {0.21, 0.26, 0.28, 0.32, 0.38, 0.42, 0.48, 0.54, 0.64, 0, 0, 0, 0, 0, 0, 0},
                new double[] {0.21, 0.24, 0.26, 0.29, 0.34, 0.39, 0.44, 0.50, 0.60, 0, 0, 0, 0, 0, 0, 0},
                new double[] {0.19, 0.23, 0.25, 0.28, 0.32, 0.37, 0.42, 0.48, 0.58, 0, 0, 0, 0, 0, 0, 0}
            },
            new double[][] // D = 40
            {
                new double[] {0.28, 0.33, 0.37, 0.41, 0.46, 0.52, 0.60, 0.68, 0.78, 0.90, 1.03, 1.16, 1.28, 1.40, 1.52, 1.64},
                new double[] {0.25, 0.30, 0.34, 0.38, 0.42, 0.48, 0.55, 0.62, 0.70, 0.80, 0.90, 1.00, 1.10, 1.20, 1.30, 1.40},
                new double[] {0.21, 0.26, 0.30, 0.33, 0.38, 0.44, 0.50, 0.56, 0.64, 0.72, 0.82, 0.92, 1.02, 1.12, 1.22, 1.32}
            },
            new double[][] // D = 50
            {
                new double[] {0.34, 0.40, 0.46, 0.52, 0.60, 0.70, 0.80, 0.90, 1.02, 1.14, 1.26, 1.38, 1.50, 1.62, 1.74, 1.86},
                new double[] {0.30, 0.36, 0.42, 0.48, 0.56, 0.66, 0.76, 0.86, 0.98, 1.10, 1.22, 1.34, 1.46, 1.58, 1.70, 1.82},
                new double[] {0.27, 0.33, 0.39, 0.45, 0.53, 0.63, 0.73, 0.83, 0.95, 1.07, 1.19, 1.31, 1.43, 1.55, 1.67, 1.79}
            },
            new double[][] // D = 60
            {
                new double[] {0.43, 0.50, 0.57, 0.64, 0.72, 0.81, 0.91, 1.02, 1.14, 1.26, 1.38, 1.50, 1.62, 1.74, 1.86, 1.98},
                new double[] {0.38, 0.45, 0.52, 0.59, 0.67, 0.76, 0.86, 0.97, 1.09, 1.21, 1.33, 1.45, 1.57, 1.69, 1.81, 1.93},
                new double[] {0.33, 0.40, 0.47, 0.54, 0.62, 0.71, 0.81, 0.92, 1.04, 1.16, 1.28, 1.40, 1.52, 1.64, 1.76, 1.88}
            }
        };
        protected override double[] DiamSpis { get; set; } = new double[] { 25, 30, 40, 50, 60 };
        protected override double[][] GlubRezs { get; set; } = new double[][]
        {
            new double[] {10,15},
            new double[] {10,15,20},
            new double[] {15,20,30},
            new double[] {20,30,40},
            new double[] {30,40,50},
        };
        public RassverlStKorozionnoStР6М5(double diam, double glub, double glubrez)
        {
            Diam = diam;
            Glub = glub;
            GlubRez = glubrez;
        }
    }
    public class RassverlStKonstrР6М5 : RassverlModel
    {
        protected override double[][][] VremOper { get; set; } = new double[][][]
        {
            new double[][] // D = 25
            {
                new double[] {0.30, 0.34, 0.36, 0.40, 0.48, 0.52, 0.58, 0.66, 0.72, 0, 0, 0, 0, 0, 0, 0},
                new double[] {0.27, 0.30, 0.34, 0.36, 0.42, 0.46, 0.50, 0.57, 0.66, 0, 0, 0, 0, 0, 0, 0}
            },
            new double[][] // D = 30
            {
                new double[] {0.32, 0.36, 0.40, 0.44, 0.52, 0.58, 0.66, 0.74, 0.84, 0, 0, 0, 0, 0, 0, 0},
                new double[] {0.30, 0.34, 0.38, 0.42, 0.50, 0.56, 0.64, 0.72, 0.82, 0, 0, 0, 0, 0, 0, 0},
                new double[] {0.28, 0.32, 0.36, 0.40, 0.48, 0.54, 0.62, 0.70, 0.80, 0, 0, 0, 0, 0, 0, 0}
            },
            new double[][] // D = 40
            {
                new double[] {0.40, 0.46, 0.52, 0.58, 0.65, 0.72, 0.80, 0.88, 1.00, 1.12, 1.24, 1.36, 1.48, 1.60, 1.72, 1.84},
                new double[] {0.36, 0.42, 0.48, 0.54, 0.61, 0.68, 0.76, 0.84, 0.96, 1.08, 1.20, 1.32, 1.44, 1.56, 1.68, 1.80},
                new double[] {0.32, 0.38, 0.44, 0.50, 0.57, 0.64, 0.72, 0.80, 0.92, 1.04, 1.16, 1.28, 1.40, 1.52, 1.64, 1.76}
            },
            new double[][] // D = 50
            {
                new double[] {0.48, 0.54, 0.60, 0.66, 0.74, 0.83, 0.92, 1.01, 1.13, 1.25, 1.37, 1.49, 1.61, 1.73, 1.85, 1.97},
                new double[] {0.44, 0.50, 0.56, 0.62, 0.70, 0.78, 0.87, 0.96, 1.08, 1.20, 1.32, 1.44, 1.56, 1.68, 1.80, 1.92},
                new double[] {0.40, 0.46, 0.52, 0.58, 0.66, 0.74, 0.83, 0.92, 1.04, 1.16, 1.28, 1.40, 1.52, 1.64, 1.76, 1.88}
            },
            new double[][] // D = 60
            {
                new double[] {0.56, 0.63, 0.70, 0.77, 0.85, 0.94, 1.04, 1.14, 1.26, 1.38, 1.50, 1.62, 1.74, 1.86, 1.98, 2.10},
                new double[] {0.50, 0.57, 0.64, 0.71, 0.79, 0.88, 0.98, 1.08, 1.20, 1.32, 1.44, 1.56, 1.68, 1.80, 1.92, 2.04},
                new double[] {0.44, 0.51, 0.58, 0.65, 0.73, 0.82, 0.92, 1.02, 1.14, 1.26, 1.38, 1.50, 1.62, 1.74, 1.86, 1.98}
            }

        };
        protected override double[] DiamSpis { get; set; } = new double[] { 25, 30, 40, 50, 60 };
        protected override double[][] GlubRezs { get; set; } = new double[][]
        {
            new double[] {10,15},
            new double[] {10,15,20},
            new double[] {15,20,30},
            new double[] {20,30,40},
            new double[] {30,40,50},
        };
        public RassverlStKonstrР6М5(double diam, double glub, double glubrez)
        {
            Diam = diam;
            Glub = glub;
            GlubRez = glubrez;
        }
    }
    public class RassverlAllumР6М5 : RassverlModel
    {
        protected override double[][][] VremOper { get; set; } = new double[][][]
        {
            new double[][] // D = 25
            {
                new double[] {0.16, 0.18, 0.21, 0.23, 0.27, 0.31, 0.35, 0.41, 0.48, 0, 0, 0, 0, 0, 0, 0},
                new double[] {0.13, 0.15, 0.18, 0.20, 0.23, 0.27, 0.31, 0.36, 0.42, 0, 0, 0, 0, 0, 0, 0}
            },
            new double[][] // D = 30
            {
                new double[] {0.18, 0.21, 0.24, 0.27, 0.31, 0.36, 0.41, 0.47, 0.54, 0, 0, 0, 0, 0, 0, 0},
                new double[] {0.16, 0.19, 0.22, 0.25, 0.29, 0.34, 0.39, 0.45, 0.52, 0, 0, 0, 0, 0, 0, 0},
                new double[] {0.14, 0.17, 0.20, 0.23, 0.27, 0.32, 0.37, 0.43, 0.50, 0, 0, 0, 0, 0, 0, 0}
            },
            new double[][] // D = 40
            {
                new double[] {0.22, 0.26, 0.30, 0.33, 0.38, 0.44, 0.50, 0.56, 0.64, 0.72, 0.82, 0.92, 1.02, 1.12, 1.22, 1.32},
                new double[] {0.20, 0.24, 0.28, 0.31, 0.36, 0.42, 0.48, 0.54, 0.62, 0.70, 0.80, 0.90, 1.00, 1.10, 1.20, 1.30},
                new double[] {0.18, 0.22, 0.26, 0.29, 0.34, 0.40, 0.46, 0.52, 0.60, 0.68, 0.78, 0.88, 0.98, 1.08, 1.18, 1.28}
            },
            new double[][] // D = 50
            {
                new double[] {0.27, 0.32, 0.37, 0.42, 0.48, 0.56, 0.64, 0.72, 0.82, 0.92, 1.02, 1.12, 1.22, 1.32, 1.42, 1.52},
                new double[] {0.24, 0.28, 0.33, 0.37, 0.43, 0.50, 0.57, 0.64, 0.74, 0.84, 0.94, 1.04, 1.14, 1.24, 1.34, 1.44},
                new double[] {0.21, 0.26, 0.30, 0.34, 0.40, 0.46, 0.53, 0.60, 0.70, 0.80, 0.90, 1.00, 1.10, 1.20, 1.30, 1.40}
            },
            new double[][] // D = 60
            {
                new double[] {0.32, 0.37, 0.42, 0.47, 0.53, 0.60, 0.68, 0.76, 0.86, 0.96, 1.06, 1.16, 1.26, 1.36, 1.46, 1.56},
                new double[] {0.28, 0.33, 0.38, 0.43, 0.49, 0.56, 0.63, 0.71, 0.81, 0.91, 1.01, 1.11, 1.21, 1.31, 1.41, 1.51},
                new double[] {0.24, 0.29, 0.34, 0.39, 0.45, 0.52, 0.59, 0.67, 0.77, 0.87, 0.97, 1.07, 1.17, 1.27, 1.37, 1.47}
            }
        };
        protected override double[] DiamSpis { get; set; } = new double[] { 25, 30, 40, 50, 60 };
        protected override double[][] GlubRezs { get; set; } = new double[][]
        {
            new double[] {10,15},
            new double[] {10,15,20},
            new double[] {15,20,30},
            new double[] {20,30,40},
            new double[] {30,40,50},
        };
        public RassverlAllumР6М5(double diam, double glub, double glubrez)
        {
            Diam = diam;
            Glub = glub;
            GlubRez = glubrez;
        }
    }
    public class RassverlMedР6М5 : RassverlModel
    {
        protected override double[][][] VremOper { get; set; } = new double[][][]
        {
            new double[][] // D = 25
            {
                new double[] {0.18, 0.22, 0.24, 0.28, 0.32, 0.36, 0.42, 0.48, 0.54, 0, 0, 0, 0, 0, 0, 0},
                new double[] {0.16, 0.19, 0.22, 0.25, 0.29, 0.33, 0.38, 0.44, 0.50, 0, 0, 0, 0, 0, 0, 0}
            },
            new double[][] // D = 30
            {
                new double[] {0.20, 0.24, 0.27, 0.31, 0.36, 0.41, 0.48, 0.54, 0.62, 0, 0, 0, 0, 0, 0, 0},
                new double[] {0.18, 0.21, 0.24, 0.28, 0.33, 0.38, 0.44, 0.50, 0.58, 0, 0, 0, 0, 0, 0, 0},
                new double[] {0.16, 0.20, 0.22, 0.26, 0.30, 0.35, 0.41, 0.48, 0.55, 0, 0, 0, 0, 0, 0, 0}
            },
            new double[][] // D = 40
            {
                new double[] {0.26, 0.30, 0.34, 0.39, 0.45, 0.52, 0.60, 0.68, 0.78, 0.88, 0.98, 1.08, 1.18, 1.28, 1.38, 1.48},
                new double[] {0.24, 0.28, 0.32, 0.36, 0.42, 0.48, 0.55, 0.62, 0.72, 0.82, 0.92, 1.02, 1.12, 1.22, 1.32, 1.42},
                new double[] {0.22, 0.26, 0.30, 0.34, 0.39, 0.45, 0.51, 0.58, 0.68, 0.78, 0.88, 0.98, 1.08, 1.18, 1.28, 1.38}
            },
            new double[][] // D = 50
            {
                new double[] {0.31, 0.36, 0.41, 0.46, 0.53, 0.61, 0.69, 0.77, 0.87, 0.97, 1.07, 1.17, 1.27, 1.37, 1.47, 1.57},
                new double[] {0.28, 0.33, 0.38, 0.43, 0.50, 0.57, 0.65, 0.73, 0.83, 0.93, 1.03, 1.13, 1.23, 1.33, 1.43, 1.53},
                new double[] {0.25, 0.30, 0.35, 0.40, 0.46, 0.53, 0.61, 0.69, 0.79, 0.89, 0.99, 1.09, 1.19, 1.29, 1.39, 1.49}
            },
            new double[][] // D = 60
            {
                new double[] {0.36, 0.42, 0.48, 0.54, 0.61, 0.69, 0.78, 0.87, 0.98, 1.09, 1.20, 1.31, 1.42, 1.53, 1.64, 1.75},
                new double[] {0.32, 0.38, 0.44, 0.50, 0.57, 0.65, 0.74, 0.83, 0.94, 1.05, 1.16, 1.27, 1.38, 1.49, 1.60, 1.71},
                new double[] {0.28, 0.34, 0.40, 0.46, 0.53, 0.61, 0.70, 0.79, 0.90, 1.01, 1.12, 1.23, 1.34, 1.45, 1.56, 1.67}
            }
        };
        protected override double[] DiamSpis { get; set; } = new double[] { 25, 30, 40, 50, 60 };
        protected override double[][] GlubRezs { get; set; } = new double[][]
        {
            new double[] {10,15},
            new double[] {10,15,20},
            new double[] {15,20,30},
            new double[] {20,30,40},
            new double[] {30,40,50},
        };
        public RassverlMedР6М5(double diam, double glub, double glubrez)
        {
            Diam = diam;
            Glub = glub;
            GlubRez = glubrez;
        }
    }
    public class RassverlModelFactory
    {
        public static RassverlModel Create(string mat, string matinstr, double diam, double glub, double glubRez)
        {
            if (mat == "Чугун" && matinstr == "Р6М5")
                return new RassverlChugР6М5(diam, glub, glubRez);
            else if (mat == "Сталь углеродистая" && matinstr == "Р6М5")
                return new RassverlStKonstrР6М5(diam, glub, glubRez);
            else if (mat == "Сталь коррозионностойкая" && matinstr == "Р6М5")
                return new RassverlStKorozionnoStР6М5(diam, glub, glubRez);
            else if (mat == "Алюминиевые сплавы" && matinstr == "Р6М5")
                return new RassverlAllumР6М5(diam, glub, glubRez);
            else if (mat == "Медные сплавы" && matinstr == "Р6М5")
                return new RassverlMedР6М5(diam, glub, glubRez);
            else
                throw new ArgumentException("Неподдерживаемая комбинация");
        }
    }   
}
