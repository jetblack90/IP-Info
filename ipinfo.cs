using static System.Console;
using static System.ConsoleColor;
using System.Net;
using Newtonsoft.Json;

namespace IP_Info
{
    class ipinfo
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0 || args[0] == "-h" || args[0] == "--help")
            {
                DisplayHelp();
                return;
            }

            string ipAddress = "";

            if (args[0] == "-myip" || args[0] == "--myip")
            {
                ipAddress = GetPublicIpAddress();
            }
            else
            {
                ipAddress = args[0];
            }

            try
            {
                string apiUrl = $"http://ip-api.com/json/{ipAddress}?fields=status,message,country,countryCode,region,regionName,city,zip,lat,lon,timezone,isp,org,as,asname,reverse,mobile,proxy,hosting,query";
                string jsonResult = GetJsonFromUrl(apiUrl);
                IpInfo ipInfo = JsonConvert.DeserializeObject<IpInfo>(jsonResult);

                if (ipInfo.status == "success")
                {
                    CursorVisible = false;
                    bool isColored = false;
                    Clear();
                    Logo();

                    for (int i = 0; i <= 100; i++)
                    {
                        Write($"\r\t\x1b[1;34mFetching... \x1b[1;32;42m{i}%\x1b[0m");
                        Thread.Sleep(10);
                    }
                    Thread.Sleep(50);

                    WriteLine($"\n\n\n\t\x1b[1;37mIP-address: \x1b[1;32m{ipInfo.query}");
                nowColor:
                    if (isColored == false)
                    {
                        ForegroundColor = Green;
                        WriteLine($"\n\tCountry: {ipInfo.country} ({ipInfo.countryCode})");
                        Thread.Sleep(100);
                        WriteLine($"\tRegion: {ipInfo.regionName} ({ipInfo.region})");
                        Thread.Sleep(100);
                        WriteLine($"\tCity: {ipInfo.city}");
                        Thread.Sleep(100);
                        WriteLine($"\tZIP Code: {ipInfo.zip}");
                        Thread.Sleep(100);
                        WriteLine($"\tLatitude & Longitude: {ipInfo.lat.ToString().Replace(',', '.')}, {ipInfo.lon.ToString().Replace(',', '.')}");

                        Thread.Sleep(100);
                        WriteLine($"\n\tTime Zone: {ipInfo.timezone}");
                        Thread.Sleep(100);
                        WriteLine($"\tISP: {ipInfo.isp}");
                        Thread.Sleep(100);
                        WriteLine($"\tOrganization: {ipInfo.org}");

                        Thread.Sleep(100);
                        WriteLine($"\n\tAS Number: {ipInfo.@as}");
                        Thread.Sleep(100);
                        WriteLine($"\tAS Name: {ipInfo.asname}");
                        Thread.Sleep(100);
                        WriteLine($"\tReverse DNS: {ipInfo.reverse}");

                        Thread.Sleep(100);
                        WriteLine($"\n\tMobile: {ipInfo.mobile}");
                        Thread.Sleep(100);
                        WriteLine($"\tProxy: {ipInfo.proxy}");
                        Thread.Sleep(100);
                        WriteLine($"\tHosting: {ipInfo.hosting}");
                        Thread.Sleep(100);
                        for (int i = 0 + 50; i <= 100; i++)
                        {
                            Write($"\r\tColorizing results... ( {i}% )");
                            Thread.Sleep(10);
                        }

                        isColored = true;
                        goto nowColor;
                    }
                    else if (isColored == true)
                    {
                        Clear();
                        Logo();

                        WriteLine($"\n\n\n\t\x1b[1;37mIP-address: \x1b[1;32m{ipInfo.query}");

                        Thread.Sleep(10);
                        WriteLine($"\n\t\x1b[1;36mCountry: \x1b[1;33m{ipInfo.country} ({ipInfo.countryCode})");
                        Thread.Sleep(10);
                        WriteLine($"\t\x1b[1;36mRegion: \x1b[1;33m{ipInfo.regionName} ({ipInfo.region})");
                        Thread.Sleep(10);
                        WriteLine($"\t\x1b[1;36mCity: \x1b[1;33m{ipInfo.city}");
                        Thread.Sleep(10);
                        WriteLine($"\t\x1b[1;36mZIP Code: \x1b[1;33m{ipInfo.zip}");
                        Thread.Sleep(10);
                        WriteLine($"\t\x1b[1;36mLatitude & Longitude: \x1b[1;33m{ipInfo.lat.ToString().Replace(',', '.')}\x1b[1;37m, \x1b[1;33m{ipInfo.lon.ToString().Replace(',', '.')}");

                        Thread.Sleep(10);
                        WriteLine($"\n\t\x1b[1;36mTime Zone: \x1b[1;33m{ipInfo.timezone}");
                        Thread.Sleep(10);
                        WriteLine($"\t\x1b[1;36mISP: \x1b[1;33m{ipInfo.isp}");
                        Thread.Sleep(10);
                        WriteLine($"\t\x1b[1;36mOrganization: \x1b[1;33m{ipInfo.org}");

                        Thread.Sleep(10);
                        WriteLine($"\n\t\x1b[1;36mAS Number: \x1b[1;33m{ipInfo.@as}");
                        Thread.Sleep(10);
                        WriteLine($"\t\x1b[1;36mAS Name: \x1b[1;33m{ipInfo.asname}");
                        Thread.Sleep(10);
                        WriteLine($"\t\x1b[1;36mReverse DNS: \x1b[1;33m{ipInfo.reverse}");

                        Thread.Sleep(10);
                        WriteLine($"\n\t\x1b[1;36mMobile: \x1b[1;33m{ipInfo.mobile}");
                        Thread.Sleep(10);
                        WriteLine($"\t\x1b[1;36mProxy: \x1b[1;33m{ipInfo.proxy}");
                        Thread.Sleep(10);
                        WriteLine($"\t\x1b[1;36mHosting: \x1b[1;33m{ipInfo.hosting}\x1b[0m\n\n");

                        CursorVisible = true;
                    }
                }
                else
                {
                    Thread.Sleep(100);
                    WriteLine($"\n\t\x1b[1;31mError: {ipInfo.message}\x1b[0m\n\n");
                }
            }
            catch (Exception ex)
            {
                Thread.Sleep(100);
                WriteLine($"\n\t\x1b[1;31mError: {ex.Message}\x1b[0m\n\n");
            }
        }

        private static string GetJsonFromUrl(string url)
        {
            using (WebClient client = new WebClient())
            {
                return client.DownloadString(url);
            }
        }

        private static string GetPublicIpAddress()
        {
            using (var client = new WebClient())
            {
                return client.DownloadString("https://api.ipify.org");
            }
        }

        private static void Logo()
        {
            Clear();
            WriteLine("\x1b[1;33m");
            Write(@"
        ██╗██████╗       ██╗███╗   ██╗███████╗ ██████╗ 
        ██║██╔══██╗      ██║████╗  ██║██╔════╝██╔═══██╗
        ██║██████╔╝█████╗██║██╔██╗ ██║█████╗  ██║   ██║
        ██║██╔═══╝ ╚════╝██║██║╚██╗██║██╔══╝  ██║   ██║
        ██║██║           ██║██║ ╚████║██║     ╚██████╔╝
        ╚═╝╚═╝           ╚═╝╚═╝  ╚═══╝╚═╝      ╚═════╝");
            Write("\x1b[0;37m");
            WriteLine(@"
        by vida.loca (aka jet.black) | https://github.com/jetblack90");
        }

        private static void DisplayHelp()
        {
            Clear();
            Logo();

            WriteLine("\n\n\n\t\x1b[1;31mUsage:\n");
            WriteLine("\t\x1b[1;36mipinfo \x1b[1;32m[IP_ADDRESS]      \x1b[1;37m: \x1b[1;34mLook up information for the specified IP address.");
            WriteLine("\t\x1b[1;36mipinfo \x1b[1;32m-myip \x1b[0;37mor \x1b[1;32m--myip   \x1b[1;37m: \x1b[1;34mLook up information for your own public IP address.");
            WriteLine("\t\x1b[1;36mipinfo \x1b[1;32m-h \x1b[0;37mor \x1b[1;32m--help      \x1b[1;37m: \x1b[1;34mDisplay this help message.\x1b[0m");
        }

        class IpInfo
        {
            public string status { get; set; }
            public string message { get; set; }
            public string query { get; set; }
            public string country { get; set; }
            public string countryCode { get; set; }
            public string region { get; set; }
            public string regionName { get; set; }
            public string city { get; set; }
            public string zip { get; set; }
            public float lat { get; set; }
            public float lon { get; set; }
            public string timezone { get; set; }
            public string isp { get; set; }
            public string org { get; set; }
            public string @as { get; set; }
            public string asname { get; set; }
            public string reverse { get; set; }
            public bool mobile { get; set; }
            public bool proxy { get; set; }
            public bool hosting { get; set; }
        }
    }
}
