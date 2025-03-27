﻿namespace Georeferenciamento.Application.Exceptions;

public sealed class InternalServerErrorException : ApplicationException
{
    public InternalServerErrorException(string? message) : base(message)
    {
    }
}