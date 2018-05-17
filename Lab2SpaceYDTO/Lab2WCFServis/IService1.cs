using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Lab2SpaceYDTO;

namespace Lab2WCFServis
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        void InitializeGame();
        [OperationContract]
        Starship SendStarship(Starship starship, string systemName);
        [OperationContract]
        SpaceSystem GetSystem();
        [OperationContract]
        Starship GetStarship(int money);
    }
}
