using System.Collections.Generic;

namespace PayQApi.Models
{
    /// <summary>
    /// Use this API to send an invitation from the designated funding account, allowing the user to create an account in the funding accounts currency.
    /// </summary>
    public class Invitations : UserDetails
    {/// <summary>
     /// <para><b>Required</b></para>
     /// Funding account which the payment is sourced from.
     /// <see cref="https://payquickerv101152018.docs.apiary.io/#reference/invitations/send-invitations/send-invitations?console=1"/>
     /// </summary>
        public string FundingAccountPublicId { get; set; }

        /// <summary>
        /// If configured at the company funding account level this option allows for the issuance of a branded/personalized VISA/MasterCard upon payment, paid for by the inviting company. This is often done in the context of a payment if business rules stipulate the ordering of a card is based on having earned a certain amount prior to issuance.
        /// </summary>
        public bool IssuePlasticCard { get; set; }

        /// <summary>
        /// <para><b>Required</b></para>
        /// Immutable value established on invitation which represents the user only the platform for all API calls. This value is unique within a tenant.
        /// </summary>
        public string UserCompanyAssignedUniqueKey { get; set; }

        /// <summary>
        /// <para><b>Required</b></para>
        /// Email address of the user being paid. Email address is provided on every payment and allows the framework to self-heal (email addresses changed outside of the PayQuicker platform) as well as proactively notify the paying company if a user updates their email address within the platform if desired (callback URI or report).
        /// </summary>
        public string UserNotificationEmailAddress { get; set; }

        /// <summary>
        /// If planning on delivering the invitation by alternate means (custom email, hyperlink in website, etc.), you can disable the automatic email notification by PayQuicker of the invitation creation.
        /// </summary>
        public bool NotifyUser { get; set; }

        public List<Address> Addresses { get; set; }
    }

    public class InvitationsResponse
    {
        /// <summary>
        /// Globally unique invitation key which can be emailed to the user or utilized in the back office for registration.
        /// </summary>
        public string InvitationKey { get; set; }

        public string InvitationStatus { get; set; }

        /// <summary>
        /// UTC datetime when the invitation was created.
        /// </summary>
        public string DateInvited { get; set; }

        public InvitationsRegistrationDetails RegistrationDetails { get; set; }
    }

    public class InvitationsRegistrationDetails
    {
        public UserDetails UserDetails { get; set; }
        public List<Address> Addresses { get; set; }
        public bool IssuePlasticCard { get; set; }
        public string FundingAccountPublicId { get; set; }
    }

    public class UserDetails
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}