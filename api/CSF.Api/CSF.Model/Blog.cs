using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CSF.Model
{
    [Table("Blog")]
    public class Blog : BaseModel
    {
        public string Body { get; set; }
    }
}
