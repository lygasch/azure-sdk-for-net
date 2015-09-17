﻿//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Microsoft.Azure.Management.DataFactories.Models
{
    /// <summary>
    /// AzureML Web Service linked service.
    /// </summary>
    [AdfTypeName("AzureML")]
    public class AzureMLLinkedService : LinkedServiceTypeProperties
    {
        /// <summary>
        /// Optional. Name of the AzureML web service (informational only).
        /// </summary>
        public string ExperimentName { get; set; }

        /// <summary>
        /// Required. The API key for accessing the AzureML model endpoint.
        /// </summary>
        [AdfRequired]
        public string ApiKey { get; set; }

        /// <summary>
        /// Required. The AzureML Web Service REST URL for requesting batch
        /// scoring.
        /// </summary>
        [AdfRequired]
        public string MlEndpoint { get; set; }

        /// <summary>
        /// Optional. The AzureML endpoint management REST URL for the endpoint. The URL should be of the form:
        /// https://management.azureml.net/workspaces/_workspace id_/webservices/_service id_/endpoints/_endpointName_.
        /// Include this property for updating the endpoint after retraining, using 
        /// <see cref="Microsoft.Azure.Management.DataFactories.Models.AzureMLUpdateResourceActivity" />.
        /// </summary>
        public string ManagementEndpoint { get; set; }

        /// <summary>
        /// Initializes a new instance of the AzureMLLinkedService class.
        /// </summary>
        public AzureMLLinkedService()
        {
        }

        /// <summary>
        /// Initializes a new instance of the AzureMLLinkedService class with
        /// required arguments.
        /// </summary>
        public AzureMLLinkedService(string mlEndpoint, string apiKey)
            : this()
        {
            Ensure.IsNotNullOrEmpty(mlEndpoint, "mlEndpoint");
            Ensure.IsNotNullOrEmpty(apiKey, "apiKey");

            this.MlEndpoint = mlEndpoint;
            this.ApiKey = apiKey;
        }
    }
}
