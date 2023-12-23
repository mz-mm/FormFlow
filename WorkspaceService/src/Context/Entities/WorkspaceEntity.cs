using System.ComponentModel.DataAnnotations.Schema;

namespace src.Context.Entities;

[Table("WORKSPACE")]
public class Workspace : BaseEntity
{
    public const int MAxWorkspaceName = 30;
    public const int MinWorkspaceName = 3;
    
    public const int MAxWorkspaceDescription = 30;
    public const int MinWorkspaceDescription = 0;
    
    [Column("NAME")]
    public string Name { get; set; } = string.Empty;
    
    [Column("DESCRIPTION")]
    public string Description { get; set; } = string.Empty;
    
    [Column("CREATEDAT")]
    public DateTime CreatedAt { get; set; }
}
