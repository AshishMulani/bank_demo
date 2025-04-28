namespace bank_demo.Services
{
    public static class BeneficiaryService
    {
        private static List<Beneficiary> _beneficiaries = new List<Beneficiary>();

        public static IReadOnlyList<Beneficiary> Beneficiaries => _beneficiaries.AsReadOnly();

        public static void AddBeneficiary(Beneficiary beneficiary)
        {
            _beneficiaries.Add(beneficiary);
        }
    }
}
