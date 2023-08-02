namespace BibliotecaTDA;

public class Cola
{
    private object? valor;
    private Cola? subcabeza;

    public Cola ( )
    {
        valor = null;
        subcabeza = null;
    }

    public Cola ( object? valor, Cola? subcabeza )
    {
        this.valor = valor;
        this.subcabeza = subcabeza;
    }

    public bool EsVacia ( )
    {
        return valor == null && subcabeza == null;
    }

    public bool es_lleno ( )
    {
        return false;
    }

    public void Acolar ( object? val )
    {
        if ( EsVacia() ) {
            valor = val;
            subcabeza = new Cola();
            return;
        }
        subcabeza.Acolar( val );
    }

    public object? Desacolar ( )
    {
        if ( EsVacia() )
            return null;

        object? val = valor;
        valor = subcabeza.valor;
        subcabeza = subcabeza.subcabeza;

        return val;
    }

    public object? Cima ( )
    {
        return valor;
    }

}

