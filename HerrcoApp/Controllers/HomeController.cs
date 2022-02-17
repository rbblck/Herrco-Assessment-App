using System.Collections.Generic;
using System.Diagnostics;
using HerrcoApp.Classes;
using HerrcoApp.Classes.BusinessLogic;
using HerrcoApp.Classes.Entities;
using HerrcoApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace HerrcoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public static bool firstViewed = true;  // UI Control boolean.

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Home and app view.
        public IActionResult Index()
        {
            LoggerClass.ClearLogFile();

            // If first viewd, the view will only have init info to prepare the
            // UI for the first ping button press.
            if (firstViewed)
            {
                firstViewed = false;

                // Get the latest spread sheet and up date the stored spread
                // sheet to prepare a comparison spread sheet for the first
                // ping action.
                SpreadSheetModel ssModel = new SpreadSheetModel();
                ssModel.InitialiseStoredSpreadSheet();

                // Init Messages.
                List<string> updateMsgs = new List<string>();
                updateMsgs.Add("No Updates");
                ViewBag.chgMsgArr = JsonConvert.SerializeObject(updateMsgs);

                // Init chart key titles.
                List<string> titles = new List<string>();
                titles.Add($"Created ({0})");
                titles.Add($"Updated ({0})");
                titles.Add($"Deleted ({0})");
                titles.Add($"Error ({0})");

                ViewBag.titleArr = JsonConvert.SerializeObject(titles);

                // Init chart data display.
                List<int> chartData = new List<int>();
                chartData.Add(0);
                chartData.Add(0);
                chartData.Add(0);
                chartData.Add(0);
                chartData.Add(1);

                ViewBag.chartDataArr = JsonConvert.SerializeObject(chartData);
            }
            else
            {
                // Get the spread sheet changes since the app init, refreash or
                // last click of the ping button in the UI
                SpreadSheetModel ssModel = new SpreadSheetModel();
                SpreadSheetTrackingClass stc = ssModel.GetTrackingInformation();
                ChangeDiscoveryClass cdc = new ChangeDiscoveryClass();

                // Variable to hold errors
                int errors = stc.NumberOfErrors;

                // Get the list of update messages and convert to a serializable
                // string for ViewBag for later display for the ticker tape on
                // the UI.
                ViewBag.chgMsgArr = JsonConvert.SerializeObject(
                    cdc.GetUpdateMessages(stc));

                // Control variable, if it ends up to be 1 then the UI will
                // respond and just show a grey donut chart.
                int blank = 0;

                // check the above.
                if (stc.NumberOfAdditions == 0
                    && stc.UpdateDetails.Count == 0
                    && stc.NumerOfDeletes == 0
                    && errors == 0)
                {
                    blank = 1;
                }

                // List of titles for the chart key in the UI.
                List<string> titles = new List<string>();
                titles.Add($"Created ({stc.NumberOfAdditions})");
                titles.Add($"Updated ({stc.UpdateDetails.Count})");
                titles.Add($"Deleted ({stc.NumerOfDeletes})");
                titles.Add($"Error ({errors})");

                // Serialize the list to preare a string for the UI.
                ViewBag.titleArr = JsonConvert.SerializeObject(titles);

                // List of data for the chart Display in the UI.
                List<int> chartData = new List<int>();
                chartData.Add(stc.NumberOfAdditions);
                chartData.Add(stc.UpdateDetails.Count);
                chartData.Add(stc.NumerOfDeletes);
                chartData.Add(errors);
                chartData.Add(blank);

                // Serialize the list to preare a string for the UI.
                ViewBag.chartDataArr = JsonConvert.SerializeObject(chartData);
            }

            return View();
        }

        // Home Static Instructions view.
        public IActionResult Instructions()
        {
            firstViewed = true;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
