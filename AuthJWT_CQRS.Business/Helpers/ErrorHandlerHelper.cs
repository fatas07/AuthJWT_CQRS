using AuthJWT_CQRS.Business.CQRS.Models.Base;

namespace AuthJWT_CQRS.Business.Helpers
{
    public static class ErrorHandlerHelper
    {
        public static readonly ErrorHandlerModel AUTH_ERROR = new ErrorHandlerModel("1000", Resources.Errors._1000);

        // USER ERROR CODES
        public static readonly ErrorHandlerModel INVALID_USER = new ErrorHandlerModel("2000", Resources.Errors._2000);
        public static readonly ErrorHandlerModel USER_NOT_FOUND = new ErrorHandlerModel("2001", Resources.Errors._2001);
        public static readonly ErrorHandlerModel USER_EXIST = new ErrorHandlerModel("2002", Resources.Errors._2002);
        public static readonly ErrorHandlerModel UNKNOWN_REGISTER_ERROR = new ErrorHandlerModel("2003", Resources.Errors._2003);
        public static readonly ErrorHandlerModel REFRESH_TOKEN_EXPIRED = new ErrorHandlerModel("2004", Resources.Errors._2004);

        // SERVER ERROR CODES
        public static readonly ErrorHandlerModel INTERNAL_SERVER_ERROR = new ErrorHandlerModel("3000", Resources.Errors._3000);

        // MODEL VALIDATION ERROR CODES
        public static readonly ErrorHandlerModel MODEL_VALIDATION_ERROR = new ErrorHandlerModel("4000", Resources.Errors._4000);

        // GENERAL ERROR CODES
        public static readonly ErrorHandlerModel UNEXPECTED_ERROR = new ErrorHandlerModel("5000", Resources.Errors._5000);

    }
}
