using KeyService.Configuration;

namespace KeyService.ServiceCollectionExtensions
{
    internal static class ConfigurationExtensions
    {
        public static WebApplicationBuilder AddKestrelSettings(this WebApplicationBuilder builder, KestrelSettings kestrelSettings)
        {
            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.Listen(System.Net.IPAddress.Parse(kestrelSettings.ListeningIPv4Address), kestrelSettings.PortNumber);

                if (kestrelSettings.UseTls)
                {
                    serverOptions.Listen(System.Net.IPAddress.Parse(kestrelSettings.ListeningIPv4Address), kestrelSettings.TlsPortNumber, listenOptions =>
                    {
                        listenOptions.UseHttps();
                    });
                }
            });

            return builder;
        }
    }
}
