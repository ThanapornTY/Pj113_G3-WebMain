using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project113_G3.Models
{
    public class datagameviewmodel
    {
        public string Model { get; set; }
        public int Amount { get; set; }
    }

    public class UserDataModel
    {
        public string Model { get; set; }
        public int Amount { get; set; }
    }


    public class RequestGameData1
    {
        public string Model1 { get; set; }
        public int Amount1 { get; set; }
    }
    public class ReportUser
    {
        public string Model { get; set; }
        public int Amount { get; set; }
    }

    public class UserDataAPI
    {
        public string Model { get; set; }
        public int Amount { get; set; }
    }

    public class OrderDetailsDataModel
    {

        private DashboardEntities db = new DashboardEntities();

        public List<datagameviewmodel> GetOrderbyModel()
        {
            var chartDataList = new List<datagameviewmodel>();
            

            var prod = db.Datagames.OrderBy(i => i.Id).ToList();
            foreach (var item in prod.GroupBy(i => i.TypeGame))
            {
                var chartData = new datagameviewmodel();
                chartData.Model = item.FirstOrDefault().TypeGame;
                chartData.Amount = item.Count();
                chartDataList.Add(chartData);
            }
            return chartDataList;
        }

        public List<RequestGameData1> GetRequestgameModel()
        {
            var chartDataList = new List<RequestGameData1>();


            var prod = db.RequestGameDatas.OrderBy(i => i.Id).ToList();
            foreach (var item in prod.GroupBy(i => i.RQGGame))
            {
                var chartData = new RequestGameData1();
                chartData.Model1 = item.FirstOrDefault().RQGGame;
                chartData.Amount1 = item.Count();
                chartDataList.Add(chartData);
            }
            return chartDataList;
        }


        public List<ReportUser> GetReportUser()
        {
            var chartDataList = new List<ReportUser>();


            var prod = db.RQ_Reported.OrderBy(i => i.RQrp_Id).ToList();
            foreach (var item in prod.GroupBy(i => i.RQrp_ByUsername))
            {
                var chartData = new ReportUser();
                chartData.Model = item.FirstOrDefault().RQrp_ByUsername;
                chartData.Amount = item.Count();
                chartDataList.Add(chartData);
            }
            return chartDataList;
        }



    }

  





}