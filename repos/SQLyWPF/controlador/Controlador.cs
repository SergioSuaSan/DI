using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLyWPF
{
    
    public class Controlador
    {
        Modelo modelo;
      
        public Controlador()
        {
            modelo = new Modelo();

        }

        internal string eliminarCliente(string IdCliente)
        {
            return modelo.eliminarCliente(IdCliente);
        }

        internal string eliminarPedido(string IdPedido)
        {
            return modelo.eliminarPedido(IdPedido);
        }

        internal string getCampoCliente()
        {
            return modelo.getCampoCliente();
        }

        internal string getCampoPedido()
        {
            return modelo.getCampoPedido();
        }

        internal string getPKCliente()
        {
            return modelo.getPKCliente();
        }

        internal string getPKPedido()
        {
            return modelo.getPKPedido();
        }

        internal string insertarCliente(string text)
        {
            return modelo.insertarCliente(text); 
        }

        internal DataTable muestraClientes()
        {
            return modelo.muestraClientes();
        }

        internal DataTable muestraPedidos()
        {
            return modelo.muestraPedidos();
        }

        internal DataTable muestraPedidosPorCliente(string IdCliente)
        {
            return modelo.muestraPedidosPorCliente(IdCliente);
        }
    }
}
