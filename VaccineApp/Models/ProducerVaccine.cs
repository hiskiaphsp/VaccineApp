using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccineApp.Models
{
    public class ProducerVaccine
    {
        public int Id { get; set; }
        public string ProducerName { get; set; }
        public string VaccineName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string VaccineType { get; set; }
        public float DoseCount { get; set; }
        public string Dose { get; set; }
        public float Price { get; set; }
    }

}