namespace Manero_backend.Services
{

    /// <summary>
    /// 🙂 👍 ServiceResponse for better error handling and response messages to the client.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ServiceResponse<T>
    {
        public T Data { get; set; } = default!;
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public Dictionary<string, object> Extensions { get; set; } = null!;
    }
}
