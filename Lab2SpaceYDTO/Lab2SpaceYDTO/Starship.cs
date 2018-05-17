using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Lab2SpaceYDTO
{
    [DataContract]
    public class Starship
    {
        [DataMember]
        public List<Person> Crew { get; set; }
        [DataMember]
        public int Gold { get; set; }
        [DataMember]
        public int ShipPower { get; set; }
    }
}
