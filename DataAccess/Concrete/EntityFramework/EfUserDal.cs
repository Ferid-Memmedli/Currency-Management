using Core.DataAccessCore.EntityFrameworkCore;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EFEntityRepositoryBase<User, EfContext>, IUserDal
    {

    }
}
