using System;
using System.Collections.Generic;

namespace Infrastructure.EF;

public partial class Tenant
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Domain { get; set; } = null!;

    public string SchemaName { get; set; } = null!;

    public bool? IsActive { get; set; }

    public DateTime? CreatedAt { get; set; }
}
