using System;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;

namespace AuthorizeNET.CustomerProfiles
{
    class DeleteCustomerProfile
    {
       public static void Run(string apiLoginId, string apiTransactionKey)
        {
            Console.WriteLine("DeleteCustomerProfile Sample");
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name            = apiLoginId,
                ItemElementName = ItemChoiceType.transactionKey,
                Item            = apiTransactionKey,
            };

            //please update the subscriptionId according to your sandbox credentials
            var request = new deleteCustomerProfileRequest
            {
                customerProfileId = "10000"
            };

            //Prepare Request
            var controller = new deleteCustomerProfileController(request);
            controller.Execute();

             //Send Request to EndPoint
            deleteCustomerProfileResponse response = controller.GetApiResponse(); 
            if (response != null && response.messages.resultCode == messageTypeEnum.Ok)
            {
                if (response.messages.message != null)
                {
                    Console.WriteLine("Success, ResultCode : " + response.messages.resultCode.ToString());
                }
            }
            else
            {
                if (response != null)
                    Console.WriteLine("Error: " + response.messages.message[0].code + "  " + response.messages.message[0].text);
            }

        }
    }
}
