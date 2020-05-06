using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using GodAndItemManager;
using System.Text;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DankSmite
{
    [Route("ds/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private ConfigurationManager.ConfigurationHandler _configuration;
        public TestController(IConfiguration config)
        {
            _configuration = new ConfigurationManager.ConfigurationHandler(config);
            
        }

        [HttpGet("{SettingName}")]
        public void GetMyThingy(string settingName)
        {


            string s = _configuration.GetGeneralSettings<string>(settingName);
            StreamWriter writer = new StreamWriter(HttpContext.Response.Body);
            writer.WriteLine(s);
            writer.Flush();

        }

        [HttpGet]
        public void GetGodNamesAsString()
        {
            StringBuilder builder = new StringBuilder("<!DOCTYPE html>" +
                "<html lang=\"en\">" +
                "<head></head>" +
                "<body>");

            List<God> gods = SmiteGamepediaApi.GetAllGods();

            foreach (var god in gods)
            {
                builder.Append($"{god.Name} <img src=\"{god.Picture}\" style=\"width: auto; \"/> <br />");
            }
            builder.Append("</body></html>");

            string fullHtml = builder.ToString();

            using (StreamWriter writer = new StreamWriter(HttpContext.Response.Body))
            {
                writer.WriteLine(fullHtml);
            }
        }

    }
}
