using Kristel_C2.Models;

using Microsoft.AspNetCore.Mvc;

namespace Kristel_C2.Controllers
{
    public class HomeController : Controller
    {
        private static List<SupportTicket> TicketList = new List<SupportTicket>()
        {
            new SupportTicket(002, "Aforo", "Importación con requerimiento de revision"),
            new SupportTicket(003, "Retiro", "Importación lista para retirar")
        };

        public IActionResult Index()
        {
            List<SupportTicket> ticketOpen = new List<SupportTicket>();
            foreach (SupportTicket tickets in TicketList)
            {
                if (tickets.IsOpen)
                {
                    ticketOpen.Add(tickets);
                }
            }
            return View(ticketOpen);
        }
        public IActionResult GenerarTicket()
        {
            return View();
        }

        public IActionResult TicketGuardado(SupportTicket tickets)
        {
        if (!ModelState.IsValid)
        {
             return View("GenerarTicket", tickets);
        }
             TicketList.Add(tickets);
             return RedirectToAction("Index");
        }


        public IActionResult Resuelto()
        {
            List<SupportTicket> Resuelto = new List<SupportTicket>();
            foreach (SupportTicket tickets in TicketList)
            {
                if (!tickets.IsOpen)
                {
                    Resuelto.Add(tickets);
                    
                }
            }
            return View(Resuelto);
        }
        public IActionResult Cierre(int ticketNum)
        {
            SupportTicket tickets = TicketList.Find(e => e.TicketNumber == ticketNum);

            tickets.MarkAsResolved();
            return RedirectToAction("Index");
        }
    }
}
