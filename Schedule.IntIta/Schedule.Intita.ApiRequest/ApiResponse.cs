using Schedule.IntIta.Domain.Models;

namespace Schedule.Intita.ApiRequest
{
    public class ApiResponse<TResponse> where TResponse : IEntity
    {
        public int StatusCode { get; set; }
        public string ContentAsString { get; set; }
        public TResponse[] Response { get; set; }
        public bool IsDeserializeSuccess { get; set; }
    }
}