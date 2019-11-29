using System;
using System.Collections.Generic;
using System.Text;

namespace CorporationMobile.Models
{
    public class Provider
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CNPJ { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public Nullable<DateTime> BirthDate { get; set; }
        public DateTime DateRegister { get; set; }
        public DateTime HourRegister { get; set; }
        public string Phone { get; set; }
        public Corporation Corporation { get; set; }
    }
}
