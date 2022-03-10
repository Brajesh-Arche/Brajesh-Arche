using Arche.Domain;
using System.Collections.Generic;

namespace Arche.Service
{
    public interface IServices
    {
        IEnumerable<Employee> GetEmployees();
        Employee GetEmployee(int Id);
        void InsertEmployee(Employee model);
        void UpdateEmployee(Employee model);
        void DeleteEmployee(Employee model);
    }
}
