namespace Schedule.Intita.ApiRequest
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string ContentAsString { get; set; }
        public string Response { get; set; }
        public bool IsDeserializeSuccess { get; set; }
    }
}