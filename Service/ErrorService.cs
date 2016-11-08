using Data.Repositories;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Training.Data.Infrastructure;

namespace Service
{


    public interface IErrorService
    {
        Error Create(Error err);

        void SaveChanges();
    }

    public class ErrorService : IErrorService
    {
        private IErrorRepository _errorRepository;
        private IUnitOfWork _unitOfWork;

        public ErrorService(IErrorRepository errorRepository, IUnitOfWork unitOfWork)
        {
            this._errorRepository = errorRepository;
            this._unitOfWork = unitOfWork;
        }

        public Error Create(Error err)
        {
            return _errorRepository.Add(err);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
