namespace BibliotecaTDA;

public class Nodo
{
    /* Disclaimer
     * Equivalente a una estructura con un miembro de su mismo
     * tipo (csharp no permite esto en un struct)
     * Por eso no se requiere de Propiedades.
    */

    public object? value;
    public Nodo? next;

    public Nodo ( object? value, Nodo? next ) {
        this.value = value;
        this.next  = next;
    }

    public Nodo ( ) {
        this.value = null;
        this.next  = null;
    }
}

