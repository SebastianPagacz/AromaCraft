using System;
using System.ComponentModel;

namespace AromaCraft.Domain.Models;

public record Result<T>
{
    public bool IsSuccess { get; private set; }
    public T Value { get; private set; }
    public string Message { get; private set; } = string.Empty;

    private Result() { }
    private Result(bool isSuccess, T value, string message)
    {
        IsSuccess = isSuccess;
        Value = value;
        Message = message;
    }

    public static Result<T> Success(T value, string message) // I don't think such level of encapsulation is required. I think just a basic record with fields would be sufficient
    {
        return new Result<T>(true, value, message);
    }

    public static Result<T> Fail(T value, string message) // I don't think such level of encapsulation is required. I think just a basic record with fields would be sufficient
    {
        return new Result<T>(true, value, message);
    }
}
