using Adapter.Model;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Adapter.UnitTests
{
    public class PatternRendererShould
    {
        [Fact]
        public void RenderTwoPatterns()
        {
            var myRenderer = new PatternRenderer();

            var myList = new List<Pattern>
                             {
                                 new Pattern {Id = 1, Name = "Pattern One", Description = "Pattern One Description"},
                                 new Pattern {Id = 2, Name = "Pattern Two", Description = "Pattern Two Description"}
                             };

            string result = myRenderer.ListPatterns(myList);

            Console.Write(result);

            int lineCount = result.Count(c => c == '\n');
            lineCount.Should().Be(myList.Count + 1);
        }
    }
}
