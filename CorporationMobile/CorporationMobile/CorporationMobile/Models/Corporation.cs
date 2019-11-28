using System;
using System.Collections.Generic;
using System.Text;

namespace CorporationMobile.Models
{
    public class Corporation
    {
        public int ID { get; set; }
        public string UF { get; set; }
        public string NameFantasy { get; set; }
        public string CNPJ { get; set; }
        public List<Provider> Providers { get; set; }
    }
}
