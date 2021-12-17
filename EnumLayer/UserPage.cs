using System.ComponentModel;

namespace EnumLayer
{
    public class UserPage
    {
        public enum Module
        {
            [Description("Application")]
            Application,
            [Description("Configuration")]
            Configuration,
            [Description("Core Configuration")]
            CoreConfiguration,
            [Description("Home")]
            Home,
            [Description("Report")]
            Report,
            [Description("Transaction")]
            Transaction,
            [Description("Vaishnav")]
            Vaishnav
        }

        public enum SubModule
        {
            [Description("Account")]
            Account,
            [Description("Bhandar Samagri")]
            BhandarSamagri,
            [Description("Darshan Manorath")]
            DarshanManorath,
            [Description("Email Configuration")]
            EmailConfiguration,
            [Description("Receipt Configuration")]
            ReceiptConfiguration
        }

        public enum PageController
        {
            AccountGroup,
            AccountHead,
            AccountTransaction,
            ApplicationUser,
            Bhandar,
            BhandarCategory,
            BhandarGroup,
            Configuration,
            Darshan,
            Home,
            Mandir,
            MandirVoucher,
            Manorath,
            Padhramani,
            Receipt,
            Report,
            Samagri,
            SamagriTransaction,
            Store,
            Supplier,
            UnitConversion,
            UnitMeasurement,
            Vaishnav
        }

        public enum PageActionMethod
        {
            AccountGroup,
            AccountHead,
            AccountTransaction,
            Annexure,
            ApplicationUser,
            ApplicationUserList,
            BalanceSheet,
            Bhandar,
            BhandarCategory,
            BhandarGroup,
            BhandarTransaction,
            Complementary,
            Configuration,
            CreateAccountGroup,
            CreateAccountHead,
            CreateBhandar,
            CreateBhandarCategory,
            CreateBhandarGroup,
            CreateMandirVoucher,
            CreateManorath,
            CreateSamagri,
            CreateStore,
            Createsupplier,
            CreateUnitConversion,
            CreateUnitMeasurement,
            DarshanTime,
            Donation,
            General,
            IncomeExpenditure,
            Issue,
            IssueForSamagri,
            Mandir,
            MandirList,
            MandirVoucher,
            Manorath,
            ManorathReceipt,
            ManorathReceiptReport,
            Nek,
            Padhramani,
            PadhramaniRequest,
            Purchase,
            Receipt,
            ReceiptList,
            ReportList,
            Samagri,
            SamagriTransaction,
            Scrapped,
            SoldOut,
            Store,
            Supplier,
            UnitConversion,
            UnitMeasurement,
            Vaishnav,
            VaishnavJan
        }
    }
}
