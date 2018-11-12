using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NBench;
using ProjectManager.EntityModel;
using ProjectManager.API;
using ProjectManager.API.Controllers;
using System.Net.Http;
using System.Web.Http;


namespace ProjectManager.PerformanceTest
{
    public class PerformanceTest
    {
        private const string CounterName = "Counter";
        private Counter counter;
        private int key;
        private const int AcceptableMinThroughput = 100;

        [PerfSetup]
        public void setup(BenchmarkContext context)
        {
            counter = context.GetCounter(CounterName);
            key = 0;
        }

        [PerfBenchmark(NumberOfIterations = 500,RunMode =RunMode.Throughput,RunTimeMilliseconds = 600000,TestMode = TestMode.Measurement)]
        [CounterMeasurement(CounterName)]
        [CounterThroughputAssertion(CounterName,MustBe.GreaterThan,AcceptableMinThroughput)]
        public void BenchMark(BenchmarkContext context)
        {
            var controller = new ProjectController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            List<TaskData> Response = controller.Get().ToList();
            counter.Increment();            
        }

        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput, RunTimeMilliseconds = 600000, TestMode = TestMode.Measurement)]
        [CounterMeasurement(CounterName)]
        [CounterThroughputAssertion(CounterName, MustBe.GreaterThan, AcceptableMinThroughput)]
        public void BenchMarkFirst(BenchmarkContext context)
        {
            var controller = new ProjectController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            List<ProjectData> Response = controller.GetAllProjects().ToList<ProjectData>();
            counter.Increment();
        }
        [PerfBenchmark(NumberOfIterations = 500, RunMode = RunMode.Throughput, RunTimeMilliseconds = 600000, TestMode = TestMode.Measurement)]
        [CounterMeasurement(CounterName)]
        [CounterThroughputAssertion(CounterName, MustBe.GreaterThan, AcceptableMinThroughput)]
        public void BenchMarkSecond(BenchmarkContext context)
        {
            var controller = new ProjectController()
            {
                Request = new System.Net.Http.HttpRequestMessage(),
                Configuration = new HttpConfiguration()
            };
            List<UserData> Response = controller.GetAllUsers().ToList<UserData>();
            counter.Increment();
        }
    }
}
