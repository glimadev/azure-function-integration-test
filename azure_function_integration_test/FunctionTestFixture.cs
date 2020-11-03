using azure_function_integration_test.Tests;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Xunit;

namespace azure_function_integration_test
{
    public class FunctionTestFixture : BaseTest, IDisposable
    {
        private readonly Process _funcHostProcess;

        public FunctionTestFixture()
        {
            var dotnetExePath = Environment.ExpandEnvironmentVariables("%ProgramFiles%\\dotnet\\dotnet.exe");
            var functionHostPath = Environment.ExpandEnvironmentVariables("%APPDATA%\\npm\\node_modules\\azure-functions-core-tools\\bin\\func.dll");
            var functionAppFolder = Path.GetRelativePath(Directory.GetCurrentDirectory(), "..\\..\\..\\..\\azure_function\\bin\\Debug\\netcoreapp3.1");

            _funcHostProcess = new Process
            {
                StartInfo =
                {
                    FileName = dotnetExePath,
                    Arguments = $"\"{functionHostPath}\" start -p {Port}",
                    WorkingDirectory = functionAppFolder
                }
            };

            var success = _funcHostProcess.Start();

            if (!success)
            {
                throw new InvalidOperationException("Could not start Azure Functions host.");
            }

            Thread.Sleep(TimeSpan.FromSeconds(10));
        }

        public virtual void Dispose()
        {
            if (!_funcHostProcess.HasExited)
            {
                _funcHostProcess.Kill();
            }

            _funcHostProcess.Dispose();
        }
    }
}
