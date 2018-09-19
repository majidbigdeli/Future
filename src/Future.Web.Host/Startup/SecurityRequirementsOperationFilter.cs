using System.Collections.Generic;
using System.Linq;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Majid.Authorization;

namespace Future.Web.Host.Startup
{
    public class SecurityRequirementsOperationFilter : IOperationFilter
    {
        public void Apply(Operation operation, OperationFilterContext context)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            var actionAttrs = context.ApiDescription.ActionAttributes().ToList();
#pragma warning restore CS0618 // Type or member is obsolete
            if (actionAttrs.OfType<MajidAllowAnonymousAttribute>().Any())
            {
                return;
            }

#pragma warning disable CS0618 // Type or member is obsolete
            var controllerAttrs = context.ApiDescription.ControllerAttributes().ToList();
#pragma warning restore CS0618 // Type or member is obsolete
            var actionMajidAuthorizeAttrs = actionAttrs.OfType<MajidAuthorizeAttribute>().ToList();

            if (!actionMajidAuthorizeAttrs.Any() && controllerAttrs.OfType<MajidAllowAnonymousAttribute>().Any())
            {
                return;
            }

            var controllerMajidAuthorizeAttrs = controllerAttrs.OfType<MajidAuthorizeAttribute>().ToList();
            if (controllerMajidAuthorizeAttrs.Any() || actionMajidAuthorizeAttrs.Any())
            {
                operation.Responses.Add("401", new Response { Description = "Unauthorized" });

                var permissions = controllerMajidAuthorizeAttrs.Union(actionMajidAuthorizeAttrs)
                    .SelectMany(p => p.Permissions)
                    .Distinct().ToList();

                if (permissions.Any())
                {
                    operation.Responses.Add("403", new Response { Description = "Forbidden" });
                }

                operation.Security = new List<IDictionary<string, IEnumerable<string>>>
                {
                    new Dictionary<string, IEnumerable<string>>
                    {
                        { "bearerAuth", permissions }
                    }
                };
            }
        }
    }
}
