using Data.Repositories;
using Model.Models;
using System;
using System.Collections.Generic;
using Training.Data.Infrastructure;

namespace Service
{
    public interface IProvinceService
    {
        Province Add(Province Province);

        void Update(Province Province);

        Province Delete(int id);

        IEnumerable<Province> GetAll();

        IEnumerable<Province> GetAll(string keyword);

        Province GetById(int id);

        void SaveChanges();
    }

    public class ProvinceService : IProvinceService
    {
        private IProvinceRepository _ProvinceRepository;
        private IUnitOfWork _unitOfWork;

        public ProvinceService(IProvinceRepository ProvinceRepository, IUnitOfWork unitOfWork)
        {
            this._ProvinceRepository = ProvinceRepository;
            this._unitOfWork = unitOfWork;
        }

        public Province Add(Province Province)
        {
            var newProvince = _ProvinceRepository.Add(Province);
            _unitOfWork.Commit();
            return newProvince;
        }

        public Province Delete(int id)
        {
            return _ProvinceRepository.Delete(id);
        }

        public IEnumerable<Province> GetAll()
        {
            return _ProvinceRepository.GetAll();
        }

        public IEnumerable<Province> GetAll(string keyword)
        {
            if (!String.IsNullOrEmpty(keyword))
            {
                return _ProvinceRepository.GetMulti(x => x.Name.Contains(keyword));
            }
            else
            {
                return _ProvinceRepository.GetAll();
            }
        }

        public Province GetById(int id)
        {
            return _ProvinceRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Province Province)
        {
            _ProvinceRepository.Update(Province);
        }
    }
}