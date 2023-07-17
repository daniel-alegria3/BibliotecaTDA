namespace BibliotecaTDA;

public class ListaIterativa
{
    private Nodo? first;

    public ListaIterativa ( ) {
        first = null;
    }

    public void listar ( )
    {
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
        while ( curr != null ) {
            ++count;
            curr = curr.next ;
        }

        return count;
    }

    public void agregar ( object? target )
    {
        if ( first == null ) {
            first = new Nodo( target, null );
            return;
        }

        Nodo? curr = first;
        while ( curr.next != null ) {
            curr = curr.next;
        }

        curr.next = new Nodo( target, null );
        return;
    }

    public bool insertar ( object? target, uint pos )
    { // returns true if succesful
        if ( pos >= longitud() )
            // append(target); return true;
            return false;

        Nodo? curr = first;
        while ( pos-- > 0 )
            curr = curr.next;

        object? val = curr.value;
        curr.value = target;
        curr.next = new Nodo( val, curr.next );

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

    public uint? ubicacion ( object? target )
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

    public bool remover ( object? target )
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
        return null; // TODO

        if ( pos >= longitud() )
            return null;

        Nodo? curr = first;

        while ( pos-- > 0 ) {
            curr = curr.next;
        }

        object? val;
        if ( curr.next != null ) {
            val = curr.value;
            curr.value = curr.next.value;
            curr.next = curr.next.next;
        }

        return val;
    }

}

