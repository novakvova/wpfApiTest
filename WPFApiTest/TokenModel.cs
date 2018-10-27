using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFApiTest
{
    public class TokenModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string Token { get { return $"{token_type} {access_token}"; } }
    }
}
