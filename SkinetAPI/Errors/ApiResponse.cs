﻿
namespace SkinetAPI.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode, string message = null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDeafultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }

        private string GetDeafultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "You have made bad request",
                401 => "You are not authorized",
                404 => "Resource was not found",
                500 => "An error has occured",
                _ => null
            };
        }
    }
}