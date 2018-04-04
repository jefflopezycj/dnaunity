// Copyright (c) 2012 DotNetAnywhere
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

#if UNITY_5 || UNITY_2017 || UNITY_2018

using System;
using System.Collections.Generic;
using UnityEngine;

namespace DnaUnity
{


    /// <summary>
    /// Dna script monobehavior (should only be one of these per scene)
    /// </summary>
    public class DnaScript : MonoBehaviour
    {
        public string[] assembliesToLoad;
        public int heapSize = 10000000;
        public string[] assemblySearchPaths = new string[] {
//            "${UNITY_DIR}/Mono/Lib/mono/unity",
//            "${UNITY_DIR}/Managed",
            "${PROJECT_DIR}/lib",
            "${PROJECT_DIR}/Library/ScriptAssemblies"
        };

        /// <summary>
        /// Keeps track of all of the property names for all classes serialized in this scene.
        /// </summary>
        public List<DnaSerializedTypeInfo> stringTables = new List<DnaSerializedTypeInfo>();

        public void Initialize()
        {
            Dna.Reset();
            Dna.Init(heapSize, assemblySearchPaths);
        }

        public void LoadScripts()
        {
            foreach (string assemblyName in assembliesToLoad)
            {
                Dna.Load(assemblyName);
            }
        }

        public void OnDestroy()
        {
            Dna.Reset();
        }

    }
}

#endif