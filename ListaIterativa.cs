namespace BibliotecaTDA;

public class ListaIterativa
{
    private Nodo? first;

    public ListaIterativa ( ) {
        first = null;
    }

    public void listar ( )
    {
        // Console.WriteLine("ENLISTANDO ...");

        Nodo? curr = first;
        while ( curr != null ) {
            Console.Write($"{curr.value}, ");
            curr = curr.next;
        }
        Console.Write("\n");
    }

    public bool es_vacia ( )
    {
        return first == null;
    }

    public uint longitud ( )
    {
        uint count = 0;

        Nodo? curr = first;
        for ( ; curr != null; curr = curr.next )
            ++count;

        return count;
    }

    public bool agregar ( object target )
    { // returns true if succesful

        if ( first == null ) {
            first = new Nodo( target, null );
            return true;
        }

        Nodo? curr = first;
        while ( curr != null ) {
            if ( curr.next == null ) {
                curr.next = new Nodo( target, null );
                return true;
            }
            curr = curr.next;
        }

        return false;
    }

    public bool insertar ( object target, uint pos )
    { // returns true if succesful
        if ( pos >= longitud() )
            // append(target); return true;
            return false;

        if ( pos == 0 ) {
            first = new Nodo( target, first );
            return true;
        }

        Nodo? curr = first;
        while ( pos-- > 1 )
            curr = curr.next;
        curr.next = new Nodo( target, curr.next );

        return true;
    }

    public object? iesimo ( uint pos )
    { // returns obj at index 'pos'

        if ( pos >= longitud() )
            return null;

        Nodo? curr = first;
        while ( pos-- > 0 )
            curr = curr.next;

        return curr == null ? null : curr.value;
    }

    public uint? ubicacion ( object target )
    { // returns zero-based index of the first 'target' ocurrence
        Nodo? curr = first;
        uint i = 0;

        while ( curr != null ) {
            if ( curr.value.Equals(target) )
                return i;

            curr = curr.next;
            ++i;
        }

        return null;
    }

    public bool remover ( object target )
    {
        if ( first == null )
            return false;

        Nodo? prev = null;
        Nodo? curr = first;

        while ( curr != null && !target.Equals(curr.value) ) {
            prev = curr;
            curr = curr.next;
        }

        if ( curr == null )
            return false;

        if ( prev == null )
            first = first.next;
        else
            prev.next = curr.next;

        return true;
    }

    public object? pop ( uint pos )
    { // returns element at index 'pos' and removes it

        if ( pos >= longitud() )
            return null;

        if ( first == null )
            return null;

        Nodo? prev = null;
        Nodo? curr = first;

        while ( curr != null && pos-- > 0 ) {
            prev = curr;
            curr = curr.next;
        }

        if ( curr == null )
            return null;

        object val;
        if ( prev == null ) {
            val = first.value;
            first = first.next;
        } else {
            val = curr.value;
            prev.next = curr.next;
        }

        return val;
    }

}

