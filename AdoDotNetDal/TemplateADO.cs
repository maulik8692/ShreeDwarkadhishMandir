using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoDotNetDal
{
    public abstract class TemplateADO<AnyType> : AbstractDal<AnyType>
    {
        protected SqlConnection con = null;
        protected SqlCommand cmd = null;
        public TemplateADO(string _connectionString) : base(_connectionString)
        {
        }

        private void Open()
        {
            con = new SqlConnection(connectionString);
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        private void Close()
        {
            con.Close();
        }

        // Design Pattern : Template Pattern
        protected List<AnyType> SearchExcute() // Fixed Sequence Select
        {
            List<AnyType> anyTypes = null;
            Open();
            anyTypes = SearchCommand();
            Close();
            return anyTypes;
        }

        protected List<AnyType> SearchExcute<T>(T anyObject)
        {
            List<AnyType> anyTypes = null;
            Open();
            anyTypes = SearchCommand(anyObject);
            Close();
            return anyTypes;
        }

        protected List<AnyType> GetReportExcute<T>(T anyObject)
        {
            List<AnyType> anyTypes = null;
            Open();
            anyTypes = GetReportCommand(anyObject);
            Close();
            return anyTypes;
        }

        protected List<AnyType> DropdownWithSearchExcute<T>(T anyObject)
        {
            List<AnyType> anyTypes = null;
            Open();
            anyTypes = DropdownWithSearchCommand(anyObject);
            Close();
            return anyTypes;
        }

        protected AnyType GetDetailExcute<T>(T anyObject)
        {
            AnyType anyTypes;
            Open();
            anyTypes = GetDetailCommand(anyObject);
            Close();
            return anyTypes;
        }

        protected void AddExcute(AnyType anyType)
        {
            Open();
            AddCommand(anyType);
            Close();
        }

        protected void UpdateExcute(AnyType anyType)
        {
            Open();
            UpdateCommand(anyType);
            Close();
        }

        protected void SaveExcute(AnyType anyType)
        {
            Open();
            SaveCommand(anyType);
            Close();
        }

        protected AnyType SaveWithReturnExcute(AnyType anyType)
        {
            AnyType returnAnyType;
            Open();
            returnAnyType = SaveWithReturnCommand(anyType);
            Close();
            return returnAnyType;
        }

        protected bool CheckDataExcute(AnyType anyObject)
        {
            Open();
            bool t = CheckDataCommand(anyObject);
            Close();
            return t;
        }

        protected abstract void AddCommand(AnyType anyType); // Child Classes
        protected abstract void UpdateCommand(AnyType anyType); // Child Classes
        protected abstract void SaveCommand(AnyType anyType); // Child Classes
        protected abstract AnyType SaveWithReturnCommand(AnyType anyType); // Child Classes

        protected abstract List<AnyType> SearchCommand(); // Child Classes
        protected abstract List<AnyType> SearchCommand<T>(T anyObject); // Child Classes
        protected abstract List<AnyType> GetReportCommand<T>(T anyObject); // Child Classes
        protected abstract List<AnyType> DropdownWithSearchCommand<T>(T anyObject); // Child Classes
        protected abstract bool CheckDataCommand(AnyType anyObject); // Child Classes
        protected abstract AnyType GetDetailCommand<T>(T anyObject); // Child Classes

        public override void Add(AnyType anyType)
        {
            AddExcute(anyType);
        }

        public override void Update(AnyType anyType)
        {
            UpdateExcute(anyType);
        }

        public override void Save(AnyType anyType)
        {
            SaveExcute(anyType);
        }

        public override AnyType SaveWithReturn(AnyType anyType)
        {
           return SaveWithReturnExcute(anyType);
        }

        public override List<AnyType> Search()
        {
            return SearchExcute();
        }

        public override List<AnyType> Search<T>(T anyObject)
        {
            return SearchExcute(anyObject);
        }

        public override List<AnyType> DropdownWithSearch<T>(T anyObject)
        {
            return DropdownWithSearchExcute(anyObject);
        }

        public override bool CheckData(AnyType anyObject)
        {
            return CheckDataExcute(anyObject);
        }

        public override AnyType GetDetail<T>(T anyObject)
        {
            return GetDetailExcute(anyObject);
        }

        public override List<AnyType> GetReport<T>(T anyObject)
        {
            return GetReportExcute(anyObject);
        }
    }
}
