using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreApp.Models
{
    public class SocialIcon
    {
        public int Id { get; set; }
        public string IconName { get; set; }
        public string IconBgColor { get; set; }
        public string IconClass { get; set; }
        public string IconTargetUrl { get; set; }

        public static List<SocialIcon> GetAppSocialIcons()
        {
            return new List<SocialIcon>
            {
                new SocialIcon
                {
                    Id = 1,
                    IconName = "Facebook",
                    IconClass = "fab fa-facebook-f",
                    IconBgColor = "#3b5998",
                    IconTargetUrl = "https://facebook.com/"
                },
                new SocialIcon
                {
                    Id = 2,
                    IconName = "Twitter",
                    IconClass = "fab fa-twitter",
                    IconBgColor = "#1da1f2",
                    IconTargetUrl = "https://twitter.com/"
                },
                new SocialIcon
                {
                    Id = 3,
                    IconName = "Pinterest",
                    IconClass = "fab fa-pinterest",
                    IconBgColor = "#bd081c",
                    IconTargetUrl = "https://in.pinterest.com/"
                },
            };
        }
    }
}
