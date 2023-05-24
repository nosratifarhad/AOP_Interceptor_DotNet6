using Castle.DynamicProxy;
using System.Diagnostics;
using System.Reflection;

namespace AOPInterceptorWebApplication.Logging;

//https://aspnetboilerplate.com/Pages/Documents/Articles/Aspect-Oriented-Programming-using-Interceptors/index.html
public interface ILoggingInterceptor : IInterceptor { }

public class LoggingInterceptor : ILoggingInterceptor
{
    public ILogger Logger { get; set; }

    public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
    {
        Logger = logger;
    }

    public void Intercept(IInvocation invocation)
    {
        try
        {
            if (IsAsyncMethod(invocation.Method))
            {
                InterceptAsync(invocation);
            }
            else
            {
                InterceptSync(invocation);
            }
        }
        catch (Exception exp)
        {
            Logger.LogError(
                "Exception Message: {0}.", exp.Message);
            throw new Exception(exp.Message);
        }
    }

    private void InterceptAsync(IInvocation invocation)
    {
        //Before method execution
        var stopwatch = Stopwatch.StartNew();

        //Calling the actual method, but execution has not been finished yet
        invocation.Proceed();

        //We should wait for finishing of the method execution
        ((Task)invocation.ReturnValue)
            .ContinueWith(task =>
            {
                //After method execution
                stopwatch.Stop();
                Logger.LogInformation(
                    "MeasureDurationAsyncInterceptor: {0} executed in {1} milliseconds.",
                    invocation.MethodInvocationTarget.Name,
                    stopwatch.Elapsed.TotalMilliseconds.ToString("0.000")
                    );
            });
    }

    private void InterceptSync(IInvocation invocation)
    {
        //Before method execution
        var stopwatch = Stopwatch.StartNew();

        //Executing the actual method
        invocation.Proceed();

        //After method execution
        stopwatch.Stop();
        Logger.LogInformation(
            "MeasureDurationAsyncInterceptor: {0} executed in {1} milliseconds.",
            invocation.MethodInvocationTarget.Name,
            stopwatch.Elapsed.TotalMilliseconds.ToString("0.000")
            );
    }

    public static bool IsAsyncMethod(MethodInfo method)
    {
        return (
            method.ReturnType == typeof(Task) ||
            (method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == typeof(Task<>))
            );
    }
}
