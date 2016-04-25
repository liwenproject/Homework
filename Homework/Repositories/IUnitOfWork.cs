using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Homework.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; set; }
        void save();
    }
}
