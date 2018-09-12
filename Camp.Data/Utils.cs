using System;
using System.Collections.Generic;
using System.Text;

namespace Camp.Data
{
    public class ResultSvc<T>
    {
        public bool IsOK { get; set; }
        public T Obj { get; set; }
        private ICollection<string> errors;
        public virtual ICollection<string> Errors
        {
            get { return errors ?? (errors = new HashSet<string>()); }
            set { errors = value; }
        }

        public ResultSvc(bool IsOK, ICollection<string> Errors, T Obj)
        {
            this.IsOK = IsOK;
            this.Errors = Errors;
            this.Obj = Obj;
        }
    }
}
