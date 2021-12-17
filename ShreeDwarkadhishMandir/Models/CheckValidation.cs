using CommonLayer;
using EnumLayer;
using FactoryDal;
using FactoryMiddleLayer;
using InterfaceDal;
using InterfaceMiddleLayer;
using System.Linq;
using static EnumLayer.UserPage;

namespace ShreeDwarkadhishMandir.Models
{
    public static class CheckValidation
    {
        public static IPageModule IsAuthenticated(Module Module, SubModule? SubModule, PageController Controller, PageActionMethod Method)
        {
            IPageModule request = Factory<IPageModule>.Create("PageModule");
            request.Module = Enumerations.GetEnumDescription(Module);
            request.SubModule = SubModule.IsNull() ? string.Empty : Enumerations.GetEnumDescription(SubModule);
            request.Controller = Controller.ToString();
            request.ActionMenthod = Method.ToString();
            request.UserId = Function.ReadCookie(CookiesKey.AuthenticatedId).ToInt();

            IRepository<IPageModule> dbRequest = FactoryDalLayer<IRepository<IPageModule>>.Create("PageModule");

            return dbRequest.Search(request).FirstOrDefault();
        }

        #region Home
        public static IPageModule Home()
        {
            return IsAuthenticated(Module.Home, null, PageController.Home, PageActionMethod.General);
        }

        public static bool IsAllowedHome()
        {
            IPageModule result = Home();

            return result != null && result.IsAllowed;
        }
        #endregion Home

        #region Vaishnav
        public static IPageModule Vaishnav()
        {
            return IsAuthenticated(Module.Vaishnav, null, PageController.Vaishnav, PageActionMethod.Vaishnav);
        }
        public static IPageModule VaishnavJan()
        {
            return IsAuthenticated(Module.Vaishnav, null, PageController.Vaishnav, PageActionMethod.VaishnavJan);
        }
        public static IPageModule Padhramani()
        {
            return IsAuthenticated(Module.Vaishnav, null, PageController.Padhramani, PageActionMethod.Padhramani);
        }
        public static IPageModule PadhramaniRequest()
        {
            return IsAuthenticated(Module.Vaishnav, null, PageController.Padhramani, PageActionMethod.PadhramaniRequest);
        }

        public static bool IsAllowedVaishnav()
        {
            IPageModule result = Vaishnav();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedVaishnavJan()
        {
            IPageModule result = VaishnavJan();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedPadhramani()
        {
            IPageModule result = Padhramani();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedPadhramaniRequest()
        {
            IPageModule result = PadhramaniRequest();
            return result != null && result.IsAllowed;
        }
        #endregion Vaishnav

        #region Application
        public static IPageModule ApplicationUser()
        {
            return IsAuthenticated(Module.Application, null, PageController.ApplicationUser, PageActionMethod.ApplicationUser);
        }
        public static IPageModule ApplicationUserList()
        {
            return IsAuthenticated(Module.Application, null, PageController.ApplicationUser, PageActionMethod.ApplicationUserList);
        }

        public static bool IsAllowedApplicationUser()
        {
            IPageModule result = ApplicationUser();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedApplicationUserList()
        {
            IPageModule result = ApplicationUserList();
            return result != null && result.IsAllowed;
        }
        #endregion Application

        #region CoreConfiguration
        public static IPageModule Mandir()
        {
            return IsAuthenticated(Module.CoreConfiguration, null, PageController.Mandir, PageActionMethod.Mandir);
        }
        public static IPageModule MandirList()
        {
            return IsAuthenticated(Module.CoreConfiguration, null, PageController.Mandir, PageActionMethod.MandirList);
        }
        public static IPageModule EmailConfiguration()
        {
            return IsAuthenticated(Module.CoreConfiguration, SubModule.EmailConfiguration, PageController.Configuration, PageActionMethod.Configuration);
        }

        public static bool IsAllowedMandir()
        {
            IPageModule result = Mandir();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedMandirList()
        {
            IPageModule result = MandirList();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedEmailConfiguration()
        {
            IPageModule result = EmailConfiguration();
            return result != null && result.IsAllowed;
        }
        #endregion CoreConfiguration

        #region Configuration
        public static IPageModule Configuration()
        {
            return IsAuthenticated(Module.Configuration, null, PageController.Configuration, PageActionMethod.Configuration);
        }
        public static IPageModule ReceiptConfiguration()
        {
            return IsAuthenticated(Module.Configuration, SubModule.ReceiptConfiguration, PageController.Configuration, PageActionMethod.Configuration);
        }

        public static bool IsAllowedConfiguration()
        {
            IPageModule result = Configuration();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedReceiptConfiguration()
        {
            IPageModule result = ReceiptConfiguration();
            return result != null && result.IsAllowed;
        }
        #endregion Configuration

        #region DarshanManorath
        public static IPageModule DarshanTime()
        {
            return IsAuthenticated(Module.Configuration, SubModule.DarshanManorath, PageController.Darshan, PageActionMethod.DarshanTime);
        }
        public static IPageModule Manorath()
        {
            return IsAuthenticated(Module.Configuration, SubModule.DarshanManorath, PageController.Manorath, PageActionMethod.Manorath);
        }
        public static IPageModule CreateManorath()
        {
            return IsAuthenticated(Module.Configuration, SubModule.DarshanManorath, PageController.Manorath, PageActionMethod.CreateManorath);
        }

        public static bool IsAllowedDarshanTime()
        {
            IPageModule result = DarshanTime();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedManorath()
        {
            IPageModule result = Manorath();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedCreateManorath()
        {
            IPageModule result = CreateManorath();
            return result != null && result.IsAllowed;
        }
        #endregion DarshanManorath

        #region Bhandar
        public static IPageModule Bhandar()
        {
            return IsAuthenticated(Module.Configuration, SubModule.BhandarSamagri, PageController.Bhandar, PageActionMethod.Bhandar);
        }
        public static IPageModule CreateBhandar()
        {
            return IsAuthenticated(Module.Configuration, SubModule.BhandarSamagri, PageController.Bhandar, PageActionMethod.CreateBhandar);
        }

        public static bool IsAllowedBhandar()
        {
            IPageModule result = Bhandar();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedCreateBhandar()
        {
            IPageModule result = CreateBhandar();
            return result != null && result.IsAllowed;
        }
        #endregion Bhandar

        #region Samagri
        public static IPageModule Samagri()
        {
            return IsAuthenticated(Module.Configuration, SubModule.BhandarSamagri, PageController.Samagri, PageActionMethod.Samagri);
        }
        public static IPageModule CreateSamagri()
        {
            return IsAuthenticated(Module.Configuration, SubModule.BhandarSamagri, PageController.Samagri, PageActionMethod.CreateSamagri);
        }

        public static bool IsAllowedSamagri()
        {
            IPageModule result = Samagri();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedCreateSamagri()
        {
            IPageModule result = CreateSamagri();
            return result != null && result.IsAllowed;
        }
        #endregion Samagri

        #region Store
        public static IPageModule Store()
        {
            return IsAuthenticated(Module.Configuration, SubModule.BhandarSamagri, PageController.Store, PageActionMethod.Store);
        }
        public static IPageModule CreateStore()
        {
            return IsAuthenticated(Module.Configuration, SubModule.BhandarSamagri, PageController.Store, PageActionMethod.CreateStore);
        }
        public static bool IsAllowedStore()
        {
            IPageModule result = Store();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedCreateStore()
        {
            IPageModule result = CreateStore();
            return result != null && result.IsAllowed;
        }
        #endregion Store

        #region BhandarCategory
        public static IPageModule BhandarCategory()
        {
            return IsAuthenticated(Module.Configuration, SubModule.BhandarSamagri, PageController.BhandarCategory, PageActionMethod.BhandarCategory);
        }
        public static IPageModule CreateBhandarCategory()
        {
            return IsAuthenticated(Module.Configuration, SubModule.BhandarSamagri, PageController.BhandarCategory, PageActionMethod.CreateBhandarCategory);
        }
        public static bool IsAllowedBhandarCategory()
        {
            IPageModule result = BhandarCategory();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedCreateBhandarCategory()
        {
            IPageModule result = CreateBhandarCategory();
            return result != null && result.IsAllowed;
        }
        #endregion BhandarCategory

        #region BhandarGroup
        public static IPageModule BhandarGroup()
        {
            return IsAuthenticated(Module.Configuration, SubModule.BhandarSamagri, PageController.BhandarGroup, PageActionMethod.BhandarGroup);
        }
        public static IPageModule CreateBhandarGroup()
        {
            return IsAuthenticated(Module.Configuration, SubModule.BhandarSamagri, PageController.BhandarGroup, PageActionMethod.CreateBhandarGroup);
        }
        public static bool IsAllowedBhandarGroup()
        {
            IPageModule result = BhandarGroup();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedCreateBhandarGroup()
        {
            IPageModule result = CreateBhandarGroup();
            return result != null && result.IsAllowed;
        }
        #endregion BhandarGroup

        #region UnitMeasurement
        public static IPageModule UnitMeasurement()
        {
            return IsAuthenticated(Module.Configuration, SubModule.BhandarSamagri, PageController.UnitMeasurement, PageActionMethod.UnitMeasurement);
        }
        public static IPageModule CreateUnitMeasurement()
        {
            return IsAuthenticated(Module.Configuration, SubModule.BhandarSamagri, PageController.UnitMeasurement, PageActionMethod.CreateUnitMeasurement);
        }
        public static bool IsAllowedUnitMeasurement()
        {
            IPageModule result = UnitMeasurement();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedCreateUnitMeasurement()
        {
            IPageModule result = CreateUnitMeasurement();
            return result != null && result.IsAllowed;
        }
        #endregion UnitMeasurement

        #region UnitConversion
        public static IPageModule UnitConversion()
        {
            return IsAuthenticated(Module.Configuration, SubModule.BhandarSamagri, PageController.UnitConversion, PageActionMethod.UnitConversion);
        }
        public static IPageModule CreateUnitConversion()
        {
            return IsAuthenticated(Module.Configuration, SubModule.BhandarSamagri, PageController.UnitConversion, PageActionMethod.CreateUnitConversion);
        }
        public static bool IsAllowedUnitConversion()
        {
            IPageModule result = UnitConversion();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedCreateUnitConversion()
        {
            IPageModule result = CreateUnitConversion();
            return result != null && result.IsAllowed;
        }
        #endregion

        #region Supplier
        public static IPageModule Supplier()
        {
            return IsAuthenticated(Module.Configuration, SubModule.BhandarSamagri, PageController.Supplier, PageActionMethod.Supplier);
        }
        public static IPageModule Createsupplier()
        {
            return IsAuthenticated(Module.Configuration, SubModule.BhandarSamagri, PageController.Supplier, PageActionMethod.Createsupplier);
        }
        public static bool IsAllowedSupplier()
        {
            IPageModule result = Supplier();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedCreatesupplier()
        {
            IPageModule result = Createsupplier();
            return result != null && result.IsAllowed;
        }
        #endregion Supplier

        #region AccountHead & AccountGroup
        public static IPageModule AccountHead()
        {
            return IsAuthenticated(Module.Configuration, SubModule.Account, PageController.AccountHead, PageActionMethod.AccountHead);
        }
        public static IPageModule CreateAccountHead()
        {
            return IsAuthenticated(Module.Configuration, SubModule.Account, PageController.AccountHead, PageActionMethod.CreateAccountHead);
        }
        public static IPageModule AccountGroup()
        {
            return IsAuthenticated(Module.Configuration, SubModule.Account, PageController.AccountGroup, PageActionMethod.AccountGroup);
        }
        public static IPageModule CreateAccountGroup()
        {
            return IsAuthenticated(Module.Configuration, SubModule.Account, PageController.AccountGroup, PageActionMethod.CreateAccountGroup);
        }
        public static bool IsAllowedAccountHead()
        {
            IPageModule result = AccountHead();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedCreateAccountHead()
        {
            IPageModule result = CreateAccountHead();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedAccountGroup()
        {
            IPageModule result = AccountGroup();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedCreateAccountGroup()
        {
            IPageModule result = CreateAccountGroup();
            return result != null && result.IsAllowed;
        }
        #endregion AccountHead & AccountGroup

        #region Report
        public static IPageModule ReportList()
        {
            return IsAuthenticated(Module.Report, null, PageController.Report, PageActionMethod.ReportList);
        }
        public static IPageModule BalanceSheet()
        {
            return IsAuthenticated(Module.Report, SubModule.Account, PageController.Report, PageActionMethod.BalanceSheet);
        }
        public static IPageModule IncomeExpenditure()
        {
            return IsAuthenticated(Module.Report, SubModule.Account, PageController.Report, PageActionMethod.IncomeExpenditure);
        }
        public static IPageModule Annexure()
        {
            return IsAuthenticated(Module.Report, SubModule.Account, PageController.Report, PageActionMethod.Annexure);
        }
        public static IPageModule ManorathReceipt()
        {
            return IsAuthenticated(Module.Report, SubModule.Account, PageController.Report, PageActionMethod.ManorathReceipt);
        }
        public static IPageModule ManorathReceiptReport()
        {
            return IsAuthenticated(Module.Report, SubModule.Account, PageController.Report, PageActionMethod.ManorathReceiptReport);
        }
        public static IPageModule AccountTransactionReport()
        {
            return IsAuthenticated(Module.Report, SubModule.Account, PageController.Report, PageActionMethod.AccountTransaction);
        }
        public static IPageModule BhandarTransaction()
        {
            return IsAuthenticated(Module.Report, SubModule.BhandarSamagri, PageController.Report, PageActionMethod.BhandarTransaction);
        }

        public static bool IsAllowedReportList()
        {
            IPageModule result = ReportList();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedBalanceSheet()
        {
            IPageModule result = BalanceSheet();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedIncomeExpenditure()
        {
            IPageModule result = IncomeExpenditure();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedAnnexure()
        {
            IPageModule result = Annexure();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedManorathReceipt()
        {
            IPageModule result = ManorathReceipt();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedManorathReceiptReport()
        {
            IPageModule result = ManorathReceiptReport();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedAccountTransactionReport()
        {
            IPageModule result = AccountTransactionReport();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedBhandarTransaction()
        {
            IPageModule result = BhandarTransaction();
            return result != null && result.IsAllowed;
        }
        #endregion Report

        #region Account Transaction
        public static IPageModule MandirVoucher()
        {
            return IsAuthenticated(Module.Transaction, SubModule.Account, PageController.MandirVoucher, PageActionMethod.MandirVoucher);
        }
        public static IPageModule CreateMandirVoucher()
        {
            return IsAuthenticated(Module.Transaction, SubModule.Account, PageController.MandirVoucher, PageActionMethod.CreateMandirVoucher);
        }
        public static IPageModule AccountTransaction()
        {
            return IsAuthenticated(Module.Transaction, SubModule.Account, PageController.AccountTransaction, PageActionMethod.AccountTransaction);
        }
        public static IPageModule ReceiptList()
        {
            return IsAuthenticated(Module.Transaction, SubModule.Account, PageController.Receipt, PageActionMethod.ReceiptList);
        }
        public static IPageModule CreateReceipt()
        {
            return IsAuthenticated(Module.Transaction, SubModule.Account, PageController.Receipt, PageActionMethod.Receipt);
        }

        public static bool IsAllowedMandirVoucher()
        {
            IPageModule result = MandirVoucher();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedCreateMandirVoucher()
        {
            IPageModule result = CreateMandirVoucher();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedAccountTransaction()
        {
            IPageModule result = AccountTransaction();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedReceiptList()
        {
            IPageModule result = ReceiptList();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedCreateReceipt()
        {
            IPageModule result = CreateReceipt();
            return result != null && result.IsAllowed;
        }
        #endregion Account Transaction

        #region SamagriTransaction
        public static IPageModule SamagriTransaction()
        {
            return IsAuthenticated(Module.Transaction, SubModule.BhandarSamagri, PageController.SamagriTransaction, PageActionMethod.SamagriTransaction);
        }
        public static IPageModule IssueForSamagri()
        {
            return IsAuthenticated(Module.Transaction, SubModule.BhandarSamagri, PageController.SamagriTransaction, PageActionMethod.IssueForSamagri);
        }
        public static IPageModule Issue()
        {
            return IsAuthenticated(Module.Transaction, SubModule.BhandarSamagri, PageController.SamagriTransaction, PageActionMethod.Issue);
        }
        public static IPageModule SoldOut()
        {
            return IsAuthenticated(Module.Transaction, SubModule.BhandarSamagri, PageController.SamagriTransaction, PageActionMethod.SoldOut);
        }
        public static IPageModule Scrapped()
        {
            return IsAuthenticated(Module.Transaction, SubModule.BhandarSamagri, PageController.SamagriTransaction, PageActionMethod.Scrapped);
        }
        public static IPageModule Purchase()
        {
            return IsAuthenticated(Module.Transaction, SubModule.BhandarSamagri, PageController.SamagriTransaction, PageActionMethod.Purchase);
        }
        public static IPageModule Donation()
        {
            return IsAuthenticated(Module.Transaction, SubModule.BhandarSamagri, PageController.SamagriTransaction, PageActionMethod.Donation);
        }
        public static IPageModule Complementary()
        {
            return IsAuthenticated(Module.Transaction, SubModule.BhandarSamagri, PageController.SamagriTransaction, PageActionMethod.Complementary);
        }
        public static IPageModule Nek()
        {
            return IsAuthenticated(Module.Transaction, SubModule.BhandarSamagri, PageController.SamagriTransaction, PageActionMethod.Nek);
        }

        public static bool IsAllowedSamagriTransaction()
        {
            IPageModule result = SamagriTransaction();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedIssueForSamagri()
        {
            IPageModule result = IssueForSamagri();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedIssue()
        {
            IPageModule result = Issue();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedSoldOut()
        {
            IPageModule result = SoldOut();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedScrapped()
        {
            IPageModule result = Scrapped();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedPurchase()
        {
            IPageModule result = Purchase();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedDonation()
        {
            IPageModule result = Donation();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedComplementary()
        {
            IPageModule result = Complementary();
            return result != null && result.IsAllowed;
        }
        public static bool IsAllowedNek()
        {
            IPageModule result = Nek();
            return result != null && result.IsAllowed;
        }
        #endregion SamagriTransaction

    }
}