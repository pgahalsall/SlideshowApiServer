using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading;

namespace SlideshowApi.Services
{
    public class IdentityService : IIdentityService
    {
        public IdentityService()
        {
        }

        public string CurrentUser
        {
            get
            {
#if DEBUG
                return "PeterHalsall";
#else
        return Thread.CurrentPrincipal.Identity.Name;
#endif
            }
        }
    }
}