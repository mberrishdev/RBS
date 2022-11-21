namespace RBS.API.Infrastracture
{
    public class CancellationMiddleware
    {
        private readonly RequestDelegate _next;

        public CancellationMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            using (var timoutTS = CancellationTokenSource.CreateLinkedTokenSource(context.RequestAborted))
            {
                //todo add cancellation time in settings
                timoutTS.CancelAfter(15000);
                context.RequestAborted = timoutTS.Token;
                await _next(context);
            }
        }
    }
}
