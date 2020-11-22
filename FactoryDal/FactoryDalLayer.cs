using AdoDotNetDal;
using FactoryDal.Properties;
using InterfaceDal;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Resolution;

namespace FactoryDal
{
    public class FactoryDalLayer<AnyType>
    {
        private static IUnityContainer ObjectsofOurProjects = null;
        public static AnyType Create(string type)
        {
            // Design pattern :- Lazy loading. Eager loading
            if (ObjectsofOurProjects == null)
            {
                ObjectsofOurProjects = new UnityContainer();

                ObjectsofOurProjects.RegisterType<IRepository<IDarshan>, DarshanDal>("Darshan");
                ObjectsofOurProjects.RegisterType<IRepository<ICountry>, CountryDal>("Country");
                ObjectsofOurProjects.RegisterType<IRepository<IState>, StateDal>("State");
                ObjectsofOurProjects.RegisterType<IRepository<ICity>, CityDal>("City");
                ObjectsofOurProjects.RegisterType<IRepository<IVillage>, VillageDal>("Village");

                ObjectsofOurProjects.RegisterType<IRepository<IMandir>, MandirDal>("Mandir");
                ObjectsofOurProjects.RegisterType<IRepository<IUserType>, UserTypeDal>("UserType");
                ObjectsofOurProjects.RegisterType<IRepository<IAppConfiguration>, AppConfigurationDal>("AppConfiguration");
                ObjectsofOurProjects.RegisterType<IRepository<ApplicationUserBase>, ApplicationUserDal>("ApplicationUser");
                ObjectsofOurProjects.RegisterType<IRepository<ApplicationUserBase>, AuthenticationUserDal>("AuthenticationUser");
                ObjectsofOurProjects.RegisterType<IRepository<IAccountHead>, AccountHeadDal>("AccountHead");
                ObjectsofOurProjects.RegisterType<IRepository<IAccountHeadDropdown>, AccountHeadDropdownDal>("AccountHeadDropdown");
                ObjectsofOurProjects.RegisterType<IRepository<IReceipt>, ReceiptDal>("Receipt");
                ObjectsofOurProjects.RegisterType<IRepository<IAccountTransaction>, AccountTransaction>("AccountTransaction");
                ObjectsofOurProjects.RegisterType<IRepository<IBhandarTransaction>, BhandarTransactionDal>("BhandarTransaction");
                ObjectsofOurProjects.RegisterType<IRepository<IVaishnav>, VaishnavDal>("Vaishnav");
                ObjectsofOurProjects.RegisterType<IRepository<IOccupation>, OccupationDal>("Occupation");
                ObjectsofOurProjects.RegisterType<IRepository<IPadhramaniRequest>, PadhramaniRequestDal>("PadhramaniRequest");
                ObjectsofOurProjects.RegisterType<IRepository<IEmailConfiguration>, EmailConfigurationDal>("EmailConfiguration");
                ObjectsofOurProjects.RegisterType<IRepository<IServiceStatus>, ServiceStatusDal>("ServiceStatus");

                ObjectsofOurProjects.RegisterType<IRepository<IBhandar>, BhandarDal>("Bhandar");
                ObjectsofOurProjects.RegisterType<IRepository<ISupplier>, SupplierDal>("Supplier");
                ObjectsofOurProjects.RegisterType<IRepository<IBhandarCategory>, BhandarCategoryDal>("BhandarCategory");
                ObjectsofOurProjects.RegisterType<IRepository<IUnitOfMeasurement>, UnitOfMeasurementDal>("UnitOfMeasurement");

                ObjectsofOurProjects.RegisterType<IRepository<ICommunication>, CommunicationDal>("Communication");
                ObjectsofOurProjects.RegisterType<IRepository<ISamagriMaster>, SamagriMasterDal>("Samagri");
                ObjectsofOurProjects.RegisterType<IRepository<ISamagriBhandarDetail>, SamagriBhandarDal>("SamagriBhandar");
                ObjectsofOurProjects.RegisterType<IRepository<IEmailLog>, EmailLogDal>("EmailLog");
                ObjectsofOurProjects.RegisterType<IRepository<IDashboard>, DashboardDal>("Dashboard");
                ObjectsofOurProjects.RegisterType<IRepository<IDefaultGroups>, DefaultGroupsDal>("DefaultGroups");
                ObjectsofOurProjects.RegisterType<IRepository<IAccountGroup>, AccountGroupDal>("AccountGroup");
                ObjectsofOurProjects.RegisterType<IRepository<IManorath>, ManorathDal>("Manorath");

                ObjectsofOurProjects.RegisterType<IRepository<IBalanceSheet>, BalanceSheetDal>("BalanceSheet");
                ObjectsofOurProjects.RegisterType<IRepository<IIncomeAndExpenditure>, IncomeExpenditureDal>("IncomeAndExpenditure");
                ObjectsofOurProjects.RegisterType<IRepository<IAnnexure>, AnnexureDal>("Annexure");
                ObjectsofOurProjects.RegisterType<IRepository<IMandirVoucher>, MandirVoucherDal>("MandirVoucher");
            }

            // Design Pattern : RIP. Replace If with Polymorephism
            return ObjectsofOurProjects.Resolve<AnyType>(type,
                new ResolverOverride[] {
                    new ParameterOverride("_connectionString",
                    @"Data Source=localhost;Initial Catalog=KrishnadasAdhikari;Integrated Security=True")
                });
        }
    }
}
