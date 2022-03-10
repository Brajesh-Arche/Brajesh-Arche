using System;
using System.Collections.Generic;
using Arche.Domain;
using Arche.Repository;


namespace Arche.Service
{
    public class Services : IServices
    {
        private IRepository<Employee> _employeeRepository;
        private readonly object Id;

        public Services(IRepository<Employee> employeeRepository)
        {
            
            this._employeeRepository = employeeRepository;
        }
        public void DeleteEmployee(Employee model)
        {
            Employee employee = GetEmployee(Id);
            _employeeRepository.Remove(employee);
        }

        private Employee GetEmployee(object id)
        {
            throw new NotImplementedException();
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeRepository.Get(Id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeRepository.GetAll();
        }

        public void InsertEmployee(Employee model)
        {
            _employeeRepository.Insert(model);
        }
        public void UpdateEmployee(Employee model)
        {
            _employeeRepository.Update(model);   
        }

      
    }
}
