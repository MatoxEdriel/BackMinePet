using Domain.Services;

namespace Presentations.Services;

public class TenantService: ITenantService
{
    private readonly IHttpContextAccessor _contextAccessor;


    public TenantService(IHttpContextAccessor contextAccessor)
    {
        _contextAccessor = contextAccessor;
    }

    public string GetCurrentTenant()
    {
        return _contextAccessor.HttpContext?.Items["Tenant"]?.ToString() ?? "default";

    }
}