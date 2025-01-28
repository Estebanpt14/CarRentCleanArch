using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Abstractions;

namespace CleanArchitecture.Domain.Abstractions
{
    public class Result
    {
        public Result(bool isSuccess,Error error)
        {
            if((isSuccess && error != Error.None) || (!isSuccess && error == Error.None))
                throw new InvalidOperationException();
            
            IsSuccess = isSuccess;
            Error = error;
        }

        public bool IsSuccess {get;}

        public Error Error{get;}

        public static Result Success() => new(true, Error.None);

        public static Result Failure(Error error) => new(false, error);

        public static Result<T> Success<T>(T value)
            => new(value, true, Error.None);

        public static Result<T> Failure<T>(Error error)
            => new(default, false, error);

        public static Result<T> Create<T>(T? value)
            => value is not null ? Success(value) : Failure<T>(Error.Null);
    }
}

public class Result<T> : Result
{
    private readonly T? _value;

    protected internal Result(T value, bool isSuccess, Error error) : base(isSuccess, error)
    {
        _value = value;
    }

    [NotNull]
    public T Value => IsSuccess 
        ? _value! 
        : throw new InvalidOperationException("The result value is not valid");

    public static implicit operator Result<T> (T value) => Create(value);
}