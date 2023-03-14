using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlanMyTripWebAPI.Models
{
    public class FlightSchedule
    {

        [Key]
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public System.DateTime DepartureTime { get; set; }
    }
}