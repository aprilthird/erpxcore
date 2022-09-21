using ERP.XCore.Hotel.Web.Client.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication.Internal;
using System.Security.Claims;

namespace ERP.XCore.Hotel.Web.Client.Factories
{
    public class ApplicationAccountFactory
        : AccountClaimsPrincipalFactory<ApplicationUserAccount>
    {
        public ApplicationAccountFactory(NavigationManager navigationManager,
            IAccessTokenProviderAccessor accessor) : base(accessor)
        {

        }

        public override async ValueTask<ClaimsPrincipal> CreateUserAsync(
            ApplicationUserAccount account, RemoteAuthenticationUserOptions options)
        {
            var initialUser = await base.CreateUserAsync(account, options);

            if (initialUser.Identity.IsAuthenticated)
            {
                ((ClaimsIdentity)initialUser.Identity)
                    .AddClaim(new Claim("prueba", "prueba"));

                foreach (var value in account.Modules)
                {
                    ((ClaimsIdentity)initialUser.Identity)
                        .AddClaim(new Claim("amr", value));
                }
            }

            return initialUser;
        }
    }
}
