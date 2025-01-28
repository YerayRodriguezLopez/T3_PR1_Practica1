namespace T3PR1Practica1
{
    public class Program
    {
        private static EnergySystem[] Simulations;
        private static int SimulationIndex = 0;

        public const string MenuOption1 = "1. Iniciar simulació";
        public const string MenuOption2 = "2. Veure informe de simulacions";
        public const string MenuOption3 = "3. Sortir";
        public const string InvalidOption = "Opció invàlida.";
        public const string Exiting = "Sortint de l'aplicació.";
        public const string MaxSimulationsReached = "No hi ha més espai disponible per a noves simulacions.";
        public const string Error = "Error: {0}";
        public const string SelectSystemType = "Selecciona el tipus de sistema:";
        public const string SystemTypeSolar = "1. Solar";
        public const string SystemTypeWind = "2. Eòlic";
        public const string SystemTypeHydro = "3. Hidroelèctric";
        public const string OptionPrompt = "Opció: ";
        public const string EnterMaxSimulations = "Introdueix el nombre màxim de simulacions: ";
        public const string PositiveNumberError = "La capacitat ha de ser un número positiu. Torna a provar-ho.";
        public const string EmptyReport = "No hi ha simulacions registrades.";
        public const string SimulationCompleted = "Simulació completada. Energia generada: {0} unitats.";
        public const string SimulationReportTitle = "\nInforme de Simulacions:";
        public const string SimulationReportHeader = "--------------------------------------------------------------";
        public const string SimulationReportColumns1 = "| {0,-20} | {1,-14} | {2,16:F2} | ";
        public const string SimulationReportColumns2 = "| {0,-20} | {1,-16} | {2,16:F2} | ";
        public const string DateColumn = "Data i hora";
        public const string TypeColumn = "Tipus de Sistema";
        public const string EnergyColumn = "Energia Generada";
        public const string MenuTitle = "Menú:";

        public static void Main()
        {
            bool flag = false;

            while (!flag)
            {
                DisplayMenu();

                switch (Console.ReadLine())
                {
                    case "1":
                        Console.Clear();
                        if (Simulations == null)
                        {
                            ConfigureMaxSimulations();
                        }
                        StartSimulation();
                        break;
                    case "2":
                        Console.Clear();
                        DisplayReport();
                        break;
                    case "3":
                        Console.Clear();
                        Console.WriteLine(Exiting);
                        flag = true;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine(InvalidOption);
                        break;
                }
            }
        }

        private static void DisplayMenu()
        {
            Console.WriteLine(MenuTitle);
            Console.WriteLine(MenuOption1);
            Console.WriteLine(MenuOption2);
            Console.WriteLine(MenuOption3);
            Console.Write(OptionPrompt);
        }

        private static void ConfigureMaxSimulations()
        {
            Simulations = new EnergySystem[(int)HelperClass.RequestValue(EnterMaxSimulations, PositiveNumberError, 0)];
        }

        private static void StartSimulation()
        {
            if (SimulationIndex >= Simulations.Length)
            {
                Console.Clear();
                Console.WriteLine(MaxSimulationsReached);
            }
            else
            {
                Console.Clear();
                Console.WriteLine(SelectSystemType);
                Console.WriteLine(SystemTypeSolar);
                Console.WriteLine(SystemTypeWind);
                Console.WriteLine(SystemTypeHydro);
                Console.Write(OptionPrompt);
                EnergySystem system = null;

                do
                {
                    switch (Console.ReadLine())
                    {
                        case "1":
                            Console.Clear();
                            system = new SolarSystem();
                            break;
                        case "2":
                            Console.Clear();
                            system = new WindSystem();
                            break;
                        case "3":
                            Console.Clear();
                            system = new HydroelectricSystem();
                            break;
                        default:
                            Console.WriteLine(InvalidOption);
                            break;
                    }
                } while (system == null);

                system.ConfigureParameters();
                system.CalculateEnergy();
                system.SimulationDate = DateTime.Now;
                Simulations[SimulationIndex++] = system;
                Console.Clear();
                Console.WriteLine(string.Format(SimulationCompleted, system.GeneratedEnergy));
            }
        }

        private static void DisplayReport()
        {

            if (Simulations == null || Simulations.All(s => s == null))
            {
                Console.WriteLine(EmptyReport);
            }
            else
            {
                Console.WriteLine(SimulationReportTitle);
                Console.WriteLine(SimulationReportHeader);
                Console.WriteLine(string.Format(SimulationReportColumns1, DateColumn, TypeColumn, EnergyColumn));
                Console.WriteLine(SimulationReportHeader);

                foreach (var simulation in Simulations)
                {
                    if (simulation != null)
                    {
                        Console.WriteLine(string.Format(SimulationReportColumns2, simulation.SimulationDate, simulation.SystemType, simulation.GeneratedEnergy));
                        Console.WriteLine(SimulationReportHeader);
                    }
                }
            }
        }
    }
}
