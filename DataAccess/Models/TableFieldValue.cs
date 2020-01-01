using System;
using System.Collections.Generic;

namespace MyDataAccess.Models
{
    public partial class TableFieldValue
    {
        public long TableFieldValueId { get; set; }
        public long? TableFieldId { get; set; }
        public string Value { get; set; }
    }
}
