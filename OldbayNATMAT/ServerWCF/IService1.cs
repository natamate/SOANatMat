using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ObjectsManager.Model;

namespace ServerWCF
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        Wing GetWing(string name);

        [OperationContract]
        String CreateWing(Wing wing);
    }
}
