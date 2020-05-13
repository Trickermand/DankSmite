using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GodAndItemManager;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DankSmite.Pages.Shared
{
    public class DSRemakeModel : PageModel
    {
        public List<God> Gods { get; private set; }

        public DSRemakeModel()
        {
            Gods = SmiteGamepediaApi.GetAllGods();

        }


        public void OnGet()
        {
        }
    }
}
