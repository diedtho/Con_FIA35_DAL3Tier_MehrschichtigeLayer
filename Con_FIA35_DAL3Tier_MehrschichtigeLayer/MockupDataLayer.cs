using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Con_FIA35_DAL3Tier_MehrschichtigeLayer
{
    class MockupDataLayer : IDaten
    {
        List<Person> Personenliste;

        public MockupDataLayer()
        {
            Personenliste = new List<Person>
            {
                new Person {PID = 1, Nachname="Blöd",Vorname="Hein",Geburtsdatum=new DateTime(1977,12,24), HatKundenkarte=true},
                new Person {PID = 2, Nachname="Unruh",Vorname="Ute",Geburtsdatum=new DateTime(1988,7,13), HatKundenkarte=true}
            };
        }

        public bool DeletePerson(Person person)
        {
            bool geklappt = false;
            geklappt = Personenliste.Remove(person);
            
            return geklappt;
        }

        public int InsertPerson(Person person)
        {
            int NeueMaxId;

            NeueMaxId = Personenliste.Max(p => p.PID) + 1;
            person.PID = NeueMaxId;
            Personenliste.Add(person);

            return NeueMaxId;
      
        }
                

        public List<Person> SelectAllPersons()
        {
            return Personenliste;
        }

        public Person SelectPersonById(int Id)
        {
            return Personenliste.FirstOrDefault(p => p.PID == Id);           
        }

        public bool UpdatePerson(Person person)
        {
            Person p = Personenliste.FirstOrDefault(p => p.PID == person.PID);
            if (p != null)
            {
                p.Vorname = person.Vorname;
                p.Nachname = person.Nachname;
                p.Geburtsdatum = person.Geburtsdatum;
                p.HatKundenkarte = person.HatKundenkarte;
                return true;
            }

            return false;
        }
    }
}
