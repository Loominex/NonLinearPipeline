using Microsoft.AspNetCore.Http;
using Sso.UMProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace IsdPanel.Common
{
    public  class CurrentUser
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IPrincipal PrincipalUser;

        public CurrentUser(IHttpContextAccessor httpContext)
        {
            this.httpContextAccessor = httpContext;
            var PrincipalUser = httpContextAccessor.HttpContext.User as IPrincipal;
        }

        public  SsoUser User
        {
            get
            {
                return PrincipalUser as SsoUser;
            }
        }

        public  int UserId
        {
            get
            {
                return (PrincipalUser as SsoUser).Id;
            }
        }


        public  string UserShowName
        {
            get
            {
                if (this.User != null)
                    return string.Format("{0} ({1})", (object)this.User.Id, (object)this.User.ShowName);
                return "";
            }
        }

        public bool IsAdmin
        {
            get
            {
                return this.CurrentUserHasPermission("FullAccess");
            }
        }


        public  bool CurrentUserHasPermission(string permission)
        {
            SsoUser user = this.User;
            if (user == null)
                return false;
            return user.HasPermission(permission);
        }

        public  bool CurrentUserHasPermission(Permission permission)
        {
            return this.CurrentUserHasPermission(permission.ToString());
        }

        public  bool HasBranchAccess
        {
            get
            {
                return this.CurrentUserHasPermission("BranchAccess");
            }
        }
    }
}
