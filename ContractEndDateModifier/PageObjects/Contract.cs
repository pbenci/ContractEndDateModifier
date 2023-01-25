namespace InsuranceAdjuster
{
    public class Contracts
    {
        public string Code { get; private set; }
        public string ContractRowId { get; private set; }
        public string InsurancePrice { get; private set; }

        public Contracts(string Code, string ContractRowId, string InsurancePrice)
        {
            this.Code = Code;
            this.ContractRowId = ContractRowId;
            this.InsurancePrice = InsurancePrice;
        }
    }
}