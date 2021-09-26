using Adapter.Library;
using Adapter.Test;
using System;
using Xunit;
using FluentAssertions;
using System.IO;
using System.Linq;
using System.Data.OleDb;

namespace Adapter.UnitTests
{
    public class DataRendererShould
    {
        [Fact]
        public void RenderTwoRowGivenStubDataAdapter()
        {
            var myRenderer = new DataRenderer(new StubAdapater());
            var writer = new StringWriter();
            myRenderer.Render(writer);
            string result = writer.ToString();
            int lineCount = result.Count(c => c == '\n');
            lineCount.Should().Be(2);
        }

        [Fact]
        public void RenderTwoRowsGivenOleDbDataRenderer()
        {
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
            {
                var adapter = new OleDbDataAdapter();
                adapter.SelectCommand = new OleDbCommand("SELECT * FROM Pattern");
                adapter.SelectCommand.Connection =
                    new OleDbConnection(
                        @"Provider=Microsoft.SQLSERVER.CE.OLEDB.3.5;Data Source=Sample.sdf");
                var myRenderer = new DataRenderer(adapter);

                var writer = new StringWriter();
                myRenderer.Render(writer);

                string result = writer.ToString();
                Console.Write(result);

                int lineCount = result.Count(c => c == '\n');
                lineCount.Should().Be(3);
                return;
            }
            Assert.True(true);
            return;
            
        }

    }
}
