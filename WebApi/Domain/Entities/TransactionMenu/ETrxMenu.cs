namespace WebApi.Domain.Entities.TransactionMenu
{
    public class ETrxMenu
    {
        public string TransactionNumber { get; set; }

        public string? Title { get; set; }

        public bool IsNewTransaction { get; set; }

        public string? TransactionUrl { get; set; }
    }
    
}
