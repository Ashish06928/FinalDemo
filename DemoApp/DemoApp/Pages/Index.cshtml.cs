using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DemoApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<DemoApp.Models.Task> TaskList { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var client = new HttpClient();
            string path = "http://localhost:7071/api/task";
            var response = client.GetAsync(path).GetAwaiter().GetResult();
            if (response.IsSuccessStatusCode)
            {
                TaskList = JsonConvert.DeserializeObject<List<DemoApp.Models.Task>>(response.Content.ReadAsStringAsync().GetAwaiter().GetResult().ToString());

            }
        }
    }
}
