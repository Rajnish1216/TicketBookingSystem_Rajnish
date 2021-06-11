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
    public class DetailsModel : PageModel
    {
        private readonly TicketBookingSystem_Rajnish.Data.ApplicationDbContext _context;

        public DetailsModel(TicketBookingSystem_Rajnish.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public BussLayer.Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Customer = await _context.Customers
                .Include(c => c.Seat)
                .Include(c => c.Ticket).FirstOrDefaultAsync(m => m.ID == id);

            if (Customer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
