using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreeDwarkadhishMandir.Models
{
    public static class AppConfigurationKeys
    {
        public static string EncryptionKey { get { return "EncryptionKey"; } }

        public static string URLEncryptionKey { get { return "URLEncryptionKey"; } }

        public static string AccountHeadAgainstReceipt { get { return "AccountHeadAgainstReceipt"; } }

        public static string DefaultReceiptId { get { return "DefaultReceiptId"; } }
    }
}