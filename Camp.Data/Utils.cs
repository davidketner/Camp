using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Camp.Data
{
    public class ResultSvc<T>
    {
        public virtual bool IsOK => Errors.Count == 0;
        public T Obj { get; set; }
        private ICollection<string> errors;
        public virtual ICollection<string> Errors
        {
            get { return errors ?? (errors = new HashSet<string>()); }
            set { errors = value; }
        }

        public ResultSvc(ICollection<string> Errors, T Obj)
        {
            this.Errors = Errors;
            this.Obj = Obj;
        }

        public virtual string Message => !IsOK ? Errors.Aggregate((i, j) => i + " " + j) : "";
    }
}
