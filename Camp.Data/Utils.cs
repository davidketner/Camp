using System;
using System.Collections.Generic;
using System.Text;

namespace Camp.Data
{
    public class ResultSvc
    {
        public bool IsOK { get; set; }
        public IEnumerable<string> Errors { get; set; }

        public ResultSvc(bool IsOK, IEnumerable<string> Errors)
        {
            this.IsOK = IsOK;
            this.Errors = Errors;
        }
    }
}
