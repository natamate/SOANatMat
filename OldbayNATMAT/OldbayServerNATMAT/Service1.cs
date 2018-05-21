using System;
using System.Collections.Generic;
using System.ServiceModel;
using ObjectsManager.Interfaces;
using ObjectsManager.LiteDB;
using ObjectsManager.Model;

namespace OldbayServerNATMAT
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class Service1 : IService1
    {
        private readonly IWingRepository _wingRepository;

        public Service1()
        {
            this._wingRepository = new WingRepository();
        }

        public Wing GetWing(string name)
        {
            return this._wingRepository.Get(name);
        }

        public string CreateWing(Wing wing)
        {
            return this._wingRepository.Add(wing).ToString();
        }

        public List<Wing> GetAllWings()
        {
            return this._wingRepository.GetAllWings();
        }
    }
}
