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

    public bool es_vacio ( )
    {
        return valor == null && subcabeza == null;
    }

    public bool es_lleno ( )
    {
        return false;
    }

    public void colar ( object? val )
    {
        if ( es_vacio() ) {
            valor = val;
            subcabeza = new Cola();
            return;
        }
        subcabeza.colar( val );
    }

    public object? desacolar ( )
    {
        if ( es_vacio() )
            return null;

        object? val = valor;
        valor = subcabeza.valor;
        subcabeza = subcabeza.subcabeza;

        return val;
    }

    public object? cabeza ( )
    {
        return valor;
    }

}

