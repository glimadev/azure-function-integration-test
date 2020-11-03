using System;

namespace azure_function_integration_test.Tests
{
    public class BaseTest
    {
        public static int Port { get; } = 7071;
        public Uri Endpoint = new Uri($"http://localhost:{Port}");
    }
}
