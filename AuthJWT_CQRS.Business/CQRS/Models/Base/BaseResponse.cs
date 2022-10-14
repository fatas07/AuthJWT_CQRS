
namespace AuthJWT_CQRS.Business.CQRS.Models.Base
{
    public class ResponseModel
    {
        public bool Success { get; set; }
    }

    public class ResponseModelError : ResponseModel
    {
        public ResponseModelError()
        {
            Success = false;
        }
        public ErrorHandlerModel Error { get; set; }
    }

    public class ResponseModelOk<T> : ResponseModel
    {
        public ResponseModelOk()
        {
            Success = true;
        }
        public T payload { get; set; }
    }

    public class ResponseModelOk : ResponseModel
    {
        public ResponseModelOk()
        {
            Success = true;
        }
    }
}
