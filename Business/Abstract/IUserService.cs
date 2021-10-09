using Core.UtilitiesCore.Results.Abstract;
using Entities.Concrete;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        Task<IDataResult<List<ValidationFailure>>> AddUserAsync(User entity);
        Task<IDataResult<User>> GetByUserAsync(User entity);
    }
}
