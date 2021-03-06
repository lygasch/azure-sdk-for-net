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
using System.Linq;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Management.Compute.Models
{
    /// <summary>
    /// A substatus object containing additional status information reported by
    /// the Resource Extension.
    /// </summary>
    public partial class ResourceExtensionSubStatus
    {
        private int? _code;
        
        /// <summary>
        /// Optional. Integer status code from the result of applying the
        /// substatus settings.
        /// </summary>
        public int? Code
        {
            get { return this._code; }
            set { this._code = value; }
        }
        
        private GuestAgentFormattedMessage _formattedMessage;
        
        /// <summary>
        /// Optional. This object encapsulates a formatted localized status
        /// message.
        /// </summary>
        public GuestAgentFormattedMessage FormattedMessage
        {
            get { return this._formattedMessage; }
            set { this._formattedMessage = value; }
        }
        
        private GuestAgentMessage _message;
        
        /// <summary>
        /// Optional. This object encapsulates a localized status message.
        /// </summary>
        public GuestAgentMessage Message
        {
            get { return this._message; }
            set { this._message = value; }
        }
        
        private string _name;
        
        /// <summary>
        /// Optional. A name for the substatus.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        
        private string _status;
        
        /// <summary>
        /// Optional. The resource extension substatus, containing values like
        /// Transitioning, Error, Success, or Warning.
        /// </summary>
        public string Status
        {
            get { return this._status; }
            set { this._status = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the ResourceExtensionSubStatus class.
        /// </summary>
        public ResourceExtensionSubStatus()
        {
        }
    }
}
