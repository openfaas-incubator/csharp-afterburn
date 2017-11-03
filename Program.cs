// Copyright (c) Alex Ellis 2017. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.IO;
using OpenFaaS.Afterburn.Lib;

namespace OpenFaaS.Afterburn
{
    class Program
    {
        static void Main(string[] args)
        {
            var function = new Function.Handler();

            System.Diagnostics.Debug.WriteLine("C# AfterBurn running.");

            var httpFormatter = new HttpFormatter();
            var stdin = Console.OpenStandardInput();
            using(TextReader reader = new StreamReader(stdin)) {

                while(true) {
                    HeaderParser parser = new HeaderParser();
                    var header = parser.Parse(reader);

                    foreach(string v in header.HttpHeaders) {
                        System.Diagnostics.Debug.WriteLine(v +"="+header.HttpHeaders[v]);
                    }

                    System.Diagnostics.Debug.WriteLine("Content-Length: " + header.ContentLength);

                    BodyParser bodyParser = new BodyParser();
                    char[] body = new char[0]{};
                    if (header.ContentLength > 0) {
                        body = bodyParser.Parse(reader, header.ContentLength);
                        
                        System.Diagnostics.Debug.WriteLine( body );
                    }

                    var httpAdded = httpFormatter.Format(function.Invoke(body));
                    Console.WriteLine(httpAdded);
                }
            }
        }

    }
  
}