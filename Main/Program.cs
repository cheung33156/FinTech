// Copyright 2020 Tsz Ning Cheung 

using System;
using IEX;
using IEX.Stock;


class Program
{
    static void Main(string[] args)
    {
        IEX.Configs.AccessToken = "Tsk_750bc3b4e374437faf4e067b9799e806";

        //IEX.Search.Request obj = new IEX.Search.Request();
        //string response = obj.Command("search")
        //    .Fragment("Apple")
        //    .Execute()
        //    .ToString();
        Request request = new Request();
        request.Symbol("AAPL").Command("company");

        Results results = new IEX.Stock.Results();

        IEX.Stock.Rest action = new IEX.Stock.Rest(request, results);
        Console.WriteLine(action.DoRequest());
        Console.ReadLine();

    }
}

