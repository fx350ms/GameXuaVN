using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using GameXuaVN.Controllers;

namespace GameXuaVN.Web.Controllers
{
   
    public class HomeController : GameXuaVNControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
