namespace Api.Endpoints
{
    public class GetTicketsRequest
    {
        public Guid Id { get; set; }
        public int? PageNumber { get; set; } = 1;
        public int? PageSize { get; set; }
        public string Lang { get; set; } = "en";
    }
}
