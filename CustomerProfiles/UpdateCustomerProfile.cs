using System;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;

namespace AuthorizeNET.CustomerProfiles
{
    class UpdateCustomerProfile
    {
        public static void Run(string apiLoginId, string apiTransactionKey)
        {
            Console.WriteLine("Update customer profile sample");

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
            // define the merchant information (authentication / transaction id)
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = apiLoginId,
                ItemElementName = ItemChoiceType.transactionKey,
                Item = apiTransactionKey,
            };

            var profile = new customerProfileExType
            {
                merchantCustomerId = "custId123",
                description = "some description",
                email = "newaddress@example.com",
                customerProfileId = "36605093"
            };

            var request = new updateCustomerProfileRequest();
            request.profile = profile;

            // instantiate the controller that will call the service
            var controller = new updateCustomerProfileController(request);
            controller.Execute();

            // get the response from the service (errors contained if any)
            var response = controller.GetApiResponse();

            if (response.messages.resultCode == messageTypeEnum.Ok)
            {
                Console.WriteLine(response.messages.message[0].text);
            }
            else
            {
                Console.WriteLine("Error: " + response.messages.message[0].code + "  " +
                                  response.messages.message[0].text);
            }
        }
    }
}
