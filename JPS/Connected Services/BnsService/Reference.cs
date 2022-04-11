﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BnsService
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BnsService.IBNS")]
    public interface IBNS
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBNS/DeductBNS", ReplyAction="http://tempuri.org/IBNS/DeductBNSResponse")]
        System.Threading.Tasks.Task<float> DeductBNSAsync(string cn, float amt);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBNS/CheckBNS", ReplyAction="http://tempuri.org/IBNS/CheckBNSResponse")]
        System.Threading.Tasks.Task<bool> CheckBNSAsync(string cn);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IBNS/CheckAmt", ReplyAction="http://tempuri.org/IBNS/CheckAmtResponse")]
        System.Threading.Tasks.Task<bool> CheckAmtAsync(string cn, float amt);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public interface IBNSChannel : BnsService.IBNS, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3-preview3.21351.2")]
    public partial class BNSClient : System.ServiceModel.ClientBase<BnsService.IBNS>, BnsService.IBNS
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public BNSClient() : 
                base(BNSClient.GetDefaultBinding(), BNSClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IBNS.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BNSClient(EndpointConfiguration endpointConfiguration) : 
                base(BNSClient.GetBindingForEndpoint(endpointConfiguration), BNSClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BNSClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(BNSClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BNSClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(BNSClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public BNSClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<float> DeductBNSAsync(string cn, float amt)
        {
            return base.Channel.DeductBNSAsync(cn, amt);
        }
        
        public System.Threading.Tasks.Task<bool> CheckBNSAsync(string cn)
        {
            return base.Channel.CheckBNSAsync(cn);
        }
        
        public System.Threading.Tasks.Task<bool> CheckAmtAsync(string cn, float amt)
        {
            return base.Channel.CheckAmtAsync(cn, amt);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IBNS))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IBNS))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:63678/BNS.svc");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return BNSClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IBNS);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return BNSClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IBNS);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IBNS,
        }
    }
}
