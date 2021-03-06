// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Hyak.Common;
using Microsoft.Azure.Management.SiteRecovery;
using Microsoft.Azure.Management.SiteRecovery.Models;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Management.SiteRecovery
{
    /// <summary>
    /// Definition of server operations for the Site Recovery extension.
    /// </summary>
    internal partial class ServerOperations : IServiceOperations<SiteRecoveryManagementClient>, IServerOperations
    {
        /// <summary>
        /// Initializes a new instance of the ServerOperations class.
        /// </summary>
        /// <param name='client'>
        /// Reference to the service client.
        /// </param>
        internal ServerOperations(SiteRecoveryManagementClient client)
        {
            this._client = client;
        }
        
        private SiteRecoveryManagementClient _client;
        
        /// <summary>
        /// Gets a reference to the
        /// Microsoft.Azure.Management.SiteRecovery.SiteRecoveryManagementClient.
        /// </summary>
        public SiteRecoveryManagementClient Client
        {
            get { return this._client; }
        }
        
        /// <summary>
        /// Get the server object by Id.
        /// </summary>
        /// <param name='serverId'>
        /// Required. Server ID.
        /// </param>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response model for the server object
        /// </returns>
        public async Task<ServerResponse> GetAsync(string serverId, CustomRequestHeaders customRequestHeaders, CancellationToken cancellationToken)
        {
            // Validate
            if (serverId == null)
            {
                throw new ArgumentNullException("serverId");
            }
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("serverId", serverId);
                tracingParameters.Add("customRequestHeaders", customRequestHeaders);
                TracingAdapter.Enter(invocationId, this, "GetAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/Subscriptions/";
            if (this.Client.Credentials.SubscriptionId != null)
            {
                url = url + Uri.EscapeDataString(this.Client.Credentials.SubscriptionId);
            }
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(this.Client.ResourceGroupName);
            url = url + "/providers/";
            url = url + "Microsoft.SiteRecovery";
            url = url + "/";
            url = url + "SiteRecoveryVault";
            url = url + "/";
            url = url + Uri.EscapeDataString(this.Client.ResourceName);
            url = url + "/Servers/";
            url = url + Uri.EscapeDataString(serverId);
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2015-08-10");
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-client-request-id", customRequestHeaders.ClientRequestId);
                httpRequest.Headers.Add("x-ms-version", "2015-01-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    ServerResponse result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new ServerResponse();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            Server serverInstance = new Server();
                            result.Server = serverInstance;
                            
                            JToken propertiesValue = responseDoc["properties"];
                            if (propertiesValue != null && propertiesValue.Type != JTokenType.Null)
                            {
                                ServerProperties propertiesInstance = new ServerProperties();
                                serverInstance.Properties = propertiesInstance;
                                
                                JToken providerVersionValue = propertiesValue["providerVersion"];
                                if (providerVersionValue != null && providerVersionValue.Type != JTokenType.Null)
                                {
                                    string providerVersionInstance = ((string)providerVersionValue);
                                    propertiesInstance.ProviderVersion = providerVersionInstance;
                                }
                                
                                JToken serverVersionValue = propertiesValue["serverVersion"];
                                if (serverVersionValue != null && serverVersionValue.Type != JTokenType.Null)
                                {
                                    string serverVersionInstance = ((string)serverVersionValue);
                                    propertiesInstance.ServerVersion = serverVersionInstance;
                                }
                                
                                JToken lastHeartbeatValue = propertiesValue["lastHeartbeat"];
                                if (lastHeartbeatValue != null && lastHeartbeatValue.Type != JTokenType.Null)
                                {
                                    DateTime lastHeartbeatInstance = ((DateTime)lastHeartbeatValue);
                                    propertiesInstance.LastHeartbeat = lastHeartbeatInstance;
                                }
                                
                                JToken connectionStatusValue = propertiesValue["connectionStatus"];
                                if (connectionStatusValue != null && connectionStatusValue.Type != JTokenType.Null)
                                {
                                    string connectionStatusInstance = ((string)connectionStatusValue);
                                    propertiesInstance.ConnectionStatus = connectionStatusInstance;
                                }
                                
                                JToken friendlyNameValue = propertiesValue["friendlyName"];
                                if (friendlyNameValue != null && friendlyNameValue.Type != JTokenType.Null)
                                {
                                    string friendlyNameInstance = ((string)friendlyNameValue);
                                    propertiesInstance.FriendlyName = friendlyNameInstance;
                                }
                                
                                JToken fabricTypeValue = propertiesValue["fabricType"];
                                if (fabricTypeValue != null && fabricTypeValue.Type != JTokenType.Null)
                                {
                                    string fabricTypeInstance = ((string)fabricTypeValue);
                                    propertiesInstance.FabricType = fabricTypeInstance;
                                }
                                
                                JToken fabricObjectIDValue = propertiesValue["fabricObjectID"];
                                if (fabricObjectIDValue != null && fabricObjectIDValue.Type != JTokenType.Null)
                                {
                                    string fabricObjectIDInstance = ((string)fabricObjectIDValue);
                                    propertiesInstance.FabricObjectID = fabricObjectIDInstance;
                                }
                            }
                            
                            JToken idValue = responseDoc["id"];
                            if (idValue != null && idValue.Type != JTokenType.Null)
                            {
                                string idInstance = ((string)idValue);
                                serverInstance.Id = idInstance;
                            }
                            
                            JToken nameValue = responseDoc["name"];
                            if (nameValue != null && nameValue.Type != JTokenType.Null)
                            {
                                string nameInstance = ((string)nameValue);
                                serverInstance.Name = nameInstance;
                            }
                            
                            JToken typeValue = responseDoc["type"];
                            if (typeValue != null && typeValue.Type != JTokenType.Null)
                            {
                                string typeInstance = ((string)typeValue);
                                serverInstance.Type = typeInstance;
                            }
                            
                            JToken locationValue = responseDoc["location"];
                            if (locationValue != null && locationValue.Type != JTokenType.Null)
                            {
                                string locationInstance = ((string)locationValue);
                                serverInstance.Location = locationInstance;
                            }
                            
                            JToken tagsSequenceElement = ((JToken)responseDoc["tags"]);
                            if (tagsSequenceElement != null && tagsSequenceElement.Type != JTokenType.Null)
                            {
                                foreach (JProperty property in tagsSequenceElement)
                                {
                                    string tagsKey = ((string)property.Name);
                                    string tagsValue = ((string)property.Value);
                                    serverInstance.Tags.Add(tagsKey, tagsValue);
                                }
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
        
        /// <summary>
        /// Get the list of all servers under the vault.
        /// </summary>
        /// <param name='customRequestHeaders'>
        /// Optional. Request header parameters.
        /// </param>
        /// <param name='cancellationToken'>
        /// Cancellation token.
        /// </param>
        /// <returns>
        /// The response model for the list servers operation.
        /// </returns>
        public async Task<ServerListResponse> ListAsync(CustomRequestHeaders customRequestHeaders, CancellationToken cancellationToken)
        {
            // Validate
            
            // Tracing
            bool shouldTrace = TracingAdapter.IsEnabled;
            string invocationId = null;
            if (shouldTrace)
            {
                invocationId = TracingAdapter.NextInvocationId.ToString();
                Dictionary<string, object> tracingParameters = new Dictionary<string, object>();
                tracingParameters.Add("customRequestHeaders", customRequestHeaders);
                TracingAdapter.Enter(invocationId, this, "ListAsync", tracingParameters);
            }
            
            // Construct URL
            string url = "";
            url = url + "/Subscriptions/";
            if (this.Client.Credentials.SubscriptionId != null)
            {
                url = url + Uri.EscapeDataString(this.Client.Credentials.SubscriptionId);
            }
            url = url + "/resourceGroups/";
            url = url + Uri.EscapeDataString(this.Client.ResourceGroupName);
            url = url + "/providers/";
            url = url + "Microsoft.SiteRecovery";
            url = url + "/";
            url = url + "SiteRecoveryVault";
            url = url + "/";
            url = url + Uri.EscapeDataString(this.Client.ResourceName);
            url = url + "/Servers";
            List<string> queryParameters = new List<string>();
            queryParameters.Add("api-version=2015-08-10");
            if (queryParameters.Count > 0)
            {
                url = url + "?" + string.Join("&", queryParameters);
            }
            string baseUrl = this.Client.BaseUri.AbsoluteUri;
            // Trim '/' character from the end of baseUrl and beginning of url.
            if (baseUrl[baseUrl.Length - 1] == '/')
            {
                baseUrl = baseUrl.Substring(0, baseUrl.Length - 1);
            }
            if (url[0] == '/')
            {
                url = url.Substring(1);
            }
            url = baseUrl + "/" + url;
            url = url.Replace(" ", "%20");
            
            // Create HTTP transport objects
            HttpRequestMessage httpRequest = null;
            try
            {
                httpRequest = new HttpRequestMessage();
                httpRequest.Method = HttpMethod.Get;
                httpRequest.RequestUri = new Uri(url);
                
                // Set Headers
                httpRequest.Headers.Add("x-ms-client-request-id", customRequestHeaders.ClientRequestId);
                httpRequest.Headers.Add("x-ms-version", "2015-01-01");
                
                // Set Credentials
                cancellationToken.ThrowIfCancellationRequested();
                await this.Client.Credentials.ProcessHttpRequestAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                
                // Send Request
                HttpResponseMessage httpResponse = null;
                try
                {
                    if (shouldTrace)
                    {
                        TracingAdapter.SendRequest(invocationId, httpRequest);
                    }
                    cancellationToken.ThrowIfCancellationRequested();
                    httpResponse = await this.Client.HttpClient.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
                    if (shouldTrace)
                    {
                        TracingAdapter.ReceiveResponse(invocationId, httpResponse);
                    }
                    HttpStatusCode statusCode = httpResponse.StatusCode;
                    if (statusCode != HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        CloudException ex = CloudException.Create(httpRequest, null, httpResponse, await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false));
                        if (shouldTrace)
                        {
                            TracingAdapter.Error(invocationId, ex);
                        }
                        throw ex;
                    }
                    
                    // Create Result
                    ServerListResponse result = null;
                    // Deserialize Response
                    if (statusCode == HttpStatusCode.OK)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        string responseContent = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);
                        result = new ServerListResponse();
                        JToken responseDoc = null;
                        if (string.IsNullOrEmpty(responseContent) == false)
                        {
                            responseDoc = JToken.Parse(responseContent);
                        }
                        
                        if (responseDoc != null && responseDoc.Type != JTokenType.Null)
                        {
                            JToken valueArray = responseDoc["value"];
                            if (valueArray != null && valueArray.Type != JTokenType.Null)
                            {
                                foreach (JToken valueValue in ((JArray)valueArray))
                                {
                                    Server serverInstance = new Server();
                                    result.Servers.Add(serverInstance);
                                    
                                    JToken propertiesValue = valueValue["properties"];
                                    if (propertiesValue != null && propertiesValue.Type != JTokenType.Null)
                                    {
                                        ServerProperties propertiesInstance = new ServerProperties();
                                        serverInstance.Properties = propertiesInstance;
                                        
                                        JToken providerVersionValue = propertiesValue["providerVersion"];
                                        if (providerVersionValue != null && providerVersionValue.Type != JTokenType.Null)
                                        {
                                            string providerVersionInstance = ((string)providerVersionValue);
                                            propertiesInstance.ProviderVersion = providerVersionInstance;
                                        }
                                        
                                        JToken serverVersionValue = propertiesValue["serverVersion"];
                                        if (serverVersionValue != null && serverVersionValue.Type != JTokenType.Null)
                                        {
                                            string serverVersionInstance = ((string)serverVersionValue);
                                            propertiesInstance.ServerVersion = serverVersionInstance;
                                        }
                                        
                                        JToken lastHeartbeatValue = propertiesValue["lastHeartbeat"];
                                        if (lastHeartbeatValue != null && lastHeartbeatValue.Type != JTokenType.Null)
                                        {
                                            DateTime lastHeartbeatInstance = ((DateTime)lastHeartbeatValue);
                                            propertiesInstance.LastHeartbeat = lastHeartbeatInstance;
                                        }
                                        
                                        JToken connectionStatusValue = propertiesValue["connectionStatus"];
                                        if (connectionStatusValue != null && connectionStatusValue.Type != JTokenType.Null)
                                        {
                                            string connectionStatusInstance = ((string)connectionStatusValue);
                                            propertiesInstance.ConnectionStatus = connectionStatusInstance;
                                        }
                                        
                                        JToken friendlyNameValue = propertiesValue["friendlyName"];
                                        if (friendlyNameValue != null && friendlyNameValue.Type != JTokenType.Null)
                                        {
                                            string friendlyNameInstance = ((string)friendlyNameValue);
                                            propertiesInstance.FriendlyName = friendlyNameInstance;
                                        }
                                        
                                        JToken fabricTypeValue = propertiesValue["fabricType"];
                                        if (fabricTypeValue != null && fabricTypeValue.Type != JTokenType.Null)
                                        {
                                            string fabricTypeInstance = ((string)fabricTypeValue);
                                            propertiesInstance.FabricType = fabricTypeInstance;
                                        }
                                        
                                        JToken fabricObjectIDValue = propertiesValue["fabricObjectID"];
                                        if (fabricObjectIDValue != null && fabricObjectIDValue.Type != JTokenType.Null)
                                        {
                                            string fabricObjectIDInstance = ((string)fabricObjectIDValue);
                                            propertiesInstance.FabricObjectID = fabricObjectIDInstance;
                                        }
                                    }
                                    
                                    JToken idValue = valueValue["id"];
                                    if (idValue != null && idValue.Type != JTokenType.Null)
                                    {
                                        string idInstance = ((string)idValue);
                                        serverInstance.Id = idInstance;
                                    }
                                    
                                    JToken nameValue = valueValue["name"];
                                    if (nameValue != null && nameValue.Type != JTokenType.Null)
                                    {
                                        string nameInstance = ((string)nameValue);
                                        serverInstance.Name = nameInstance;
                                    }
                                    
                                    JToken typeValue = valueValue["type"];
                                    if (typeValue != null && typeValue.Type != JTokenType.Null)
                                    {
                                        string typeInstance = ((string)typeValue);
                                        serverInstance.Type = typeInstance;
                                    }
                                    
                                    JToken locationValue = valueValue["location"];
                                    if (locationValue != null && locationValue.Type != JTokenType.Null)
                                    {
                                        string locationInstance = ((string)locationValue);
                                        serverInstance.Location = locationInstance;
                                    }
                                    
                                    JToken tagsSequenceElement = ((JToken)valueValue["tags"]);
                                    if (tagsSequenceElement != null && tagsSequenceElement.Type != JTokenType.Null)
                                    {
                                        foreach (JProperty property in tagsSequenceElement)
                                        {
                                            string tagsKey = ((string)property.Name);
                                            string tagsValue = ((string)property.Value);
                                            serverInstance.Tags.Add(tagsKey, tagsValue);
                                        }
                                    }
                                }
                            }
                            
                            JToken nextLinkValue = responseDoc["nextLink"];
                            if (nextLinkValue != null && nextLinkValue.Type != JTokenType.Null)
                            {
                                string nextLinkInstance = ((string)nextLinkValue);
                                result.NextLink = nextLinkInstance;
                            }
                        }
                        
                    }
                    result.StatusCode = statusCode;
                    if (httpResponse.Headers.Contains("x-ms-request-id"))
                    {
                        result.RequestId = httpResponse.Headers.GetValues("x-ms-request-id").FirstOrDefault();
                    }
                    
                    if (shouldTrace)
                    {
                        TracingAdapter.Exit(invocationId, result);
                    }
                    return result;
                }
                finally
                {
                    if (httpResponse != null)
                    {
                        httpResponse.Dispose();
                    }
                }
            }
            finally
            {
                if (httpRequest != null)
                {
                    httpRequest.Dispose();
                }
            }
        }
    }
}
