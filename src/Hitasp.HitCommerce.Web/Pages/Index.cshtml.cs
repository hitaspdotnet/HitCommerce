using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Hitasp.HitCommerce.Web.Pages
{
    public class IndexModel : HitCommercePageModel
    {
        public void OnGet()
        {
        }

        public async Task OnPostLoginAsync()
        {
            await HttpContext.ChallengeAsync("oidc");
        }
    }
}