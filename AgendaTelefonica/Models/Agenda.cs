using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgendaTelefonica.Models
{
    public class Agenda
    {
        public int Id { get; set; }
        
        [Required]
        public string Nome { get; set; }

        public string Empresa { get; set; }

        public string Endereco { get; set; }
        
        [Phone(ErrorMessage = "Campo Telefone Residencial não é um número de telefone válido.")]        
        public string TelefoneCasa { get; set; }

        [Phone(ErrorMessage = "Campo Telefone Comercial não é um número de telefone válido.")]
        public string TelefoneTrabalho { get; set; }

        [Phone(ErrorMessage = "Campo Telefone Celular não é um número de telefone válido.")]
        public string TelefoneCelular { get; set; }

        [Phone(ErrorMessage = "Campo Outro Telefone não é um número de telefone válido.")]
        public string TelefoneOutro { get; set; }

        [EmailAddress(ErrorMessage = "Campo E-mail Particular é inválido.")]
        public string EmailParticular { get; set; }

        [EmailAddress(ErrorMessage = "Campo E-mail Comercial é inválido.")]
        public string EmailTrabalho { get; set; }

        [EmailAddress(ErrorMessage = "Campo Outro E-mail é inválido.")]
        public string EmailOutro { get; set; }

        public string TelefonePrincipal {
            get
            {
                if (!string.IsNullOrEmpty(TelefoneCelular))
                    return TelefoneCelular;
                if (!string.IsNullOrEmpty(TelefoneCasa))
                    return TelefoneCasa;
                if (!string.IsNullOrEmpty(TelefoneTrabalho))
                    return TelefoneTrabalho;
                else
                    return TelefoneOutro;
            }
        }

        public string EmailPrincipal
        {
            get
            {
                if (!string.IsNullOrEmpty(EmailParticular))
                    return EmailParticular;
                if (!string.IsNullOrEmpty(EmailTrabalho))
                    return EmailTrabalho;                
                else
                    return EmailOutro;
            }
        }
    }
}