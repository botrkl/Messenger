namespace FlashApp.Api.Middlewares
{
    public class UnauthorizedMiddleware:IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            await next(context);
            if (context.Response.StatusCode == 401)
            {
                context.Response.Redirect("https://localhost:7270/");
            }
        }
    }
}
