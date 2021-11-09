using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Con_FIA35_DAL3Tier_MehrschichtigeLayer
{
    internal interface IDaten
    {
        public bool DeletePerson(Person person);
        public bool InsertPerson(Person person);
        Person SelectPersonById(int Id);
        List<Person> SelectAllPersons();
        bool UpdatePerson(Person person);

    }
}
