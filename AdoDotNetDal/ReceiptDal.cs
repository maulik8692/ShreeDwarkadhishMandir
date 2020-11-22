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
    public class ReceiptDal : TemplateADO<IReceipt>
    {
        public ReceiptDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IReceipt anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IReceipt anyObject)
        {
            cmd.CommandText = "CheckReceiptConfiguration";
            cmd.CommandType = CommandType.StoredProcedure;
            
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IReceipt> IReceipts = new List<IReceipt>();
            while (dr.Read())
            {
                IReceipt IReceipt = Factory<IReceipt>.Create("Receipt");
                IReceipt.ReceiptConfigurationExists = dr["ReceiptConfigurationExists"].ToBool();
                IReceipts.Add(IReceipt);
            }

            return IReceipts.FirstOrDefault().IsNull() ? false : IReceipts.First().ReceiptConfigurationExists;
        }

        protected override List<IReceipt> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IReceipt GetDetailCommand<T>(T anyObject)
        {
            IReceipt IReceiptRequest = anyObject as IReceipt;

            cmd.CommandText = "GetManorathReceiptById";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", IReceiptRequest.Id);
            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IReceipt> IReceipts = new List<IReceipt>();
            while (dr.Read())
            {
                IReceipt IReceipt = Factory<IReceipt>.Create("Receipt");
              
                IReceipt.MandirName = dr["MandirName"].ToString();
                IReceipt.ImageUrl = dr["ImageUrl"].ToString();

                IReceipt.MandirAddress = dr["MandirAddress"].ToString();
                IReceipt.Id = dr["Id"].ToInt();
                IReceipt.ReceiptNo = dr["ReceiptNo"].ToString();

                IReceipt.RegistrationNumber = dr["RegistrationNumber"].ToString();

                IReceipt.GurudevName = dr["GurudevName"].ToString();
                IReceipt.MandirHeader = dr["MandirHeader"].ToString();
                
                if (dr["ManorathDate"].IsNotNull() && dr["ManorathDate"].IsDate())
                {
                    IReceipt.ManorathDate = dr["ManorathDate"].ToString().ToDateTime("MM/dd/yyyy hh:mm:ss tt");
                }

                if (dr["CreatedOn"].IsNotNull() && dr["CreatedOn"].IsDate())
                {
                    IReceipt.CreatedOn = dr["CreatedOn"].ToString().ToDateTime("MM/dd/yyyy hh:mm:ss tt");
                }
                IReceipt.ManorathiName = dr["ManorathiName"].ToString();
                IReceipt.ManorathName = dr["ManorathName"].ToString();
                IReceipt.ManorathType = dr["ManorathType"].ToInt();
                IReceipt.Nek = dr["Nek"].ToDecimal();
                IReceipt.Email = dr["Email"].ToString();
                IReceipt.CreatedBy = dr["CreatedBy"].ToInt();
                IReceipt.CreatedDisplayName = dr["DisplayName"].ToString();
                IReceipts.Add(IReceipt);
            }

            return IReceipts.FirstOrDefault();
        }
       
        protected override void SaveCommand(IReceipt anyType)
        {
            throw new NotImplementedException();
        }

        protected override IReceipt SaveWithReturnCommand(IReceipt anyType)
        {
            cmd.CommandText = "SaveManorathReceipt";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Nek", anyType.Nek);
            cmd.Parameters.AddWithValue("@ManorathId", anyType.ManorathId);
            cmd.Parameters.AddWithValue("@ManorathType", anyType.ManorathType);
            cmd.Parameters.AddWithValue("@TrasactionType", anyType.TrasactionType);
            cmd.Parameters.AddWithValue("@VaishnavId", anyType.VaishnavId);
            cmd.Parameters.AddWithValue("@ManorathiName", anyType.ManorathiName);
            cmd.Parameters.AddWithValue("@Email", anyType.Email);
            cmd.Parameters.AddWithValue("@MobileNo", anyType.MobileNo);
            cmd.Parameters.AddWithValue("@ManorathDate", anyType.ManorathDate);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            cmd.Parameters.AddWithValue("@ChequeBank", anyType.ChequeBank);
            cmd.Parameters.AddWithValue("@ChequeBranch", anyType.ChequeBranch);
            cmd.Parameters.AddWithValue("@ChequeNumber", anyType.ChequeNumber);
            cmd.Parameters.AddWithValue("@ChequeDate", anyType.ChequeDate);
            cmd.Parameters.AddWithValue("@ChequeStatus", anyType.ChequeStatus);

            cmd.Parameters.AddWithValue("@ManorathTithi", anyType.ManorathTithi);
            cmd.Parameters.AddWithValue("@ManorathTithiMaas", anyType.ManorathTithiMaas);
            cmd.Parameters.AddWithValue("@ManorathTithiPaksh", anyType.ManorathTithiPaksh);
            cmd.Parameters.AddWithValue("@Description", anyType.Description);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IReceipt> IReceipts = new List<IReceipt>();
            while (dr.Read())
            {
                IReceipt IReceipt = Factory<IReceipt>.Create("Receipt");
                IReceipt.Id = dr["Id"].ToInt();
                IReceipt.ManorathType = dr["ManorathType"].ToInt();

                IReceipts.Add(IReceipt);
            }

            return IReceipts.FirstOrDefault();
        }

        protected override List<IReceipt> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IReceipt> SearchCommand<T>(T anyObject)
        {
            IReceipt IReceiptRequest = anyObject as IReceipt;

            cmd.CommandText = "GetManorathReceipts";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MandirId", IReceiptRequest.MandirId);
            cmd.Parameters.AddWithValue("@PageNumber", IReceiptRequest.PageNumber);
            cmd.Parameters.AddWithValue("@PageSize", IReceiptRequest.PageSize);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IReceipt> IReceipts = new List<IReceipt>();
            while (dr.Read())
            {
                IReceipt IReceipt = Factory<IReceipt>.Create("Receipt");
                IReceipt.Id = dr["Id"].ToInt();
                IReceipt.ReceiptNo = dr["ReceiptNo"].ToString();
                IReceipt.Nek = dr["Nek"].ToDecimal();
                IReceipt.ManorathType = dr["ManorathType"].ToInt();
                IReceipt.ManorathiName = dr["ManorathiName"].ToString();
                IReceipt.ManorathName = dr["ManorathName"].ToString();

                if (dr["ManorathDate"].IsNotNull() && dr["ManorathDate"].IsDate())
                {
                    IReceipt.ManorathDate = dr["ManorathDate"].ToString().ToDateTime("MM/dd/yyyy hh:mm:ss tt");
                }
                IReceipt.CreatedBy = dr["CreatedBy"].ToInt();
                IReceipt.CreatedDisplayName = dr["DisplayName"].ToString();
               
                IReceipt.Total = dr["total"].ToInt();
                IReceipt.Page = dr["page"].ToInt();
                IReceipt.Records = dr["records"].ToInt();
                IReceipts.Add(IReceipt);
            }

            return IReceipts;
        }

        protected override List<IReceipt> GetReportCommand<T>(T anyObject)
        {
            IReceipt IReceiptRequest = anyObject as IReceipt;

            cmd.CommandText = "GetManorathReceiptReport";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@MandirId", IReceiptRequest.MandirId);
            cmd.Parameters.AddWithValue("@FromDate", IReceiptRequest.FromDate);
            cmd.Parameters.AddWithValue("@ToDate", IReceiptRequest.ToDate);
            cmd.Parameters.AddWithValue("@ManorathFromDate", IReceiptRequest.ManorathFromDate);
            cmd.Parameters.AddWithValue("@ManorathToDate", IReceiptRequest.ManorathToDate);
            cmd.Parameters.AddWithValue("@AccountId", IReceiptRequest.AccountId);
            cmd.Parameters.AddWithValue("@OnlyManorath", IReceiptRequest.OnlyManorath);
            cmd.Parameters.AddWithValue("@UserId", IReceiptRequest.CreatedBy);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IReceipt> IReceipts = new List<IReceipt>();
            while (dr.Read())
            {
                IReceipt IReceipt = Factory<IReceipt>.Create("Receipt");
                IReceipt.Id = dr["Id"].ToInt();
                IReceipt.ManorathType = dr["ManorathType"].ToInt();

                if (dr["ManorathDate"].IsNotNull() && dr["ManorathDate"].IsDate())
                {
                    IReceipt.ManorathDate = dr["ManorathDate"].ToString().ToDateTime("MM/dd/yyyy hh:mm:ss tt");
                }

                IReceipt.ReceiptNo = dr["ReceiptNo"].ToString();
                IReceipt.ManorathId = dr["ManorathAccountId"].ToInt();
                IReceipt.ManorathName = dr["ManorathName"].ToString();
                IReceipt.Nek = dr["Nek"].ToDecimal();
                IReceipt.VaishnavId = dr["VaishnavId"].ToInt();
                IReceipt.ManorathiName = dr["ManorathiName"].ToString();
                IReceipt.Email = dr["Email"].ToString();
                IReceipt.MobileNo = dr["MobileNo"].ToString();
                IReceipt.CreatedBy = dr["CreatedBy"].ToInt();
                IReceipt.CreatedDisplayName = dr["DisplayName"].ToString();
                IReceipts.Add(IReceipt);
            }

            return IReceipts;
        }

        protected override void UpdateCommand(IReceipt anyType)
        {
            throw new NotImplementedException();
        }
    }
}
