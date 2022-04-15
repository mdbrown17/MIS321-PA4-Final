namespace api.Models
{
    public class ConnectionString
    {
        public string cs {get; set;}

        public ConnectionString()
        {
            string server = "z3iruaadbwo0iyfp.cbetxkdyhwsb.us-east-1.rds.amazonaws.com";
            string database = "ntn2tkrm3kwxdpc0";
            string port = "3306";
            string userName = "prxqr46g78q7y5er";
            string password = "r3g3v2095hp7lnt5";

            cs = $@"server = {server}; user = {userName}; database = {database}; port = {port}; password = {password}";
        }
    }
}