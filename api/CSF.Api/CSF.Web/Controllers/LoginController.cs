using Amazon.CognitoIdentity;
using Amazon.CognitoIdentity.Model;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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

            // Not handling any AuthChallenges atm
            //AdminRespondToAuthChallengeResponse challengeResponse = await cognitoProvider.AdminRespondToAuthChallengeAsync(new AdminRespondToAuthChallengeRequest()
            //{
            //    UserPoolId = "us-east-1_8zHPTN94n",
            //    ChallengeName = authResponse.ChallengeName,
            //    Session = authResponse.Session,
            //    ChallengeResponses = new Dictionary<string, string>
            //    {
            //        ["NEW_PASSWORD"] = "P@ssword1",
            //        ["USERNAME"] = creds.username
            //    },
            //    ClientId = "6jihcdqm2oh1r39ksfj5k3dcf5"
            //});

            // If we want to do Cognito federated Auth - we should add GetIdAsync and GetCredentialsForIdentityAsync

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = jwtSecurityTokenHandler.ReadJwtToken(authResponse.AuthenticationResult.IdToken);

            ClaimsIdentity id = new ClaimsIdentity(token.Claims, "password");
            ClaimsPrincipal p = new ClaimsPrincipal(id);

            await HttpContext.Authentication.SignInAsync("Cookies", p);
        }

        [Route("Logout")]
        public async Task Logout()
        {
            await HttpContext.Authentication.SignOutAsync("Cookies");
        }
    }
}
