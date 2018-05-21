using System;
using System.Collections.Generic;
using System.ServiceModel;
using ObjectsManager.Model;

namespace OldbayServerNATMAT
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Wing GetWing(string name);

        [OperationContract]
        String CreateWing(Wing wing);

        [OperationContract]
        List<Wing> GetAllWings();
    }
}