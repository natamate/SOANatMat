using System.Runtime.Serialization;

namespace Lab2SpaceYDTO
{
    [DataContract]
    public class SpaceSystem
    {
        [DataMember]
        public string Name { get; set; }

        public int MinShipPower { get; set; }
        [DataMember]
        public int BaseDistance { get; set; }

        public int Gold { get; set; }

    }
}
