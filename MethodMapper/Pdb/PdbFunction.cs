//------------------------------------------------------------------------------
// <copyright company="CQSE GmbH">
//   Copyright (c) CQSE GmbH
// </copyright>
// <license>
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </license>
//------------------------------------------------------------------------------

namespace Cqse.ConQAT.Dotnet.Bummer
{
    using Common.Util.Runtime;

    /// <summary>
    /// Wraps a Microsoft.Cci.Pdb.PdbFunction.
    /// </summary>
    public class PdbFunction
    {
        /// <summary>
        /// Gets or sets the IL function token.
        /// </summary>
        public uint Token { get; set; }

        /// <summary>
        /// Gets or sets the filename of the source file 
        /// where the function is defined.
        /// </summary>
        public string SourceFilename { get; set; }

        /// <summary>
        /// Gets or sets the start line of the function 
        /// within its containing file.
        /// </summary>
        public uint StartLine { get; set; }

        /// <summary>
        /// Gets or sets the end line of the function 
        /// within its containing file.
        /// </summary>
        public uint EndLine { get; set; }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return ObjectUtils.Equals(this, obj, a => a.Token, a => a.SourceFilename, a => a.StartLine, a => a.EndLine);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return ObjectUtils.GetHashCode(this.Token, this.SourceFilename, this.StartLine, this.EndLine);
        }
    }
}
