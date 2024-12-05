using ObjectInAreaSimulation.Enums;

namespace ObjectInAreaSimulation.Classes.Interfaces
{
    public interface ISimulation
    {
        void Initialize();

        void Run();

        void FinalizeResult();

        SimulationState ExecuteCommand(int command);
    }
}
