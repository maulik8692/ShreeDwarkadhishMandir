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
    public class MandirVoucherDal : TemplateADO<IMandirVoucher>
    {
        public MandirVoucherDal(string _connectionString) : base(_connectionString)
        {
        }

        protected override void AddCommand(IMandirVoucher anyType)
        {
            throw new NotImplementedException();
        }

        protected override bool CheckDataCommand(IMandirVoucher anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IMandirVoucher> DropdownWithSearchCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override IMandirVoucher GetDetailCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override List<IMandirVoucher> GetReportCommand<T>(T anyObject)
        {
            throw new NotImplementedException();
        }

        protected override void SaveCommand(IMandirVoucher anyType)
        {
            cmd.CommandText = "SaveMandirVoucher";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@VoucherNo", anyType.VoucherNo);
            cmd.Parameters.AddWithValue("@VoucherDate", anyType.VoucherDate);
            cmd.Parameters.AddWithValue("@AccountId", anyType.AccountId);
            cmd.Parameters.AddWithValue("@VoucherAmount", anyType.VoucherAmount);
            cmd.Parameters.AddWithValue("@Description", anyType.Description);
            cmd.Parameters.AddWithValue("@CreatedBy", anyType.CreatedBy);
            cmd.Parameters.AddWithValue("@VoucherType", anyType.VoucherType);
            cmd.ExecuteNonQuery();
        }

        protected override IMandirVoucher SaveWithReturnCommand(IMandirVoucher anyType)
        {
            throw new NotImplementedException();
        }

        protected override List<IMandirVoucher> SearchCommand()
        {
            throw new NotImplementedException();
        }

        protected override List<IMandirVoucher> SearchCommand<T>(T anyObject)
        {
            IMandirVoucher supplierRequest = anyObject as IMandirVoucher;

            cmd.CommandText = "GetMandirVouchers";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@PageNumber", supplierRequest.PageNumber);
            cmd.Parameters.AddWithValue("@PageSize", supplierRequest.PageSize);

            SqlDataReader dr = null;
            dr = cmd.ExecuteReader();

            List<IMandirVoucher> suppliers = new List<IMandirVoucher>();
            while (dr.Read())
            {
                IMandirVoucher MandirVoucherRequest = Factory<IMandirVoucher>.Create("MandirVoucher");
                MandirVoucherRequest.Id = dr["Id"].ToInt();
                MandirVoucherRequest.AccountName = dr["AccountName"].ToString();
                MandirVoucherRequest.VoucherAmount = dr["VoucherAmount"].ToDouble();
                MandirVoucherRequest.VoucherType = dr["VoucherType"].ToString();
                MandirVoucherRequest.DispalyAmount = "₹" + MandirVoucherRequest.VoucherAmount.ToString("0.00");
                MandirVoucherRequest.DisplayVoucherDate = dr["DisplayVoucherDate"].ToString();
                MandirVoucherRequest.VoucherNo = dr["VoucherNo"].ToInt();
                MandirVoucherRequest.Total = dr["total"].ToInt();
                MandirVoucherRequest.Page = dr["page"].ToInt();
                MandirVoucherRequest.Records = dr["records"].ToInt();
                suppliers.Add(MandirVoucherRequest);
            }

            return suppliers;
        }

        protected override void UpdateCommand(IMandirVoucher anyType)
        {
            throw new NotImplementedException();
        }
    }
}
