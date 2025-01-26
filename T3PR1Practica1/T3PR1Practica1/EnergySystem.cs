using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace T3PR1Practica1
{
    public abstract class EnergySystem : IEnergyCalculable
    {
        public string SystemType { get; protected set; }
        public double GeneratedEnergy { get; protected set; }
        public DateTime SimulationDate { get; set; }

        public abstract void ConfigureParameters();
        public abstract void CalculateEnergy();
    }
}