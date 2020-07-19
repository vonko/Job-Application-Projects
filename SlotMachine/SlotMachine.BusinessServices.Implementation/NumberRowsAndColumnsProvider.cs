namespace SlotMachine.BusinessServices.Implementation
{
    public class NumberRowsAndColumnsProvider : INumberRowsAndColumnsProvider
    {
        /*I could not well understand from the task 
          requirement whether on every game turn we should generate 4 rows of symbols, but from the picture it looks this way*/
        private const int NUMBER_ROWS = 4;
        private const int NUMBER_COLUMNS = 3;

        public int NumberRows
        {
            get
            {
                return NUMBER_ROWS;
            }
        }

        public int NumberColumns
        {
            get
            {
                return NUMBER_COLUMNS;
            }
        }
    }
}
