using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Security.Claims;
using MadBug.WebAPI;
using MadBug.WebAPI.Models;

namespace MadBug.API.Controllers
{
    /// <summary>
    /// Controlador base para API REST
    /// </summary>
    public class BaseApiController : ApiController
    {
        private ApplicationUserManager _userManager;
    
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        /// <summary>
        /// Obtiene el usuario en sesión
        /// </summary>
        protected ApplicationUser CurrentUser
        {
            get
            {
                var claimsPrincipal = User as ClaimsPrincipal;
                var userIdClaim = claimsPrincipal.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier);
                if (userIdClaim.Count() > 0)
                {
                    var userId = userIdClaim.SingleOrDefault().Value;
                    var user = ApplicationDbContext.Create().Users.Where(x => x.Id == userId).SingleOrDefault();
                    return user;
                }
                return null;
            }
        }
        /// <summary>
        /// Obtiene el identificador del usuario que está en sesión
        /// </summary>
        protected string CurrentUserId
        {
            get
            {
                return CurrentUser != null ? CurrentUser.Id : null;
            }
        }


    }
}