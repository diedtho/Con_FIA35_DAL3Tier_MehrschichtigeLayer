using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Con_FIA35_DAL3Tier_MehrschichtigeLayer
{
    internal class PersonenBL
    {
        IDaten DatenZugriff;


        // Dependency injection
        public PersonenBL(IDaten DataAccess)

        {
            DatenZugriff = DataAccess;

        }

        public int AddPerson(Person p)
        {
            return DatenZugriff.InsertPerson(p);
        }

        public bool RemovePerson(Person p)
        {
            return DatenZugriff.DeletePerson(p);

        }

        public bool RefreshPerson(Person person)
        {
            return DatenZugriff.UpdatePerson(person);
        }

        public List<Person> ReadAllPerson()
        {
            return DatenZugriff.SelectAllPersons();
        }

        public Person ReadPersonById(int Id)
        {
            return DatenZugriff.SelectPersonById(Id);
        }

        // Älteste Person
        public Person GetOldestPerson()
        {
            List<Person> PersonenListe = ReadAllPerson();
            DateTime ÄltestesDatum = PersonenListe.Min(p => p.Geburtsdatum);

            return PersonenListe.FirstOrDefault(p => p.Geburtsdatum == ÄltestesDatum);
        }

        // Alle, die heute Geburtstag haben
        public List<Person> AlleGeburtstagskinder()
        {
            List<Person> PersonenListe = DatenZugriff.SelectAllPersons();
            return PersonenListe.FindAll(p=>(p.Geburtsdatum.Day==DateTime.Now.Day && p.Geburtsdatum.Month==DateTime.Now.Month));
        }

        // Alle mit einer Kundenkarte
        public List<Person> AlleKartenInhaber()
        {
            List<Person> PersonenListe = DatenZugriff.SelectAllPersons();
            return PersonenListe.FindAll(p => p.HatKundenkarte == true);

        }

        // Alle Personen mit einem 'a' im Vornamen
        public List<Person> GetPersonsByCharInForename(string zeichen)
        {
            List<Person> PersonenListe = DatenZugriff.SelectAllPersons();
            return PersonenListe.FindAll(p => p.Vorname.ToUpper().Contains(zeichen.ToUpper()));
        }


    }
}
