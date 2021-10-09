using Business.Abstract;
using Business.FluentValidation;
using Business.Methods;
using Core.UtilitiesCore.Results.Abstract;
using Core.UtilitiesCore.Results.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        readonly IUserDal userDal;
        UserValidator userValidator;
        public UserManager(IUserDal _userDal,UserValidator validationRules)
        {
            userDal = _userDal;
            userValidator = validationRules;
        }

        public async Task<IDataResult<List<ValidationFailure>>> AddUserAsync(User entity)
        {
            ValidationResult val = userValidator.Validate(entity);
            if (val.IsValid)
            {
                User user = await userDal.GetAsync(p=>p.Email == entity.Email);
                if (user == null)
                {
                    entity.Password = HelperMethods.ToSHA256(entity.Password);
                    await userDal.AddAsync(entity);
                    return new SuccesDataResult<List<ValidationFailure>>(val.Errors);
                }
                else
                {
                    List<ValidationFailure> customFailure = new List<ValidationFailure>();
                    ValidationFailure validation = new ValidationFailure("Email","Email Daha Evvel Qeydiyyatdan Kecilib");
                    customFailure.Add(validation);
                    return new ErrorDataResult<List<ValidationFailure>>(customFailure);
                }
            }
            return new ErrorDataResult<List<ValidationFailure>>(val.Errors);
        }

        public async Task<IDataResult<User>> GetByUserAsync(User entity)
        {
            ValidationResult val = userValidator.Validate(entity);
            if (val.IsValid)
            {
                entity.Password = HelperMethods.ToSHA256(entity.Password);
                User user = await userDal.GetAsync(m => m.Email == entity.Email && m.Password == entity.Password);
                if (user != null)
                    return new SuccesDataResult<User>(user);
            }
            return new ErrorDataResult<User>(entity,"Yanlış məlumatlar daxil olunub");
        }
    }
}
