namespace TankStelle.Helpers
{
    public static class AddressHelper
    {
        // Tries to parse address according to format "Bonner Str. 98 (50677 Neustadt/Süd)",
        // if no matches then returns address as Street.
        public static Address TryParse(string address)
        {
            try
            {
                string[] adrPart = address.Split('(');

                string[] adrPart2 = adrPart[1].Split(' ');

                return new Address()
                {
                    Street = adrPart[0],
                    PostalCode = adrPart2[0],
                    City = adrPart2[1].Remove(adrPart2[1].Length-1)
                };
            }
            catch (System.Exception)
            {
                return new Address()
                {
                    Street = address
                };
            }


        }
    }
}