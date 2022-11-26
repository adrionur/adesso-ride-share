namespace AdessoRideShare.Domain
{
    public class ApiResponse
    {
        public object Response { get; set; }
        public bool IsSuccess { get; set; }
        public IList<string> Errors { get; set; }
        public ApiResponse(object response, bool success, IList<string> errors = null)
        {
            this.Response = response;
            this.IsSuccess = success;
            this.Errors = errors;
        }

        public ApiResponse()
        {
        }
    }
}
