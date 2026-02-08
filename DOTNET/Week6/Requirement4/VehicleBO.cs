
namespace Requirement4
{
    internal class VehicleBO
    {
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, string type)
        {
            List<Vehicle> result = new List<Vehicle>();

            foreach (var v in vehicleList)
            {
                if (v.Type == type)
                    result.Add(v);
            }

            return result;
        }

        // search vehicles by parked time
        public List<Vehicle> FindVehicle(List<Vehicle> vehicleList, DateTime parkedTime)
        {
            List<Vehicle> result = new List<Vehicle>();

            foreach (var v in vehicleList)
            {
                if (v.Ticket.ParkedTime == parkedTime)
                    result.Add(v);
            }

            return result;
        }
    }
}
