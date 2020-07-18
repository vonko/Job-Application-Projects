namespace FootballLeague.Models
{
    //Wrapper class for communication between service layer and its client. 
    //It carries the data
    //It can bring information for success or error in case of unexpected behavior instead of exceptions
    //In case of need it can be extended to bring speci result type, for example to give information of a required behavior that must happen in the web layer like redirect

    public class Result<TData> : Result
        where TData : class
    {
        public TData Data { get; set; }

        public Result<TData> SetData(TData data)
        {
            this.Data = data;

            return this;
        }
    }

    public class Result
    {
        public bool IsError { get; set; }

        public bool IsSucess => !this.IsError;

        public string Message { get; set; }

        public Result SetError(string message)
        {
            this.IsError = true;
            this.Message = message;

            return this;
        }

        public Result SetSuccess(string message)
        {
            this.IsError = false;
            this.Message = message;

            return this;
        }       
    }
}
