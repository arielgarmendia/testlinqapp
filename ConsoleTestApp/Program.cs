using ConsoleTestApp;
using ConsoleTestApp.Linq;
using ConsoleTestApp.Models;
using System.Linq;
using System.Numerics;

var process = new ProcessLinq();
var puchases = new Purchases();

var building = new BuildingContact(1, "Paseo sin Gracia No. 21");

PopulateLists();
DísplayMenuContents();
MenuHandler();

void MenuHandler()
{
    var exit = false;

    do
    {
        var menuOption = Console.ReadKey(true);

        switch (menuOption.KeyChar)
        {
            case '1':
                SearchPersonalContact();
                break;
            case '2':
                SearchHouseContacts();
                break;
            case '3':
                ListPersonalContacts();
                break;
            case '4':
                ListHousesContacts();
                break;
            case '5':
                exit = true;
                break;
            default:
                exit = true;
                break;
        }

    } while (!exit);
}

void DísplayMenuContents()
{
    Console.WriteLine("Test App: Menu Options");
    Console.WriteLine("");

    Console.WriteLine("Please select an option:");
    Console.WriteLine("[1] Search for a Personal Contact.");
    Console.WriteLine("[2] Search for Contacts in a House.");
    Console.WriteLine("[3] List all Personal Contacts in all Houses.");
    Console.WriteLine("[4] List all Houses in the Building.");
    Console.WriteLine("[5] Exit App.");
}

void PopulateLists()
{
    Console.WriteLine("Test App: Populating Houses and Contacts Lists...");
    Console.WriteLine("");

    var house1 = new HouseContact(1, 1, "Bajo 1A", 91111111)
    {
        HouseContacts = new List<PersonalContact>
            {
                new PersonalContact(1, 1, "Juan A", 620111111),
                new PersonalContact(2, 1,"Maria B", 620111112),
                new PersonalContact(3, 1, "Baby AB")
            }
    };

    var house2 = new HouseContact(2, 1, "Bajo 1B", 91111112)
    {
        HouseContacts = new List<PersonalContact>
            {
                new PersonalContact(4, 2, "Old Garry", 620111113)
            }
    };

    var house3 = new HouseContact(3, 1, "Bajo 1C", 91111113)
    {
        HouseContacts = new List<PersonalContact>
            {
                new PersonalContact(5, 3, "Brad P", 620111111),
                new PersonalContact(6, 3, "Johnny D", 620111112),
            }
    };

    building.BuildingContacts.AddRange(new [] { house1, house2, house3 });
}

void SearchPersonalContact()
{
    Console.WriteLine("Search for a personal contact.");
    Console.WriteLine("Type a personal phone number:");

    var phone = Console.ReadLine();

    Console.WriteLine("Searching personal phone number: " + phone);

    if (!String.IsNullOrEmpty(phone))
    {
        var persons = building.BuildingContacts.Where
            (
                h => h.HouseContacts.Any()
            ).Select
            (
                h => h.HouseContacts.FirstOrDefault(p => p.MobileNumber != null && p.MobileNumber.ToString().Contains(phone)
            )).Where(c => c != null).ToList();

        if (persons.Any())
        {
            persons.ForEach
                (
                    person => Console.WriteLine(String.Format("Name: {0} - House: {1}", person?.FullName, building.BuildingContacts.FirstOrDefault(h => h.Id == person?.HouseId).HouseName))
                );
        }
        else
            Console.WriteLine(string.Format("Nothing found for mobile number: {0}", phone));
    }

    Console.WriteLine("");
    DísplayMenuContents();
}

void ListPersonalContacts()
{
    Console.WriteLine("Listing all personal contacts.");

    var persons = building.BuildingContacts.Where
    (
        h => h.HouseContacts.Any()
    ).Select
    (
        h => h.HouseContacts
    ).Where(c => c != null).ToList();

    if (persons.Any())
    {
        persons.ForEach
            (
                p => p.ForEach(person => Console.WriteLine(String.Format("Name: {0} - House: {1}", person?.FullName, building.BuildingContacts.FirstOrDefault(h => h.Id == person?.HouseId).HouseName)))
            );
    }
    else
        Console.WriteLine("Nothing found.");

    Console.WriteLine("");
    DísplayMenuContents();
}

void SearchHouseContacts()
{
    Console.WriteLine("Search for Contacts in a house:");
    Console.WriteLine("Type a house phone number:");

    var phone = Console.ReadLine();

    Console.WriteLine("Searching house phone number: " + phone);

    if (!String.IsNullOrEmpty(phone))
    {
        var persons = building.BuildingContacts.Where
            (
                h => h.HouseContacts.Any() && h.LandLine.ToString().Contains(phone)
            ).Select
            (
                h => h.HouseContacts
            ).Where(c => c != null).ToList();

        if (persons.Any())
        {
            persons.ForEach
                (
                    p => p.ForEach(person => Console.WriteLine(String.Format("Name: {0} - House: {1}", person?.FullName, building.BuildingContacts.FirstOrDefault(h => h.Id == person?.HouseId).HouseName)))
                );
        }
        else
            Console.WriteLine(string.Format("Nothing found for house phone number: {0}", phone));
    }

    Console.WriteLine("");
    DísplayMenuContents();
}

void ListHousesContacts()
{
    Console.WriteLine("Listing all houses.");

    if (building.BuildingContacts.Any())
    {
        building.BuildingContacts.ForEach
            (
                house => Console.WriteLine(String.Format("House Name: {0} - Building Name: {1}", house?.HouseName, building.BuildingName))
            );
    }
    else
        Console.WriteLine("Nothing found.");

    Console.WriteLine("");
    DísplayMenuContents();
}