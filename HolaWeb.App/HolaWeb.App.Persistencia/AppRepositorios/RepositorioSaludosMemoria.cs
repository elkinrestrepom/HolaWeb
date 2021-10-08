using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using HolaWeb.App.Dominio;

namespace HolaWeb.App.Persistencia.AppRepositorios
{
    public class RepositorioSaludosMemoria : IRepositorioSaludos    

    {
        List<Saludo> saludos;
        public RepositorioSaludosMemoria()
        {
            saludos= new List<Saludo>( )  
            {
                new Saludo {Id=1, EnEspanol="Buenos dias", EnIngles="Good Morning", EnItaliano="Bon Dia"},
                new Saludo {Id=2, EnEspanol="Buenos Tardes", EnIngles="Good Afternoon", EnItaliano="Bon Tarde"},
                new Saludo {Id=3, EnEspanol="Buenos Noches", EnIngles="Good Night", EnItaliano="Bon Nochie"}

            };
        }
        public IEnumerable<Saludo> GetAll()
        {
            return saludos;
        }
        
        public Saludo GetSaludoPorId(int saludoId)
        {
            return saludos.SingleOrDefault(s => s.Id==saludoId);
        }
        public IEnumerable<Saludo> GetSaludosPorFiltro(string filtro=null)
        {
            var saludos = GetAll();
            if (saludos != null)    // Si se tienen saludos
            {
                
                if(!String.IsNullOrEmpty(filtro)) // Si el filtro tiene algún valor
                {
                    saludos = saludos.Where(s =>s.EnEspanol.Contains(filtro));

                }
            }
            return null;
        }

        public IEnumerable<Saludo> Update(Saludo saludoActualizado)
        {
            var saludo= saludos.SingleOrDefault(r => saludoActualizadoId);

            if(saludo!= null)
            {
                saludo.EnEspanol = saludoActualizado.EnEspanol;
                saludo.EnIngles = saludoActualizado.EnIngles;
                saludo.EnItaliano = saludoActualizado.EnItaliano;
            }
            return saludo;
        }
    }
}