using Core.UtilitiesCore.Results.Abstract;

namespace Core.UtilitiesCore.Results.Concrete
{
    public class SuccessResult : Result
    {
        public SuccessResult(string message) : base(true, message)
        {

        }
        public SuccessResult() : base(true)
        {

        }
    }
}
