using System;
namespace dogfunctions
{
    public static class Keys
    {
        public static class MobileCenter
        {
            /// <summary>
            /// The Url of your iOS App in Mobile Center - usually something like:
            /// https://api.mobile.azure.com/v0.1/apps/{username}/{appname}
            /// </summary>
            public static string iOSUrl = "https://api.mobile.azure.com/v0.1/apps/{username}/{appnameios}";

            /// <summary>
            /// The Url of your Android App in Mobile Center - usually something like:
            /// https://api.mobile.azure.com/v0.1/apps/{username}/{appname}
            /// </summary>
            public static string AndroidUrl = "https://api.mobile.azure.com/v0.1/apps/{username}/{appnamedroid}";

            /// <summary>
            /// Mobile Center API Auth Key
            /// </summary>
            public static string AuthKey = "";
        }

        public static class CosmosDB
        {
            /// <summary>
            /// Your CosmosDB Endpoint - fond in the Azure portal
            /// </summary>
            public static string Endpoint = "https://adoptadog.documents.azure.com:443";

            /// <summary>
            /// Your CosmosDB AuthKey - found in the Azure portal
            /// </summary>
            public static string AuthKey = "B2xooPZ58F7JjOsRd4DDqrp3tHxqmYj1XOp5Y2QUoVmt5Gl34nEkgosQeJRVHoQsGz9kPnqRNPeVwfnW2a8Sqg==";

            /// <summary>
            /// The DatabaseId for the SQL CosmosDB Database
            /// </summary>
            public static string DatabaseId = "AdobterDB";

            /// <summary>
            /// The CollectionID within your Database
            /// </summary>
            public static string CollectionId = "Dogs";
        }

    }
}
