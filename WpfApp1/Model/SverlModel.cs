using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public abstract class SverlModel : OperModelBase
    {
        protected override double[] GlubSpis { get; set; } = new double[] { 10, 15, 20, 30, 40, 50, 60, 80, 100, 125, 150, 175, 200, 225, 250, 300 };       
    }
    public class SverlChugР6М5 : SverlModel
    {
        protected override double[][] VremOper { get; set; } = new double[][]
        {
            new double[] { 0.19, 0.23, 0.25, 0.38, 0.44, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new double[] { 0.2, 0.22, 0.24, 0.31, 0.37, 0.48, 0.58, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new double[] {0.21, 0.23, 0.25, 0.35, 0.47, 0.55, 0.7, 0.93, 0, 0, 0, 0, 0, 0, 0, 0},
            new double[] {0.2, 0.22, 0.24, 0.36, 0.41, 0.5, 0.71, 0.98, 1.15, 0, 0, 0, 0, 0, 0, 0},
            new double[] {0.22, 0.25, 0.27, 0.35, 0.39, 0.54, 0.72, 0.88, 1.04, 1.2, 0, 0, 0, 0, 0, 0},
            new double[] {0.24, 0.27, 0.29, 0.38, 0.44, 0.5, 0.66, 0.94, 1.15, 1.65, 2.1, 0, 0, 0, 0, 0},
            new double[] {0.27, 0.32, 0.35, 0.44, 0.51, 0.59, 0.68, 0.86, 1.25, 1.55, 2.1, 2.5, 2.8, 0, 0, 0},
            new double[] {0.28, 0.33, 0.36, 0.41, 0.49, 0.57, 0.66, 0.78, 1.15, 1.5, 1.8, 2.8, 3.2, 3.65, 4, 0},
            new double[] {0.32, 0.36, 0.39, 0.46, 0.55, 0.62, 0.73, 0.87, 1.05, 1.35, 2.05, 2.45, 3.1, 3.55, 3.94, 4.6},
        };
        protected override double[] DiamSpis { get; set; } = new double[] { 4, 6, 8, 10, 12, 16, 20, 25, 30 };
        public SverlChugР6М5(double diam, double glub)
        { 
            Diam = diam;
            Glub = glub;
        }           
    }
    public class SverlChugBK6 : SverlModel
    {
        protected override double[][] VremOper { get; set; } = new double[][]
        {
            new double[] {0.17, 0.19, 0.21, 0.27, 0.34, 0.37, 0.55, 0.62, 0, 0, 0, 0, 0, 0, 0, 0 },
            new double[] {0.17, 0.19, 0.21, 0.24, 0.32, 0.44, 0.49, 0.64, 0, 0, 0, 0, 0, 0, 0, 0 },
            new double[] {0.19, 0.21, 0.22, 0.27, 0.29, 0.34, 0.45, 0.52, 0.69, 0.9, 0, 0, 0, 0, 0, 0},
            new double[] {0.22, 0.23, 0.29, 0.33, 0.36, 0.53, 0.65, 0.75, 0.88, 1.15, 1.45, 0, 0, 0, 0, 0},
            new double[] {0.21, 0.23, 0.25, 0.31, 0.34, 0.38, 0.43, 0.61, 0.71, 0.86, 1.12, 1.37, 1.55, 0, 0, 0},
            new double[] {0.22, 0.24, 0.25, 0.28, 0.32, 0.35, 0.41, 0.49, 0.69, 0.87, 1.05, 1.25, 1.45, 1.74, 1.86, 0},
            new double[] {0.23, 0.25, 0.27, 0.31, 0.34, 0.37, 0.44, 0.51, 0.6, 0.83, 1, 1.15, 1.4, 1.75, 1.87, 2.23},
        };
        protected override double[] DiamSpis { get; set; } = new double[] { 8, 10, 12, 16, 20, 25, 30 };
        public SverlChugBK6(double diam, double glub)
        {
            Diam = diam;
            Glub = glub;
        }
    }
    
    public class SverlStKorozionnoStР6М5 : SverlModel
    {
        protected override double[][] VremOper { get; set; } = new double[][]
        {
            new double[] { 0.25, 0.44, 0.60, 0.93, 1.15, 2.21, 0,    0,    0,    0,    0,    0,    0,    0,    0,    0    }, // d = 4
            new double[] { 0.26, 0.45, 0.55, 0.85, 1.00, 1.20, 0,    0,    0,    0,    0,    0,    0,    0,    0,    0    }, // d = 6
            new double[] { 0.30, 0.45, 0.60, 0.95, 1.00, 1.30, 1.60, 0,    0,    0,    0,    0,    0,    0,    0,    0    }, // d = 8
            new double[] { 0.35, 0.50, 0.60, 0.85, 1.30, 1.56, 1.80, 2.40, 0,    0,    0,    0,    0,    0,    0,    0    }, // d = 10
            new double[] { 0.44, 0.60, 0.70, 0.95, 1.20, 1.70, 2.05, 2.60, 3.15, 4.00, 4.90, 6.00, 0,    0,    0,    0    }, // d = 12
            new double[] { 0.52, 0.70, 0.85, 1.05, 1.40, 1.60, 2.70, 3.40, 4.20, 5.00, 6.50, 7.50, 9.00, 10.00, 11.00, 0 }, // d = 16
            new double[] { 0.65, 0.90, 1.05, 1.35, 1.60, 1.80, 2.40, 4.00, 4.80, 6.00, 7.50, 8.50, 10.00, 11.50, 12.50, 0 }, // d = 20
            new double[] { 0.85, 1.15, 1.40, 1.65, 2.00, 2.50, 3.00, 3.70, 6.00, 7.50, 8.50, 10.50, 12.00, 13.50, 14.50, 18.00 }, // d = 25
            new double[] { 1.05, 1.35, 1.60, 1.90, 2.30, 2.80, 3.30, 4.00, 4.80, 8.00, 9.50, 11.00, 12.50, 14.50, 16.00, 19.00 }  // d = 30
        };
        protected override double[] DiamSpis { get; set; } = new double[] { 4, 6, 8, 10, 12, 16, 20, 25, 30 };
        public SverlStKorozionnoStР6М5(double diam, double glub)
        {
            Diam = diam;
            Glub = glub;
        }
    }
    public class SverlStKonstrР6М5 : SverlModel
    {
        protected override double[][] VremOper { get; set; } = new double[][]
        {          
            new double[] { 0.21, 0.28, 0.31, 0.56, 0.64, 0.75, 0,    0,    0,    0,    0,    0,    0,    0,    0,    0    }, // d = 4
            new double[] { 0.24, 0.19, 0.21, 0.37, 0.44, 0.51, 0.63, 0,    0,    0,    0,    0,    0,    0,    0,    0    }, // d = 6
            new double[] { 0.19, 0.22, 0.26, 0.44, 0.56, 0.66, 1.00, 1.30, 0,    0,    0,    0,    0,    0,    0,    0    }, // d = 8
            new double[] { 0.21, 0.24, 0.28, 0.42, 0.59, 0.73, 0.89, 1.40, 1.70, 0,    0,    0,    0,    0,    0,    0    }, // d = 10
            new double[] { 0.26, 0.31, 0.35, 0.49, 0.57, 0.70, 0.99, 1.25, 1.60, 2.00, 0,    0,    0,    0,    0,    0    }, // d = 12
            new double[] { 0.29, 0.34, 0.40, 0.51, 0.61, 0.71, 0.88, 1.35, 1.65, 2.20, 2.70, 0,    0,    0,    0,    0    }, // d = 16
            new double[] { 0.34, 0.41, 0.46, 0.59, 0.70, 0.84, 0.98, 1.30, 1.95, 2.35, 3.10, 3.70, 4.20, 0,    0,    0    }, // d = 20
            new double[] { 0.36, 0.43, 0.50, 0.59, 0.72, 0.83, 0.98, 1.25, 1.80, 2.35, 2.80, 3.75, 4.40, 5.00, 5.50, 0    }, // d = 25
            new double[] { 0.41, 0.48, 0.55, 0.64, 0.78, 0.91, 1.05, 1.35, 1.60, 2.30, 3.45, 4.10, 4.75, 5.50, 6.00, 7.00 }  // d = 30
        };
        protected override double[] DiamSpis { get; set; } = new double[] { 4, 6, 8, 10, 12, 16, 20, 25, 30 };
        public SverlStKonstrР6М5(double diam, double glub)
        {
            Diam = diam;
            Glub = glub;
        }
    }
    public class SverlAllumР6М5 : SverlModel
    {
        protected override double[][] VremOper { get; set; } = new double[][]
        {
            new double[] { 0.10, 0.16, 0.24, 0.40, 0.44, 0.48, 0,    0,    0,    0,    0,    0,    0,    0,    0,    0    }, // d = 5
            new double[] { 0.11, 0.12, 0.15, 0.26, 0.36, 0.44, 0.52, 0,    0,    0,    0,    0,    0,    0,    0,    0    }, // d = 6
            new double[] { 0.10, 0.12, 0.13, 0.20, 0.36, 0.40, 0.52, 0.64, 0,    0,    0,    0,    0,    0,    0,    0    }, // d = 8
            new double[] { 0.10, 0.12, 0.13, 0.20, 0.36, 0.40, 0.52, 0.64, 0.72, 0,    0,    0,    0,    0,    0,    0    }, // d = 10
            new double[] { 0.14, 0.16, 0.18, 0.22, 0.24, 0.40, 0.53, 0.64, 0.72, 0,    0,    0,    0,    0,    0,    0    }, // d = 12
            new double[] { 0.14, 0.16, 0.18, 0.22, 0.24, 0.25, 0.48, 0.56, 0.68, 0.88, 1.04, 1.28, 0,    0,    0,    0    }, // d = 16
            new double[] { 0.14, 0.16, 0.18, 0.22, 0.24, 0.25, 0.30, 0.58, 0.68, 0.83, 1.04, 1.28, 1.56, 0,    0,    0    }, // d = 20
            new double[] { 0.15, 0.18, 0.19, 0.22, 0.25, 0.26, 0.30, 0.37, 0.68, 0.80, 0.96, 1.16, 1.44, 1.68, 1.84, 0    }, // d = 25
            new double[] { 0.20, 0.21, 0.22, 0.24, 0.27, 0.30, 0.34, 0.40, 0.48, 1.00, 1.04, 1.28, 1.48, 1.84, 2.00, 2.24 }  // d = 30
        };
        protected override double[] DiamSpis { get; set; } = new double[] { 5, 6, 8, 10, 12, 16, 20, 25, 30 };
        public SverlAllumР6М5(double diam, double glub)
        {
            Diam = diam;
            Glub = glub;
        }
    }
    public class SverlMedР6М5 : SverlModel
    {
        protected override double[][] VremOper { get; set; } = new double[][]
        {
            new double[] { 0.13, 0.20, 0.30, 0.50, 0.55, 0.60, 0,    0,    0,    0,    0,    0,    0,    0,    0,    0    }, // d = 5
            new double[] { 0.13, 0.15, 0.16, 0.40, 0.45, 0.55, 0.65, 0,    0,    0,    0,    0,    0,    0,    0,    0    }, // d = 6
            new double[] { 0.13, 0.15, 0.16, 0.25, 0.45, 0.50, 0.65, 0.80, 0,    0,    0,    0,    0,    0,    0,    0    }, // d = 8
            new double[] { 0.13, 0.15, 0.16, 0.25, 0.45, 0.50, 0.65, 0.80, 0.90, 0,    0,    0,    0,    0,    0,    0    }, // d = 10
            new double[] { 0.18, 0.20, 0.21, 0.28, 0.30, 0.50, 0.65, 0.80, 0.90, 1.10, 0,    0,    0,    0,    0,    0    }, // d = 12
            new double[] { 0.18, 0.20, 0.22, 0.28, 0.30, 0.50, 0.60, 0.70, 0.85, 1.10, 1.30, 1.60, 0,    0,    0,    0    }, // d = 16
            new double[] { 0.18, 0.20, 0.23, 0.28, 0.30, 0.33, 0.37, 0.70, 0.85, 1.04, 1.30, 1.60, 1.95, 0,    0,    0    }, // d = 20
            new double[] { 0.19, 0.22, 0.24, 0.28, 0.28, 0.32, 0.37, 0.46, 0.85, 1.00, 1.20, 1.45, 1.80, 2.10, 2.30, 0    }, // d = 25
            new double[] { 0.25, 0.26, 0.28, 0.30, 0.34, 0.38, 0.43, 0.50, 0.60, 1.25, 1.30, 1.60, 1.85, 2.30, 2.50, 3.00 }  // d = 30
        };
        protected override double[] DiamSpis { get; set; } = new double[] { 5, 6, 8, 10, 12, 16, 20, 25, 30 };
        public SverlMedР6М5(double diam, double glub)
        {
            Diam = diam;
            Glub = glub;
        }
    }
    public class SverlModelFactory
    {
        public static SverlModel Create(string mat, string matinstr, double diam, double glub)
        {
            if (mat == "Чугун" && matinstr == "Р6М5")
                return new SverlChugР6М5(diam, glub);
            else if (mat == "Чугун" && matinstr == "BK6")
                return new SverlChugBK6(diam, glub);
            else if (mat == "Сталь углеродистая" && matinstr == "Р6М5")
                return new SverlStKonstrР6М5(diam, glub);
            else if (mat == "Сталь коррозионностойкая" && matinstr == "Р6М5")
                return new SverlStKorozionnoStР6М5(diam, glub);
            else if (mat == "Алюминиевые сплавы" && matinstr == "Р6М5")
                return new SverlAllumР6М5(diam, glub);
            else if (mat == "Медные сплавы" && matinstr == "Р6М5")
                return new SverlMedР6М5(diam, glub);
            else
                throw new ArgumentException("Неподдерживаемая комбинация");
        }
    }
}
