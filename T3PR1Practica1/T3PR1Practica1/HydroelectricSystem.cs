using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T3PR1Practica1
{
    public class HydroelectricSystem : EnergySystem
    {
        public const string EnterWaterFlow = "Introdueix el cabal d'aigua (>=20 m3): ";
        public const string ErrorWaterFlow = "El cabal d'aigua ha de ser com a mínim 20 m3. Torna a provar-ho.";

        private double waterFlow;

        public HydroelectricSystem()
        {
            SystemType = "Hidroelectrica";
        }

        public override void ConfigureParameters()
        {
            waterFlow = HelperClass.RequestValue(EnterWaterFlow, ErrorWaterFlow, 20);
        }

        public void ConfigureParameters(double waterFlow)
        {
            this.waterFlow = waterFlow;
        }

        public override double CalculateEnergy()
        {
            GeneratedEnergy = waterFlow * 9.8 * 0.8;
            return GeneratedEnergy;
        }
    }
}