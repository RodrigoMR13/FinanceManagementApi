namespace Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int TransactionTypeId { get; set; }
        public TransactionType TransactionType { get; set; }
        public float Value { get; set; }
        public DateTime DateTime { get; set; }
    }
}
