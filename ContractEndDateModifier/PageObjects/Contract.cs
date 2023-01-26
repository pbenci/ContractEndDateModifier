namespace ContractEndDateModifier
{
    public class Contracts
    {
        public string Code { get; private set; }
        public string ContractRowId { get; private set; }
        public string NewEndDate { get; private set; }

        public Contracts(string Code, string ContractRowId, string NewEndDate)
        {
            this.Code = Code;
            this.ContractRowId = ContractRowId;
            this.NewEndDate = NewEndDate;
        }
    }
}