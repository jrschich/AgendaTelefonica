using AgendaTelefonica.DAO;
using AgendaTelefonica.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgendaTelefonica.BLL
{
    public class ContatoBLL
    {
        private AgendaDAO _dao;

        public ContatoBLL()
        {
            _dao = new AgendaDAO();
        }

        public List<Agenda> ListarContatos()
        {
            var lstContatos = _dao.ListarAgenda();

            return lstContatos.OrderBy(p => p.Nome).ToList();

        }

        public Agenda ObterPorId(int id)
        {
            return _dao.ObterContato(id);
        }

        public void Incluir(Agenda obj)
        {
            Validacoes(obj);
            _dao.Incluir(obj);
        }

        public void Alterar(Agenda obj)
        {
            Validacoes(obj);
            _dao.Alterar(obj);
        }

        public void Excluir(Agenda obj)
        {
            _dao.Excluir(obj);
        }

        private void Validacoes(Agenda obj)
        {
            if (string.IsNullOrEmpty(obj.Nome) || obj.Nome.Length < 5)
                throw new Exception("Campo Nome é obrigatório e deve ter no minimo 5 caracteres!");

            if (string.IsNullOrEmpty(obj.TelefoneCasa) && string.IsNullOrEmpty(obj.TelefoneTrabalho) && string.IsNullOrEmpty(obj.TelefoneCelular) && string.IsNullOrEmpty(obj.TelefoneOutro))
                throw new Exception("Informe pelo menos 1 dos telefones!");

            if (string.IsNullOrEmpty(obj.EmailParticular) && string.IsNullOrEmpty(obj.EmailTrabalho) && string.IsNullOrEmpty(obj.EmailOutro))
                throw new Exception("Informe pelo menos 1 dos E-mails!");            
        }
    }
}