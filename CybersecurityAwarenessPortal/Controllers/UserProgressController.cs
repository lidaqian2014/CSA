﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CybersecurityAwarenessPortal.Models;
using Newtonsoft.Json;

namespace CybersecurityAwarenessPortal.Controllers
{
    public class UserProgressController : Controller
    {
        // GET: UserProgress
        public ActionResult UserProgressView()
        {
            Models.UserProgressModel upm = new Models.UserProgressModel();
            upm.EmployeeEmail = Session["username"].ToString();
            upm.EmployeeID = upm.GetEmployeeID();
            upm.numOfCompletedModules = upm.GetNumOfModulesCompleted();
            upm.percentage = ((double)upm.numOfCompletedModules / 5 )* 100;
            Session["perc"] = upm.percentage;

            List<DataPoint> dataPoints = new List<DataPoint>();
            dataPoints.Add(new DataPoint("Threats OverView", upm.GetMaxAttemptsM1()));
            dataPoints.Add(new DataPoint("Password Safety", upm.GetMaxAttemptsM2()));
            dataPoints.Add(new DataPoint("Internet Protection", 0));
            dataPoints.Add(new DataPoint("Email Protection", 0));
            dataPoints.Add(new DataPoint("Preventive Measure", 0));
            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);
            return View();
        }
    }
}