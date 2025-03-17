namespace CozyHouse.UI.DTO
{
    public class AuthorizationDTO
    {
        private LoginDTO? login;
        private RegisterDTO? register;
        public LoginDTO LoginDTO 
        { 
            get
            {
                if (login == null)
                {
                    login = new LoginDTO();
                }
                return login;
            }
            set
            {
                login = value;
            }
        }
        public RegisterDTO RegisterDTO 
        {
            get
            {
                if (register == null)
                {
                    register = new RegisterDTO();
                }
                return register;
            }
            set
            {
                register = value;
            }
        }
    }
}
