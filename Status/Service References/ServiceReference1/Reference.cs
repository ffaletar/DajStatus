﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Status.ServiceReference1 {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.UrlShorteningServiceSoap")]
    public interface UrlShorteningServiceSoap {
        
        // CODEGEN: Generating message contract since element name inputUrl from namespace http://tempuri.org/ is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ShortenUrl", ReplyAction="*")]
        Status.ServiceReference1.ShortenUrlResponse ShortenUrl(Status.ServiceReference1.ShortenUrlRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ShortenUrl", ReplyAction="*")]
        System.Threading.Tasks.Task<Status.ServiceReference1.ShortenUrlResponse> ShortenUrlAsync(Status.ServiceReference1.ShortenUrlRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ShortenUrlRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ShortenUrl", Namespace="http://tempuri.org/", Order=0)]
        public Status.ServiceReference1.ShortenUrlRequestBody Body;
        
        public ShortenUrlRequest() {
        }
        
        public ShortenUrlRequest(Status.ServiceReference1.ShortenUrlRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ShortenUrlRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string inputUrl;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string pass;
        
        public ShortenUrlRequestBody() {
        }
        
        public ShortenUrlRequestBody(string inputUrl, string pass) {
            this.inputUrl = inputUrl;
            this.pass = pass;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class ShortenUrlResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="ShortenUrlResponse", Namespace="http://tempuri.org/", Order=0)]
        public Status.ServiceReference1.ShortenUrlResponseBody Body;
        
        public ShortenUrlResponse() {
        }
        
        public ShortenUrlResponse(Status.ServiceReference1.ShortenUrlResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class ShortenUrlResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string ShortenUrlResult;
        
        public ShortenUrlResponseBody() {
        }
        
        public ShortenUrlResponseBody(string ShortenUrlResult) {
            this.ShortenUrlResult = ShortenUrlResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface UrlShorteningServiceSoapChannel : Status.ServiceReference1.UrlShorteningServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class UrlShorteningServiceSoapClient : System.ServiceModel.ClientBase<Status.ServiceReference1.UrlShorteningServiceSoap>, Status.ServiceReference1.UrlShorteningServiceSoap {
        
        public UrlShorteningServiceSoapClient() {
        }
        
        public UrlShorteningServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public UrlShorteningServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UrlShorteningServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public UrlShorteningServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        Status.ServiceReference1.ShortenUrlResponse Status.ServiceReference1.UrlShorteningServiceSoap.ShortenUrl(Status.ServiceReference1.ShortenUrlRequest request) {
            return base.Channel.ShortenUrl(request);
        }
        
        public string ShortenUrl(string inputUrl, string pass) {
            Status.ServiceReference1.ShortenUrlRequest inValue = new Status.ServiceReference1.ShortenUrlRequest();
            inValue.Body = new Status.ServiceReference1.ShortenUrlRequestBody();
            inValue.Body.inputUrl = inputUrl;
            inValue.Body.pass = pass;
            Status.ServiceReference1.ShortenUrlResponse retVal = ((Status.ServiceReference1.UrlShorteningServiceSoap)(this)).ShortenUrl(inValue);
            return retVal.Body.ShortenUrlResult;
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<Status.ServiceReference1.ShortenUrlResponse> Status.ServiceReference1.UrlShorteningServiceSoap.ShortenUrlAsync(Status.ServiceReference1.ShortenUrlRequest request) {
            return base.Channel.ShortenUrlAsync(request);
        }
        
        public System.Threading.Tasks.Task<Status.ServiceReference1.ShortenUrlResponse> ShortenUrlAsync(string inputUrl, string pass) {
            Status.ServiceReference1.ShortenUrlRequest inValue = new Status.ServiceReference1.ShortenUrlRequest();
            inValue.Body = new Status.ServiceReference1.ShortenUrlRequestBody();
            inValue.Body.inputUrl = inputUrl;
            inValue.Body.pass = pass;
            return ((Status.ServiceReference1.UrlShorteningServiceSoap)(this)).ShortenUrlAsync(inValue);
        }
    }
}
