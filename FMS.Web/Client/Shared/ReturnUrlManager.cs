namespace FMS.Web.Client.Shared
{
    public class ReturnUrlManager
    {
        private string _returnUrl;

        public string ReturnUrl 
        {
            get
            {
                string returnUrl = _returnUrl;
                _returnUrl = null;

                return returnUrl;
            } 
            set => _returnUrl = value; 
        }
    }
}
