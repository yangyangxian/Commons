using System;
using System.Collections.Generic;

namespace MyDataAccess.Models
{
    public partial class TableField
    {
        public long TableFieldId { get; set; }
        public long? TableId { get; set; }
        public long? FieldId { get; set; }
        public string FieldDisplayName { get; set; }
    }
}
