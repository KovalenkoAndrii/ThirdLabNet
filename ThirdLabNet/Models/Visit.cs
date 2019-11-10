namespace ThirdLabNet.Models
{
    public class Visit
    {
        public int Id { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int OperationId { get; set; }
        public Operation Operation { get; set; }

        public string VisitDate { get; set; }
    }
}
