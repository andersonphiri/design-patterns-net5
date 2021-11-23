using System.Collections;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace LazyLoad.Ghosts
{
    public abstract class DomainObject
    {
        public int Id { get; set; }
        private LoadStatus Status;
        protected DomainObject(int id)
        {
            Id = id;
        }
        public bool IsGhost { get => Status == LoadStatus.Ghost;  }
        public bool IsLoaded { get => Status == LoadStatus.Loaded; }
        public void MarkLoading()
        {
            Debug.Assert(IsGhost);
            Status = LoadStatus.Loading;
        }
        public void MarkLoaded()
        {
            Debug.Assert(Status == LoadStatus.Loading);
            Status = LoadStatus.Loaded;
        }
        public virtual void Load()
        {
            if (!IsGhost) return;
            var dataRow = GetDataRow();
            LoadLine(dataRow);
        }
        private void LoadLine(ArrayList dataRow)
        {
            if (!IsGhost) return;
            MarkLoading();
            DoLoadLine(dataRow);
            MarkLoaded();
        }
        protected abstract void DoLoadLine(ArrayList dataRow);
        protected abstract ArrayList GetDataRow();
    }
}
