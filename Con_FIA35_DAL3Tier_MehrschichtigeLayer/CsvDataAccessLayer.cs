using CsvHelper;
using CsvHelper.Configuration;
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

        List<Person> PersonenListe;
        CsvConfiguration conf;

        public CsvDataAccessLayer()
        {
            conf = new CsvConfiguration(new CultureInfo("DE-de")) { Delimiter = ";" };

            using (var reader = new StreamReader("Personen.csv"))
            using (var csv = new CsvReader(reader, conf))
            {
                PersonenListe = csv.GetRecords<Person>().ToList();
            }


        }

        public bool DeletePerson(Person person)
        {
            bool geklappt = PersonenListe.Remove(person);

            // CSV "Wegschreiben" (Sichern bzw. Speichern)
            Wegschreiben();

            return geklappt;
        }


        public List<Person> SelectAllPersons()
        {
            

            using (var reader = new StreamReader("Personen.csv"))
            using (var csv = new CsvReader(reader, conf))
            {
                PersonenListe = csv.GetRecords<Person>().ToList();
            }
            return PersonenListe;

        }

        public Person SelectPersonById(int Id)
        {
            return PersonenListe.FirstOrDefault(p => p.PID == Id);

        }

        public bool UpdatePerson(Person person)
        {

            
            Person p = PersonenListe.FirstOrDefault(p => p.PID == person.PID);

            if (p != null)
            {
                p.Vorname = person.Vorname;
                p.Nachname = person.Nachname;
                p.Geburtsdatum = person.Geburtsdatum;
                p.HatKundenkarte = person.HatKundenkarte;
                Wegschreiben();

                return true;
            }

            return false;
        }


        int IDaten.InsertPerson(Person person)
        {
            int NeueMaxId = 0;

            NeueMaxId = PersonenListe.Max(p => p.PID) + 1;
            person.PID = NeueMaxId;
            PersonenListe.Add(person);

            // Wegschreiben
            Wegschreiben();

            return NeueMaxId;

        }

        // Hilfsmethode
        private void Wegschreiben()
        {

            using (var writer = new StreamWriter("Personen.csv"))
            using (var csv = new CsvWriter(writer, conf))
            {
                csv.WriteRecords(PersonenListe);
            }
        }



    }
}
