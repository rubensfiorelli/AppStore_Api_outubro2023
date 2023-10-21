namespace AppStore.Domain.Responses
{
    public sealed class Response
    {
        private static Response ok = new() { Success = true };
        private static Response fail = new() { Success = false };

        public Response(bool success = false)
        {
            Success = success;
        }

        public bool Success { get; private set; }
        public static Response Ok { get => ok; set => ok = value; }
        public static Response Fail { get => fail; set => fail = value; }
    }
}
