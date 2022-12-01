namespace ConsoleTestApp.Models
{
    internal class HouseContact
    {
        public HouseContact(int id, int bulldingID, string houseName, int landLine)
        {
            Id = id;
            BuildingId = bulldingID;
            HouseName = houseName;
            LandLine = landLine;
            HouseContacts = new List<PersonalContact>();
        }

        public int Id { get; set; }
        public int BuildingId { get; set; }
        public string HouseName { get; set; }
        public int LandLine { get; set; }
        public List<PersonalContact> HouseContacts { get; set; }
    }
}
