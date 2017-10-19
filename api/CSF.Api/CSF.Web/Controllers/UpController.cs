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
    public class UpController : ControllerBase
    {
        public UpController()
        {
        }

        [Route("[controller]")]
        public UpCheckModel Get()
        {
            return new UpCheckModel()
            {
                Status = "healthy"
            };
        }
    }

    public class UpCheckModel
    {
        public string Status { get; set; }
    }
}
