// Copyright (C) Siemens AG 2022-2024. All rights reserved. Confidential.

Console.WriteLine("Hello, World!\n");

// tag::exception-program[]
Console.WriteLine("Error Handling by Exception\n");

var exceptionBl = new BusinessLogic();

try
{
   var result = exceptionBl.Divide(1, 1);
   Console.WriteLine($"result is: {result}");
}
catch (MyBLException blEx)
{
    Console.WriteLine($"Business Logic Exception: {blEx.Message}");
    Console.WriteLine($"Inner Exception Type: {blEx.InnerException?.GetType().Name}");
}

try
{
   var result = exceptionBl.Divide(1, 0);
   Console.WriteLine($"result is: {result}");
}
catch (MyBLException blEx)
{
    Console.WriteLine($"Business Logic Exception: {blEx.Message}");
    Console.WriteLine($"Inner Exception Type: {blEx.InnerException?.GetType().Name}");
}
// end::exception-program[]

// tag::result-program[]
Console.WriteLine("\nError Handling by Result\n");
 
var resultBL = new BusinessLogicWithResult();

var divisionResult = resultBL.Divide(1, 1);
divisionResult.IsOk(result => Console.WriteLine($"Result of division: {result}"));
divisionResult.IsFail(error => Console.WriteLine($"Error: {error}"));

divisionResult = resultBL.Divide(1, 0);
divisionResult.IsOk(result => Console.WriteLine($"Result of division: {result}"));
divisionResult.IsFail(error => Console.WriteLine($"Error: {error}"));
// end::result-program[]


// tag::exception-contract[]
public class MyBLException : Exception
{
    public MyBLException(string message, Exception innerException) : base(message, innerException)
    {
    }
}
// end::exception-contract[]

// tag::exception-logic[]
public class BusinessLogic
{
    public float Divide(int numerator, int denominator)
    {
        try
        {
            // Business logic code that might throw exceptions like a DivideByZeroException
            return numerator / denominator;
        }
        catch (Exception ex)
        {
            // Catch all inner exceptions and rethrow as MyBLException
            throw new MyBLException("Error in BusinessLogic", ex);
        }
    }
}
// end::exception-logic[]

// tag::result-contract[]
public struct Result<T>
{
    public T? Value { get; }
    public bool IsSuccess { get; }
    public string ErrorMessage { get; }

    private Result(bool isSuccess, T? value, string? errorMessage)
    {
        Value = value;
        IsSuccess = isSuccess;        
        ErrorMessage = errorMessage ?? string.Empty;
    }

    public static Result<T> Success(T value) => new Result<T>(true, value, default);

    public static Result<T> Failure(string errorMessage) => new Result<T>(false, default, errorMessage);
  

    public void IsOk(Action<T> action)
    {
        if (IsSuccess && Value != null)
        {
            action(Value);
        }
    }

    public void IsFail(Action<string> action)
    {
        if (!IsSuccess || Value is null)
        {
            action(ErrorMessage);
        }
    }

    public TResult Match<TResult>(Func<T, TResult> onSuccess, Func<string, TResult> onFail)
    {
        return (IsSuccess && Value != null) ? onSuccess(Value) : onFail(ErrorMessage);
    }

    public Result<TResult> AndThen<TResult>(Func<T, Result<TResult>> then)
    {  
        return Match(then, m => Result<TResult>.Failure(m));
    }

    public Result<T> OrElse(Func<string, Result<T>> @else)
    {
        return Match(value => Result<T>.Success(value), @else);
    }
}
// end::result-contract[]

// tag::result-logic[]
public class BusinessLogicWithResult
{
    public Result<int> Divide(int numerator, int denominator)
    {        
        if (denominator == 0)
        {
            return Result<int>.Failure("Cannot divide by zero.");
        }

        int result = numerator / denominator;
        return Result<int>.Success(result);       
    }

    public Result<int> DivideAndThen(int numerator, int denominator)
    {
        return Divide(numerator, denominator).AndThen(
            result => result > 0 
                ? Result<int>.Success(result) 
                : Result<int>.Failure("Result must be positive.")
        );
    }

    public Result<int> DivideWithMatch(int numerator, int denominator)
    {
        return Divide(numerator, denominator).Match(
            result => result > 0 
                ? Result<int>.Success(result) 
                : Result<int>.Failure("Result must be positive."),
            errorMsg => Result<int>.Failure($"An unexpected error occurred: {errorMsg}")
        );
    }

    public Result<int> DivideWithOrElse(int numerator, int denominator)
    {
        return Divide(numerator, denominator).OrElse(
            m => Result<int>.Success(m.Length)
        );
    }
}
// end::result-logic[]