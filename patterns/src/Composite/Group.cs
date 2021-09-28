using System.Collections.Generic;
using System.Linq;

namespace Composite
{
    public class Group : Party
    {
        public string Name { get; set; }
        public List<Party> Members { get; set; } = new();

        public int Gold 
        { 
            get
            {
                return Members.Sum(m => m.Gold);
            } 
            set
            {
                var share = value / Members.Count;
                var lo = value % Members.Count;
                foreach (var member in Members)
                {
                    member.Gold += share + lo;
                    lo = 0;
                }
            } 
        }

        public void Stats()
        {
            Members.ForEach(m => m.Stats());
        }
    }
}
