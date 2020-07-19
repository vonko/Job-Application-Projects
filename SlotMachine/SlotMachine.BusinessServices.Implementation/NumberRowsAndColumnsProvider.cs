namespace SlotMachine.BusinessServices.Implementation
{
    public class NumberRowsAndColumnsProvider : INumberRowsAndColumnsProvider
    {
        /*I could not well understand from the task 
          requirements whether on every game turn we should generate 4 rows of symbols, 
          but from the picture and the phrase below it looks this way:

          'A table with the results of each spin is displayed to the player. '
          
          However it seems strange to me, I think every turn should be only one row
          and this is easily changed if we change the NUMBER_ROWS constant below to 1*/

        private const int NUMBER_ROWS_PER_TURN = 4; //= 1?
        private const int NUMBER_COLUMNS = 3;

        public int NumberRowsPerTurn
        {
            get
            {
                return NUMBER_ROWS_PER_TURN;
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
