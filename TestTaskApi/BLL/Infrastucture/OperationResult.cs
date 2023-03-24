namespace TestTaskApi.BLL.Infrastructure
{ 
    public class OperationResult
    {
        public string textErrorMessage { get; set; }
        public string textSuccessMessage { get; set; } = "Успешный результат";

        public  OperationResult(string textErrorMessage)
        {
            this.textErrorMessage = textErrorMessage; 
            this.textSuccessMessage = textSuccessMessage;   
        }
       
        public static OperationResult CreateErrorResult(string textErrorMessage)
        {
            return new OperationResult(textErrorMessage);
        }
        public static OperationResult CreateSuccessResult()
        {
            return new OperationResult(null);
        }
        public static OperationResult CreateSuccessResult(string textSuccessMessage)
        {
            return new OperationResult(null);
        }
    }
}
