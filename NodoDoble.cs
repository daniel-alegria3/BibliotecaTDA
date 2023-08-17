
namespace lista_doblemente_enlazada
{
    public class NodoDoble
    {
        public object? valor;
        public NodoDoble? anterior;
        public NodoDoble? posterior;

        public NodoDoble ( object? valor, NodoDoble? anterior, NodoDoble? siguiente )
        {
            this.valor = valor;
            this.anterior = anterior;
            this.posterior = siguiente;
        }

        public NodoDoble ( )
        {
            vaciar();
        }

        public bool es_vacio ( )
        {
            return valor == null && posterior == null;
        }

        public void vaciar ( )
        {
            valor = null;
            anterior = null;
            posterior = null;
        }
    }
}

