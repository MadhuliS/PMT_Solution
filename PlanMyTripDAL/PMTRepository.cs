using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using PlanMyTripDAL;

namespace PlanMyTripDAL
{
    public class PMTRepository
    {
        PlanMyTripDBEntities planMyTripDBContext = null;

        //View List of all flights
        public List<Flight> ViewFlightsMethod()
        {
            return (new PlanMyTripDBEntities().Flights.ToList());
        }

        //Add new flight details
        public bool AddFlightMethod(Flight f)
        {
            planMyTripDBContext = new PlanMyTripDBEntities();
            planMyTripDBContext.Flights.Add(f);
            planMyTripDBContext.SaveChanges();
            return true;
        }

        //To update the existing flight details
        public Flight GetFlightById(string fID)
        {
            planMyTripDBContext = new PlanMyTripDBEntities();
            Flight fAvailable = planMyTripDBContext.Flights.Find(fID);
            return fAvailable;
        }

        public bool UpdateFlightMethod(Flight fNew)
        {
            planMyTripDBContext = new PlanMyTripDBEntities();
            Flight f = planMyTripDBContext.Flights.Find(fNew.FlightNumber);
            f.FlightName = fNew.FlightName;
            f.FlightName = fNew.FlightName;
            f.NoOfSeatsAvailable = fNew.NoOfSeatsAvailable;
            f.SeatsCapacity = fNew.SeatsCapacity;
            planMyTripDBContext.SaveChanges();
            return true;
        }
        //public bool DeleteCategoryByID(string cID)
        //{
        //    es = new EShoppyDBEntities();
        //    Catogory cat = es.Catogories.Find(cID);
        //    es.Catogories.Remove(cat);
        //    es.SaveChanges();
        //    return true;
        //}

        //To delete the flight details
        public bool DeleteFlightMethod(string fID)
        {
            planMyTripDBContext = new PlanMyTripDBEntities();
            Flight f = planMyTripDBContext.Flights.Find(fID);
            planMyTripDBContext.Flights.Remove(f);
            planMyTripDBContext.SaveChanges();
            return true;
        }

        //search flight by usp API
        public List<PlanMyTripDAL.usp_SearchFlights_Result> GetFlightDetailsByUPI(string origin, string dept, DateTime depTime)
        {
            return new PlanMyTripDBEntities().usp_SearchFlights(origin, dept, depTime).ToList();
        }

        public List<FlightSchedule> GetFlightSchedules()
        {
            return new PlanMyTripDBEntities().FlightSchedules.ToList();
        }
        
    }
}
