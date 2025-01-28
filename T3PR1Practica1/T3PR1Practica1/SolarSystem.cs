using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T3PR1Practica1
{
    public class SolarSystem : EnergySystem
    {
        public const string EnterSunHours = "Introdueix les hores de sol disponibles (>1): ";
        public const string ErrorSunHours = "Les hores de sol han de ser superiors a 1. Torna a provar-ho.";
        private double sunHours;

        public SolarSystem()
        {
            SystemType = "Solar";
        }

        public override void ConfigureParameters()
        {
            sunHours = Program.RequestValue(EnterSunHours, ErrorSunHours, 1);
        }
        public void ConfigureParameters(double sunHours)
        {
            this.sunHours = sunHours;
        }

        public override double CalculateEnergy()
        {
            GeneratedEnergy = sunHours * 1.5;
            return GeneratedEnergy;
        }
    }
}