using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SignalRExample.Models;

namespace SignalRExample.Pages
{
    public class IndexModel : PageModel
    {
        readonly ApplicationDbContext _dbContext;
        public IndexModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Message> Messages { get; set; }

        public void OnGet()
        {
            Messages = _dbContext.Messages.ToList();
        }
    }
}
