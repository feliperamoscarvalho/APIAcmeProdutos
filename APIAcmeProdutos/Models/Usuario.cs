using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIAcmeProdutos.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        public String Cliente { get; set; } //indica se é um cliente "coyote" ou "papa-leguas"
        public String Nome { get; set; }
        public String registration_id { get; set; } //registration id do dispositivo do usuário
    }
}