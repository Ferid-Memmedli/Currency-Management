using Core.UtilitiesCore.Results.Abstract;

namespace Core.UtilitiesCore.Results.Concrete
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {

        }
        public ErrorResult() : base(false)
        {

        }
    }
}
