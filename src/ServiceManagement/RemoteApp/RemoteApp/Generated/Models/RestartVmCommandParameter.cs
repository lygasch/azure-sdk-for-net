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

namespace Microsoft.WindowsAzure.Management.RemoteApp.Models
{
    /// <summary>
    /// Parameter definition for session commands.
    /// </summary>
    public partial class RestartVmCommandParameter
    {
        private string _logoffMessage;
        
        /// <summary>
        /// Optional. Logoff warning message to be displayed to users.
        /// </summary>
        public string LogoffMessage
        {
            get { return this._logoffMessage; }
            set { this._logoffMessage = value; }
        }
        
        private int _logoffWaitTimeInSeconds;
        
        /// <summary>
        /// Optional. Wait time in seconds before force logoff.
        /// </summary>
        public int LogoffWaitTimeInSeconds
        {
            get { return this._logoffWaitTimeInSeconds; }
            set { this._logoffWaitTimeInSeconds = value; }
        }
        
        private string _virtualMachineName;
        
        /// <summary>
        /// Required. Name of the VM to restart.
        /// </summary>
        public string VirtualMachineName
        {
            get { return this._virtualMachineName; }
            set { this._virtualMachineName = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the RestartVmCommandParameter class.
        /// </summary>
        public RestartVmCommandParameter()
        {
        }
        
        /// <summary>
        /// Initializes a new instance of the RestartVmCommandParameter class
        /// with required arguments.
        /// </summary>
        public RestartVmCommandParameter(string virtualMachineName)
            : this()
        {
            if (virtualMachineName == null)
            {
                throw new ArgumentNullException("virtualMachineName");
            }
            this.VirtualMachineName = virtualMachineName;
        }
    }
}
