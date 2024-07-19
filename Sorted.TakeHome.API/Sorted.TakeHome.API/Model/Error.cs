namespace Sorted.TakeHome.API.Model
{
    public class Error
    {
        public string Message { get; set; }
        public IEnumerable<ErrorDetail> Details { get; set; }
    }
}
