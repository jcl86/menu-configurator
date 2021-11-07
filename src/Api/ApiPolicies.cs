using MenuConfigurator.Model;
using Microsoft.AspNetCore.Authorization;

namespace MenuConfigurator.Api
{
    public static class ApiPolicies
    {
        public const string AdminOnly = nameof(AdminOnly);

        public static void Configure(AuthorizationOptions options)
        {
            options.InvokeHandlersAfterFailure = true;

            options.AddPolicy(AdminOnly, policy =>
            {
                policy.RequireAuthenticatedUser();
                policy.RequireRole(Roles.Administrator);
            });

            options.AddPolicyFromPermission("PolicyName", 
                new string[] { "Permission1", "Permission2" });

        }

        private static void AddPolicyFromPermission(this AuthorizationOptions options, 
            string policyName, 
            string[] allowedClaims)
        {
            options.AddPolicy(policyName, policy =>
            {
                policy.RequireAuthenticatedUser();

                policy.RequireAssertion(
                    context =>
                    {
                        if (context.User.IsInRole(Roles.Administrator))
                        {
                            return true;
                        }

                        foreach (var item in allowedClaims)
                        {
                            if (context.User.HasClaim(claim => claim.Type == Permissions.PermissionClaim && claim.Value == item))
                            {
                                return true;
                            }
                        }
                        return false;
                    });
            });
        }
    }
}