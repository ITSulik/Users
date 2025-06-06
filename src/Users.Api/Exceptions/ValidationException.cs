using System;

namespace Users.Api.Exceptions;

public class ValidationException : Exception
{
    public ValidationException(string message) : base(message){}
    
}