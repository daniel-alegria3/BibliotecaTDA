namespace BibliotecaTDA;

public class ListaRecursiva
{
    private object? value;
    private ListaRecursiva? sublista;

    public ListaRecursiva ( object? value, ListaRecursiva? sublista ) {
        this.value = value;
        this.sublista = sublista;
    }

    public ListaRecursiva ( ) {
        value = null;
        sublista = null;
    }

    public bool EsVacio ( )
    {
        return value == null && sublista == null;
    }

    public void Listar ( )
    {
        if ( EsVacio() ) {
            Console.Write("\n");
            return;
        }
        Console.Write($"{value}, ");
        sublista.Listar();
    }

    public uint Longitud ( )
    {
        if ( EsVacio() )
            return 0;
        return 1 + sublista.Longitud();
    }

    public void Agregar ( object? target )
    { // returns true if succesful
        if ( EsVacio() ) {
            value = target;
            sublista = new ListaRecursiva();
            return;
        }
        sublista.Agregar( target );
    }

    public bool Insertar ( object? target, uint pos )
    { // returns true if succesful
        if ( pos >= Longitud() )
            return false;

        if ( pos == 0 ) {
            sublista = new ListaRecursiva( value, sublista );
            value = target;
            return true;
        }

        sublista.Insertar( target, pos-1 );
        return false;
    }

    public object? Iesimo ( uint pos )
    { // returns obj at index 'pos'
        if ( pos >= Longitud() )
            return null;

        if ( pos == 0 ) {
            return value;
        }

        return sublista.Iesimo( pos-1 );
    }

    public uint? Ubicacion ( object? target )
    { // returns zero-based index of the first 'target' ocurrence
        if ( EsVacio() )
            return null;

        if ( value.Equals( target ) )
            return 0;

        return 1 + sublista.Ubicacion( target );
    }

    public bool Remover ( object? target )
    {
        if ( EsVacio() )
            return false;

        if ( value.Equals( target ) ) {
            value = sublista.value;
            sublista = sublista.sublista;
            return true;

        }

        sublista.Remover( target );

        return false;
    }

    public object? Pop ( uint pos )
    { // returns element at index 'pos' and removes it
        if ( pos >= Longitud() )
            return null;

        if ( pos == 0 ) {
            object? val = value;

            value = sublista.value;
            sublista = sublista.sublista;
            return val;
        }

        return sublista.Pop( pos-1 );
    }

}

