using SharedLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.Core.Services
{
    public interface IServiceGeneric<T, TDto> where T : class where TDto : class
    {
        Task<Response<TDto>> AddAsync(TDto entity);
        Task<Response<NoDataDto>> Update(TDto entity, int id);
        Task<Response<NoDataDto>> Delete(int id);
        Task<Response<TDto>> GetByIdAsync(int id);//Response: for using data that api uses
        Task<Response<IEnumerable<TDto>>> GetAllAsync();

        Task<Response<IEnumerable<TDto>>> Where(Expression<Func<T, bool>> predicate);//IEnumerable: because of this data is final data anymore, we can use IEnumerable anymore
    }
}
