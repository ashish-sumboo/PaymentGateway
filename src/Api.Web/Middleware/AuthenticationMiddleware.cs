namespace Api.Web.Middleware
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;

    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate next;

        public AuthenticationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            string authHeader = context.Request.Headers["Authorization"];

            if (authHeader != null && authHeader.Equals("Bearer NWY5MzAxNTU4OWZjZWEwMThmMGMyZDk3YmQwYTM1MDgxODZhOGI3ZDM2MDU5MWIwNTQ3ZDA3NDNk", StringComparison.OrdinalIgnoreCase))
            {
                await this.next.Invoke(context);
            }
            else
            {
                context.Response.StatusCode = 401;
            }
        }
    }
}
