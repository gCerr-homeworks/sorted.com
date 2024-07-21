namespace Sorted.TakeHome.API.Model
{
    public class ErrorResponse
    {
        public string Message { get; set; }

        // According to yaml specs this was supposed to be called "Detail"
        // Renamed as it seems semantically more correct as a plural
        public IEnumerable<ErrorDetail> Details { get; set; }
    }
}
