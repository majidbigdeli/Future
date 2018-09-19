using System;
using Majid;
using Majid.Authorization;
using Majid.Dependency;
using Majid.UI;

namespace Future.Authorization
{
    public class MajidLoginResultTypeHelper : MajidServiceBase, ITransientDependency
    {
        public MajidLoginResultTypeHelper()
        {
            LocalizationSourceName = FutureConsts.LocalizationSourceName;
        }

        public Exception CreateExceptionForFailedLoginAttempt(MajidLoginResultType result, string usernameOrEmailAddress, string tenancyName)
        {
            switch (result)
            {
                case MajidLoginResultType.Success:
                    return new Exception("Don't call this method with a success result!");
                case MajidLoginResultType.InvalidUserNameOrEmailAddress:
                case MajidLoginResultType.InvalidPassword:
                    return new UserFriendlyException(L("LoginFailed"), L("InvalidUserNameOrPassword"));
                case MajidLoginResultType.InvalidTenancyName:
                    return new UserFriendlyException(L("LoginFailed"), L("ThereIsNoTenantDefinedWithName{0}", tenancyName));
                case MajidLoginResultType.TenantIsNotActive:
                    return new UserFriendlyException(L("LoginFailed"), L("TenantIsNotActive", tenancyName));
                case MajidLoginResultType.UserIsNotActive:
                    return new UserFriendlyException(L("LoginFailed"), L("UserIsNotActiveAndCanNotLogin", usernameOrEmailAddress));
                case MajidLoginResultType.UserEmailIsNotConfirmed:
                    return new UserFriendlyException(L("LoginFailed"), L("UserEmailIsNotConfirmedAndCanNotLogin"));
                case MajidLoginResultType.LockedOut:
                    return new UserFriendlyException(L("LoginFailed"), L("UserLockedOutMessage"));
                default: // Can not fall to default actually. But other result types can be added in the future and we may forget to handle it
                    Logger.Warn("Unhandled login fail reason: " + result);
                    return new UserFriendlyException(L("LoginFailed"));
            }
        }

        public string CreateLocalizedMessageForFailedLoginAttempt(MajidLoginResultType result, string usernameOrEmailAddress, string tenancyName)
        {
            switch (result)
            {
                case MajidLoginResultType.Success:
                    throw new Exception("Don't call this method with a success result!");
                case MajidLoginResultType.InvalidUserNameOrEmailAddress:
                case MajidLoginResultType.InvalidPassword:
                    return L("InvalidUserNameOrPassword");
                case MajidLoginResultType.InvalidTenancyName:
                    return L("ThereIsNoTenantDefinedWithName{0}", tenancyName);
                case MajidLoginResultType.TenantIsNotActive:
                    return L("TenantIsNotActive", tenancyName);
                case MajidLoginResultType.UserIsNotActive:
                    return L("UserIsNotActiveAndCanNotLogin", usernameOrEmailAddress);
                case MajidLoginResultType.UserEmailIsNotConfirmed:
                    return L("UserEmailIsNotConfirmedAndCanNotLogin");
                default: // Can not fall to default actually. But other result types can be added in the future and we may forget to handle it
                    Logger.Warn("Unhandled login fail reason: " + result);
                    return L("LoginFailed");
            }
        }
    }
}
