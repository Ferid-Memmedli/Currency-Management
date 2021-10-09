using Core.UtilitiesCore.Results.Abstract;

namespace Core.UtilitiesCore.Results.Concrete
{
    public class SuccesDataResult<T> : DataResult<T>
    {
        public SuccesDataResult(T data, string message) : base(data, true, message)
        {

        }
        public SuccesDataResult(T data) : base(data, true)
        {

        }
        public SuccesDataResult(string message) : base(default, true, message)
        {

        }
        public SuccesDataResult() : base(default, true)
        {

        }
    }
}
