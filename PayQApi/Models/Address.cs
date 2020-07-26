namespace PayQApi.Models
{
    public class Address
    {
        /// <summary>
        ///<para>Required</para>
        /// </summary>

        public string Type { get; set; }
        /*{
            AddressType_Residential, AddressType_Mailing
        }*/
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }

        public string Region { get; set; }
        public string PostalCode { get; set; }

        /// <summary>
        /// <para>ex. USA, CAN, MEX etc.</para>
        /// Country Alpha2, Alpha3, or an enum string value obtained through the Codes endpoint. Showing Alpha3 examples.
        /// </summary>
        public string Country { get; set; }
    }
}