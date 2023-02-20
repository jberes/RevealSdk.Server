using Reveal.Sdk;

namespace RevealSdk.Server
{
    internal class UserContextProvider : IRVUserContextProvider
    {
        public IRVUserContext GetUserContext(HttpContext aspnetContext)
        {
            //when using standard auth mechanisms, the userId can be obtained using aspnetContext.User.Identity.Name.
            var userIdentityName = aspnetContext.User.Identity.Name;
            var userId = (userIdentityName != null) ? userIdentityName : "ALFKI";

            //var props = new Dictionary<string, object>() { { "some-property", 
            //        aspnetContext.Request.Cookies["some-cookie-name"]. } };

            var props = new Dictionary<string, object>() { { "company-id", 
                    6 } };

            return new RVUserContext(userId, props);
        }
    }
}
