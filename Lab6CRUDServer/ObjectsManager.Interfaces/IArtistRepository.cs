using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectsManager.Model;

namespace ObjectsManager.Interfaces
{
    public interface IArtistRepository
    {
        List<Artist> GetAll();
        int Add(Artist artist);
        Artist Get(int id);
        Artist Update(Artist artist);
        bool Delete(int id);
    }
}
