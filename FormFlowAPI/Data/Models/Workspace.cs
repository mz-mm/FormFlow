using Microsoft.AspNetCore.Identity;

namespace FormFlowApi.Data.Models;

public class Workspace
{
    public const int MAxWorkspaceName = 30;
    public const int MinWorkspaceName = 3;
    
    public const int MAxWorkspaceDescription = 30;
    public const int MinWorkspaceDescription = 0;
    
    public string Id { get; set; }
    public string WorkspaceName { get; set; }
    public string WorkspaceDescription { get; set; }
    public DateTime CreatedAt { get; set; }
    public List<EventManager> EventManagers { get; set; }
    public List<UserWorkspace> UserWorkspaces { get; set; }

    
    private Workspace() { }

    private Workspace(Guid id ,string workspaceName, string workspaceDescription, DateTime createdAt)
    {
        Id = id.ToString();
        WorkspaceName = workspaceName;
        WorkspaceDescription = workspaceDescription;
        CreatedAt = createdAt;
        UserWorkspaces = [];
    }

    public static Workspace Create(string workspaceName, string workspaceDescription, Guid? id = null, DateTime? dateTime = null)
    {
        if (workspaceName.Length is < MinWorkspaceName or > MAxWorkspaceName || string.IsNullOrWhiteSpace(workspaceName))
            throw new ArgumentException("Invalid Workspace name length");
        
        
        if (workspaceDescription.Length is < MinWorkspaceDescription or > MAxWorkspaceDescription)
            throw new ArgumentException("Invalid Workspace description length");

        return new Workspace(
            id ?? Guid.NewGuid(),
            workspaceName,
            workspaceDescription,
            DateTime.UtcNow);
    }
}
