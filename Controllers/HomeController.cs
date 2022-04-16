using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using IsdPanel.Steps;
using IsdPipeline;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace IsdPanel.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            new FlowBasePipeline<Steps.MyObj>(new BusinessMgr()).
            //دریافت کاربران از Active Directory
            Push(new TestStep()).
           Initiate();
            return View();
        }

    }
}
