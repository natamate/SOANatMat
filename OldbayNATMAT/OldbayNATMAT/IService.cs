using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace OldbayNATMAT
{
    [ServiceContract]
    interface IService
    {
        [OperationContract]
        Wing GetWing(string name);

        [OperationContract]
        String CreateWing(Wing wing);
    }
}
