namespace ConsoleTestApp.Models
{
    internal class BuildingContact
    {
        public BuildingContact(int id, string buildingName)
        {
            Id = id;
            BuildingName = buildingName;
            BuildingContacts = new List<HouseContact>();
        }

        public int Id { get; set; }
        public string BuildingName { get; set; }
        public List<HouseContact> BuildingContacts { get; set; }
    }
}
