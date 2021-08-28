using InterfaceMiddleLayer;
using MiddleLayer;
using Unity;
using Unity.Injection;
using ValidationAlgorithms;

namespace FactoryMiddleLayer
{
    public class Factory<AnyType> // Design Pattern : Simple Factory Pattern
    {
        private static IUnityContainer ObjectsofOurProjects = null;
        public static AnyType Create(string Type)
        {
            // Design pattern :- Lazy loading. Eager loading
            if (ObjectsofOurProjects == null)
            {
                ObjectsofOurProjects = new UnityContainer();
                ObjectsofOurProjects.RegisterType<ApplicationUserBase, VallabhKul>
                    ("Vallabh", new InjectionConstructor(new ValidationSimpleUser()));
                ObjectsofOurProjects.RegisterType<ApplicationUserBase, SystemAdministrator>
                    ("System Admin", new InjectionConstructor(new ValidationUserAll()));
                ObjectsofOurProjects.RegisterType<ApplicationUserBase, Adhikari>
                    ("Adhikariji", new InjectionConstructor(new ValidationUserAll()));
                ObjectsofOurProjects.RegisterType<ApplicationUserBase, Mukhyaji>
                    ("Mukhyaji", new InjectionConstructor(new ValidationUserAll()));
                ObjectsofOurProjects.RegisterType<ApplicationUserBase, Samadhaniji>
                    ("Samadhani", new InjectionConstructor(new ValidationUserAll()));
                ObjectsofOurProjects.RegisterType<ApplicationUserBase, Bhandari>
                    ("Bhandari", new InjectionConstructor(new ValidationUserAll()));
                ObjectsofOurProjects.RegisterType<ApplicationUserBase, AuthenticationUser>
                    ("AuthenticationUser", new InjectionConstructor(new ValidationAuthentication()));

                ObjectsofOurProjects.RegisterType<IAccountHead, AccountHead>
                    ("AccountHead", new InjectionConstructor(new ValidationAccountHead()));
                //ObjectsofOurProjects.RegisterType<AccountHead, FixedDeposit>
                //    ("FixedDeposit", new InjectionConstructor(new ValidationFixedDeposit()));
                //ObjectsofOurProjects.RegisterType<AccountHead, BhetHead>
                //    ("BhetHead", new InjectionConstructor(new ValidationBhet()));
                //ObjectsofOurProjects.RegisterType<AccountHead, ManorathHead>
                //   ("ManorathHead", new InjectionConstructor(new ValidationManorath()));
                //ObjectsofOurProjects.RegisterType<AccountHead, DarshanHead>
                //  ("DarshanHead", new InjectionConstructor(new ValidationDarshanHead()));
                //ObjectsofOurProjects.RegisterType<AccountHead, GeneralAccount>
                //  ("GeneralAccount", new InjectionConstructor(new ValidationBhet()));
                //ObjectsofOurProjects.RegisterType<AccountHead, SupplierHead>
                // ("SupplierHead", new InjectionConstructor(new ValidationSupplierHead()));

                ObjectsofOurProjects.RegisterType<IReceipt, Receipt>
                    ("Receipt", new InjectionConstructor(new ValidationReceipt()));
                //ObjectsofOurProjects.RegisterType<ReceiptBase, ManorathReceipt>
                //    ("ManorathReceipt", new InjectionConstructor(new ValidationManorathReceipt()));
                //ObjectsofOurProjects.RegisterType<ReceiptBase, DarshanReceipt>
                //   ("DarshanReceipt", new InjectionConstructor(new ValidationManorathReceipt()));

                ObjectsofOurProjects.RegisterType<IBhandarGroup, BhandarGroup>
                  ("BhandarGroup", new InjectionConstructor(new ValidationBhandarGroup()));

                ObjectsofOurProjects.RegisterType<IBhandar, Bhandar>
                  ("Bhandar", new InjectionConstructor(new ValidationBhandar()));

                ObjectsofOurProjects.RegisterType<IBhandarTransaction, BhandarTransaction>
                  ("BhandarTransaction", new InjectionConstructor(new ValidationBhandarTransaction()));

                ObjectsofOurProjects.RegisterType<ISamagri, Samagri>
                ("Samagri", new InjectionConstructor(new ValidationSamagri()));

                ObjectsofOurProjects.RegisterType<ISamagriDetail, SamagriDetail>
                ("SamagriDetail", new InjectionConstructor(new ValidationSamagriDetail()));

                ObjectsofOurProjects.RegisterType<IDarshan, Darshan>
                    ("Darshan", new InjectionConstructor(new ValidationDarshan()));

                ObjectsofOurProjects.RegisterType<IMandir, Mandir>
                    ("Mandir", new InjectionConstructor(new ValidationMandir()));
                ObjectsofOurProjects.RegisterType<IAccountTransaction, AccountTransaction>
                   ("AccountTransaction", new InjectionConstructor(new ValidationAccountTransaction()));

                ObjectsofOurProjects.RegisterType<IVaishnav, Vaishnav>
                   ("Vaishnav", new InjectionConstructor(new ValidationVaishnav()));

                ObjectsofOurProjects.RegisterType<IPadhramaniRequest, PadhramaniRequest>
                   ("PadhramaniRequest", new InjectionConstructor(new ValidationPadhramaniRequest()));

                ObjectsofOurProjects.RegisterType<IEmailConfiguration, EmailConfiguration>
                 ("EmailConfiguration", new InjectionConstructor(new ValidationEmailConfiguration()));

                ObjectsofOurProjects.RegisterType<ISupplier, Supplier>
                ("Supplier", new InjectionConstructor(new ValidationSupplier()));

                ObjectsofOurProjects.RegisterType<IUnitOfMeasurement, UnitOfMeasurement>
                ("UnitOfMeasurement", new InjectionConstructor(new ValidationUnitOfMeasurement()));

                ObjectsofOurProjects.RegisterType<IBhandarCategory, BhandarCategory>
                ("BhandarCategory", new InjectionConstructor(new ValidationBhandarCategory()));

                ObjectsofOurProjects.RegisterType<ICommunication, Communication>
                ("Communication", new InjectionConstructor(new ValidationCommunication()));

                ObjectsofOurProjects.RegisterType<IAccountGroup, AccountGroup>
                ("AccountGroup", new InjectionConstructor(new ValidationAccountGroup()));

                ObjectsofOurProjects.RegisterType<IManorath, Manorath>
                ("Manorath", new InjectionConstructor(new ValidationManorath()));


                ObjectsofOurProjects.RegisterType<IMandirVoucher, MandirVoucher>
                ("MandirVoucher", new InjectionConstructor(new ValidationMandirVouchers()));

                ObjectsofOurProjects.RegisterType<IAccountHeadDropdown, AccountHeadDropdown>
                  ("AccountHeadDropdown");

                ObjectsofOurProjects.RegisterType<IDefaultGroups, DefaultGroups>
                   ("DefaultGroups");

                ObjectsofOurProjects.RegisterType<ICountry, Country>
                    ("Country");
                ObjectsofOurProjects.RegisterType<IState, State>
                    ("State");
                ObjectsofOurProjects.RegisterType<ICity, City>
                    ("City");
                ObjectsofOurProjects.RegisterType<IVillage, Village>
                   ("Village");
                ObjectsofOurProjects.RegisterType<IOccupation, Occupation>
                   ("Occupation");
                ObjectsofOurProjects.RegisterType<IUserType, UserType>
                    ("UserType");
                ObjectsofOurProjects.RegisterType<IDashboard, Dashboard>
                    ("Dashboard");

                ObjectsofOurProjects.RegisterType<IAppConfiguration, AppConfiguration>
                    ("AppConfiguration");
                ObjectsofOurProjects.RegisterType<IServiceStatus, ServiceStatus>
                  ("ServiceStatus");
                ObjectsofOurProjects.RegisterType<IEmailLog, EmailLog>
                  ("EmailLog");


                ObjectsofOurProjects.RegisterType<IBalanceSheet, BalanceSheet>("BalanceSheet");
                ObjectsofOurProjects.RegisterType<IIncomeAndExpenditure, IncomeAndExpenditure>("IncomeAndExpenditure");
                ObjectsofOurProjects.RegisterType<IAnnexure, Annexure>("Annexure");
            }

            //Design pattern :-  RIP Replace If with Poly
            return ObjectsofOurProjects.Resolve<AnyType>(Type);
        }
    }
}