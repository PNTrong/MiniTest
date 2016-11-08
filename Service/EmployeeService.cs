using Data.Repositories;
using Model.Models;
using System;
using System.Collections.Generic;
using Training.Data.Infrastructure;

namespace Service
{
    public interface IEmployeeService
    {
        Employee Add(Employee Employee);

        void Update(Employee Employee);

        Employee Delete(int id);

        IEnumerable<Employee> GetAll();

        IEnumerable<Employee> GetAll(string keyword);

        IEnumerable<Employee> GetAll(int provinceId);

        Employee GetById(int id);

        void SaveChanges();
    }

    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _EmployeeRepository;
        private IUnitOfWork _unitOfWork;

        public EmployeeService(IEmployeeRepository EmployeeRepository, IUnitOfWork unitOfWork)
        {
            this._EmployeeRepository = EmployeeRepository;
            this._unitOfWork = unitOfWork;
        }

        public Employee Add(Employee Employee)
        {
            var newEmployee = _EmployeeRepository.Add(Employee);
            _unitOfWork.Commit();
            return newEmployee;
        }

        public Employee Delete(int id)
        {
            return _EmployeeRepository.Delete(id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _EmployeeRepository.GetAll();
        }

        public IEnumerable<Employee> GetAll(int provinceId)
        {
            return _EmployeeRepository.GetMulti(x => x.ProvinceId == provinceId);
        }

        public IEnumerable<Employee> GetAll(string keyword)
        {
            if (!String.IsNullOrEmpty(keyword))
            {
                return _EmployeeRepository.GetMulti(x => x.Name.Contains(keyword));
            }
            else
            {
                return _EmployeeRepository.GetAll();
            }
        }

        public Employee GetById(int id)
        {
            return _EmployeeRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Employee Employee)
        {
            _EmployeeRepository.Update(Employee);
        }
    }
}