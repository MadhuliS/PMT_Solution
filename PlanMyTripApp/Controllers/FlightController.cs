using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PlanMyTripDAL;
using PlanMyTripApp;
using System.Net.Http;

namespace PlanMyTripApp.Controllers
{
    public class FlightController : Controller
    {

        PMTRepository pmtRepo = new PMTRepository();
        


        //View All List Controller
        public ActionResult ShowAllFlights()
        {
            var flightList = pmtRepo.ViewFlightsMethod();
            List<Models.Flight> FlighModel = new List<Models.Flight>();
            foreach (var FlightDal in flightList)
            {
                Models.Flight temp = new Models.Flight();
                temp.FlightName = FlightDal.FlightName;
                temp.FlightNumber = FlightDal.FlightNumber;
                temp.SeatsCapacity = FlightDal.SeatsCapacity;
                temp.NoOfSeatsAvailable = FlightDal.NoOfSeatsAvailable;
                FlighModel.Add(temp);
            }
            return View(FlighModel);
        }

        //Insering new flight details
        [HttpGet]
        public ActionResult InsertNewFlight()
        {
            return View();
        }
        [HttpPost]
        public ActionResult InsertNewFlight(Models.Flight ModelFlight) 
        {
            PlanMyTripDAL.Flight DalFlight = new PlanMyTripDAL.Flight();
            DalFlight.NoOfSeatsAvailable = ModelFlight.NoOfSeatsAvailable;
            DalFlight.SeatsCapacity = ModelFlight.SeatsCapacity;
            DalFlight.FlightName = ModelFlight.FlightName;
            DalFlight.FlightNumber = ModelFlight.FlightNumber;

            if (pmtRepo.AddFlightMethod(DalFlight))
            {
                ViewBag.Message = "Flight Details Added Successfully";
            }
            else
            {
                ViewBag.Message = "Failed";

            }
            
            return View();
        }

        //update flight details
        [HttpGet]
        public ActionResult UpdateFlightDetails()
        {
            var oldFlight = pmtRepo.GetFlightById(Request.QueryString["fID"]);
            Models.Flight modelF = new Models.Flight();
            modelF.FlightName = oldFlight.FlightName;
            modelF.FlightNumber = oldFlight.FlightNumber;
            modelF.NoOfSeatsAvailable = oldFlight.NoOfSeatsAvailable;
            modelF.SeatsCapacity = oldFlight.SeatsCapacity;
            return View(modelF);
        }
        [HttpPost]
        public ActionResult UpdateFlightDetails(Models.Flight fnew)
        {
            var oldF = pmtRepo.GetFlightById(Request.QueryString["fID"]);
            oldF.FlightName = fnew.FlightName;
            oldF.FlightNumber = fnew.FlightNumber;
            oldF.NoOfSeatsAvailable = fnew.NoOfSeatsAvailable;
            oldF.SeatsCapacity = fnew.SeatsCapacity;
            pmtRepo.UpdateFlightMethod(oldF);
            return RedirectToAction("ShowAllFlights");
        }
        
        //Delete Flight Details
        [HttpGet]
        public ActionResult DeleteFlightDetails()
        {
            var oldFlight = pmtRepo.GetFlightById(Request.QueryString["fID"]);
            Models.Flight modelF = new Models.Flight();
            modelF.FlightName = oldFlight.FlightName;
            modelF.FlightNumber = oldFlight.FlightNumber;
            modelF.NoOfSeatsAvailable = oldFlight.NoOfSeatsAvailable;
            modelF.SeatsCapacity = oldFlight.SeatsCapacity;
            return View(modelF);
        }
        [HttpPost]
        [ActionName("DeleteFlightDetails")]
        public ActionResult DeleteCategoryConfirm()
        {
            pmtRepo.DeleteFlightMethod(Request.QueryString["fID"]);
            return Redirect("ShowAllFlights");
        }

        [HttpGet]
        public ActionResult ShowFlightDetails()
        {
            var flightDetails = pmtRepo.GetFlightById(Request.QueryString["fID"]);
            Models.Flight f = new Models.Flight();
            f.FlightName = flightDetails.FlightName;
            f.FlightNumber = flightDetails.FlightNumber;
            f.NoOfSeatsAvailable = flightDetails.NoOfSeatsAvailable;
            f.SeatsCapacity = flightDetails.SeatsCapacity;

            return View(f);
        }
        
        //Search Op
        [HttpGet]
        public ActionResult SearchFlightsUsingAPI()  //empty with model
        {
            var flightSList = pmtRepo.GetFlightSchedules();
            Models.FlightSchedule FlightSModel = new Models.FlightSchedule();
            FlightSModel.fList = new List<Models.FlightSchedule>();
            foreach (var f in flightSList)
            {
                Models.FlightSchedule temp = new Models.FlightSchedule();
                temp.DepartureTime = f.DepartureTime;
                temp.Destination = f.Destination;
                temp.FlightNumber = f.FlightNumber;
                temp.Origin = f.Origin;
                temp.Id = f.Id;
                FlightSModel.fList.Add(temp);
            }
            return View(FlightSModel);
        }
        
        [HttpPost]
        public ActionResult SearchFlightsUsingAPI(FormCollection fc) //usp  list
        {
            List<PlanMyTripDAL.usp_SearchFlights_Result> fList = new List<usp_SearchFlights_Result>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62921/");
                string [] allData = fc[0].Split(',');
                var responseForm = client.GetAsync("SearchFlight/" + allData[0].ToString() +"/"+allData[1].ToString() +"/"+fc[1].ToString());
                //string urlData = "http://localhost:62921/" + "SearchFlight/" + allData[0].ToString() + "/" + allData[1].ToString() + "/" + fc[1].ToString();
                var responseCode = responseForm.Result;
                if (responseCode.IsSuccessStatusCode)
                {
                    var getJsonList = responseCode.Content.ReadAsAsync<List<PlanMyTripDAL.usp_SearchFlights_Result>>();
                    fList = getJsonList.Result;
                }
            }
            return View("SearchFlightsUsingUSP", fList);
        }

        public ActionResult ShowAllFlightsScheduleFromAPI() //dal list
        {

            List<PlanMyTripWebAPI.Models.FlightSchedule> flightAPI = new List<PlanMyTripWebAPI.Models.FlightSchedule>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62921/");
                var responseFrom = client.GetAsync("SearchFlight/");
                var responseCode = responseFrom.Result;
                if (responseCode.IsSuccessStatusCode)
                {
                    var getJsonList = responseCode.Content.ReadAsAsync<List<PlanMyTripWebAPI.Models.FlightSchedule>>();
                    flightAPI = getJsonList.Result;
                }
            }
            return View(flightAPI);
        }
     }

        
        
    
}