# FinTech
This folder contains my collection of FINTECJ programs. 
Starting with IEX which is a dotnet sample program for accessing IEX 
(The Investor's Exchange).
It uses a fluent interface to facilitate the class initialization process.

Example:

        Request request = new Request();
        request.Symbol("AAPL").Command("company");
        Results results = new IEX.Stock.Results();
        IEX.Stock.Rest action = new IEX.Stock.Rest(request, results);
