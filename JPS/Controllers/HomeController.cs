using JPS.Data;
using JPS.Models;
using JPS.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace JPS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly JPSContext _context;

     

        public HomeController(ILogger<HomeController> logger, JPSContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [HttpGet]
        public async Task <IActionResult> ShowBill()
        {
            return View(await _context.Bill.ToListAsync());
        }



        [HttpGet]
        public async Task <IActionResult> PayBill(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill.FindAsync(id);
            if (bill == null)
            {
                return NotFound();
            }

            DeductBnsViewModel deductBnsView = new DeductBnsViewModel();
            deductBnsView.bills = bill;

            return View(deductBnsView);

        }


        [HttpPost]

        public async Task<IActionResult> PayBill(DeductBnsViewModel deductViewModel)

        {
            var Bill = await _context.Bill.FindAsync(deductViewModel.ID);


            if (Bill!=null)

            {

                if (deductViewModel.CardNum.StartsWith("4001"))
                {
                    BnsService.BNSClient client = new BnsService.BNSClient();


                    var print = await client.DeductBNSAsync(deductViewModel.CardNum, deductViewModel.Amt);

                    if (print == 0)

                    {

                        TempData["Print"] = "This account is wrong";
                    }


                    else if (print == 2)
                    {

                        TempData["Print"] = "Not Enough Funds";

                    }


                    else if (print == 1)
                    {


                        TempData["Print"] = "Transaction Succesful";

                        deductViewModel.bills = Bill;

                       

                        //newOrder.BillId = Bill.BillId;
                        Bill.Address =  deductViewModel.bills.Address;
                        Bill.CustomerId = deductViewModel.bills.CustomerId;
                        Bill.DueDate = deductViewModel.bills.DueDate;
                        Bill.GenerationDate = deductViewModel.bills.GenerationDate;
                        Bill.PremisesNumber = deductViewModel.bills.PremisesNumber;

                        Bill.AmountDue = deductViewModel.bills.AmountDue - (int) deductViewModel.Amt;

                        _context.Update(Bill);
                        await _context.SaveChangesAsync();

                    }

                }

                // AN ELSE IF STATEMET WITH STARTS WITH HEREEE

                else
                {

                    TempData["Print"] = "Invalid Bank Details, Please ensure your bank is BNS or NCB";

                }



            }

            return RedirectToAction(nameof(Display));
        }


        [HttpGet]
        public IActionResult Display ()

        {
            return View(TempData["Print"]);

        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
