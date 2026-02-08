
using System.Collections;

namespace Requirement4
{

    public class parkedTimeComparer : IComparer<Vehicle>
    {
        public int Compare(Vehicle v1, Vehicle v2)
        {
            if (v1 == null || v2 == null)
                return 0;

            return v1.Ticket.ParkedTime.CompareTo(v2.Ticket.ParkedTime);
        }
    }


}
