using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace AzureTable.Model
{
    class Employee:TableEntity
    {
        public string EmpCity { get; set; }
        public string EmpName { get; set; }
        public string DeptRowKey { get; set; }
        public string DeptName { get; set; }
    }
}
