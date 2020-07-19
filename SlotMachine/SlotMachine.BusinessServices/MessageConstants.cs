namespace SlotMachine.BusinessServices
{
    public static class MessageConstants
    {
        public const string DEPOSIT_MONEY_STATEMENT = "Please deposit money you would like to play with:";

        public const string ENTER_VALID_DEPOSIT_AMOUNT_ERROR = "Please enter a valid amount to deposit!";

        public const string ENTER_STAKE_AMOUNT_STATEMENT = "Enter stake amount:";

        public const string STAKE_AMOUNT_ERROR = "Please enter a valid stake amount amount!";

        public const string AMOUNT_SET_STATEMENT = "Amount set successfully.";

        public const string DO_NOT_HAVE_ENOUGH_BALANCE_ERROR = "You do not have balance to continue playing!";

        public const string STAKE_AMOUNT_CANNOT_BE_BIGGER_THAN_DEPOSIT_ERROR = "Stake amount cannot be bigger than the remaining deposit amount!";

        public const string VALID_DATA = "Data is valid.";
    }
}
