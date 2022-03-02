using Project113_G3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using System.Configuration;

namespace Project113_G3.Controllers
{
    public class DashboardController : Controller
    {
        
        private DashboardEntities game = new DashboardEntities();
        // GET: Dashboard
        
        public ActionResult Index()
        {
            /*ตัวเรียกใช้การนับตาราง*/
            ViewBag.CountUser = game.UserDatas.Count();
            ViewBag.CountGame = game.Datagames.Count();
            ViewBag.CountRqGame = game.RequestGameDatas.Count();

            return View();
        }

        public ActionResult VisualizeDB()
        {
            return Json(Result(), JsonRequestBehavior.AllowGet);
        }
        public List<Datagame> Result()
        {
            List<Datagame> datagames = new List<Datagame>();
            return datagames;
        }

        public List<RequestGameData> Result1()
        {
            List<RequestGameData> requestGameDatas = new List<RequestGameData>();
            return requestGameDatas;
        }
        //
        public List<UserData> ResultUser()
        {
            List<UserData> requestUserData = new List<UserData>();
            return requestUserData;
        }

        public JsonResult GetData()
        {
            using (DashboardEntities dc = new DashboardEntities())
            {
                //var v = dc.Datagames;
                var v = (from a in dc.Datagames
                         group a by a.TypeGame into g
                         select new
                         {
                             TypeGame = g.Key,
                             CountType = g.Count(),
                         });
                if (v != null)
                {
                    var chartData = new object[v.Count() + 1];
                    chartData[0] = new object[]
                    {
                 "Type",
                 "Des",
                    };
                    int j = 0;

                    foreach (var i in v)
                    {
                        j++;
                        //chartData[j] = new object[] { i.NameGame.ToString(), i.TypeGame, i.Description_Game, i.url };
                        chartData[j] = new object[] { i.TypeGame.ToString(), i.CountType.ToString() };
                    }
                    return new JsonResult { Data = chartData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public JsonResult GetData1()
        {
            using (DashboardEntities dc = new DashboardEntities())
            {
                //var v = dc.Datagames;
                var v = (from a in dc.RequestGameDatas
                         group a by a.RQGGame into g
                         select new
                         {
                             RQGGame = g.Key,
                             CountType = g.Count(),
                         });
                if (v != null)
                {
                    var chartData = new object[v.Count() + 1];
                    chartData[0] = new object[]
                    {
                 "RQGUsername",
                 "RQGGame",
                    };
                    int j = 0;

                    foreach (var i in v)
                    {
                        j++;
                        //chartData[j] = new object[] { i.NameGame.ToString(), i.TypeGame, i.Description_Game, i.url };
                        chartData[j] = new object[] { i.RQGGame.ToString(), i.CountType.ToString() };
                    }
                    return new JsonResult { Data = chartData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
                }
            }
            return new JsonResult { Data = null, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        
    }
}