using System.Collections;

namespace LazyLoad.Ghosts
{
    public class Customer : DomainObject
    {
        public Customer(int id)
            : base(id)
        {
        }

        protected override void DoLoadLine(ArrayList dataRow)
        {
            
        }

        protected override ArrayList GetDataRow()
        {
            return null;
        }
    }
}
