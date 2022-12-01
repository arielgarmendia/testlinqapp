using ConsoleTestApp.Models;

namespace ConsoleTestApp.Linq
{
    public class ProcessLinq
    {
        private List<int> IDs
        {
            get;
            set;
        } = new List<int>();

        public ProcessLinq()
        {
            var data = new List<LinqData>
            {
                new LinqData(1, "test1"),
                new LinqData(2, "test2"),
                new LinqData(3, "test3"),
                new LinqData(4, "test4"),
                new LinqData(5, "different1")
            };

            Console.WriteLine("Testing LINQ access styles:");
            HandleIDsV1(data);
            Console.WriteLine("");
            HandleIDsV2(data);
        }

        private void HandleIDsV1(List<LinqData> myDataList)
        {
            IDs = myDataList.Where(d => d.Name.Contains("test")).Select(d => d.Id).ToList();

            Console.WriteLine("Fluent style:");

            IDs.ForEach(id => Console.WriteLine(id));
        }

        private void HandleIDsV2(List<LinqData> myDataList)
        {
            IDs = (from x in myDataList where x.Name.Contains("different") select x.Id).ToList();

            Console.WriteLine("Query style:");

            foreach (int id in IDs)
                Console.WriteLine(id);
        }
    }
}