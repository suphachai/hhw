﻿// Copyright(c) 2016 Google Inc.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License. You may obtain a copy of
// the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
// WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the
// License for the specific language governing permissions and limitations under
// the License.

using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Routing;
using System;
using Cobisi.EmailVerify;

namespace GoogleCloudSamples
{
    public static class WebApiConfig
    {
        // [START sample]
        /// <summary>
        /// The simplest possible HTTP Handler that just returns "Hello World."
        /// </summary>
        public class HelloWorldHandler : HttpMessageHandler
        {

            static String axx="test";
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
                CancellationToken cancellationToken)
            {
               

                var engine = new VerificationEngine();
                // Validate john@example.com syntactically  
              
                var result = engine.Run("tods.899@gmail.com", VerificationLevel.CatchAll).Result;

                var b = engine;

                if (result.LastStatus == VerificationStatus.Success)
                {
                    axx = "Hello World222.";
                }

                return Task.FromResult(new HttpResponseMessage()
                {


                    // Content = new ByteArrayContent(Encoding.UTF8.GetBytes("Hello World222."));
                    Content = new ByteArrayContent(Encoding.UTF8.GetBytes(axx))
            });
            }
        };

        public static void Register(HttpConfiguration config)
        {

          


            var emptyDictionary = new HttpRouteValueDictionary();
            // Add our one HttpMessageHandler to the root path.
            config.Routes.MapHttpRoute("index", "", emptyDictionary, emptyDictionary,
                new HelloWorldHandler());
        }
        // [END sample]
    }
}
