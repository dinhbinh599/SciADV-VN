using AdvWeb_VN.Utilities.Dtos;
using Microsoft.Extensions.Configuration;

namespace AdvWeb_VN.Utilities.Settings;

public class DomainAddressHelper
{
    public static void ConfigureDomainAddresses(IConfiguration configuration)
    {
        DomainAddresses.BaseAddress = configuration.GetSection("BaseAddress").Value;
        DomainAddresses.PortalAddress = configuration.GetSection("PortalAddress").Value;
        DomainAddresses.ManageAddress = configuration.GetSection("ManageAddress").Value;
    }
}