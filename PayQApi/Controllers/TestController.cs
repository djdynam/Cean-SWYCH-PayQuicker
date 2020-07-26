using Newtonsoft.Json;
using PayQApi.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace PayQApi.Controllers
{
    public class TestController : Controller
    {
        // GET: test
        private API API => new API();

        public string Test1()
        {
            var req = new List<Invitations>{
                new Invitations{
                        FundingAccountPublicId = "14839d3f5e4442bee4458ef35bc68600",
                        UserNotificationEmailAddress = "john.doe@gmail.com",
                        UserCompanyAssignedUniqueKey = "EMP001",
                        IssuePlasticCard = true,
                        NotifyUser = true,
                        MiddleName= "Adam",
                        FirstName = "John",
                        LastName = "Doe",
                        Addresses = new List<Address>{
                        new Address {
                        Type = "addressType_Residential",
                        StreetAddress1 = "10 Mocking Bird Lane",
                        StreetAddress2 = "Suite 1A",
                        City = "Rochester",
                        Region = "NY",
                        PostalCode = "12345",
                        Country = "USA"
                        }
                    }
                }
            };

            var res = API.SendInvitations(req);
            return View(req, res);
        }

        public string Test2()
        {
            var req = new SendPayments
            {
                ScheduleDate = "2020-02-20 12:00",
                Payments = new List<Payment>{
                    new Payment{
                        FundingAccountPublicId = "1e0cf2a9d4da44778c2dbfba7db62f63",
                        IssuePlasticCard = true,
                        Monetary = new Monetary{
                            Amount = 23.32m
                        },
                        AccountingId = "payment01234",
                        UserCompanyAssignedUniqueKey = "EMP0111",
                        UserNotificationEmailAddress = "john.doe@gmail.com",
                        ExpirationDate = "2021-06-22"
                    }
                }
            };
            var res = API.SendPayment(req);
            return View(req, res);
        }

        public string Test3()
        {
            var req = new OAuth
            {
                Grant_type = "",
                Scope = ""
            };
            var res = API.SendGetToken(req);
            return View(req, res);
        }

        public string View(object req, object res) => $"<b>REQUEST</b><br>{JsonConvert.SerializeObject(req)}<br><br><b>RESPOND</b><br>{JsonConvert.SerializeObject(res)}<br><br>";
    }
}
