using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Con_FIA35_DAL3Tier_MehrschichtigeLayer
{
    internal class Person
    {
        public int PID { get; set; }
        public string Vorname { get; set; }

        public string Nachname { get; set; }
        public DateTime Geburtsdatum { get; set; }

        public bool HatKundenkarte { get; set; }


    }
}
