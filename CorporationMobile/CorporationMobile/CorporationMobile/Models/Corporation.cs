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


        public static List<string> States()
        {
            List<string> states = new List<string>();
            states.Add("AC");
            states.Add("AL");
            states.Add("AP");
            states.Add("AM");
            states.Add("BA");
            states.Add("CE");
            states.Add("DF");
            states.Add("ES");
            states.Add("GO");
            states.Add("MA");
            states.Add("MT");
            states.Add("MS");
            states.Add("MG");
            states.Add("PA");
            states.Add("PB");
            states.Add("PR");
            states.Add("PE");
            states.Add("PI");
            states.Add("RJ");
            states.Add("RN");
            states.Add("RS");
            states.Add("RO");
            states.Add("RR");
            states.Add("SC");
            states.Add("SP");
            states.Add("SE");
            states.Add("TO");
            return states;
        }
    }
}
