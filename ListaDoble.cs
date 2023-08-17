using System;

/* INTEGRANTES
 * Jesus Augusto Alegria Mendoza       (2152)
 * Fredy Jhon Choquemaqui Chinchercoma (215274)
 * Alegria Sallo Daniel Rodrigo        (215270)
 */


namespace lista_doblemente_enlazada
{
    public class ListaDoble
    {
        private NodoDoble primer_nodo;
        private NodoDoble actual_nodo;
        private NodoDoble ultimo_nodo;

        public NodoDoble? PrimerNodo
        {
            get { if ( es_vacio() ) return null; return actual_nodo;
            }
        }

        public NodoDoble? UltimoNodo
        {
            get { if ( es_vacio() ) return null; return ultimo_nodo; }
        }

        public NodoDoble? ActualNodo
        {
            get { if ( es_vacio() ) return null; return actual_nodo; }
        }


        public ListaDoble ( )
        {
            vaciar();
        }

        // public ListaDoble ( NodoDoble arg1, NodoDoble arg2 ) { }


        public bool es_vacio ( )
        {
            return primer_nodo.es_vacio();
        }

        public void vaciar ( )
        {
            primer_nodo = new NodoDoble();
            ultimo_nodo = primer_nodo;

            actual_nodo = primer_nodo;
        }

        public void insertar ( object? obj, uint pos )
        {
            if ( pos >= longitud() )
                return;

            NodoDoble aux = primer_nodo;
            if ( pos < longitud() / 2 ) {
                while ( pos-- > 0 )
                    aux = aux.posterior;
            } else {
                while ( pos++ < longitud() )
                    aux = aux.anterior;
            }

            NodoDoble nuevo_nodo = new NodoDoble( aux.valor, aux, aux.posterior );
            aux.valor = obj;
            aux.posterior.anterior = nuevo_nodo;

            aux.posterior = nuevo_nodo;

            if ( aux == ultimo_nodo )
                ultimo_nodo = nuevo_nodo;
        }

        public void agregar ()
        {
        }

        public int ubicacion ( object obj )
        {
            NodoDoble aux = primer_nodo;
            int i = 0;

            while ( !aux.es_vacio() ) {
                if ( obj.Equals( aux.valor ) )
                    return i;

                aux = aux.posterior;
                ++i;
            }
            return -1;
        }

        public object? iesimo ( uint pos )
        {
            NodoDoble? nodo = iesimoNodo(pos);
            return nodo == null ? null : nodo.valor;
        }

        public NodoDoble? iesimoNodo ( uint pos )
        {
            if ( pos >= longitud() )
                return null;

            NodoDoble aux = primer_nodo;
            if ( pos < longitud() / 2 ) {
                while ( pos-- > 0 )
                    aux = aux.posterior;
            } else {
                while ( pos++ < longitud() )
                    aux = aux.anterior;
            }

            return aux;
        }

        public void remover ( object? obj )
        {
        }

        public object? pop ( uint pos ) // Eliminar
        {
            if ( pos >= longitud() )
                return null;

            if ( longitud() == 1 ) {
                object? valo = primer_nodo.valor;
                vaciar();
                return valo;
            }

            NodoDoble aux = primer_nodo;
            if ( pos < longitud() / 2 ) {
                while ( pos-- > 0 )
                    aux = aux.posterior;
            } else {
                while ( pos++ < longitud() )
                    aux = aux.anterior;
            }

            object? val = aux.valor;

            aux.posterior.anterior = aux.anterior;
            if ( aux == primer_nodo )
                primer_nodo = aux.posterior;
            else
                aux.anterior.posterior = aux.posterior;

            return val;
        }

        public int longitud ( )
        {
            int count = 0;

            NodoDoble aux = primer_nodo;
            while ( !aux.es_vacio() ) {
                ++count;
                aux = aux.posterior ;
            }

            return count;
        }

        public void agregar ( object? obj )
        {
            if ( es_vacio() ) {
                primer_nodo = new NodoDoble ( obj, null, null );
                ultimo_nodo = primer_nodo;
                return;
            }
            ultimo_nodo.posterior = new NodoDoble( obj, ultimo_nodo, null );
            ultimo_nodo = ultimo_nodo.posterior;
        }

        /// ...
        public NodoDoble? primero (  )
        {
            if ( es_vacio() )
                return null;
            actual_nodo = primer_nodo;
            return actual_nodo;
        }

        public NodoDoble? ultimo (  )
        {
            if ( es_vacio() )
                return null;
            actual_nodo = ultimo_nodo;
            return actual_nodo;
        }

        public NodoDoble? anterior (  )
        {
            if ( es_vacio() || actual_nodo.anterior == null )
                return null;
            actual_nodo = actual_nodo.anterior;
            return actual_nodo;
        }

        public NodoDoble? posterior (  )
        {
            if ( es_vacio() || actual_nodo.posterior == null )
                return null;
            actual_nodo = actual_nodo.anterior;
            return actual_nodo;
        }

        public object? elemento ( )
        {
            if ( es_vacio() )
                return null;
            return actual_nodo.valor;
        }

        public bool inicio ( )
        {
            if ( es_vacio() )
                return false;

            if ( actual_nodo.es_vacio() )
                return true;
            else
                return false;
        }

        public bool fin ( )
        {
            if ( es_vacio() )
                return false;

            if ( actual_nodo.es_vacio() )
                return true;
            else
                return false;
        }
    }
}
