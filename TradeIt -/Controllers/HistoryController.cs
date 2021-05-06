using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TradeIt__.Services;
using TradeIt__.ViewModels;

namespace TradeIt__.Controllers
{
    [Authorize]
    public class HistoryController : Controller
    {

        private readonly IAccountService accountService;
        private readonly IHistoryService historyService;

        public HistoryController(IAccountService accountService,
            IHistoryService historyService)
        {
            this.accountService = accountService;
            this.historyService = historyService;
        }

        public IActionResult Index()
        {
            var historyModel = new HistoryModel(historyService.GetHistories(this.User.FindFirstValue(ClaimTypes.NameIdentifier)));
            return View(historyModel);
        }
    }
}
