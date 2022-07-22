using System;
using System.Threading.Tasks;

namespace EduFlow_Odev2.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Task CompleteAsync();
    }
}
