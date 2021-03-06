﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace MyFirstWebService
{
    class MyFirstWebService
    {
        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        static readonly HttpClient client = new HttpClient();

        static async Task Main()
        {
            JsonDocument contracts = await getContracts();
            JsonElement a = await getAContract("toulouse");
            String[] s = listStationsWithBikesAvailabilities(a);
            Console.WriteLine(a.GetArrayLength());
            // JsonDocument oneContract = await getAContract(contracts.RootElement[2].GetProperty("contract_name").ToString());
            JsonDocument news = await getNewsByContract(contracts.RootElement[2].GetProperty("number").GetInt32(), contracts.RootElement[2].GetProperty("contract_name").ToString());
            // Console.WriteLine(contracts);
            Console.WriteLine("ville de la news : "+news.RootElement.GetProperty("contractName"));
            // Console.WriteLine(users);
            Console.ReadKey();
        }
        //public static async Task<string> getContracts()
        //{
        //    HttpResponseMessage response = await client.GetAsync("https://api.jcdecaux.com/vls/v1/stations?&apiKey=fd8a1c81d81337532f88e746a545e0721fe29ccc");
        //    response.EnsureSuccessStatusCode();
        //    return await response.Content.ReadAsStringAsync();
        //}
        public static async Task<JsonDocument> getContracts()
        {
            var response = await client.GetStreamAsync("https://api.jcdecaux.com/vls/v1/stations?&apiKey=fd8a1c81d81337532f88e746a545e0721fe29ccc");
            return await JsonDocument.ParseAsync(response);
        } 
        async static public Task <JsonElement> getAContract(string param)
        {
            var response = await client.GetStreamAsync("https://api.jcdecaux.com/vls/v1/stations?contract="+param+"&apiKey=fd8a1c81d81337532f88e746a545e0721fe29ccc");
            JsonDocument contract = await JsonDocument.ParseAsync(response);
            return contract.RootElement;

        }
        async static public Task<JsonDocument> getNewsByContract(int number, string param)
        {
            var response = await client.GetStreamAsync("https://api.jcdecaux.com/vls/v3/stations/"+number+"?contract="+param+"&apiKey=2dae8548640ca7455930eb98ca0508a102ac8c1a");
            return await JsonDocument.ParseAsync(response);

        }
        static public String[] listStations(JsonElement stations)
        {
            int numberStations = stations.GetArrayLength();
            String[] s = new string[numberStations];
            for (int i = 0; i < numberStations; i++)
            {
                s[i] = stations[i].GetProperty("name").ToString();
                Console.WriteLine(stations[i].GetProperty("name").ToString());
            }
            Console.WriteLine(stations[0]);
            return s;
        }
        static public String[] listStationsWithBikesAvailabilities(JsonElement stations)
        {
            int numberStations = stations.GetArrayLength();
            String[] s = new string[numberStations];
            for (int i = 0; i < numberStations; i++)
            {
                if (int.Parse(stations[i].GetProperty("available_bikes").ToString()) > 0)
                {
                    s[i] = stations[i].GetProperty("name").ToString();
                    Console.WriteLine(stations[i].GetProperty("name").ToString());
                    Console.WriteLine("Nombre de vélos disponibles : "+ stations[i].GetProperty("available_bikes").ToString());
                }
            }
            Console.WriteLine(stations[0]);
            return s;
        }
    }
}
