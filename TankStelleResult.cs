namespace TankStelle
{
    public class TankStelleResult
    {
        public TankStelleResult(string address)
        {
            var addressObject = Helpers.AddressHelper.TryParse(address);
            Street = addressObject.Street;
            PostalCode = addressObject.PostalCode;
            City = addressObject.City;
        }
        public int Id { get; set; }
        public string Street { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Latitude { get; set; }
        public string Longtitude { get; set; }
    }
}