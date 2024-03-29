﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3603
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This code was auto-generated by Microsoft.Silverlight.ServiceReference, version 2.0.5.0
// 
namespace GHDoctor.SearchEngineService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="SearchEngineService.SearchEngineServiceSoap")]
    public interface SearchEngineServiceSoap {
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/GetNumberOfResultsForSearch", ReplyAction="*")]
        System.IAsyncResult BeginGetNumberOfResultsForSearch(GHDoctor.SearchEngineService.GetNumberOfResultsForSearchRequest request, System.AsyncCallback callback, object asyncState);
        
        GHDoctor.SearchEngineService.GetNumberOfResultsForSearchResponse EndGetNumberOfResultsForSearch(System.IAsyncResult result);
        
        [System.ServiceModel.OperationContractAttribute(AsyncPattern=true, Action="http://tempuri.org/GetNumberOfResultsForSiteSearch", ReplyAction="*")]
        System.IAsyncResult BeginGetNumberOfResultsForSiteSearch(GHDoctor.SearchEngineService.GetNumberOfResultsForSiteSearchRequest request, System.AsyncCallback callback, object asyncState);
        
        GHDoctor.SearchEngineService.GetNumberOfResultsForSiteSearchResponse EndGetNumberOfResultsForSiteSearch(System.IAsyncResult result);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetNumberOfResultsForSearchRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetNumberOfResultsForSearch", Namespace="http://tempuri.org/", Order=0)]
        public GHDoctor.SearchEngineService.GetNumberOfResultsForSearchRequestBody Body;
        
        public GetNumberOfResultsForSearchRequest() {
        }
        
        public GetNumberOfResultsForSearchRequest(GHDoctor.SearchEngineService.GetNumberOfResultsForSearchRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetNumberOfResultsForSearchRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string query;
        
        public GetNumberOfResultsForSearchRequestBody() {
        }
        
        public GetNumberOfResultsForSearchRequestBody(string query) {
            this.query = query;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetNumberOfResultsForSearchResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetNumberOfResultsForSearchResponse", Namespace="http://tempuri.org/", Order=0)]
        public GHDoctor.SearchEngineService.GetNumberOfResultsForSearchResponseBody Body;
        
        public GetNumberOfResultsForSearchResponse() {
        }
        
        public GetNumberOfResultsForSearchResponse(GHDoctor.SearchEngineService.GetNumberOfResultsForSearchResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetNumberOfResultsForSearchResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public long GetNumberOfResultsForSearchResult;
        
        public GetNumberOfResultsForSearchResponseBody() {
        }
        
        public GetNumberOfResultsForSearchResponseBody(long GetNumberOfResultsForSearchResult) {
            this.GetNumberOfResultsForSearchResult = GetNumberOfResultsForSearchResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetNumberOfResultsForSiteSearchRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetNumberOfResultsForSiteSearch", Namespace="http://tempuri.org/", Order=0)]
        public GHDoctor.SearchEngineService.GetNumberOfResultsForSiteSearchRequestBody Body;
        
        public GetNumberOfResultsForSiteSearchRequest() {
        }
        
        public GetNumberOfResultsForSiteSearchRequest(GHDoctor.SearchEngineService.GetNumberOfResultsForSiteSearchRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetNumberOfResultsForSiteSearchRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string query;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string site;
        
        public GetNumberOfResultsForSiteSearchRequestBody() {
        }
        
        public GetNumberOfResultsForSiteSearchRequestBody(string query, string site) {
            this.query = query;
            this.site = site;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class GetNumberOfResultsForSiteSearchResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="GetNumberOfResultsForSiteSearchResponse", Namespace="http://tempuri.org/", Order=0)]
        public GHDoctor.SearchEngineService.GetNumberOfResultsForSiteSearchResponseBody Body;
        
        public GetNumberOfResultsForSiteSearchResponse() {
        }
        
        public GetNumberOfResultsForSiteSearchResponse(GHDoctor.SearchEngineService.GetNumberOfResultsForSiteSearchResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://tempuri.org/")]
    public partial class GetNumberOfResultsForSiteSearchResponseBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(Order=0)]
        public long GetNumberOfResultsForSiteSearchResult;
        
        public GetNumberOfResultsForSiteSearchResponseBody() {
        }
        
        public GetNumberOfResultsForSiteSearchResponseBody(long GetNumberOfResultsForSiteSearchResult) {
            this.GetNumberOfResultsForSiteSearchResult = GetNumberOfResultsForSiteSearchResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface SearchEngineServiceSoapChannel : GHDoctor.SearchEngineService.SearchEngineServiceSoap, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class GetNumberOfResultsForSearchCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetNumberOfResultsForSearchCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public long Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((long)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class GetNumberOfResultsForSiteSearchCompletedEventArgs : System.ComponentModel.AsyncCompletedEventArgs {
        
        private object[] results;
        
        public GetNumberOfResultsForSiteSearchCompletedEventArgs(object[] results, System.Exception exception, bool cancelled, object userState) : 
                base(exception, cancelled, userState) {
            this.results = results;
        }
        
        public long Result {
            get {
                base.RaiseExceptionIfNecessary();
                return ((long)(this.results[0]));
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class SearchEngineServiceSoapClient : System.ServiceModel.ClientBase<GHDoctor.SearchEngineService.SearchEngineServiceSoap>, GHDoctor.SearchEngineService.SearchEngineServiceSoap {
        
        private BeginOperationDelegate onBeginGetNumberOfResultsForSearchDelegate;
        
        private EndOperationDelegate onEndGetNumberOfResultsForSearchDelegate;
        
        private System.Threading.SendOrPostCallback onGetNumberOfResultsForSearchCompletedDelegate;
        
        private BeginOperationDelegate onBeginGetNumberOfResultsForSiteSearchDelegate;
        
        private EndOperationDelegate onEndGetNumberOfResultsForSiteSearchDelegate;
        
        private System.Threading.SendOrPostCallback onGetNumberOfResultsForSiteSearchCompletedDelegate;
        
        private BeginOperationDelegate onBeginOpenDelegate;
        
        private EndOperationDelegate onEndOpenDelegate;
        
        private System.Threading.SendOrPostCallback onOpenCompletedDelegate;
        
        private BeginOperationDelegate onBeginCloseDelegate;
        
        private EndOperationDelegate onEndCloseDelegate;
        
        private System.Threading.SendOrPostCallback onCloseCompletedDelegate;
        
        public SearchEngineServiceSoapClient() {
        }
        
        public SearchEngineServiceSoapClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public SearchEngineServiceSoapClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SearchEngineServiceSoapClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public SearchEngineServiceSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public event System.EventHandler<GetNumberOfResultsForSearchCompletedEventArgs> GetNumberOfResultsForSearchCompleted;
        
        public event System.EventHandler<GetNumberOfResultsForSiteSearchCompletedEventArgs> GetNumberOfResultsForSiteSearchCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> OpenCompleted;
        
        public event System.EventHandler<System.ComponentModel.AsyncCompletedEventArgs> CloseCompleted;
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult GHDoctor.SearchEngineService.SearchEngineServiceSoap.BeginGetNumberOfResultsForSearch(GHDoctor.SearchEngineService.GetNumberOfResultsForSearchRequest request, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetNumberOfResultsForSearch(request, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private System.IAsyncResult BeginGetNumberOfResultsForSearch(string query, System.AsyncCallback callback, object asyncState) {
            GHDoctor.SearchEngineService.GetNumberOfResultsForSearchRequest inValue = new GHDoctor.SearchEngineService.GetNumberOfResultsForSearchRequest();
            inValue.Body = new GHDoctor.SearchEngineService.GetNumberOfResultsForSearchRequestBody();
            inValue.Body.query = query;
            return ((GHDoctor.SearchEngineService.SearchEngineServiceSoap)(this)).BeginGetNumberOfResultsForSearch(inValue, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GHDoctor.SearchEngineService.GetNumberOfResultsForSearchResponse GHDoctor.SearchEngineService.SearchEngineServiceSoap.EndGetNumberOfResultsForSearch(System.IAsyncResult result) {
            return base.Channel.EndGetNumberOfResultsForSearch(result);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private long EndGetNumberOfResultsForSearch(System.IAsyncResult result) {
            GHDoctor.SearchEngineService.GetNumberOfResultsForSearchResponse retVal = ((GHDoctor.SearchEngineService.SearchEngineServiceSoap)(this)).EndGetNumberOfResultsForSearch(result);
            return retVal.Body.GetNumberOfResultsForSearchResult;
        }
        
        private System.IAsyncResult OnBeginGetNumberOfResultsForSearch(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string query = ((string)(inValues[0]));
            return this.BeginGetNumberOfResultsForSearch(query, callback, asyncState);
        }
        
        private object[] OnEndGetNumberOfResultsForSearch(System.IAsyncResult result) {
            long retVal = this.EndGetNumberOfResultsForSearch(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetNumberOfResultsForSearchCompleted(object state) {
            if ((this.GetNumberOfResultsForSearchCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetNumberOfResultsForSearchCompleted(this, new GetNumberOfResultsForSearchCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetNumberOfResultsForSearchAsync(string query) {
            this.GetNumberOfResultsForSearchAsync(query, null);
        }
        
        public void GetNumberOfResultsForSearchAsync(string query, object userState) {
            if ((this.onBeginGetNumberOfResultsForSearchDelegate == null)) {
                this.onBeginGetNumberOfResultsForSearchDelegate = new BeginOperationDelegate(this.OnBeginGetNumberOfResultsForSearch);
            }
            if ((this.onEndGetNumberOfResultsForSearchDelegate == null)) {
                this.onEndGetNumberOfResultsForSearchDelegate = new EndOperationDelegate(this.OnEndGetNumberOfResultsForSearch);
            }
            if ((this.onGetNumberOfResultsForSearchCompletedDelegate == null)) {
                this.onGetNumberOfResultsForSearchCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetNumberOfResultsForSearchCompleted);
            }
            base.InvokeAsync(this.onBeginGetNumberOfResultsForSearchDelegate, new object[] {
                        query}, this.onEndGetNumberOfResultsForSearchDelegate, this.onGetNumberOfResultsForSearchCompletedDelegate, userState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.IAsyncResult GHDoctor.SearchEngineService.SearchEngineServiceSoap.BeginGetNumberOfResultsForSiteSearch(GHDoctor.SearchEngineService.GetNumberOfResultsForSiteSearchRequest request, System.AsyncCallback callback, object asyncState) {
            return base.Channel.BeginGetNumberOfResultsForSiteSearch(request, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private System.IAsyncResult BeginGetNumberOfResultsForSiteSearch(string query, string site, System.AsyncCallback callback, object asyncState) {
            GHDoctor.SearchEngineService.GetNumberOfResultsForSiteSearchRequest inValue = new GHDoctor.SearchEngineService.GetNumberOfResultsForSiteSearchRequest();
            inValue.Body = new GHDoctor.SearchEngineService.GetNumberOfResultsForSiteSearchRequestBody();
            inValue.Body.query = query;
            inValue.Body.site = site;
            return ((GHDoctor.SearchEngineService.SearchEngineServiceSoap)(this)).BeginGetNumberOfResultsForSiteSearch(inValue, callback, asyncState);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        GHDoctor.SearchEngineService.GetNumberOfResultsForSiteSearchResponse GHDoctor.SearchEngineService.SearchEngineServiceSoap.EndGetNumberOfResultsForSiteSearch(System.IAsyncResult result) {
            return base.Channel.EndGetNumberOfResultsForSiteSearch(result);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        private long EndGetNumberOfResultsForSiteSearch(System.IAsyncResult result) {
            GHDoctor.SearchEngineService.GetNumberOfResultsForSiteSearchResponse retVal = ((GHDoctor.SearchEngineService.SearchEngineServiceSoap)(this)).EndGetNumberOfResultsForSiteSearch(result);
            return retVal.Body.GetNumberOfResultsForSiteSearchResult;
        }
        
        private System.IAsyncResult OnBeginGetNumberOfResultsForSiteSearch(object[] inValues, System.AsyncCallback callback, object asyncState) {
            string query = ((string)(inValues[0]));
            string site = ((string)(inValues[1]));
            return this.BeginGetNumberOfResultsForSiteSearch(query, site, callback, asyncState);
        }
        
        private object[] OnEndGetNumberOfResultsForSiteSearch(System.IAsyncResult result) {
            long retVal = this.EndGetNumberOfResultsForSiteSearch(result);
            return new object[] {
                    retVal};
        }
        
        private void OnGetNumberOfResultsForSiteSearchCompleted(object state) {
            if ((this.GetNumberOfResultsForSiteSearchCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.GetNumberOfResultsForSiteSearchCompleted(this, new GetNumberOfResultsForSiteSearchCompletedEventArgs(e.Results, e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void GetNumberOfResultsForSiteSearchAsync(string query, string site) {
            this.GetNumberOfResultsForSiteSearchAsync(query, site, null);
        }
        
        public void GetNumberOfResultsForSiteSearchAsync(string query, string site, object userState) {
            if ((this.onBeginGetNumberOfResultsForSiteSearchDelegate == null)) {
                this.onBeginGetNumberOfResultsForSiteSearchDelegate = new BeginOperationDelegate(this.OnBeginGetNumberOfResultsForSiteSearch);
            }
            if ((this.onEndGetNumberOfResultsForSiteSearchDelegate == null)) {
                this.onEndGetNumberOfResultsForSiteSearchDelegate = new EndOperationDelegate(this.OnEndGetNumberOfResultsForSiteSearch);
            }
            if ((this.onGetNumberOfResultsForSiteSearchCompletedDelegate == null)) {
                this.onGetNumberOfResultsForSiteSearchCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnGetNumberOfResultsForSiteSearchCompleted);
            }
            base.InvokeAsync(this.onBeginGetNumberOfResultsForSiteSearchDelegate, new object[] {
                        query,
                        site}, this.onEndGetNumberOfResultsForSiteSearchDelegate, this.onGetNumberOfResultsForSiteSearchCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginOpen(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(callback, asyncState);
        }
        
        private object[] OnEndOpen(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndOpen(result);
            return null;
        }
        
        private void OnOpenCompleted(object state) {
            if ((this.OpenCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.OpenCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void OpenAsync() {
            this.OpenAsync(null);
        }
        
        public void OpenAsync(object userState) {
            if ((this.onBeginOpenDelegate == null)) {
                this.onBeginOpenDelegate = new BeginOperationDelegate(this.OnBeginOpen);
            }
            if ((this.onEndOpenDelegate == null)) {
                this.onEndOpenDelegate = new EndOperationDelegate(this.OnEndOpen);
            }
            if ((this.onOpenCompletedDelegate == null)) {
                this.onOpenCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnOpenCompleted);
            }
            base.InvokeAsync(this.onBeginOpenDelegate, null, this.onEndOpenDelegate, this.onOpenCompletedDelegate, userState);
        }
        
        private System.IAsyncResult OnBeginClose(object[] inValues, System.AsyncCallback callback, object asyncState) {
            return ((System.ServiceModel.ICommunicationObject)(this)).BeginClose(callback, asyncState);
        }
        
        private object[] OnEndClose(System.IAsyncResult result) {
            ((System.ServiceModel.ICommunicationObject)(this)).EndClose(result);
            return null;
        }
        
        private void OnCloseCompleted(object state) {
            if ((this.CloseCompleted != null)) {
                InvokeAsyncCompletedEventArgs e = ((InvokeAsyncCompletedEventArgs)(state));
                this.CloseCompleted(this, new System.ComponentModel.AsyncCompletedEventArgs(e.Error, e.Cancelled, e.UserState));
            }
        }
        
        public void CloseAsync() {
            this.CloseAsync(null);
        }
        
        public void CloseAsync(object userState) {
            if ((this.onBeginCloseDelegate == null)) {
                this.onBeginCloseDelegate = new BeginOperationDelegate(this.OnBeginClose);
            }
            if ((this.onEndCloseDelegate == null)) {
                this.onEndCloseDelegate = new EndOperationDelegate(this.OnEndClose);
            }
            if ((this.onCloseCompletedDelegate == null)) {
                this.onCloseCompletedDelegate = new System.Threading.SendOrPostCallback(this.OnCloseCompleted);
            }
            base.InvokeAsync(this.onBeginCloseDelegate, null, this.onEndCloseDelegate, this.onCloseCompletedDelegate, userState);
        }
        
        protected override GHDoctor.SearchEngineService.SearchEngineServiceSoap CreateChannel() {
            return new SearchEngineServiceSoapClientChannel(this);
        }
        
        private class SearchEngineServiceSoapClientChannel : ChannelBase<GHDoctor.SearchEngineService.SearchEngineServiceSoap>, GHDoctor.SearchEngineService.SearchEngineServiceSoap {
            
            public SearchEngineServiceSoapClientChannel(System.ServiceModel.ClientBase<GHDoctor.SearchEngineService.SearchEngineServiceSoap> client) : 
                    base(client) {
            }
            
            public System.IAsyncResult BeginGetNumberOfResultsForSearch(GHDoctor.SearchEngineService.GetNumberOfResultsForSearchRequest request, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = request;
                System.IAsyncResult _result = base.BeginInvoke("GetNumberOfResultsForSearch", _args, callback, asyncState);
                return _result;
            }
            
            public GHDoctor.SearchEngineService.GetNumberOfResultsForSearchResponse EndGetNumberOfResultsForSearch(System.IAsyncResult result) {
                object[] _args = new object[0];
                GHDoctor.SearchEngineService.GetNumberOfResultsForSearchResponse _result = ((GHDoctor.SearchEngineService.GetNumberOfResultsForSearchResponse)(base.EndInvoke("GetNumberOfResultsForSearch", _args, result)));
                return _result;
            }
            
            public System.IAsyncResult BeginGetNumberOfResultsForSiteSearch(GHDoctor.SearchEngineService.GetNumberOfResultsForSiteSearchRequest request, System.AsyncCallback callback, object asyncState) {
                object[] _args = new object[1];
                _args[0] = request;
                System.IAsyncResult _result = base.BeginInvoke("GetNumberOfResultsForSiteSearch", _args, callback, asyncState);
                return _result;
            }
            
            public GHDoctor.SearchEngineService.GetNumberOfResultsForSiteSearchResponse EndGetNumberOfResultsForSiteSearch(System.IAsyncResult result) {
                object[] _args = new object[0];
                GHDoctor.SearchEngineService.GetNumberOfResultsForSiteSearchResponse _result = ((GHDoctor.SearchEngineService.GetNumberOfResultsForSiteSearchResponse)(base.EndInvoke("GetNumberOfResultsForSiteSearch", _args, result)));
                return _result;
            }
        }
    }
}
