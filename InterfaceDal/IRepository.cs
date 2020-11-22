using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDal
{
    public interface IRepository<AnyType>
    {
        void Add(AnyType anyType); // inmemory addition
        void Update(AnyType anyType); // inmemory updattion
        List<AnyType> Search();
        List<AnyType> Search<T>(T anyObject);
        List<AnyType> GetReport<T>(T anyObject);
        AnyType GetDetail<T>(T anyObject);
        void Save(AnyType anyType); // physical commit
        AnyType SaveWithReturn(AnyType anyType); // physical commit
        bool CheckData(AnyType anyObject);
        List<AnyType> DropdownWithSearch<T>(T anyObject);
        
    }
}
