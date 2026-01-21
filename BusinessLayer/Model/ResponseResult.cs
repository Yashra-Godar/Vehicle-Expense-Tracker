using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Model
{
    public class ResponseResult
    {
        public ResponseResult(string status, object result)
        {
            this.status = status;
            this.result = result;
        }
        public string status { get; set; }

        public object result { get; set; }
    }
}
