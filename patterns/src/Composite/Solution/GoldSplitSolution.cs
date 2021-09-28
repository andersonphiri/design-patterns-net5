using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite.Solution
{
    /// <summary>
    /// The approach is to treat List<Person> and List<Person> as the same, so Group and Person should implement the same class
    /// The lowest level is the Person class, so the interface should be based on the person class logic
    /// </summary>
    public class GoldSplitSolution
    {
        public void RunSolution()
        {
            int gold = 1023;
            var a = new Person { Name = "A" };
            var b = new Person { Name = "B" };
            var c = new Person { Name = "C" };
            var d = new Person { Name = "D" };
            var e = new Person { Name = "E" };
            var devs = new Group { Name = "Devs", Members = { a, b, c } };
            var individuals = new List<Person> { c, d };
            var parties = new List<Party> { devs, d, e };

            var totalToSplitBy = parties.Count;
            var amountForeach = gold / totalToSplitBy;
            var leftOver = gold % totalToSplitBy;

            foreach (var person in parties)
            {
                person.Gold += amountForeach + leftOver;
                leftOver = 0;
                person.Stats();
            }
        }

        public void RunWithRootSolution()
        {
            int gold = 1023;
            var a = new Person { Name = "A" };
            var b = new Person { Name = "B" };
            var c = new Person { Name = "C" };
            var d = new Person { Name = "D" };
            var e = new Person { Name = "E" };
            var f = new Person { Name = "F" };
            var g = new Person { Name = "G" };
            var devs = new Group { Name = "Devs", Members = { a, b, c } };
            var individuals = new List<Person> { d, e };

            var root = new Group { Members = { devs, f, g } };

            root.Gold += gold;
        }
    }
}
