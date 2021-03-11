using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureTable.Model
{
    class Department:TableEntity
    {
        public string DeptName { get; set; }
        public string DeptRowKey { get; set; }
    }
}
