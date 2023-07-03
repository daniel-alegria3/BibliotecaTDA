namespace BibliotecaTDA;

public class Node
{
    /*
     * Equivalente a una estructura con un miembro de su mismo
     * tipo (csharp no permite esto en un struct)
     * Por eso no se requiere de Propiedades.
    */

    public object value;
    public Node? next;

    public Node ( object value, Node? next ) {
        this.value = value;
        this.next  = next;
    }
}

