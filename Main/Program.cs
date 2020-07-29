using System;


class Program
{
    static void Main(string[] args)
    {
        //URL for getting token https://finnhub.io/dashboard; 
        const string token = "Tsk_750bc3b4e374437faf4e067b9799e806";
        //const string token = "pk_4047e8513786474ba659893830c036ad";

        IEX.Search.FluentRequest obj = new IEX.Search.FluentRequest();
        string response = obj.Token(token)
            .Command("search")
            .Fragment("Apple")
            .Execute()
            .ToString();

        Console.WriteLine(response);
        Console.ReadLine();
    }
}

