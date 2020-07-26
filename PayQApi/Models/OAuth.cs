namespace PayQApi.Models
{
    /// <summary>
    /// <see cref="https://payquickerv101152018.docs.apiary.io/#reference/oauth/get-token/get-token"/>
    /// </summary>
    public class OAuth
    {
        /// <summary>
        /// <para><b>client_credentials</b></para>
        /// </summary>
        public string Grant_type { get; set; }

        /// <summary>
        /// <para><b>api useraccount_balance useraccount_debit etc</b></para>
        /// scopes of current token using space as a separator between scopes.
        /// </summary>
        public string Scope { get; set; }
    }

    public class OAuthResponse
    {
        /// <summary>
        /// <para><b>ex. eyJhbGciOiJIUzI1NiJ9.e30.XmNK3GpH3Ys_7wsYBfq4C3M6goz71I7dTgUkuIa5lyQ</b></para>
        /// OAuth2 Reference Access Token
        /// </summary>
        public string Access_token { get; set; }

        /// <summary>
        /// ex. 3600
        /// </summary>
        public int Expires_in { get; set; }

        /// <summary>
        /// Bearer
        /// </summary>
        public string Token_type { get; set; }
    }
}