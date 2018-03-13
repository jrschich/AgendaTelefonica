using AgendaTelefonica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgendaTelefonica.DAO
{
    public class AgendaDAO
    {
        private AgendaContext _context;

        public AgendaDAO()
        {
            _context = new AgendaContext();
        }

        public void Incluir(Agenda obj)
        {
            _context.Contatos.Add(obj);
            _context.SaveChanges();
        }

        public void Alterar(Agenda obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public Agenda ObterContato(int idContato)
        {
            return _context.Contatos.FirstOrDefault(p => p.Id == idContato);
        }

        public List<Agenda> ListarAgenda()
        {
            return _context.Contatos.ToList();
        }
        
        public void Excluir(Agenda obj)
        {
            _context.Contatos.Remove(obj);
            _context.SaveChanges();
        }
    }
}