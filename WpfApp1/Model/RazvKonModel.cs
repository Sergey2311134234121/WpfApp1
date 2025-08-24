using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WpfApp1.Model.OperModelBase;
using static WpfApp1.Model.RazvKonstrT15K67;

namespace WpfApp1.Model
{
    public abstract class RazvKonModel : OperModelBaseForRazvKon
    {

    }
    public class RazvKonChugР6М58 : RazvKonModel
    {
        protected override double[][][] VremOper { get; set; } = new double[][][]
        {
            // d = 10 мм
            new double[][]
            {
            // припуск 0.8
            new double [] {0.27, 0.32, 0.41, 0.56, 0.70, 0.86, 1.25, 1.95},
            // припуск 1.6
            new double [] {0.38, 0.52, 0.65, 0.97, 1.25, 1.60, 2.30, 3.70}
            },
            // d = 15 мм
            new double[][]
            {
            new double [] {0.25, 0.32, 0.40, 0.54, 0.67, 0.84, 1.19, 1.75},
            new double [] {0.38, 0.48, 0.65, 0.92, 1.19, 1.50, 2.20, 3.70}
            },
            // d = 20 мм
            new double[][]
            {
            new double [] {0.25, 0.32, 0.38, 0.48, 0.60, 0.75, 1.05, 1.65},
            new double [] {0.35, 0.45, 0.60, 0.86, 1.10, 1.40, 2.00, 3.20}
            },
            // d = 25 мм
            new double[][]
            {
            new double [] {0.25, 0.32, 0.35, 0.48, 0.60, 0.75, 1.05, 1.55},
            new double [] {0.32, 0.43, 0.60, 0.80, 1.05, 1.30, 1.90, 3.00}
            },
            // d = 30 мм
            new double[][]
            {
            new double [] {0.27, 0.36, 0.43, 0.59, 0.76, 0.92, 1.30, 2.10},  // припуск 1.0
            new double [] {0.32, 0.42, 0.60, 0.86, 1.10, 1.40, 2.00, 3.20},  // припуск 1.6
            new double [] {0.39, 0.54, 0.86, 1.05, 1.30, 1.70, 2.50, 4.05}   // припуск 2.0
            },
            // d = 40 мм (припыски 1.0, 1.6, 2.0)
            new double[][]
            {
                new double [] {0.31, 0.40, 0.50, 0.70, 0.86, 1.10, 1.55, 2.45},  // припуск 1.0
                new double [] {0.40, 0.54, 0.65, 0.97, 1.25, 1.60, 2.30, 3.80},  // припуск 1.6
                new double [] {0.45, 0.62, 1.00, 1.15, 1.55, 2.00, 2.90, 4.65}   // припуск 2.0
            },
            // d = 50 мм
            new double[][]
            {
                new double [] {0.33, 0.44, 0.54, 0.76, 0.95, 1.20, 1.75, 2.75},
                new double [] {0.43, 0.60, 0.76, 1.15, 1.40, 1.85, 2.70, 4.30},
                new double [] {0.49, 0.65, 1.15, 1.30, 1.70, 2.25, 3.20, 5.50}
            },
            // d = 60 мм (только конусности до 1:20)
            new double[][]
            {
                new double [] {0.49, 0.69, 0.89, 1.30, 1.65, 2.10},  // припуск 1.0
                new double [] {0.54, 0.78, 1.25, 1.50, 2.00, 2.60},  // припуск 1.6
                new double [] {0.76, 1.10, 1.45, 2.20, 2.90, 3.80}   // припуск 2.0
            },
            // d = 70 мм (только конусности до 1:15)
            new double[][]
            {
                new double [] {0.52, 0.72, 0.93, 1.35, 1.70},  // припуск 1.0
                new double [] {0.60, 0.86, 1.35, 1.60, 2.10},  // припуск 1.6
                new double [] {0.79, 1.20, 1.50, 2.40, 3.00}   // припуск 2.0
            },
            // d = 80 мм (только конусности до 1:10)
            new double[][]
            {
                new double [] {0.54, 0.78, 1.00, 1.50},  // припуск 1.0
                new double [] {0.65, 0.92, 1.50, 1.75},  // припуск 1.6
                new double [] {0.86, 1.30, 1.65, 2.60}   // припуск 2.0
            }

        };
        protected override string[] GlubSpis { get; set; } = new string[] { "1 : 3", "1 : 5", "1 : 7", "1 : 10", "1 : 15", "1 : 20", "1 : 30", "1 : 50" };
        protected override double[] DiamSpis { get; set; } = new double[] { 10, 15, 20, 25, 30, 40, 50, 60, 70, 80 };
        protected override double[][] GlubRezs { get; set; } = new double[][]
        {
            new double[] {0.8,1.6},
            new double[] {0.8,1.6},
            new double[] {0.8,1.6},
            new double[] {0.8,1.6},
            new double[] {1.0,1.6,2.0},
            new double[] {1.0,1.6,2.0},
            new double[] {1.0,1.6,2.0},
            new double[] {1.0,1.6,2.0},
            new double[] {1.0,1.6,2.0},
            new double[] {1.0,1.6,2.0}
        };
        public RazvKonChugР6М58(double diam, string glubStr, double GlubRez)
        {
            Diam = diam;
            GlubStr = glubStr;
            this.GlubRez = GlubRez;
        }
    }
    public class RazvKonChugР6М57 : RazvKonModel
    {
        protected override double[][][] VremOper { get; set; } = new double[][][]
        {
            // d = 10 мм
            new double[][]
            {
                // припуск 0.8
                new double[] {0.49, 0.58, 0.71, 0.94, 1.15, 1.45, 2.00, 3.00},
                // припуск 1.6
                new double[] {0.59, 0.78, 0.95, 1.35, 1.70, 2.15, 3.10, 4.90}
            },
            // d = 15 мм
            new double[][]
            {
                new double[] {0.49, 0.59, 0.71, 0.95, 1.15, 1.45, 2.00, 3.10},
                new double[] {0.60, 0.76, 0.96, 1.35, 1.65, 2.10, 3.00, 5.00}
            },
            // d = 20 мм
            new double[][]
            {
                new double[] {0.47, 0.59, 0.69, 0.98, 1.10, 1.35, 1.85, 2.95},
                new double[] {0.57, 0.73, 0.91, 1.25, 1.60, 2.00, 2.80, 4.15}
            },
            // d = 25 мм
            new double[][]
            {
                new double[] {0.49, 0.63, 0.71, 0.92, 1.10, 1.40, 1.90, 2.90},
                new double[] {0.59, 0.71, 0.89, 1.25, 1.55, 1.95, 2.75, 4.30}
            },
            // d = 30 мм
            new double[][]
            {
                // припуск 1.0
                new double[] {0.52, 0.66, 0.78, 1.05, 1.30, 1.60, 2.25, 3.55},
                // припуск 1.6
                new double[] {0.60, 0.77, 0.94, 1.30, 1.60, 2.10, 2.95, 4.65},
                // припуск 2.0
                new double[] {0.64, 0.81, 1.20, 1.50, 1.85, 2.40, 3.40, 5.50}
            },
            // d = 40 мм
            new double[][]
            {
                new double[] {0.57, 0.71, 0.86, 1.20, 1.45, 1.80, 2.55, 3.95},
                new double[] {0.65, 0.85, 1.00, 1.45, 1.85, 2.35, 3.30, 5.50},
                new double[] {0.71, 0.95, 1.35, 1.65, 2.10, 2.70, 3.90, 6.00}
            },
            // d = 50 мм
            new double[][]
            {
                new double[] {0.61, 0.77, 0.96, 1.25, 1.55, 2.00, 2.80, 4.40},  // припуск 1.0
                new double[] {0.71, 0.92, 1.20, 1.65, 2.05, 2.60, 3.75, 6.00},  // припуск 1.6
                new double[] {0.77, 0.97, 1.55, 1.80, 2.35, 3.05, 4.30, 7.00}   // припуск 2.0
            },
            // d = 60 мм
            new double[][]
            {
                new double[] {0.79, 1.05, 1.30, 1.85, 2.30, 2.95, 0.00, 0.00},  // припуск 1.0 (до 1:20)
                new double[] {0.84, 1.10, 1.65, 2.05, 2.65, 3.40, 0.00, 0.00},  // припуск 1.6
                new double[] {1.05, 1.45, 1.85, 2.75, 3.55, 4.60, 0.00, 0.00 }  // припуск 2.0
            },
            // d = 70 мм
            new double[][]
            {
                new double[] {0.82, 1.20, 1.35, 1.95, 2.30, 0.00, 0.00, 0.00},  // припуск 1.0 (до 1:15)
                new double[] {0.90, 1.25, 1.80, 2.20, 2.80, 0.00, 0.00, 0.00},  // припуск 1.6
                new double[] {1.10, 1.55, 1.95, 2.95, 3.70, 0.00, 0.00, 0.00 }  // припуск 2.0
            },
            // d = 80 мм
            new double[][]
            {
                new double[] {0.85, 1.15, 1.45, 2.10, 0.00, 0.00, 0.00, 0.00},  // припуск 1.0 (до 1:10)
                new double[] {0.96, 1.30, 1.95, 2.30, 0.00, 0.00, 0.00, 0.00},  // припуск 1.6
                new double[] {1.20, 1.65, 2.10, 3.20, 0.00, 0.00, 0.00, 0.00 }  // припуск 2.0
            }

        };
        protected override string[] GlubSpis { get; set; } = new string[] { "1 : 3", "1 : 5", "1 : 7", "1 : 10", "1 : 15", "1 : 20", "1 : 30", "1 : 50" };
        protected override double[] DiamSpis { get; set; } = new double[] { 10, 15, 20, 25, 30, 40, 50, 60, 70, 80 };
        protected override double[][] GlubRezs { get; set; } = new double[][]
        {
            new double[] {0.8,1.6},
            new double[] {0.8,1.6},
            new double[] {0.8,1.6},
            new double[] {0.8,1.6},
            new double[] {1.0,1.6,2.0},
            new double[] {1.0,1.6,2.0},
            new double[] {1.0,1.6,2.0},
            new double[] {1.0,1.6,2.0},
            new double[] {1.0,1.6,2.0},
            new double[] {1.0,1.6,2.0}
        };
        public RazvKonChugР6М57(double diam, string glubStr, double GlubRez)
        {
            Diam = diam;
            GlubStr = glubStr;
            this.GlubRez = GlubRez;
        }
    }
    public class RazvKonStKonstrT15K68 : RazvKonModel
    {
        protected override double[][][] VremOper { get; set; } = new double[][][]
        {
            // d = 10 мм, припуски 0.8 и 1.6
            new double[][] 
            {
                new double [] {0.28, 0.35, 0.45, 0.62, 0.78, 1.00, 1.40, 2.35},
                new double [] {0.40, 0.55, 0.73, 1.10, 1.40, 1.85, 2.65, 4.35}
            },
            // d = 15 мм, припуски 0.8 и 1.6
            new double[][]
            {
                new double [] {0.26, 0.32, 0.40, 0.55, 0.68, 0.85, 1.20, 1.90},
                new double [] {0.35, 0.50, 0.65, 0.95, 1.20, 1.55, 2.30, 3.70}
            },
            // d = 20 мм, припуски 0.8 и 1.6
            new double[][]
            {
                new double [] {0.25, 0.30, 0.38, 0.50, 0.65, 0.80, 1.15, 1.80},
                new double [] {0.35, 0.50, 0.60, 0.90, 1.15, 1.50, 2.15, 3.40}
            },
            // d = 25 мм, припуски 0.8, 1.6
            new double[][]
            {
                new double [] {0.25, 0.32, 0.40, 0.55, 0.68, 0.85, 1.20, 1.90},
                new double [] {0.35, 0.50, 0.65, 0.95, 1.20, 1.55, 2.30, 3.70},
                
            },
            // d = 30 мм, припуски 1.0, 1.6 и 2.0
            new double[][]
            {
                new double [] {0.30, 0.40, 0.50, 0.70, 0.85, 1.05, 1.55, 2.40},
                new double [] {0.37, 0.50, 0.70, 0.95, 1.25, 1.60, 2.35, 3.80},
                new double [] {0.45, 0.60, 1.00, 1.20, 1.50, 2.00, 2.90, 4.70}
            },
            // d = 40 мм
            new double[][]
            {
                // припуск 1.0
                new double [] {0.32, 0.43, 0.53, 0.77, 0.95, 1.20, 1.85, 2.80},
                // припуск 1.6
                new double [] {0.42, 0.60, 0.75, 1.10, 1.40, 1.85, 2.70, 4.40},
                // припуск 2.0
                new double [] {0.48, 0.70, 1.10, 1.30, 1.70, 2.25, 3.30, 5.50}
            },
            // d = 50 мм
            new double[][]
            {
                new double [] {0.35, 0.45, 0.58, 0.85, 1.05, 1.35, 1.95, 3.10},
                new double [] {0.45, 0.65, 0.80, 1.20, 1.60, 2.00, 3.00, 4.90},
                new double [] {0.50, 0.75, 1.20, 1.45, 1.90, 2.50, 3.70, 6.00}
            },
            // d = 60 мм
            new double[][]
            {
                new double [] {0.50, 0.63, 0.93, 1.40, 1.80, 2.30, 3.40, 5.50},
                new double [] {0.60, 0.85, 1.40, 1.70, 2.20, 2.80, 4.20, 6.85},
                new double [] {0.80, 1.20, 1.60, 2.45, 3.20, 4.20, 6.00,10.00}
            },
            // d = 70 мм
            new double[][]
            {
                new double [] {0.55, 0.75, 1.00, 1.50, 1.90, 2.50, 3.60, 6.00},
                new double [] {0.65, 0.90, 1.40, 1.80, 2.30, 3.00, 4.50, 7.50},
                new double [] {0.85, 1.25, 1.70, 2.60, 3.40, 4.50, 6.50,11.00}
            },
            // d = 80 мм
            new double[][]
            {
                new double [] {0.60, 0.80, 1.05, 1.60, 2.00, 2.65, 3.90, 6.50},
                new double [] {0.65, 0.95, 1.50, 1.90, 2.50, 3.30, 4.80, 8.00},
                new double [] {0.90, 1.35, 1.80, 2.80, 3.60, 4.80, 7.00,11.15}
            }


        };
        protected override string[] GlubSpis { get; set; } = new string[] {"1 : 3", "1 : 5", "1 : 7", "1 : 10", "1 : 15", "1 : 20", "1 : 30", "1 : 50"};
        protected override double[] DiamSpis { get; set; } = new double[] { 10, 15, 20, 25, 30, 40, 50, 60, 70, 80};
        protected override double[][] GlubRezs { get; set; } = new double[][]
        {
            new double[] {0.8,1.6},
            new double[] {0.8,1.6},
            new double[] {0.8,1.6},
            new double[] {0.8,1.6},
            new double[] {1.0,1.6,2.0},
            new double[] {1.0,1.6,2.0},
            new double[] {1.0,1.6,2.0},
            new double[] {1.0,1.6,2.0},
            new double[] {1.0,1.6,2.0},
            new double[] {1.0,1.6,2.0}
        };
        public RazvKonStKonstrT15K68(double diam, string glubStr, double GlubRez)
        {
            Diam = diam;
            GlubStr = glubStr;
            this.GlubRez = GlubRez;
        }
    }
    public class RazvKonStKonstrT15K67 : RazvKonModel
    {
        protected override double[][][] VremOper { get; set; } = new double[][][]
        {
            // d = 10 мм, припуски 0.8 и 1.6
            new double[][]
            {
                // припуск 0.8 мм
                new double [] { 0.51, 0.65, 0.81, 1.10, 1.40, 1.75, 2.50, 4.05 },
                // припуск 1.6 мм
                new double [] { 0.65, 0.85, 1.10, 1.60, 2.05, 2.65, 3.70, 6.00 }
            },
            // d = 15 мм
            new double[][]
            {
                // припуск 0.8 мм
                new double [] { 0.50, 0.64, 0.78, 1.10, 1.35, 1.70, 2.35, 3.75 },
                // припуск 1.6 мм
                new double [] { 0.60, 0.82, 1.05, 1.50, 1.85, 2.40, 3.45, 5.55 }
            },
            // d = 20 мм, припуски 0.8, 1.6
            new double[][]
            {
                new double [] {0.50, 0.63, 0.78, 1.05, 1.35, 1.70, 2.40, 3.80},
                new double [] {0.55, 0.83, 1.00, 1.45, 1.85, 2.40, 3.40, 5.50}
            },
            // d = 25 мм, припуски 0.8, 1.6
            new double[][]
            {
                new double [] {0.51, 0.66, 0.83, 1.15, 1.45, 1.80, 2.55, 4.05},
                new double [] {0.61, 0.84, 1.10, 1.55, 1.95, 2.50, 3.65, 6.00}
            },
            // d = 30 мм, припуски 1.0, 1.6, 2.0
            new double[][]
            {
                new double [] {0.57, 0.75, 0.95, 1.30, 1.65, 2.05, 2.95, 4.65},
                new double [] {0.64, 0.85, 1.15, 1.55, 2.05, 2.60, 3.75, 6.00},
                new double [] {0.72, 0.95, 1.45, 1.80, 2.30, 3.00, 4.30, 7.00}
            },
            // d = 40 мм, припуски 1.0, 1.6, 2.0
            new double[][]
            {
                new double [] {0.61, 0.80, 1.00, 1.40, 1.80, 2.50, 3.35, 5.00},
                new double [] {0.71, 0.97, 1.00, 1.75, 2.15, 2.90, 4.20, 7.00},
                new double [] {0.77, 1.05, 1.55, 1.95, 2.55, 3.30, 4.80, 8.00}
            },
            // d = 50 мм, припуски 1.0, 1.6, 2.0
            new double[][]
            {
                new double [] {0.66, 0.85, 1.10, 1.55, 1.90, 2.45, 3.50, 5.30},
                new double [] {0.76, 1.05, 1.30, 1.90, 2.45, 3.10, 4.55, 7.50},
                new double [] {0.81, 1.15, 1.70, 2.15, 2.75, 3.60, 5.50, 8.50}
            },
            // d = 60 мм, припуски 1.0, 1.6, 2.0
            new double[][]
            {
                new double [] {0.83, 1.05, 1.45, 2.15, 2.70, 3.45, 5.00, 8.05},
                new double [] {0.93, 1.30, 1.95, 2.45, 3.10, 3.95, 6.00, 9.50},
                new double [] {1.15, 1.65, 2.15, 3.20, 4.10, 5.50, 8.00, 13.00}
            },
            // d = 70 мм, припуски 1.0, 1.6, 2.0
            new double[][]
            {
                new double [] {0.90, 1.20, 1.55, 2.55, 2.85, 3.70, 5.50, 8.50},
                new double [] {1.00, 1.35, 1.95, 2.55, 3.25, 4.20, 6.00, 10.00},
                new double [] {1.20, 1.70, 2.25, 3.35, 4.35, 5.50, 8.50, 13.50}
            },
            // d = 80 мм, припуски 1.0, 1.6, 2.0
            new double[][]
            {
                new double [] {0.95, 1.30, 1.65, 2.40, 3.00, 4.00, 6.00, 9.00},
                new double [] {1.01, 1.45, 2.10, 2.70, 3.50, 4.65, 6.65, 10.50},
                new double [] {1.25, 1.85, 2.40, 3.60, 4.60, 6.00, 9.00, 14.50}
            }
        };
        protected override string[] GlubSpis { get; set; } = new string[] { "1 : 3", "1 : 5", "1 : 7", "1 : 10", "1 : 15", "1 : 20", "1 : 30", "1 : 50" };
        protected override double[] DiamSpis { get; set; } = new double[] { 10, 15, 20, 25, 30, 40, 50, 60, 70, 80 };
        protected override double[][] GlubRezs { get; set; } = new double[][]
        {
            new double[] {0.8,1.6},
            new double[] {0.8,1.6},
            new double[] {0.8,1.6},
            new double[] {0.8,1.6},
            new double[] {1.0,1.6,2.0},
            new double[] {1.0,1.6,2.0},
            new double[] {1.0,1.6,2.0},
            new double[] {1.0,1.6,2.0},
            new double[] {1.0,1.6,2.0},
            new double[] {1.0,1.6,2.0}
        };
        public RazvKonStKonstrT15K67(double diam, string glubStr, double GlubRez)
        {
            Diam = diam;
            GlubStr = glubStr;
            this.GlubRez = GlubRez;
        }
    }
    public class RazvKonModelFactory
    {
        public static RazvKonModel Create(string mat, string matinstr, double diam, string glubStr, int Kval, double GlubRez)
        {
            if (mat == "Чугун" && matinstr == "Р6М5" && Kval == 8)
                return new RazvKonChugР6М58(diam, glubStr, GlubRez);
            else if (mat == "Чугун" && matinstr == "Р6М5" && Kval == 7)
                return new RazvKonChugР6М57(diam, glubStr, GlubRez);
            else if (mat == "Сталь углеродистая" && matinstr == "T15K6" && Kval == 8)
                return new RazvKonStKonstrT15K68(diam, glubStr, GlubRez);
            else if (mat == "Сталь углеродистая" && matinstr == "T15K6" && Kval == 7)
                return new RazvKonStKonstrT15K67(diam, glubStr, GlubRez);
            else
                throw new ArgumentException("Неподдерживаемая комбинация");
        }
    }
}
