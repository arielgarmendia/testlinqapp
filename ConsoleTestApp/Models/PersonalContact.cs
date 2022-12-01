namespace ConsoleTestApp.Models
{
    internal class PersonalContact
    {
        public PersonalContact(int id, int houseID, string name, int? mobileNumber = null)
        {
            Id = id;
            HouseId = houseID;
            FullName = name;
            MobileNumber = mobileNumber;
        }

        public int Id { get; set; }
        public int HouseId { get; set; }
        public string FullName { get; set; }
        public int? MobileNumber { get; set; }
    }
}
