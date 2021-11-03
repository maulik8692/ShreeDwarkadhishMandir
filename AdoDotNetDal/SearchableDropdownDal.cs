using CommonLayer;
using FactoryMiddleLayer;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNetDal
{
    public class SearchableDropdownDal : DropdownTemplateADO<ISearchableDropdown>
    {
        public SearchableDropdownDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override List<ISearchableDropdown> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<ISearchableDropdown> DropdownWithSearchCommand(string procedureName)
        {
            cmd.CommandText = procedureName;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<ISearchableDropdown> results = new List<ISearchableDropdown>();
            while (dr.Read())
            {
                ISearchableDropdown result = Factory<ISearchableDropdown>.Create("Searchable");
                result.Id = dr["Id"].ToInt();
                result.DisplayText = dr["DisplayText"].ToString();
                result.IsActive = dr["IsActive"].ToString().ToBool();
                result.OtherFlag = dr["OtherFlag"].ToString().ToBool();
                result.OtherText = dr["OtherText"].ToString();
                results.Add(result);
            }

            return results;
        }
    }
}
