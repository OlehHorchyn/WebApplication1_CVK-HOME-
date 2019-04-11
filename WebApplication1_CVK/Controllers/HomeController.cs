using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Newtonsoft.Json;
using WebApplication1_CVK.Model;

namespace WebApplication1_CVK.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public ActionResult Index()
        {
            return View(getRegionsFromFile());
        }


        public ActionResult OkrugPage(String id)
        {
            ResToChild res = new ResToChild();
            foreach (Region region in getRegionsFromFile())
            {
                foreach(TerretoryOkrug okrug in region.okrugs)
                {
                    if (okrug.Id.Equals(id))
                    {
                        res.NumOkrug = id;
                        res.departments = okrug.departments;
                        break;
                    }
                }
            }
            return View(res);
        }

        public List<Region> getRegionsFromFile()
        {
            string fileText = Server.MapPath("~/App_Data/cvk.json");
            string Json = System.IO.File.ReadAllText(fileText);

            CVK cvk = JsonConvert.DeserializeObject<CVK>(Json);

            return cvk.Regions;
        }
    }
}