// Copyright (c) Alex Ellis 2017. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Specialized;
using System.IO;
using System.Threading;

namespace OpenFaaS.Afterburn.Function {
    public class Handler {
        public string Invoke(char[] request) {

            return "Thanks, that was: " + request.Length + " bits of data for me.";
        }
    }

}