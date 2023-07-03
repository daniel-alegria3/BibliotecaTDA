namespace BibliotecaTDA;

public class ListaIterativa
{
    private Node? first;

    public ListaIterativa ( ) {
        first = null;
    }

    public bool is_empty ( )
    {
        return first == null;
    }

    public uint length( )
    {
        uint count = 0;

        Node? curr = first;
        for ( ; curr != null; curr = curr.next )
            ++count;

        return count;
    }

    public bool append ( object target )
    { // returns true if succesful

        first = new Node( target, first );

        return true;
    }

    public bool insert ( object target, uint pos )
    { // returns true if succesful, precondicion: pos < _length (pos es un indice)
        if ( pos >= length() )
            return false;

        Node? curr = first;

        uint i = length()-1 - pos;
        while ( curr != null && i-- > 0  ) {
            curr = curr.next;
        }

        curr.next = new Node( target, curr.next );

        return true;
    }

    public object? item ( uint pos ) // 'iesimo'
    { // returns obj at index 'pos'
        Node? curr = first;

        uint i = length()-1 - pos;
        while ( curr != null && i-- > 0 )
            curr = curr.next;

        return curr == null ? null : curr.value ;
    }

    public uint? index ( object target ) // 'ubicacion'
    { // returns zero-based index of the "first" 'target' ocurrence
        Node? curr = first;

        uint i = 0;
        uint? idx = null;
        while ( curr != null ) {
            if ( curr.value.Equals(target) ) {
                idx = i;
            }

            curr = curr.next;
            ++i;
        }

        return length()-1 - idx;
    }

    public void show ( )
    {
        show_recursivo( first );
        Console.Write("\n");
    }

    private void show_recursivo ( Node? nodo )
    {
        if ( nodo == null )
            return;

        show_recursivo( nodo.next );
        Console.Write($"{nodo.value}, ");
    }

}

