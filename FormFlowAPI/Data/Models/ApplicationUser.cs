using Microsoft.AspNetCore.Identity;

namespace FormFlowApi.Data.Models;

public class ApplicationUser : IdentityUser
{
    public List<UserWorkspace> Workspaces { get; set; }
}
