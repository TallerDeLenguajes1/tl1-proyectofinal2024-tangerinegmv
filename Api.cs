namespace EspacioApi
{
    using System.Text.Json.Serialization;
       public class Root
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("latitude")]
        public double Latitude { get; set; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; set; }

        [JsonPropertyName("maiden_name")]
        public string MaidenName { get; set; }

        [JsonPropertyName("birth_data")]
        public DateTimeOffset BirthData { get; set; }

        [JsonPropertyName("phone_h")]
        public string PhoneH { get; set; }

        [JsonPropertyName("phone_w")]
        public string PhoneW { get; set; }

        [JsonPropertyName("email_u")]
        public string EmailU { get; set; }

        [JsonPropertyName("email_d")]
        public string EmailD { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("domain")]
        public string Domain { get; set; }

        [JsonPropertyName("useragent")]
        public string Useragent { get; set; }

        [JsonPropertyName("ipv4")]
        public string Ipv4 { get; set; }

        [JsonPropertyName("macaddress")]
        public string Macaddress { get; set; }

        [JsonPropertyName("plasticcard")]
        public string Plasticcard { get; set; }

        [JsonPropertyName("cardexpir")]
        public string Cardexpir { get; set; }

        [JsonPropertyName("bonus")]
        public long Bonus { get; set; }

        [JsonPropertyName("company")]
        public string Company { get; set; }

        [JsonPropertyName("color")]
        public string Color { get; set; }

        [JsonPropertyName("uuid")]
        public Guid Uuid { get; set; }

        [JsonPropertyName("height")]
        public long Height { get; set; }

        [JsonPropertyName("weight")]
        public double Weight { get; set; }

        [JsonPropertyName("blood")]
        public string Blood { get; set; }

        [JsonPropertyName("eye")]
        public string Eye { get; set; }

        [JsonPropertyName("hair")]
        public string Hair { get; set; }

        [JsonPropertyName("pict")]
        public string Pict { get; set; }

        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        [JsonPropertyName("sport")]
        public string Sport { get; set; }

        [JsonPropertyName("ipv4_url")]
        public string Ipv4Url { get; set; }

        [JsonPropertyName("email_url")]
        public string EmailUrl { get; set; }

        [JsonPropertyName("domain_url")]
        public string DomainUrl { get; set; }
    }
}

