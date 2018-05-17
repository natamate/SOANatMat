using System.Collections.Generic;
using ObjectsManager.Model;

namespace ObjectsManagerInterface
{
    public interface IPersonRepository
    {
        List<Person> GetAll();
        int Add(Person person);
        Person Get(int id);
        Person Update(Person person);
        bool Delete(int id);
    }
}
