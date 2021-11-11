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

        List<Person> Personenliste;

        public CsvDataAccessLayer()
        {
            
            // Csv-Konfiguration Delimiter usw. ...
        }

        public bool DeletePerson(Person person)
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
            List<Person> PersonenListe = SelectAllPersons();
            return PersonenListe.FirstOrDefault(p => p.PID == Id);

        }

        public bool UpdatePerson(Person person)
        {

            List<Person> PersonenListe = SelectAllPersons();
            Person p = PersonenListe.FirstOrDefault(p => p.PID == person.PID);

            p.Vorname = person.Vorname;
            p.Nachname = person.Nachname;
            p.Geburtsdatum = person.Geburtsdatum;
            p.HatKundenkarte = person.HatKundenkarte;
            Wegschreiben(PersonenListe);

            return true;
        }

        
        int IDaten.InsertPerson(Person person)
        {
            int NeueMaxId = 0;

            NeueMaxId = Personenliste.Max(p => p.PID) + 1;
            Personenliste.Add(person);

            // Wegschreiben
            Wegschreiben(Personenliste);

            return NeueMaxId;

        }

        private static void Wegschreiben(List<Person> PersonenListe)
        {
            using (var writer = new StreamWriter("Personen.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(PersonenListe);
            }
        }



    }
}
