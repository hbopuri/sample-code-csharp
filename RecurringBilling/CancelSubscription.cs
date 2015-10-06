﻿using System;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;

namespace AuthorizeNET.RecurringBilling
{
    class CancelSubscription
    {
        public static void Run(string apiLoginId, string apiTransactionKey)
        {
            Console.WriteLine("Cancel Subscription Sample");

            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name            = apiLoginId,
                ItemElementName = ItemChoiceType.transactionKey,
                Item            = apiTransactionKey,
            };

            //Please change the subscriptionId according to your request
            var request = new ARBCancelSubscriptionRequest { subscriptionId = "100748" };
            var controller = new ARBCancelSubscriptionController(request);                          // instantiate the contoller that will call the service
            controller.Execute();

            ARBCancelSubscriptionResponse response = controller.GetApiResponse();                   // get the response from the service (errors contained if any)

            //validate
            if (response != null && response.messages.resultCode == messageTypeEnum.Ok)
            {
                if (response.messages.message != null)
                {
                    Console.WriteLine("Success, Subscription Cancelled With RefID : " + response.refId);
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
