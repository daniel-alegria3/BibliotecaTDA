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

    public bool es_vacia ( )
    {
        return value == null && sublista == null;
    }

    public void listar ( )
    {
        if ( es_vacia() ) {
            Console.Write("\n");
            return;
        }
        Console.Write($"{value}, ");
        sublista.listar();
    }

    public uint longitud ( )
    {
        if ( es_vacia() )
            return 0;
        return 1 + sublista.longitud();
    }

    public void agregar ( object target )
    { // returns true if succesful
        if ( es_vacia() ) {
            value = target;
            sublista = new ListaRecursiva();
            return;
        }
        sublista.agregar( target );
    }

    public bool insertar ( object target, uint pos )
    { // returns true if succesful
        if ( pos >= longitud() )
            return false;

        if ( pos == 0 ) {
            sublista = new ListaRecursiva( value, sublista );
            value = target;
            return true;
        }

        sublista.insertar( target, --pos );
        return false;
    }

    public object? iesimo ( uint pos )
    { // returns obj at index 'pos'
        if ( pos >= longitud() )
            return null;

        if ( pos == 0 ) {
            return value;
        }

        return sublista.iesimo( --pos );
    }

    public uint? ubicacion ( object target )
    { // returns zero-based index of the first 'target' ocurrence
        if ( es_vacia() )
            return null;

        if ( value.Equals( target ) )
            return 0;

        return 1 + sublista.ubicacion( target );
    }

    public bool remover ( object target )
    {
        if ( es_vacia() )
            return false;

        if ( value.Equals( target ) ) {
            value = sublista.value;
            sublista = sublista.sublista;
            return true;

        }

        sublista.remover( target );

        return false;
    }

    public object? pop ( uint pos )
    { // returns element at index 'pos' and removes it
        if ( pos >= longitud() )
            return null;

        if ( pos == 0 ) {
            object? val = value;

            value = sublista.value;
            sublista = sublista.sublista;
            return val;
        }

        return sublista.pop( --pos );
    }

}

