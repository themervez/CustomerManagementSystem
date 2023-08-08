using AutoMapper.Internal.Mappers;
using CustomerManagementSystem.Core.Repositories;
using CustomerManagementSystem.Core.Services;
using CustomerManagementSystem.Core.UnitOfWork;
using CustomerManagementSystem.Service.Mapper;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagementSystem.Service.Services
{
    public class GenericService<T, TDto> : IGenericService<T, TDto> where T : class where TDto : class
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IGenericRepository<T> _genericRepository;

        public GenericService(IUnitOfWork unitOfWork, IGenericRepository<T> genericRepository)
        {
            _unitOfWork = unitOfWork;
            _genericRepository = genericRepository;
        }

        public async Task<Response<TDto>> AddAsync(TDto entity)
        {
            var newEntity = ObjectMapper.Mapper.Map<T>(entity);

            await _genericRepository.AddAsync(newEntity);

            await _unitOfWork.CommitAsync();

            var newDto = ObjectMapper.Mapper.Map<TDto>(newEntity);//Converted for dto's ID

            return Response<TDto>.Success(newDto, 200);
        }

        public async Task<Response<NoDataDto>> Update(TDto entity, int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);//checking

            if (isExistEntity == null)
            {
                return Response<NoDataDto>.Fail("ID not found", 404, true);
            }

            var updateEntity = ObjectMapper.Mapper.Map<T>(entity);

            _genericRepository.Update(updateEntity);

            await _unitOfWork.CommitAsync();

            //204 Status Code =>  No Content  => Response body has not data
            return Response<NoDataDto>.Success(204);
        }

        public async Task<Response<NoDataDto>> Delete(int id)
        {
            var isExistEntity = await _genericRepository.GetByIdAsync(id);

            if (isExistEntity == null)
            {
                return Response<NoDataDto>.Fail("ID not found", 404, true);
            }
            _genericRepository.Delete(isExistEntity);

            await _unitOfWork.CommitAsync();

            return Response<NoDataDto>.Success(204);
        }

        public async Task<Response<IEnumerable<TDto>>> GetAllAsync()
        {
            var customers = ObjectMapper.Mapper.Map<List<TDto>>(await _genericRepository.GetAllAsync());

            return Response<IEnumerable<TDto>>.Success(customers, 200);
        }

        public async Task<Response<TDto>> GetByIdAsync(int id)
        {
            var customer = await _genericRepository.GetByIdAsync(id);

            if (customer == null)
            {
                return Response<TDto>.Fail("ID not found", 404, true);
            }

            return Response<TDto>.Success(ObjectMapper.Mapper.Map<TDto>(customer), 200);
        }

        public async Task<Response<IEnumerable<TDto>>> Where(Expression<Func<T, bool>> predicate)
        {
            //where(x=>x.id>1)
            var list = _genericRepository.Where(predicate);

            return Response<IEnumerable<TDto>>.Success(ObjectMapper.Mapper.Map<IEnumerable<TDto>>(await list.ToListAsync()), 200);
        }
    }
}
