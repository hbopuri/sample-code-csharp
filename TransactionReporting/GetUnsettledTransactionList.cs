﻿using System;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;

namespace AuthorizeNET.TransactionReporting
{
    class GetUnsettledTransactionList
    {
        public static void Run(string apiLoginId, string apiTransactionKey)
        {
            Console.WriteLine("Get unsettled transaction list sample");

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
            // define the merchant information (authentication / transaction id)
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name = apiLoginId,
                ItemElementName = ItemChoiceType.transactionKey,
                Item = apiTransactionKey,
            };

            var request = new getUnsettledTransactionListRequest();

            // instantiate the controller that will call the service
            var controller = new getUnsettledTransactionListController(request);
            controller.Execute();

            // get the response from the service (errors contained if any)
            var response = controller.GetApiResponse();

            if (response.messages.resultCode == messageTypeEnum.Ok)
            {
                if (response.transactions == null) return;
                foreach (var item in response.transactions)
                {
                    Console.WriteLine("Transaction Id: {0} was submitted on {1}", item.transId,
                        item.submitTimeLocal);
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