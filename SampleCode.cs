using System;
using System.Collections.Generic;
using AuthorizeNET.CustomerProfiles;
using AuthorizeNET.PaymentTransactions;
using AuthorizeNET.PaypalExpressCheckout;
using AuthorizeNET.RecurringBilling;
using AuthorizeNET.TransactionReporting;
using AuthorizeNET.VisaCheckout;

namespace AuthorizeNET
{
    //===============================================================================================
    //
    //  NOTE:  If you add a new sample update the following methods here:
    //
    //              ShowMethods()   -  Add the method name
    //              RunMethod(String methodName)   -   Update the switch statement to run the method
    //
    //===============================================================================================
    class SampleCode
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                SelectMethod();
            }
            else if (args.Length == 1)
            {
                RunMethod(args[0]);
                return;
            }
            else
            {
                ShowUsage();
            }

            Console.WriteLine("");
            Console.Write("Press <Return> to finish ...");
            Console.ReadLine();
           
        }

        private static void ShowUsage()
        {
            Console.WriteLine("Usage : SampleCode [CodeSampleName]");
            Console.WriteLine("");
            Console.WriteLine("Run with no parameter to select a method.  Otherwise pass a method name.");
            Console.WriteLine("");
            Console.WriteLine("Code Sample Names: ");
            ShowMethods();
            Console.WriteLine("Code Sample Names: ");

        }

        private static void SelectMethod()
        {
            Console.WriteLine("Code Sample Names: ");
            Console.WriteLine("");
            ShowMethods();
            Console.WriteLine("");
            Console.Write("Type a sample name & then press <Return> : ");
            RunMethod(Console.ReadLine());
        }

        private static void ShowMethods()
        {
            var methodTypes = GetMethodTypes();
            methodTypes.ForEach(x=> Console.WriteLine($"\t{x}"));
        }

        private static List<string> GetMethodTypes()
        {
            List<string> methodTypes = new List<string>();
            methodTypes.Add("ChargeCreditCard");
            methodTypes.Add("CaptureOnly");
            methodTypes.Add("AuthorizeCreditCard");
            methodTypes.Add("CapturePreviouslyAuthorizedAmount");
            methodTypes.Add("CaptureFundsAuthorizedThroughAnotherChannel");
            methodTypes.Add("Refund");
            methodTypes.Add("Void");
            methodTypes.Add("DebitBankAccount");
            methodTypes.Add("CreditBankAccount");
            methodTypes.Add("ChargeCustomerProfile");
            methodTypes.Add("ChargeTokenizedCard");
            methodTypes.Add("CreateAnApplePayTransaction");
            methodTypes.Add("DecryptVisaCheckoutData");
            methodTypes.Add("CreateVisaCheckoutTransaction");
            methodTypes.Add("PayPalVoid");
            methodTypes.Add("PayPalAuthorizeCapture");
            methodTypes.Add("PayPalAuthorizeCaptureContinue");
            methodTypes.Add("PayPalAuthorizeOnly");
            methodTypes.Add("PayPalCredit");
            methodTypes.Add("PayPalGetDetails");
            methodTypes.Add("PayPalPriorAuthorizationCapture");
            methodTypes.Add("CancelSubscription");
            methodTypes.Add("CreateSubscription");
            methodTypes.Add("GetSubscriptionList");
            methodTypes.Add("GetSubscriptionStatus");
            methodTypes.Add("GetUnsettledTransactionList");
            methodTypes.Add("UpdateSubscription");
            methodTypes.Add("CreateCustomerProfile");
            methodTypes.Add("CreateCustomerPaymentProfile");
            methodTypes.Add("CreateCustomerShippingAddress");
            methodTypes.Add("DeleteCustomerProfile");
            methodTypes.Add("DeleteCustomerPaymentProfile");
            methodTypes.Add("DeleteCustomerShippingAddress");
            methodTypes.Add("ValidateCustomerPaymentProfile");
            methodTypes.Add("UpdateCustomerShippingAddress");
            methodTypes.Add("UpdateCustomerProfile");
            methodTypes.Add("UpdateCustomerPaymentProfile");
            methodTypes.Add("GetCustomerShippingAddress");
            methodTypes.Add("GetCustomerProfileId");
            methodTypes.Add("GetCustomerProfile");
            methodTypes.Add("GetCustomerPaymentProfile");
            methodTypes.Add("DeleteCustomerShippingAddress");
            methodTypes.Add("DeleteCustomerProfile");
            methodTypes.Add("DeleteCustomerPaymentProfile");
            methodTypes.Add("CreateCustomerShippingAddress");
            methodTypes.Add("CreateCustomerProfileFromTransaction");
            methodTypes.Add("GetBatchStatistics");
            methodTypes.Add("GetSettledBatchList");
            methodTypes.Add("GetTransactionDetails");
            methodTypes.Add("GetTransactionList");
            return methodTypes;
        }

        private static void RunMethod(string methodName)
        {
            // These are default transaction keys.
            // You can create your own keys in seconds by signing up for a sandbox account here: https://developer.authorize.net/sandbox/
            string apiLoginId = "5KP3u95bQpv";
            string transactionKey = "4Ktq966gC55GAX7S";

            string transactionAmount;
            string transactionId = string.Empty;

            switch (methodName)
            {
                case "ValidateCustomerPaymentProfile":
                    ValidateCustomerPaymentProfile.Run(apiLoginId, transactionKey);
                    break;
                case "UpdateCustomerShippingAddress":
                    UpdateCustomerShippingAddress.Run(apiLoginId, transactionKey);
                    break;
                case "UpdateCustomerProfile":
                    UpdateCustomerProfile.Run(apiLoginId, transactionKey);
                    break;
                case "UpdateCustomerPaymentProfile":
                    UpdateCustomerPaymentProfile.Run(apiLoginId, transactionKey);
                    break;
                case "GetCustomerShippingAddress":
                    GetCustomerShippingAddress.Run(apiLoginId, transactionKey);
                    break;
                case "GetCustomerProfileIds":
                    GetCustomerProfileIds.Run(apiLoginId, transactionKey);
                    break;
                case "GetCustomerProfile":
                    GetCustomerProfile.Run(apiLoginId, transactionKey);
                    break;
                case "GetCustomerPaymentProfile":
                    GetCustomerPaymentProfile.Run(apiLoginId, transactionKey);
                    break;
                case "DeleteCustomerShippingAddress":
                    DeleteCustomerShippingAddress.Run(apiLoginId, transactionKey);
                    break;
                case "DeleteCustomerProfile":
                    DeleteCustomerProfile.Run(apiLoginId, transactionKey);
                    break;
                case "DeleteCustomerPaymentProfile":
                    DeleteCustomerPaymentProfile.Run(apiLoginId, transactionKey);
                    break;
                case "CreateCustomerShippingAddress":
                    CreateCustomerShippingAddress.Run(apiLoginId, transactionKey);
                    break;
                case "CreateCustomerProfileFromTransaction":
                    CreateCustomerProfileFromTransaction.Run(apiLoginId, transactionKey);
                    break;
                case "GetTransactionDetails":
                    GetTransactionDetails.Run(apiLoginId, transactionKey);
                    break;
                case "GetTransactionList":
                    GetTransactionList.Run(apiLoginId, transactionKey);
                    break;
                //case "CreateAnApplePayTransaction":
                //    CreateAnApplePayTransaction.Run(apiLoginId, transactionKey);
                //    break;
                case "DecryptVisaCheckoutData":
                    DecryptVisaCheckoutData.Run(apiLoginId, transactionKey);
                    break;
                case "CreateVisaCheckoutTransaction":
                    CreateVisaCheckoutTransaction.Run(apiLoginId, transactionKey);
                    break;
                case "ChargeCreditCard":
                    ChargeCreditCard.Run(apiLoginId, transactionKey);
                    break;
                case "CaptureOnly":
                    CaptureOnly.Run(apiLoginId, transactionKey);
                    break;
                case "CapturePreviouslyAuthorizedAmount":
                    Console.WriteLine("Enter An Transaction Amount");
                    transactionAmount = Console.ReadLine();

                    Console.WriteLine("Enter An Transaction ID");
                    transactionId = Console.ReadLine();

                    CapturePreviouslyAuthorizedAmount.Run(apiLoginId, transactionKey, Convert.ToDecimal( transactionAmount ), transactionId);
                    break;
                case "CaptureFundsAuthorizedThroughAnotherChannel":
                    CaptureFundsAuthorizedThroughAnotherChannel.Run(apiLoginId, transactionKey);
                    break;
                case "AuthorizeCreditCard":
                    AuthorizeCreditCard.Run(apiLoginId, transactionKey);
                    break;
                case "Refund":
                    Console.WriteLine("Enter An Transaction Amount");
                    transactionAmount = Console.ReadLine();

                    Console.WriteLine("Enter An Transaction ID");
                    transactionId = Console.ReadLine();

                    RefundTransaction.Run(apiLoginId, transactionKey, Convert.ToDecimal( transactionAmount ), transactionId);
                    break;
                case "Void":
                    Console.WriteLine("Enter An Transaction ID");
                    transactionId = Console.ReadLine();

                    VoidTransaction.Run(apiLoginId, transactionKey, transactionId);
                    break;
                case "DebitBankAccount":
                    DebitBankAccount.Run(apiLoginId, transactionKey);
                    break;
                case "CreditBankAccount":
                    Console.WriteLine("Enter An Transaction ID");
                    transactionId = Console.ReadLine();

                    CreditBankAccount.Run(apiLoginId, transactionKey, transactionId);
                    break;
                case "ChargeCustomerProfile":
                    ChargeCustomerProfile.Run(apiLoginId, transactionKey);
                    break;
                case "ChargeTokenizedCard":
                    ChargeTokenizedCreditCard.Run(apiLoginId, transactionKey);
                    break;
                case "PayPalVoid":
                    PayPalVoid.Run(apiLoginId, transactionKey, transactionId);
                    break;
                case "PayPalAuthorizeCapture":
                    PayPalAuthorizeCapture.Run(apiLoginId, transactionKey);
                    break;
                case "PayPalAuthorizeCaptureContinue":
                    PayPalAuthorizeCaptureContinue.Run(apiLoginId, transactionKey, transactionId);
                    break;
                case "PayPalAuthorizeOnly":
                    PayPalAuthorizeOnly.Run(apiLoginId, transactionKey);
                    break;
                case "PayPalAuthorizeOnlyContinue":
                    PayPalAuthorizeCaptureContinue.Run(apiLoginId, transactionKey, transactionId);
                    break;
                case "PayPalCredit":
                    PayPalCredit.Run(apiLoginId, transactionKey, transactionId);
                    break;
                case "PayPalGetDetails":
                    PayPalGetDetails.Run(apiLoginId, transactionKey, transactionId);
                    break;
                case "PayPalPriorAuthorizationCapture":
                    PayPalPriorAuthorizationCapture.Run(apiLoginId, transactionKey, transactionId);
                    break;
                case "CancelSubscription":
                    CancelSubscription.Run(apiLoginId, transactionKey);
                    break;
                case "CreateSubscription":
                    CreateSubscription.Run(apiLoginId, transactionKey);
                    break;
                case "GetSubscriptionList":
                    GetListSubscriptions.Run(apiLoginId, transactionKey);
                    break;
                case "GetSubscriptionStatus":
                    GetSubscriptionStatus.Run(apiLoginId, transactionKey);
                    break;
                case "UpdateSubscription":
                    UpdateSubscription.Run(apiLoginId, transactionKey);
                    break;
                case "CreateCustomerProfile":
                    CreateCustomerProfile.Run(apiLoginId, transactionKey);
                    break;
                case "CreateCustomerPaymentProfile":
                    CreateCustomerPaymentProfile.Run(apiLoginId, transactionKey);
                    break;
                case "GetUnsettledTransactionList":
                    GetUnsettledTransactionList.Run(apiLoginId, transactionKey);
                    break;
                case "GetBatchStatistics":
                    GetBatchStatistics.Run(apiLoginId, transactionKey);
                    break;
                case "GetSettledBatchList":
                    GetSettledBatchList.Run(apiLoginId,transactionKey);
                     break;
                default:
                    ShowUsage();
                    break;
            }
        }

    }
}
