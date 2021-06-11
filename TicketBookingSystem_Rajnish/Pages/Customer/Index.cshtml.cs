using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TicketBookingSystem_Rajnish.BussLayer;
using TicketBookingSystem_Rajnish.Data;

namespace TicketBookingSystem_Rajnish.Pages.Customer
{
    public class IndexModel : PageModel
    {
        private readonly TicketBookingSystem_Rajnish.Data.ApplicationDbContext _context;

        public IndexModel(TicketBookingSystem_Rajnish.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BussLayer.Customer> Customer { get;set; }

        public async Task OnGetAsync()
        {
            Customer = await _context.Customers
                .Include(c => c.Seat)
                .Include(c => c.Ticket).ToListAsync();
        }
    }
}
