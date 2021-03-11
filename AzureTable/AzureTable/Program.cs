using AzureTable.Model;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Linq;

namespace AzureTable
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse("Cloud Storage Connection String from Azure Portal");

            CloudTableClient cloudTableClient = cloudStorageAccount.CreateCloudTableClient();
            CloudTable cloudTable = cloudTableClient.GetTableReference("EmployeeOrg");

            var employeeQuery = new TableQuery<Employee>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Employee"));

            var departmentQuery = new TableQuery<Department>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "Department"));

            var empList = cloudTable.ExecuteQuery<Employee>(employeeQuery).ToList();
            var depList = cloudTable.ExecuteQuery<Department>(departmentQuery).ToList();

            var result = from e in empList
                      join d in depList on e.DeptRowKey equals d.RowKey
                      select new Employee() 
                      {
                          DeptName=d.DeptName,
                          EmpName=e.EmpName,
                          EmpCity=e.EmpCity
                      };

            foreach (var emp in result)
            {
                Console.WriteLine("EmpName :"+emp.EmpName);
                Console.WriteLine("DeptName :" + emp.DeptName);
                Console.WriteLine("EmpCity :" + emp.EmpCity);
            }
            Console.ReadLine();
        }
    }
}
