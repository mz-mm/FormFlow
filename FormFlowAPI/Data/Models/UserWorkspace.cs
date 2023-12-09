namespace FormFlowApi.Data.Models;

public class UserWorkspace
{
    public string ApplicationUserId { get; set; }
    public ApplicationUser ApplicationUser { get; set; }

    public string WorkspaceId { get; set; }
    public Workspace Workspace { get; set; }
}
