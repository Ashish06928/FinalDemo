using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoApp.Pages
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public DemoApp.Models.Task Task { get; set; }
        public ActionResult OnGet(int? Id)
        {
            if (Id != null)
            {
                var client = new HttpClient();
                string path = "http://localhost:7071/api/task/" + Convert.ToString(Id);
                var response = client.DeleteAsync(path).GetAwaiter().GetResult();
               
            }
            return RedirectToPage("Index");
        }
    }
}
