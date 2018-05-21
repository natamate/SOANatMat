using System.Collections.Generic;
using ObjectsManager.Model;

namespace ObjectsManager.Interfaces
{
    public interface IWingRepository
    {
        List<Wing> GetAllWings();
        int Add(Wing wing);
        Wing Get(string name);
        Wing Get(int id);
        Wing Update(Wing wing);
        bool Delete(int id);
    }
}
