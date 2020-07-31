// Copyright 2020 Tsz Ning Cheung
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace IEX
{
    namespace Stock
    {
        public class Request : IRequest
        {
            private readonly RequestBase request = new RequestBase();
            public Request()
            {
                request.Category = "stock";
            }
            public Request Symbol(string symbol)
            {
                request.Symbol = symbol;
                return this;
            }
            public Request Command(string command)
            {
                request.Command = command;
                return this;
            }

            public override string FormatURL()
            {
                return String.Format("{0}/{1}/{2}/{3}?token={4}",
                                Configs.urlBase,
                                request.Category,
                                request.Symbol,
                                request.Command,
                                Configs.AccessToken);
            }


        }
        public class Results : IResults
        {
            [JsonProperty("symbol")]
            public string Symbol { get; set; }
            [JsonProperty("companyName")]
            public string CompanyName { get; set; }
            [JsonProperty("employees")]
            public int Employees { get; set; }
            [JsonProperty("exchange")]
            public string Exchange { get; set; }
            [JsonProperty("industry")]
            public string Industry { get; set; }
            [JsonProperty("website")]
            public string Website { get; set; }
            [JsonProperty("description")]
            public string Description { get; set; }
            [JsonProperty("CEO")]
            public string CEO { get; set; }
            [JsonProperty("securityName")]
            public string SecurityName { get; set; }
            [JsonProperty("issueType")]
            public string IssueType { get; set; }
            [JsonProperty("sector")]
            public string Sector { get; set; }
            [JsonProperty("primarySicCode")]
            public string PrimarySicCode { get; set; }
            [JsonProperty("tags")]
            public string[] Tags { get; set; }
            [JsonProperty("address")]
            public string Address { get; set; }
            [JsonProperty("state")]
            public string State { get; set; }
            [JsonProperty("city")]
            public string City { get; set; }
            [JsonProperty("zip")]
            public string Zip { get; set; }
            [JsonProperty("country")]
            public string Country { get; set; }
            [JsonProperty("phone")]
            public string Phone { get; set; }
        }

        public class Rest
        {
            IRequest Request;
            IResults Results;

            public Rest(IRequest request, IResults results)
            {
                // dependency injection
                this.Request = request;
                this.Results = results;
            }
            public String DoRequest()
            {
                string Url = Request.FormatURL();

                var client = new RestClient(Url);
                var restRequest = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(restRequest);


                Results = JsonConvert.DeserializeObject<Results> (response.Content);
                return Results.ToString();
            }
        }
    }

    namespace Search
    {
        class _Request
        {
            public string Command { get; set; }
            public string Fragment { get; set; }
        }
        public class Request
        {
            private readonly _Request request = new _Request();
            public Request Command(string command)
            {
                request.Command = command;
                return this;
            }
            public Request Fragment(string fragment)
            {
                request.Fragment = fragment;
                return this;
            }
            public new string ToString()
            {
                return request.ToString();
            }
            public Results Execute()
            {

                string Url = String.Format("{0}/{1}/{2}?token={3}",
                                Configs.urlBase,
                                request.Command,
                                request.Fragment,
                                Configs.AccessToken);

                var client = new RestClient(Url);
                var restRequest = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(restRequest);

                Results results = JsonConvert.DeserializeObject<Results>(response.Content);

                return results;
            }

        }
        public class _Result
        {
            [JsonProperty("symbol")]
            public string Symbol { get; set; }
            [JsonProperty("securityName")]
            public string SecurityName { get; set; }
            [JsonProperty("securityType")]
            public string SecurityType { get; set; }
            [JsonProperty("region")]
            public string Region { get; set; }
            [JsonProperty("exchange")]
            public string Exchange { get; set; }

        }
        public class Results : List<_Result>
        {
            public new string ToString()
            {
                return JsonConvert.SerializeObject(this, Formatting.Indented);
            }
        }

    }

    public abstract class IRequest
    {
        public abstract string FormatURL();
    }
    public abstract class IResults
    {
        public new string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }

    public class RequestBase
    {
        public string Category { get; set; }
        public string Command { get; set; }
        public string Symbol { get; set; }
    }

    public class Configs
    {
        public static string AccessToken { get; set; }
        public static string urlBase = "https://sandbox.iexapis.com/stable";
    }



}

