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

    public bool EsVacio ( )
    {
        return valor == null && subcabeza == null;
    }

    public void Acolar ( object? val )
    {
        if ( EsVacio() ) {
            valor = val;
            subcabeza = new Cola();
            return;
        }
        subcabeza.Acolar( val );
    }

    public object? Desacolar ( )
    {
        if ( EsVacio() )
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

