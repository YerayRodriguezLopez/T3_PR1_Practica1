using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T3PR1Practica1
{
    public class WindSystem : EnergySystem
    {
        public const string EnterWindSpeed = "Introdueix la velocitat del vent (>=5 m/s): ";
        public const string ErrorWindSpeed = "La velocitat del vent ha de ser com a mínim 5 m/s. Torna a provar-ho.";

        private double windSpeed;

        public WindSystem()
        {
            SystemType = "Eolic";
        }

        public override void ConfigureParameters()
        {
            windSpeed = Program.RequestValue(EnterWindSpeed, ErrorWindSpeed, 5);
        }

        public override void CalculateEnergy()
        {
            GeneratedEnergy = Math.Pow(windSpeed, 3) * 0.2;
        }
    }
}