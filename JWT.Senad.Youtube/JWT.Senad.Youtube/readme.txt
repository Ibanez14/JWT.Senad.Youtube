JWT Token Generation
By Youtube video of Senad Meskin

=> Generates!
=> And authenticates!

Steps:
1) service.AddAuthentication(jwtdefaults)
2) authBuilder.AddJwtBearer => ops.TokenValidationParameters (Startup.cs)
3) app.UseAuthentication()
3) Add TokenController with Get action that take a RequestModel and returns a token
GetTokenAction:
- SymmetricSecurityKey (goes to JwtSecurityToken)
- JwtSecurityToken (goes to JwtSecurityTokenHandler().WriteToken(..here..))
- JwtSecurityTokenHandler().WriteToken()

4) Authorize any random Controller to cheout the token



