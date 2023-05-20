using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLibrary
{
    public interface IPhoneDictionary
    {
        IEnumerable<Contact> GetBookList(); // получение всех объектов
        Contact GetBook(int id); // получение одного объекта по id
        void Add(Contact item); // создание объекта
        void Update(Contact item); // обновление объекта
        void Delete(Contact contact); // удаление объекта по id
        void DeleteByID(int id);
        Contact GetByID(int id);
    }
}
