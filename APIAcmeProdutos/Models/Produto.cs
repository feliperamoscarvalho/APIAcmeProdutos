using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APIAcmeProdutos.Models
{
    [Table("Produto")]
    public class Produto
    {
        public int ID { get; set; }
        public String Cliente { get; set; }
        public String Nome { get; set; }
    }
}