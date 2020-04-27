using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ThreadExample
{
    class Program
    {
        private static void logit(string logmesage)
        {
            var now = DateTime.Now.ToString();
            Console.WriteLine($"{now} - {logmesage}");
        }
        private static void logline()
        {
            Console.WriteLine("----------------------------------------------------------");
        }
        static string url = "https://localhost:44392/slow";
        
        static async Task Main(string[] args)
        {
            logit("warmup");
            var request = WebRequest.CreateHttp(url);
            request.Method = "GET";
            var task = Task.FromResult(request.GetResponse());
            logit("warmup done");
            logline();
            await Plain();
            logline();
            await FromResult();
            logline();
            await TaskRun();
            logline();
            await AwaitTask();
            logline();
        }

        static async Task FromResult()
        {
            logit("fromresult started");
            var request = WebRequest.CreateHttp(url);
            request.Method = "GET";
            var task = Task.FromResult(request.GetResponse());
            logit("fromresult task started");
            var result = await task;
            logit("fromresult done");
        }

        static async Task TaskRun()
        {
            logit("taskrun started");
            var request = WebRequest.CreateHttp(url);
            request.Method = "GET";
            var task = Task.Run(() => request.GetResponse());
            logit("taskrun task started");
            var result = await task;
            logit("taskrun done");
        }

        static async Task Plain()
        {
            logit("plain started");
            var request = WebRequest.CreateHttp(url);
            request.Method = "GET";
            var result = request.GetResponse();
            logit("plain done");
        }

        static async Task AwaitTask()
        {

            logit("awaittask started");
            var request = WebRequest.CreateHttp(url);
            request.Method = "GET";
            var task = request.GetResponseAsync();
            logit("awaittask task started");
            var result = await task;
            logit("awaittask done");

        }
    }
}
