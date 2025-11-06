using System;
using System.Collections.Generic;

namespace Infrastructure.EF;

public partial class Permission
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public virtual ICollection<Role> Rols { get; set; } = new List<Role>();
}
