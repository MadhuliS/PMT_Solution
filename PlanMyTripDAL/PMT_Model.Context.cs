﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlanMyTripDAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class PlanMyTripDBEntities : DbContext
    {
        public PlanMyTripDBEntities()
            : base("name=PlanMyTripDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Airport> Airports { get; set; }
        public virtual DbSet<BookingDetail> BookingDetails { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<FlightSchedule> FlightSchedules { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Itenary> Itenaries { get; set; }
        public virtual DbSet<Passenger> Passengers { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<RoomDetail> RoomDetails { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual ObjectResult<SearchFlights_Result> SearchFlights(string origin, string dest, Nullable<System.DateTime> depttime)
        {
            var originParameter = origin != null ?
                new ObjectParameter("origin", origin) :
                new ObjectParameter("origin", typeof(string));
    
            var destParameter = dest != null ?
                new ObjectParameter("dest", dest) :
                new ObjectParameter("dest", typeof(string));
    
            var depttimeParameter = depttime.HasValue ?
                new ObjectParameter("depttime", depttime) :
                new ObjectParameter("depttime", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SearchFlights_Result>("SearchFlights", originParameter, destParameter, depttimeParameter);
        }
    
        public virtual ObjectResult<usp_SearchFlights_Result> usp_SearchFlights(string origin, string dest, Nullable<System.DateTime> depttime)
        {
            var originParameter = origin != null ?
                new ObjectParameter("origin", origin) :
                new ObjectParameter("origin", typeof(string));
    
            var destParameter = dest != null ?
                new ObjectParameter("dest", dest) :
                new ObjectParameter("dest", typeof(string));
    
            var depttimeParameter = depttime.HasValue ?
                new ObjectParameter("depttime", depttime) :
                new ObjectParameter("depttime", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_SearchFlights_Result>("usp_SearchFlights", originParameter, destParameter, depttimeParameter);
        }
    
        public virtual ObjectResult<usp_SearchFlights1_Result> usp_SearchFlights1(string origin, string dest, Nullable<System.DateTime> depttime)
        {
            var originParameter = origin != null ?
                new ObjectParameter("origin", origin) :
                new ObjectParameter("origin", typeof(string));
    
            var destParameter = dest != null ?
                new ObjectParameter("dest", dest) :
                new ObjectParameter("dest", typeof(string));
    
            var depttimeParameter = depttime.HasValue ?
                new ObjectParameter("depttime", depttime) :
                new ObjectParameter("depttime", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_SearchFlights1_Result>("usp_SearchFlights1", originParameter, destParameter, depttimeParameter);
        }
    
        public virtual ObjectResult<uspSearchHotels_Result> uspSearchHotels(string city)
        {
            var cityParameter = city != null ?
                new ObjectParameter("City", city) :
                new ObjectParameter("City", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspSearchHotels_Result>("uspSearchHotels", cityParameter);
        }

        public System.Data.Entity.DbSet<PlanMyTripDAL.usp_SearchFlights_Result> usp_SearchFlights_Result { get; set; }

        //public System.Data.Entity.DbSet<PlanMyTripApp.Models.usp_SearchFlights_Result> usp_SearchFlights_Result { get; set; }
    }
}