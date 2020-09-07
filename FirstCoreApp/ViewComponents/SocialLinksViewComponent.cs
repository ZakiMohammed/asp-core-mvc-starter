using FirstCoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApp.ViewComponents
{
    public class SocialLinksViewComponent : ViewComponent
    {
        readonly List<SocialIcon> socialIcons;

        public SocialLinksViewComponent()
        {
            this.socialIcons = SocialIcon.GetAppSocialIcons();
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult(View("SocialLinks", socialIcons));
        }
    }
}
