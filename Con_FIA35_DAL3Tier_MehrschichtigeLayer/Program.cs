// See https://aka.ms/new-console-template for more information
using Con_FIA35_DAL3Tier_MehrschichtigeLayer;

Console.WriteLine("DAL (DataAccessLayer, BL, ... ");

PersonenBL personenBL = new PersonenBL(new CsvDataAccessLayer());
// PersonenBL personenBL = new PersonenBL(new MockupDataLayer());

foreach (Person person in personenBL.ReadAllPerson())
{
    Console.WriteLine($"{person.PID} - {person.Nachname} - {person.Geburtsdatum.ToShortDateString()} - {person.HatKundenkarte}");
}

Console.WriteLine("------------------------------------------------------------------------------------------------------");

personenBL.AddPerson(new Person { PID = 4711, Vorname = "Bernd", Nachname = "Brot", Geburtsdatum = new DateTime(1987, 12, 2), HatKundenkarte = true });

foreach (Person person in personenBL.ReadAllPerson())
{
    Console.WriteLine($"{person.PID} - {person.Nachname} - {person.Geburtsdatum.ToShortDateString()} - {person.HatKundenkarte}");
}

Console.WriteLine("------------------------------------------------------------------------------------------------------");

Person Person2Update = personenBL.ReadPersonById(3);
Person2Update.Nachname = "Bäcker-Brot";
personenBL.RefreshPerson(Person2Update);


foreach (Person person in personenBL.ReadAllPerson())
{
    Console.WriteLine($"{person.PID} - {person.Nachname} - {person.Geburtsdatum.ToShortDateString()} - {person.HatKundenkarte}");
}

Console.WriteLine("------------------------------------------------------------------------------------------------------");


Person Person2Delete = personenBL.ReadPersonById(3);
bool hatgeklappt = personenBL.RemovePerson(Person2Delete);

if (hatgeklappt)
{
    Console.WriteLine("Remove hat geklappt!");
}



foreach (Person person in personenBL.ReadAllPerson())
{
    Console.WriteLine($"{person.PID} - {person.Nachname} - {person.Geburtsdatum.ToShortDateString()} - {person.HatKundenkarte}");
}