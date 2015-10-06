using System;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;

namespace AuthorizeNET.TransactionReporting
{
    class GetBatchStatistics
    {
        public static void Run(string apiLoginId, string apiTransactionKey)
        {
            Console.WriteLine("Get batch statistics sample");

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
            // define the merchant information (authentication / transaction id)
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = apiLoginId,
                ItemElementName = ItemChoiceType.transactionKey,
                Item = apiTransactionKey,
            };


            // unique batch id
#pragma warning disable 219
            string batchId = "4532808";
#pragma warning restore 219
            var request = new getBatchStatisticsRequest();

            // instantiate the controller that will call the service
            var controller = new getBatchStatisticsController(request);
            controller.Execute();

            // get the response from the service (errors contained if any)
            var response = controller.GetApiResponse();

            if (response.messages.resultCode == messageTypeEnum.Ok)
            {
                if (response.batch == null) return;
                Console.WriteLine("Batch Id: {0}", response.batch.batchId);
                Console.WriteLine("Batch settled on (UTC): {0}", response.batch.settlementTimeUTC);
                Console.WriteLine("Batch settled on (Local): {0}", response.batch.settlementTimeLocal);
                Console.WriteLine("Batch settlement state: {0}", response.batch.settlementState);
                Console.WriteLine("Batch payment method: {0}", response.batch.paymentMethod);
                foreach (var item in response.batch.statistics)
                {
                    Console.WriteLine(
                        "Account type: {0} Charge amount: {1} Charge count: {2} Refund amount: {3} Refund count: {4} Void count: {5} Decline count: {6} Error amount: {7}",
                        item.accountType, item.chargeAmount, item.chargeCount, item.refundAmount, item.refundCount,
                        item.voidCount, item.declineCount, item.errorCount);
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