namespace WebApplicationDB.Middleware;

public class UserIdLoggingMiddleware
{
    private readonly RequestDelegate _next;
    public UserIdLoggingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public Task Invoke(HttpContext context)
    {
        Console.WriteLine("test");
        return _next.Invoke(context);
    }
}
