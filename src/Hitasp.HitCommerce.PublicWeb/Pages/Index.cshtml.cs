using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;

namespace Hitasp.HitCommerce.PublicWeb.Pages
{
    public class IndexModel : HitCommercePublicPageModel
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