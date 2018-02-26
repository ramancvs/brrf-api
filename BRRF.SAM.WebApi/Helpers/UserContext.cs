using BRRF.SAM.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

using System.IdentityModel.Tokens.Jwt;

namespace BRRF.SAM.WebApi.Helpers
{
    public static class UserContext
    {
        public static UserContextModel GetUserContext(HttpRequestMessage request)
        {
            UserContextModel userContextModel = new UserContextModel();
            var headers = request.Headers;
            if (headers.Contains("UserContext"))
            {
                string token = headers.GetValues("UserContext").First();
                var handler = new JwtSecurityTokenHandler();
                var jsonToken = handler.ReadToken(token);
                var claims = ((JwtSecurityToken)jsonToken).Claims;
                userContextModel.nbf = claims.Where(x => x.Type == "nbf").Select(x => x.Value).FirstOrDefault();
                userContextModel.exp = claims.Where(x => x.Type == "exp").Select(x => x.Value).FirstOrDefault();
                userContextModel.iss = claims.Where(x => x.Type == "iss").Select(x => x.Value).FirstOrDefault();
                userContextModel.aud = claims.Where(x => x.Type == "aud").Select(x => x.Value).FirstOrDefault();
                userContextModel.nonce = claims.Where(x => x.Type == "nonce").Select(x => x.Value).FirstOrDefault();
                userContextModel.iat = claims.Where(x => x.Type == "iat").Select(x => x.Value).FirstOrDefault();
                userContextModel.at_hash = claims.Where(x => x.Type == "at_hash").Select(x => x.Value).FirstOrDefault();
                userContextModel.sid = claims.Where(x => x.Type == "sid").Select(x => x.Value).FirstOrDefault();
                userContextModel.sub = claims.Where(x => x.Type == "sub").Select(x => x.Value).FirstOrDefault();
                userContextModel.auth_time = claims.Where(x => x.Type == "auth_time").Select(x => x.Value).FirstOrDefault();
                userContextModel.idp = claims.Where(x => x.Type == "idp").Select(x => x.Value).FirstOrDefault();
                userContextModel.name = claims.Where(x => x.Type == "name").Select(x => x.Value).FirstOrDefault();
                userContextModel.given_name = claims.Where(x => x.Type == "given_name").Select(x => x.Value).FirstOrDefault();
                userContextModel.family_name = claims.Where(x => x.Type == "family_name").Select(x => x.Value).FirstOrDefault();
                userContextModel.website = claims.Where(x => x.Type == "website").Select(x => x.Value).FirstOrDefault();
                userContextModel.brand_name = claims.Where(x => x.Type == "brand_name").Select(x => x.Value).FirstOrDefault(); 
            }

            return userContextModel;
        }
    }
}