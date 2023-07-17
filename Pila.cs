namespace BibliotecaTDA;

public class Pila
{
    private object? valor;
    private Pila? subpila;

    public Pila ()
    {
        valor = null;
        subpila = null;
    }

    public Pila ( object? valor, Pila? subpila )
    {
        this.valor = valor;
        this.subpila = subpila;
    }

    public bool es_vacio ( )
    {
        return valor == null && subpila == null;
    }

    public void apilar ( object? val )
    {
        subpila = new Pila ( valor, subpila );
        valor = val;
    }

    public object? desapilar ( )
    {
        if ( es_vacio() )
            return null;

        object? val = valor;
        valor = subpila.valor;
        subpila = subpila.subpila;

        return val;
    }

    public object? cima ( )
    {
        return valor;
    }

}

