﻿using System;
using AuthorizeNet.Api.Contracts.V1;
using AuthorizeNet.Api.Controllers;
using AuthorizeNet.Api.Controllers.Bases;

namespace AuthorizeNET.CustomerProfiles
{
    class CreateCustomerShippingAddress
    {
        public static void Run(string apiLoginId, string apiTransactionKey)
        {
            Console.WriteLine("CreateCustomerShippingAddress Sample");
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.RunEnvironment = AuthorizeNet.Environment.SANDBOX;
            ApiOperationBase<ANetApiRequest, ANetApiResponse>.MerchantAuthentication = new merchantAuthenticationType()
            {
                name            = apiLoginId,
                ItemElementName = ItemChoiceType.transactionKey,
                Item            = apiTransactionKey,
            };

            customerAddressType officeAddress = new customerAddressType();
            officeAddress.firstName = "Chris";
            officeAddress.lastName = "brown";
            officeAddress.address = "1200 148th AVE NE";
            officeAddress.city = "NorthBend";
            officeAddress.zip = "92101";


            var request = new createCustomerShippingAddressRequest
            {
                customerProfileId = "10000",
                address = officeAddress,
            };

            //Prepare Request
            var controller = new createCustomerShippingAddressController(request);
            controller.Execute();

             //Send Request to EndPoint
            createCustomerShippingAddressResponse response = controller.GetApiResponse(); 
            if (response != null && response.messages.resultCode == messageTypeEnum.Ok)
            {
                if (response.messages.message != null)
                {
                    Console.WriteLine("Success, customerAddressId : " + response.customerAddressId);
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
