using System.Collections.Generic;

namespace BRRF.SAM.WebApi.Models
{
    public class UserContextModel
    {
        public string nbf { get; set; }
        public string exp { get; set; }
        public string iss { get; set; }
        public string aud { get; set; }
        public string nonce { get; set; }
        public string iat { get; set; }
        public string at_hash { get; set; }
        public string sid { get; set; }
        public string sub { get; set; }
        public string auth_time { get; set; }
        public string idp { get; set; }
        public string name { get; set; }
        public string given_name { get; set; }
        public string family_name { get; set; }
        public string website { get; set; }
        public string brand_name { get; set; }
        public List<string> amr { get; set; }
    }
}