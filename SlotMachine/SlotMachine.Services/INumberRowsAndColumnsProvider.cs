namespace SlotMachine.Services
{
    public interface INumberRowsAndColumnsProvider
    {
        //This is a separate service so the logic for number of rows and columns is detached from the game engine
        int NumberRows { get; }

        int NumberColumns { get; }
    }
}
