using CsvHelper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Con_FIA35_DAL3Tier_MehrschichtigeLayer
{
    internal class CsvDataAccessLayer : IDaten
    {
        public bool DeletePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public bool InsertPerson(Person person)
        {
            throw new NotImplementedException();
        }

        public List<Person> SelectAllPersons()
        {
            List<Person> PersonenListe = new();

            using (var reader = new StreamReader("Personen.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                PersonenListe = csv.GetRecords<Person>().ToList();
            }
            return PersonenListe;

        }

        public Person SelectPersonById(int Id)
        {
            throw new NotImplementedException();
        }

        public bool UpdatePerson(Person person)
        {
            throw new NotImplementedException();
        }
    }
}
