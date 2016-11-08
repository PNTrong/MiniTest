using System;
using Data;

namespace Training.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        //Factory nơi mà mọi thứ được tạo ra.
        private SDCTestDbContext dbContext;

        public SDCTestDbContext Init()
        {
            return dbContext ?? (dbContext = new SDCTestDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }

 
    }
}