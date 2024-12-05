using ObjectInAreaSimulation.Enums;

namespace ObjectInAreaSimulation.Classes.Interfaces
{
    public interface ISimulationLogger
    {
        void LogCommand(Commands command, string message);

        void Log(string message);

        void LogError(Exception ex, string message = "");
    }
}
