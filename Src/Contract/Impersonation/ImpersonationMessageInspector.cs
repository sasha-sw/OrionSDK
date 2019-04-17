using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace SolarWinds.InformationService.Contract2.Impersonation
{
    class ImpersonationMessageInspector : IClientMessageInspector
#if !NETSTANDARD
, IDispatchMessageInspector
#endif
    {
        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            ImpersonationContext impersonationContext = ImpersonationContext.GetCurrentContext();
            if (impersonationContext != null)
            {
                var impersonationHeader = new ImpersonationHeader {TargetUsername = impersonationContext.TargetUsername};
                MessageHeader header = MessageHeader.CreateHeader(Constants.HeaderName, Constants.Namespace, impersonationHeader);
                request.Headers.Add(header);
            }
            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }

#if !NETSTANDARD
        public object AfterReceiveRequest(ref Message request, IClientChannel channel, InstanceContext instanceContext)
        {
            // Don't actually need to do anything on the server side. This header is dealt with by the IAuthorizationPolicy.
            return null;
        }
#endif

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
        }
    }
}
