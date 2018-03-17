using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Manager.Common;
using Manager.Models;
using Manager.Services;
using Manager.ViewModels;
using Microsoft.IdentityModel.Tokens;

namespace Manager.Web.Controllers
{
    /// <summary>
    /// 令牌控制器。
    /// </summary>
    public class TokensController : ApiController
    {
        private const string Key = "D2089BE672953D1136FAA84079AF1B6F3967FED8932DABFFBA3032D30E3C0618";

        private UserService userService;
        private SigningCredentials credentials;

        /// <summary>
        /// 初始化 <see cref="TokensController"/> 類別的新執行個體。
        /// </summary>
        /// <param name="userService">使用者服務。</param>
        public TokensController(UserService userService)
        {
            this.userService = userService;
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public async Task<IHttpActionResult> Post([FromBody]PostTokenQuery query)
        {
            var user = await userService.GetUserAsync(query.UserName, CryptographyUtility.Hash(query.Password));
            if (user == default(User))
                return Unauthorized();

            var header = new JwtHeader(credentials);
            var payload = new JwtPayload { { "UserName ", user.UserName } };
            var secToken = new JwtSecurityToken(header, payload);
            var handler = new JwtSecurityTokenHandler();
            var tokenString = handler.WriteToken(secToken);

            return CreatedAtRoute(Constant.RouteName, new { id = 1 }, tokenString);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}