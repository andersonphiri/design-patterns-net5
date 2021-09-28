using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Problem
{
    public class GoldSplitProblem
    {
        public void DoGoldSplitProblematic()
        {
            int gold = 1023;
            var a = new Person { Name = "A" };
            var b = new Person { Name = "B" };
            var c = new Person { Name = "C" };
            var d = new Person { Name = "D" };
            var e = new Person { Name = "E" };
            var devs = new Group { Name = "Devs", Members = { a, b, c } };
            var individuals = new List<Person> { c, d };
            var groups = new List<Group> { devs };
            var totalToSplitBy = individuals.Count + groups.Count;
            var amountForeach = gold / totalToSplitBy;
            var leftOver = gold % totalToSplitBy;

            foreach (var person  in individuals)
            {
                person.Gold += amountForeach + leftOver;
                leftOver = 0;
                person.Stats();
            }
            // then split groups

            foreach (var group in groups)
            {
                // then further split for each group
            }
        }
    }
}
