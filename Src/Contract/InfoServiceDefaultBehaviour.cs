﻿#if !NETSTANDARD
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace SolarWinds.InformationService.Contract2
{
    class InfoServiceDefaultBehaviour : IEndpointBehavior, IClientMessageInspector
    {
        private static readonly IDictionary<string, object> _defaultHeaderValue = new Dictionary<string, object>()
        {
            { "IsBase64EncodingAccepted", true }
        };

        #region IEndpointBehavior Members

        public void AddBindingParameters(ServiceEndpoint endpoint, System.ServiceModel.Channels.BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(this);
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            throw new NotImplementedException();
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }

#endregion

#region IClientMessageInspector Members

        public void AfterReceiveReply(ref System.ServiceModel.Channels.Message reply, object correlationState)
        {
        }

        public object BeforeSendRequest(ref System.ServiceModel.Channels.Message request, System.ServiceModel.IClientChannel channel)
        {
            foreach (var kv in _defaultHeaderValue)
            {
                if (request.Headers.FindHeader(kv.Key, Constants.Namespace) == -1)
                {
                    request.Headers.Add(MessageHeader.CreateHeader(kv.Key, Constants.Namespace, kv.Value));
                }
            }

            return null;
        }

#endregion
    }
}
#endif
