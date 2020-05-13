using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using GodAndItemManager;

namespace DankSmite.Pages.Shared
{
    public class MyIndexModel : PageModel
    {
        public static List<God> AllGods { get; private set; } = SmiteGamepediaApi.GetAllGods();
        public Models.CurrentGodModel CurrentGodModel { get; set; } = new Models.CurrentGodModel();
        public MyIndexModel()
        {
            God god = GetGod();
            CurrentGodModel.GodName = god.Name;
            CurrentGodModel.BootsItem = DateTime.Now.ToString("HH:mm:ss");
            CurrentGodModel.StarterItem = DateTime.Now.AddHours(4).ToString("HH:mm:ss");
        }

        private God GetGod()
        {
            return AllGods[new Random().Next(0, AllGods.Count)];
        }



        public void OnGet()
        {
        }
    }
}
