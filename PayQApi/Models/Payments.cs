using System.Collections.Generic;

namespace PayQApi.Models
{
    public class SendPayments
    {
        /// <summary>
        /// <see cref="https://private-anon-5bd206b998-payquickerv101152018.apiary-mock.com/api/v1/companies/accounts/payments"/>
        /// </summary>
        public List<Payment> Payments { get; set; }

        /// <summary>
        /// UTC datetime after which the payment(s) will process and funds will transfer
        /// </summary>
        public string ScheduleDate { get; set; }
    }

    public class Payment
    {
        /// <summary>
        /// <para><b>Required</b></para>
        /// Funding account which the payment is sourced from.
        /// </summary>
        public string FundingAccountPublicId { get; set; }

        /// <summary>
        /// If configured at the company funding account level this option allows for the issuance of a branded/personalized VISA/MasterCard upon payment, paid for by the inviting company. This is often done in the context of a payment if business rules stipulate the ordering of a card is based on having earned a certain amount prior to issuance.
        /// </summary>
        public bool IssuePlasticCard { get; set; }

        public Monetary Monetary { get; set; }

        /// <summary>
        /// Company provided, free form text property which rules defined in the company configuration determine whether a payment can be processed (i.e. disallowing duplicates globally, per funding account, per user, etc.).
        /// </summary>
        public string AccountingId { get; set; }

        /// <summary>
        /// Immutable value established on invitation which represents the user only the platform for all API calls. This value is unique within a tenant.
        /// </summary>
        public string UserCompanyAssignedUniqueKey { get; set; }

        /// <summary>
        /// Email address of the user being paid. Email address is provided on every payment and allows the framework to self-heal (email addresses changed outside of the PayQuicker platform) as well as proactively notify the paying company if a user updates their email address within the platform if desired (callback URI or report).
        /// </summary>
        public string UserNotificationEmailAddress { get; set; }

        /// <summary>
        /// Date (expressed as YYYY-MM-DD or MM-DD-YYYY) to cancel the payment if it is still scheduled or pending. A pending payment that is cancelled will result in the funds being returned from the pending funds account back to the funding account. This enables the company to automatically recover funds for payments that have not completed typically due to the recipient not completing enrollment for a financial account.
        /// </summary>
        public string ExpirationDate { get; set; }
    }

    public class Monetary
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public string Language { get; set; }
        public string FormattedAmount { get; set; }
    }

    public class PaymentResponse
    {
        public List<PaymentRespose> Payments { get; set; }
        public string ScheduleDate { get; set; }
    }

    public class PaymentRespose
    {
        public string TransactionPublicId { get; set; }
        public string AuthDate { get; set; }
        public Monetary Monetary { get; set; }
    }
}