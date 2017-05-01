using Amazon.CognitoIdentity;
using Amazon.CognitoIdentity.Model;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CSF.Web.Controllers
{
    public class LoginController : ControllerBase
    {
        private IAmazonCognitoIdentity cognito;
        private IAmazonCognitoIdentityProvider cognitoProvider;

        public LoginController(IAmazonCognitoIdentity cognito, IAmazonCognitoIdentityProvider cognitoProvider)
        {
            this.cognitoProvider = cognitoProvider;
            this.cognito = cognito;
        }

        /// <summary>
        /// Can't seem to get POST to serialize anything but an exact object... didn't seem this way in standard
        /// </summary>
        public class Credentials
        {
            public string username { get; set; }
            public string password { get; set; }
        }

        [Route("[controller]")]
        public async Task Post([FromBody]Credentials creds)
        {
            AdminInitiateAuthResponse authResponse =  await cognitoProvider.AdminInitiateAuthAsync(new AdminInitiateAuthRequest()
            {
                UserPoolId = "us-east-1_8zHPTN94n",
                AuthFlow = AuthFlowType.ADMIN_NO_SRP_AUTH,
                AuthParameters = new Dictionary<string, string>
                {
                    ["USERNAME"] = creds.username, ["PASSWORD"] = creds.password
                },
                ClientId = "6jihcdqm2oh1r39ksfj5k3dcf5"
            });


            if (creds.username == creds.password)
            {
                GetIdResponse response = await cognito.GetIdAsync(new GetIdRequest()
                {
                    AccountId = "749316239733",
                    IdentityPoolId = "us-east-1:3dcf8ac0-8894-4f75-b0e0-3adc53142170",
                    //Logins = new Dictionary<string, string>
                    //{
                    //    ["cognito-idp.us-east-1.amazonaws.com/us-east-1_8zHPTN94n"] = "6jihcdqm2oh1r39ksfj5k3dcf5"
                    //}
                });
                
                
                List<Claim> claims = new List<Claim>
                {
                    new Claim("sub", "19828281888"),
                    new Claim("given_name", "Dominick"),
                    new Claim("role", "Geek")
                };

                ClaimsIdentity id = new ClaimsIdentity(claims, "password");
                ClaimsPrincipal p = new ClaimsPrincipal(id);

                await HttpContext.Authentication.SignInAsync("Cookies", p);
            }
        }

        [Route("Logout")]
        public async Task Logout()
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");
        }
    }
}
