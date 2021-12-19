﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;

        [BindProperty]
        public DemoApp.Models.User UserLogin {get; set;}
        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void OnGet()
        {

        }

        public ActionResult OnPost()
        {
            var json = JsonConvert.SerializeObject(UserLogin);
            var client = new HttpClient();
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");
            string path = $"{_configuration["AppSettings:BaseAPI"]}api/Login";
            var res = client.PostAsync(path, content).GetAwaiter().GetResult();
            if(res.IsSuccessStatusCode)
            {
                return RedirectToPage("Dashboard");
            }
            else
            {
                return RedirectToPage("Index");
            }
        }
    }
}
