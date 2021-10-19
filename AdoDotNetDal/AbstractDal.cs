using InterfaceDal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNetDal
{
    public abstract class AbstractDal<AnyType> : IRepository<AnyType>
    {
        protected string connectionString = string.Empty;

        public AbstractDal(string _connectionString)
        {
            connectionString = _connectionString;
        }

        protected List<AnyType> AnyTypes = new List<AnyType>();

        public virtual void Add(AnyType anyType)
        {
            throw new NotImplementedException();
        }

        public virtual AnyType SaveWithReturn(AnyType anyType)
        {
            throw new NotImplementedException();
        }

        public virtual void Save(AnyType anyType)
        {
            throw new NotImplementedException();
        }

        public virtual List<AnyType> Search()
        {
            throw new NotImplementedException();
        }

        public virtual List<AnyType> Search<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        public virtual List<AnyType> GetReport<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        public virtual List<AnyType> DropdownWithSearch<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        public virtual List<AnyType> DropdownWithSearch(string procedureName)
        {
            throw new NotImplementedException();
        }

        public virtual void Update(AnyType anyType)
        {
            throw new NotImplementedException();
        }

        public virtual bool CheckData(AnyType anyObject)
        {
            throw new NotImplementedException();
        }

        public virtual AnyType GetDetail<T>(T anyObject)
        {
            throw new NotImplementedException();
        }
    }
}
