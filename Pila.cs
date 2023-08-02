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

    public bool EsVacia ( )
    {
        return valor == null && subpila == null;
    }

    public void Apilar ( object? val )
    {
        subpila = new Pila ( valor, subpila );
        valor = val;
    }

    public object? Desapilar ( )
    {
        if ( EsVacia() )
            return null;

        object? val = valor;
        valor = subpila.valor;
        subpila = subpila.subpila;

        return val;
    }

    public object? Cima ( )
    {
        return valor;
    }

    public void mostrar ()
    {
        if ( EsVacia() ) {
            return;
        }
        subpila.mostrar();
        Console.Write($"{valor}, ");
    }

}

