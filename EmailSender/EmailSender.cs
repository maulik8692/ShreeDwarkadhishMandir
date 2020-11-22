using CommonLayer;
using FactoryDal;
using FactoryMiddleLayer;
using InterfaceDal;
using InterfaceMiddleLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace EmailSender
{
    public partial class EmailSender : ServiceBase
    {
        string serviceName = "EmailSender";
        public EmailSender()
        {
            InitializeComponent();
            OnTimerElapsed(null,null);
        }

        protected override void OnStart(string[] args)
        {
            IServiceStatus serviceStatusRequest = Factory<IServiceStatus>.Create("ServiceStatus");
            IRepository<IServiceStatus> dal = FactoryDalLayer<IRepository<IServiceStatus>>.Create("ServiceStatus");

            serviceStatusRequest.ServiceName = this.serviceName;
            serviceStatusRequest.IsRunning = false;
            dal.Save(serviceStatusRequest);

            List<IServiceStatus> serviceStatus = dal.Search(serviceStatusRequest);
            if (serviceStatus.IsNotNull() && serviceStatus.Count > 0 && serviceStatus.FirstOrDefault().TimeInterval > 0)
            {
                Timer timer = new Timer();
                timer.Interval = serviceStatus.FirstOrDefault().TimeInterval;
                timer.Elapsed += OnTimerElapsed;
                timer.AutoReset = false;
                timer.Start();
            }
        }

        private void OnTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            IServiceStatus serviceStatusRequest = Factory<IServiceStatus>.Create("ServiceStatus");
            IRepository<IServiceStatus> dal = FactoryDalLayer<IRepository<IServiceStatus>>.Create("ServiceStatus");

            serviceStatusRequest.ServiceName = this.serviceName;
            serviceStatusRequest.IsRunning = false;
           
            List<IServiceStatus> serviceStatus = dal.Search(serviceStatusRequest);
            if (serviceStatus.IsNotNull() && serviceStatus.Count > 0 && serviceStatus.FirstOrDefault().IsRunning == false)
            {
                serviceStatusRequest.IsRunning = true;
                dal.Save(serviceStatusRequest);

                SendHtmlFormattedEmail();

                serviceStatusRequest.IsRunning = false;
                dal.Save(serviceStatusRequest);
            }
        }

        protected override void OnStop()
        {
            IServiceStatus serviceStatusRequest = Factory<IServiceStatus>.Create("ServiceStatus");
            IRepository<IServiceStatus> dal = FactoryDalLayer<IRepository<IServiceStatus>>.Create("ServiceStatus");

            serviceStatusRequest.ServiceName = this.serviceName;
            serviceStatusRequest.IsRunning = false;
            dal.Save(serviceStatusRequest);
        }

        private void SendHtmlFormattedEmail()
        {
            try
            {
                IRepository<IEmailConfiguration> dal = FactoryDalLayer<IRepository<IEmailConfiguration>>.Create("EmailConfiguration");
                List<IEmailConfiguration> emailConfigurations = dal.Search();

                if (emailConfigurations.IsNotNull() && emailConfigurations.Count > 0)
                {
                    IEmailConfiguration emailConfiguration = emailConfigurations.FirstOrDefault();

                    MailAddress fromAddress = new MailAddress(emailConfiguration.Username, emailConfiguration.DisplayName);
                    
                    string fromPassword = emailConfiguration.Password;
                   
                    IRepository<IEmailLog> email = FactoryDalLayer<IRepository<IEmailLog>>.Create("EmailLog");
                    List<IEmailLog> emailLogs = email.Search();

                    foreach (var emailLog in emailLogs.Where(x=>x.EmailId.IsEmail()))
                    {
                        try
                        {
                            var smtp = new SmtpClient
                            {
                                Host = emailConfiguration.Server,
                                Port = emailConfiguration.Port,
                                EnableSsl = emailConfiguration.SSL,
                                DeliveryMethod = SmtpDeliveryMethod.Network,
                                UseDefaultCredentials = false,
                                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                            };

                            MailAddress toAddress = new MailAddress(emailLog.EmailId, emailLog.DisplayName);
                            using (var message = new MailMessage(fromAddress, toAddress)
                            {
                                Subject = emailLog.EmailSubject,
                                Body = emailLog.EmailContent,
                                IsBodyHtml = true
                            })
                            {
                                smtp.Send(message);
                            }

                            emailLog.Status = "Success";
                            email.Save(emailLog);
                        }
                        catch (Exception ex)
                        {
                            emailLog.Status = "Failed";
                            email.Save(emailLog);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private string PopulateBody()
        {
            string body = string.Empty;
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Templates\EmailTemplate.html");

            using (StreamReader reader = new StreamReader(path))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{UserName}", "maulik");
            body = body.Replace("{Title}", "MR");
            body = body.Replace("{Url}", "https://google.com");
            body = body.Replace("{Description}", "description");
            return body;


        }

        protected bool SendEmailAttachments(string strSubject, string strEmailId, string emailContent, List<string> listFilePaths)
        {
            try
            {

                //ECubeConfiguration obj = new ECubeConfiguration();
                //DataTable dt = new DataTable();
                //string strSmtpServerIp = string.Empty, strFrom = string.Empty, strPassword = string.Empty, strBcc = string.Empty, strClub = string.Empty, replyTo = string.Empty, strCC = string.Empty;
                //int strSmtpPort = 0;
                //bool enableSsl = false;
                //dt = obj.GetEmailConfigurationByProfileName("eCube");
                //if (dt != null && dt.Rows.Count > 0)
                //{
                //    if (!string.IsNullOrEmpty(dt.Rows[0]["SMPTServer"].ToString()))
                //    {
                //        strSmtpServerIp = dt.Rows[0]["SMPTServer"].ToString();
                //    }

                //    if (!string.IsNullOrEmpty(dt.Rows[0]["Port"].ToString()))
                //    {
                //        strSmtpPort = Convert.ToInt32(dt.Rows[0]["Port"].ToString(), CultureInfo.CurrentCulture);
                //    }

                //    if (!string.IsNullOrEmpty(dt.Rows[0]["UserName"].ToString()))
                //    {
                //        strFrom = dt.Rows[0]["UserName"].ToString();
                //    }

                //    if (!string.IsNullOrEmpty(dt.Rows[0]["Password"].ToString()))
                //    {
                //        strPassword = dt.Rows[0]["Password"].ToString();
                //    }

                //    if (dt.Rows[0]["EnableSSL"] != null)
                //    {
                //        enableSsl = Convert.ToBoolean(dt.Rows[0]["EnableSSL"].ToString(), CultureInfo.CurrentCulture);
                //    }

                //    if (dt.Rows[0]["ReplierEmail"] != null)
                //    {
                //        replyTo = dt.Rows[0]["ReplierEmail"].ToString();
                //    }

                //    //strBcc = obj.GetAaaConfigByKeyName("eCubeAdminBccEmail");
                //    //strCC = obj.GetAaaConfigByKeyName("eCubeAdminCcEmail");
                //    //strClub = CubeCrmPropertyInfo();
                //    if (emailContent != string.Empty)
                //    {
                //        //emailContent = GetPropertyInfo(emailContent, "Email");
                //    }

                //    if (strSubject != string.Empty)
                //    {
                //        strSubject = string.Format(CultureInfo.CurrentCulture, "{0} | {1}", strSubject, strClub);
                //    }

                //    if (dt.Rows[0]["IsExchange"] != null && dt.Rows[0]["IsExchange"].ToString().ToLower() == "false")
                //    {
                //        MailMessage mailMsg = null;
                //        mailMsg = new MailMessage(new MailAddress(strFrom.Trim(), strClub), new MailAddress(strEmailId));

                //        mailMsg.BodyEncoding = Encoding.Default;
                //        mailMsg.Subject = strSubject.Trim();
                //        mailMsg.Body = emailContent;
                //        mailMsg.IsBodyHtml = true;
                //        if (!string.IsNullOrEmpty(strBcc))
                //        {
                //            foreach (string sBCC in strBcc.Split(",".ToCharArray()))
                //            {
                //                mailMsg.Bcc.Add(sBCC.Trim());
                //            }
                //        }

                //        if (!string.IsNullOrEmpty(strCC))
                //        {
                //            foreach (string sCC in strCC.Split(",".ToCharArray()))
                //            {
                //                mailMsg.CC.Add(sCC.Trim());
                //            }
                //        }

                //        if (replyTo != string.Empty)
                //        {
                //            mailMsg.ReplyToList.Add(new MailAddress(replyTo, "reply-to"));
                //        }

                //        //string strAdminEmail = obj.GetAaaConfigByKeyName("eCubeAdminEmail").ToString();
                //        if (strAdminEmail != string.Empty)
                //        {
                //            mailMsg.From = new MailAddress(strAdminEmail, strClub, System.Text.Encoding.UTF8);
                //        }
                //        else
                //        {
                //            mailMsg.From = new MailAddress(strFrom, strClub, System.Text.Encoding.UTF8);
                //        }

                //        var client = new SmtpClient(strSmtpServerIp, strSmtpPort)
                //        {
                //            Credentials = new NetworkCredential(strFrom, strPassword),
                //            EnableSsl = enableSsl
                //        };

                //        foreach (string sPath in listFilePaths)
                //        {
                //            if (File.Exists(sPath))
                //            {
                //                System.Net.Mail.Attachment att = new System.Net.Mail.Attachment(sPath);
                //                mailMsg.Attachments.Add(att);
                //            }
                //        }

                //        client.Send(mailMsg);
                //    }
                //    else
                //    {
                //        ExchangeService service = new ExchangeService(ExchangeVersion.Exchange2010_SP2);
                //        service.Credentials = new NetworkCredential(strFrom.Trim(), strPassword);
                //        service.AutodiscoverUrl(strFrom.Trim());

                //        EmailMessage message = new EmailMessage(service);
                //        message.Subject = strSubject.Trim();
                //        message.Body = new MessageBody();

                //        emailContent = emailContent.Contains("<body>") ? emailContent : "<body>" + emailContent + "</body>";
                //        emailContent = emailContent.Contains("<html>") ? emailContent : "<html><head><title></title></head>" + emailContent + "</html>";

                //        message.Body.Text = emailContent;
                //        message.Body.BodyType = BodyType.HTML;

                //        if (!string.IsNullOrEmpty(strEmailId))
                //        {
                //            message.ToRecipients.Add(new Microsoft.Exchange.WebServices.Data.EmailAddress(strEmailId));
                //        }

                //        if (!string.IsNullOrEmpty(replyTo))
                //        {
                //            message.ReplyTo.Add(new Microsoft.Exchange.WebServices.Data.EmailAddress(replyTo));
                //        }

                //        if (!string.IsNullOrEmpty(strCC))
                //        {
                //            foreach (string cc in strCC.Split(",".ToCharArray()))
                //            {
                //                message.CcRecipients.Add(new Microsoft.Exchange.WebServices.Data.EmailAddress(cc.Trim()));
                //            }
                //        }

                //        if (!string.IsNullOrEmpty(strBcc))
                //        {
                //            foreach (string bcc in strBcc.Split(",".ToCharArray()))
                //            {
                //                message.BccRecipients.Add(new Microsoft.Exchange.WebServices.Data.EmailAddress(bcc.Trim()));
                //            }
                //        }

                //        foreach (string path in listFilePaths)
                //        {
                //            if (File.Exists(path))
                //            {
                //                message.Attachments.AddFileAttachment(path);
                //            }
                //        }

                //        message.SendAndSaveCopy();
                //    }

                //    return true;
                //}
                //else
                //{
                //    return false;
                //}

                return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
