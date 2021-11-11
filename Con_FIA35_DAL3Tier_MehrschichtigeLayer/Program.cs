// See https://aka.ms/new-console-template for more information
using Con_FIA35_DAL3Tier_MehrschichtigeLayer;

Console.WriteLine("DAL (DataAccessLayer, BL, ... ");

PersonenBL personenBL = new PersonenBL(new CsvDataAccessLayer());

foreach(Person person in personenBL.ReadAllPerson())
{
    Console.WriteLine($"{person.PID} - {person.Nachname} - {person.Geburtsdatum.ToShortDateString()} - {person.HatKundenkarte}");
}