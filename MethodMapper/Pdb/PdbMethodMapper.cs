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

using System.Collections.Generic;
using System.IO;

namespace Cqse.ConQAT.Dotnet.Bummer
{
    /// <summary>
    /// Method mapper for Microsoft .NET symbol files (.pdb).
    /// </summary>
    public class PdbMethodMapper : MethodMapperBase
    {
        /// <summary>
        /// File extension of Pdb files.
        /// </summary>
        private const string PdbExtension = ".pdb";

        /// <inheritdoc/>
        protected override string GetSupportedExtension() => PdbExtension;

        /// <inheritdoc/>
        protected override IEnumerable<MethodMapping> ReadMethodMappings(string pathToSymbolFile)
        {
            using (FileStream fileStream = File.OpenRead(pathToSymbolFile))
            {
                IEnumerable<PdbFunction> pdbFunctions = PdbFile
                    .LoadPdbFunctions(fileStream);

                foreach (PdbFunction pdbFunction in pdbFunctions)
                {
                    yield return GetMapping(pdbFunction);
                }
            }
        }

        /// <summary>
        /// Provides the method mapping for the specified Pdb method.
        /// </summary>
        private static MethodMapping GetMapping(PdbFunction pdbFunction)
        {
            return new MethodMapping()
            { 
                MethodToken = pdbFunction.Token,
                SourceFile = pdbFunction.SourceFilename,
                StartLine = pdbFunction.StartLine,
                EndLine = pdbFunction.EndLine
            };
        }
    }
}
