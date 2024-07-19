namespace Sorted.TakeHome.API.Model
{
    public class ErrorResponse
    {
        public string Message { get; set; }
        public IEnumerable<ErrorDetail> Details { get; set; }
    }
}
