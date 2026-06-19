using System;
using System.ComponentModel;

namespace AromaCraft.Domain.Models;

public record Result<T>
{
    public bool IsSuccess { get; }
    public bool IsFailed => !IsSuccess;
    public T Value { get; }
    public string Message { get; } = string.Empty;

    private Result() { }
    private Result(bool isSuccess, T value)
    {
        IsSuccess = isSuccess;
        Value = value;
    }

    private Result(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(true, value);
    }

    public static Result<T> Fail(string message)
    {
        return new Result<T>(false, message);
    }
}
