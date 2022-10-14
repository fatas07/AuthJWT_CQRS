namespace AuthJWT_CQRS.Business.CQRS.Models.Base
{
    public class ErrorHandlerModel
    {
        public string Code { get; set; }
        public string Message { get; set; }

        public ErrorHandlerModel(string Code, string Message)
        {
            this.Code = Code;
            this.Message = Message;

        }
    }
}
