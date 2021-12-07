using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_5_2.Models
{
    public interface ICRUDContactRepository
    {
        Contact FindById(int id);
        Contact Add(Contact contact);

        void Delete(int id);

        Contact Update(Contact contact);

        List<Contact> FindAll();

    }
}
