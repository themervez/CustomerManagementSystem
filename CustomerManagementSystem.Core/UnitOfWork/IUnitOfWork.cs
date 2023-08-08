using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.Core.UnitOfWork
{
    public interface IUnitOfWork//for otomatic rollback
    {
        Task CommitAsync();//SaveChangesAsync

        void Commit();//SaveChanges
    }
}
