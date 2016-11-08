using Data.Repositories;
using Model.Models;
using System;
using System.Collections.Generic;
using Training.Data.Infrastructure;

namespace Service
{
    public interface ICountyService
        {
            County Add(County Employee);

            void Update(County Employee);

            County Delete(int id);

            IEnumerable<County> GetAll();

            IEnumerable<County> GetAll(int id);

            IEnumerable<County> GetAll(string keyword);

            County GetById(int id);

            void SaveChanges();
        }

        public class CountyService : ICountyService
        {
            private ICountyRepository _countyRepository;
            private IUnitOfWork _unitOfWork;

            public CountyService(ICountyRepository countyRepository, IUnitOfWork unitOfWork)
            {
                this._countyRepository = countyRepository;
                this._unitOfWork = unitOfWork;
            }

            public County Add(County county)
            {
                var newEmployee = _countyRepository.Add(county);
                _unitOfWork.Commit();
                return newEmployee;
            }

            public County Delete(int id)
            {
                return _countyRepository.Delete(id);
            }

            public IEnumerable<County> GetAll()
            {
                return _countyRepository.GetAll();
            }

        public IEnumerable<County> GetAll(int id)
        {
            return _countyRepository.GetMulti(x => x.ProvinceId == id);
        }

        public IEnumerable<County> GetAll(string keyword)
            {
                if (!String.IsNullOrEmpty(keyword))
                {
                    return _countyRepository.GetMulti(x => x.Name.Contains(keyword));
                }
                else
                {
                    return _countyRepository.GetAll();
                }
            }

            public County GetById(int id)
            {
                return _countyRepository.GetSingleById(id);
            }

            public void SaveChanges()
            {
                _unitOfWork.Commit();
            }

            public void Update(County county)
            {
                _countyRepository.Update(county);
            }
        }
    }
