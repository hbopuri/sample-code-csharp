using System;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;

namespace AuthorizeNET.CustomerProfiles
{
    class GetCustomerProfileIds
    {
        public static void Run(string apiLoginId, string apiTransactionKey)
        {
            Console.WriteLine("Get Customer Profile Id sample");

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
            // define the merchant information (authentication / transaction id)
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = apiLoginId,
                ItemElementName = ItemChoiceType.transactionKey,
                Item = apiTransactionKey,
            };

            var request = new getCustomerProfileIdsRequest();

            // instantiate the controller that will call the service
            var controller = new getCustomerProfileIdsController(request);
            controller.Execute();

            // get the response from the service (errors contained if any)
            var response = controller.GetApiResponse();

            if (response.messages.resultCode == messageTypeEnum.Ok)
            {
                Console.WriteLine(response.messages.message[0].text);
                Console.WriteLine("Customer Profile Ids: ");
                foreach (var id in response.ids)
                {
                    Console.WriteLine(id);
                }
            }
            else
            {
                Console.WriteLine("Error: " + response.messages.message[0].code + "  " +
                                  response.messages.message[0].text);
            }
        }
    }
}
