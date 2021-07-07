namespace Supermarket.API.Domain.Model.Services.Communication
{
    public class Response<T> : BaseResponse
    {
        public T Data { get; private set; }

        private Response(bool success, string message, T Data) : base(success, message)
        {
            this.Data = Data;
        }

        /// <summary>
        /// Creates a success response.
        /// </summary>
        /// <param name="T">saved Item.</param>
        /// <returns>Response.</returns>
        public Response(T Data) : this(true, string.Empty, Data)
        { }

        /// <summary>
        /// Creates am error response.
        /// </summary>
        /// <param name="message">Error message.</param>
        /// <returns>Response.</returns>
        public Response(string message) : this(false, message, default)
        { }
    }
}