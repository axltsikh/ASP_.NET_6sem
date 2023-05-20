using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace eightSecond.Repository
{
    public interface Ilerax
    {
        LeraX GetById(int id);
        IEnumerable<LeraX> GetAll();
        void Add(LeraX entity);
        void Remove(LeraX entity);
        void Update(LeraX entity);
    }
}
