using System;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;

namespace AuthorizeNET.TransactionReporting
{
    class GetTransactionDetails
    {
      public static void Run(string apiLoginId, String apiTransactionKey)
      {
          Console.WriteLine("Get transaction details sample");

          ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
          // define the merchant information (authentication / transaction id)
          ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
          {
              name = apiLoginId,
              ItemElementName = ItemChoiceType.transactionKey,
              Item = apiTransactionKey,
          };

          // unique transaction id
          string transactionId = "2238300325";

          var request = new getTransactionDetailsRequest();
          request.transId = transactionId;

          // instantiate the controller that will call the service
          var controller = new getTransactionDetailsController(request);
          controller.Execute();

          // get the response from the service (errors contained if any)
          var response = controller.GetApiResponse();


          if (response.messages.resultCode == messageTypeEnum.Ok)
          {
              if (response.transaction == null) return;
              Console.WriteLine("Transaction Id: {0}", response.transaction.transId);
              Console.WriteLine("Transaction type: {0}", response.transaction.transactionType);
              Console.WriteLine("Transaction status: {0}", response.transaction.transactionStatus);
              Console.WriteLine("Transaction auth amount: {0}", response.transaction.authAmount);
              Console.WriteLine("Transaction settle amount: {0}", response.transaction.settleAmount);
          }
          else
          {
              Console.WriteLine("Error: " + response.messages.message[0].code + "  " +
                                response.messages.message[0].text);
          }
      }
    }
}
