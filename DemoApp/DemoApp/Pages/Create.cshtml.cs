using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace DemoApp.Pages
{
    public class CreateModel : PageModel
    {

        [BindProperty]
        public DemoApp.Models.Task Task { get; set; }
        public void OnGet()
        {
        }
        public ActionResult OnPost()
        {
            var json = JsonConvert.SerializeObject(Task);
            var client = new HttpClient();
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            string path = "http://localhost:7071/api/task";
            var res = client.PostAsync(path, content).GetAwaiter().GetResult();
            return RedirectToPage("Index");
        }
    }
}
