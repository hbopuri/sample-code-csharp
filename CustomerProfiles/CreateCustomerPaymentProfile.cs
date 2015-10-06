﻿using System;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;

namespace AuthorizeNET.CustomerProfiles
{
    class CreateCustomerPaymentProfile
    {
        public static void Run(string apiLoginId, string apiTransactionKey)
        {
            Console.WriteLine("CreateCustomerPaymentProfile Sample");
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name            = apiLoginId,
                ItemElementName = ItemChoiceType.transactionKey,
                Item            = apiTransactionKey,
            };

            var bankAccount = new bankAccountType
            {
                accountNumber = "01245524321",
                routingNumber = "000000204",
                accountType = bankAccountTypeEnum.checking,
                echeckType = echeckTypeEnum.WEB,
                nameOnAccount = "test",
                bankName = "Bank Of America"
            };

            paymentType echeck = new paymentType {Item = bankAccount};

            customerPaymentProfileType echeckPaymentProfile = new customerPaymentProfileType();
            echeckPaymentProfile.payment = echeck;

            var request = new createCustomerPaymentProfileRequest
            {
                customerProfileId = "10000",
                paymentProfile = echeckPaymentProfile,
                validationMode = validationModeEnum.none
            };

            //Prepare Request
            var controller = new createCustomerPaymentProfileController(request);
            controller.Execute();

             //Send Request to EndPoint
            createCustomerPaymentProfileResponse response = controller.GetApiResponse(); 
            if (response != null && response.messages.resultCode == messageTypeEnum.Ok)
            {
                if (response.messages.message != null)
                {
                    Console.WriteLine("Success, createCustomerPaymentProfileID : " + response.customerPaymentProfileId);
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
