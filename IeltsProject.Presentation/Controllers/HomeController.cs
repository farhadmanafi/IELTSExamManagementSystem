using ExamContext.Ielts.Aplication.Contracts.IeltsAggregarte;
using ExamContext.Ielts.Facade.Contracts.IeltsAggregarte;
using ExamContext.ReadModel.Queries.Contracts.IeltsExamContext.IeltsAggregarte.IeltsAggregarte;
using IeltsProject.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace IeltsProject.Presentation.Controllers
{
    //[Authorize(Roles = "Admin")]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //chekin2
        /// <summary>
        /// /check in 2: Gholami
        /// </summary>
        private readonly IIeltsExamCommandFacade _iIeltsExamCommandFacade;
        private readonly IIeltsExamQueryFacade _iIeltsExamQueryFacade;
        public HomeController(ILogger<HomeController> logger,
            IIeltsExamCommandFacade iIeltsExamCommandFacade,
            IIeltsExamQueryFacade iIeltsExamQueryFacade)
        {
            _logger = logger;
            _iIeltsExamCommandFacade = iIeltsExamCommandFacade;
            _iIeltsExamQueryFacade = iIeltsExamQueryFacade;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            //AddIeltsExamCommand command = new AddIeltsExamCommand();
            //command.Title = "new";
            //command.Description = "Desvriptionnnn";

            //_iIeltsExamCommandFacade.AddIeltsExam(command);

            //var data = _iIeltsExamQueryFacade.GetIeltsExamList();
 
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
