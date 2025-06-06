using System;

namespace Users.Api.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string message) : base(message){}
    
}   