using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GodAndItemManager;

namespace DankSmite
{
    public class MyIndexModel : PageModel
    {
        public List<God> Gods { get; private set; }

        public MyIndexModel()
        {
            Gods = SmiteGamepediaApi.GetAllGods();

        }

        public void OnGet()
        {
        }
    }
}
