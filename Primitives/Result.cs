using DocumentManagment.Domains.Errors;

namespace DocumentManagment.Domains.Primitives;

public class Result<T>
{

    private Result(T result)
    {
        IsSuccess = true;
        Error = Error.None;
        Value = result;
    }

    private Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }
        IsSuccess = isSuccess;
        Error = error;
        Value = default;
    }

    public T? Value { get; private set; }

    public bool IsSuccess { get; set; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; set; }

    public static implicit operator Result<T>(T value) => Result<T>.Success(value);
    public static Result<T> Success(T value) => new(value);

    public static Result<T> Failure(Error error) => new(false, error);
}

public class Result
{
    private Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None ||
            !isSuccess && error == Error.None)
        {
            throw new ArgumentException("Invalid error", nameof(error));
        }
        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; set; }

    public bool IsFailure => !IsSuccess;

    public Error Error { get; set; }

    public static Result Success() => new(true, Error.None);

    public static Result Failure(Error error) => new(false, error);
}
