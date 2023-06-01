using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VaccineApp.Models
{
    public class CommunityVaccineRecord
    {
        public int Id { get; set; }
        public string CommunityName { get; set; }
        public string NIK { get; set; }
        public string VaccineName { get; set; }
        public DateTime VaccineDate { get; set; }
        public int DoseNumber { get; set; }
        public string AdministrationType { get; set; }
        public string NurseName { get; set; }
        public string HospitalName { get; set; }
    }
}