using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Threading;

namespace Vacations.PingWebJob
{
    internal class Program
    {
        private static void Main()
        {
            var infoLogger = Console.Out;
            var errorLogger = Console.Error;

            infoLogger.WriteLine("Starting web job...");

            try
            {
                const string url = @"https://btangular.azurewebsites.net/auth";

                var shutdownFilePath = Environment.GetEnvironmentVariable("WEBJOBS_SHUTDOWN_FILE");

                if (string.IsNullOrEmpty(shutdownFilePath))
                {
                    throw new InvalidOperationException("WEBJOBS_SHUTDOWN_FILE variable has empty value");
                }

                infoLogger.WriteLine("Web job has started");

                while (!File.Exists(shutdownFilePath))
                {
                    Thread.Sleep(TimeSpan.FromMinutes(1));

                    var request = (HttpWebRequest)WebRequest.Create(url);
                    request.AutomaticDecompression = DecompressionMethods.GZip;

                    string html;

                    using (var response = (HttpWebResponse)request.GetResponse())
                    using (var stream = response.GetResponseStream())
                    using (var reader = new StreamReader(stream ?? throw new InvalidOperationException("Get HTML Failed!!!")))
                    {
                        html = reader.ReadToEnd();
                    }

                    infoLogger.WriteLine("I got a HTML. Length count: {0}", html.Length);
                }

                infoLogger.WriteLine("Shutdown request was detected. Gracefully stopping...");
            }
            catch (Exception exception)
            {
                var error = string.Format(CultureInfo.InvariantCulture, "Error: {0}", exception.Message);

                errorLogger.WriteLine(error);
            }
        }
    }
}
