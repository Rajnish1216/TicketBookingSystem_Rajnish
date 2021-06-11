using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TicketBookingSystem_Rajnish.BussLayer;
using TicketBookingSystem_Rajnish.Data;

namespace TicketBookingSystem_Rajnish.Pages.Seat
{
    public class CreateModel : PageModel
    {
        private readonly TicketBookingSystem_Rajnish.Data.ApplicationDbContext _context;

        public CreateModel(TicketBookingSystem_Rajnish.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BussLayer.Seat Seat { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Seats.Add(Seat);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
