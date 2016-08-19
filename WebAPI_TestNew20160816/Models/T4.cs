using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI_TestNew20160816.Models
{
    public class T4
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string AgentID { get; set; }

        public string Name { get; set; }
        //public List<string> ACDID { get; set; }//40001,40018
        public string NotWorkOnTime_times { get; set; }  //未值機次數
    }
}