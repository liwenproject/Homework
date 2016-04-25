using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Homework.Repositories;

namespace Homework.Models
{
    public class LogService
    {
        IRepository<Log> _LogRep;
        public LogService(IUnitOfWork UnitOfWork)
        {
            _LogRep = new Repository<Log>(UnitOfWork);
        }

        public void Add(int Category, int Amount, string actionMark)
        {
            var result = new Log()
            {
                Id = Guid.NewGuid(),
                CreateTime = System.DateTime.Now,
                Categoryyy = Category,
                Amounttt = Amount,
                ActionRemark = actionMark
            };
            Add(result);
        }

        public void Add(Log data)
        {
            _LogRep.Create(data);
        }

        public void Save()
        {
            _LogRep.Commit();
        }

    }
}