using Application.Common.Interfaces;
using System.Security.Claims;

namespace QualityManager.Services
{
    public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
    {
        public string UserId
        {
            get
            {
                ClaimsIdentity? clams = httpContextAccessor.HttpContext?.User.Identity as ClaimsIdentity;

                string userId = clams?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;

                return userId;
            }
        }
    }
}