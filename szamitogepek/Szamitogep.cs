using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace szamitogepek
{
    public class Szamitogep
    {
        public int Azonosito { get; set; }
        public string CPU { get; set; }
        public double Sebesseg { get; set; }
        public int RAM { get; set; }
        public string Tipus { get; set; }
        public string OS { get; set; }
        public string Gyarto { get; set; }
        public string Modell { get; set; }
        public double KijelzoMeret { get; set; }

        public double KijelzoMeretCm => this.KijelzoMeret * 2.54;

        public Szamitogep(string s)
        {
            string[] v = s.Split('|');
            this.Azonosito = int.Parse(v[0]);
            this.CPU = v[1];
            this.Sebesseg = double.Parse(v[2]);
            string[] ramAdatok = v[3].Split(' ');
            this.RAM = int.Parse(ramAdatok.First());
            this.Tipus = ramAdatok.Last();
            this.OS = v[4];
            this.Gyarto = v[5].Split(' ').First();
            this.Modell = v[5].Split(' ').Last();
            this.KijelzoMeret = double.Parse(v[6]);
        }

        public override string ToString()
        {
            return $"{this.Azonosito}, {this.CPU}, {this.Sebesseg}, {this.RAM}GB {this.Tipus}, {this.OS}, {this.Gyarto}, {this.Modell}, {this.KijelzoMeret}";
        }
    }
}
