namespace ContractEndDateModifier
{
    public class Contracts
    {
        public string Code { get; private set; }
        public string RowId { get; private set; }
        public string NewEndDate { get; private set; }
        public string PreviousEndDate { get; private set; }


        public Contracts(string Code, string RowId, string NewEndDate, string PreviousEndDate)
        {
            this.Code = Code;
            this.RowId = RowId;
            this.NewEndDate = NewEndDate;
            this.PreviousEndDate = PreviousEndDate;
        }
    }
}