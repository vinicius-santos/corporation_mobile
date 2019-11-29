using System;
using System.Collections.Generic;
using System.Text;

namespace CorporationMobile.Helpers
{
   public class Constants
    {
        //trocar aqui abiguinhos para o ip da wifi da sua maquina :)
        //trocar no iis tbm o ip  C:\bludata\corporation_api\CorporationApi\.vs\CorporationApi\config\applicationhost.config
        //E não menos importante rode em mode ADM o visual pq se não pode dar problemas de permissão.
        //E não esqueça pela amor de deus firewall e anti-virus ><
        public static string API_URL = "http://192.168.25.139:60924/api/";
    }
}
