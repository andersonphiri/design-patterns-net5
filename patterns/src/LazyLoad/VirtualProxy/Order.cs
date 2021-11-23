using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoad.VirtualProxy
{
    public class Order
    {
        public int Id { get; set; }

        public virtual Customer Customer { get; set; }
        public string PrintLabel()
        {
            return Customer.CompanyName + "\n" + Customer.Address;
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
    public class OrderProxy : Order
    {
        public override Customer Customer { get
            {
                return base.Customer ?? (base.Customer = new());
            }
                
            set => base.Customer = value; 
        }
        public override bool Equals(object obj)
        {
            var other = obj as Order;
            if (other == null) return false;
            return other.Id == this.Id;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
    public class OrderFactory
    {
        public static Order CreateFromId(int id) => new OrderProxy() { Id = id, };
    }

}
