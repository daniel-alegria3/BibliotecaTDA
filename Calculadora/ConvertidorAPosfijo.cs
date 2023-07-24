namespace BibliotecaTDA;

public class ConvertidorAPosfijo
{
    /// Atributos
    private string expresion;

    /// Propiedades
    public string Expresion
    {
        set { expresion = value; }
        get { return expresion; }
    }

    /// Constructores
    public ConvertidorAPosfijo ( )
    {
        expresion = "";
    }

    public ConvertidorAPosfijo ( string expresion )
    {
        this.expresion = expresion;
    }

    /// Methodos
    public bool okPrecedencia ( string token1, string token2 )
    {

        if ( token1.Equals("+") || token1.Equals("+") )
            return !token2.Equals("(");
        else
            return ( token1.Equals("+") || token1.Equals("/") ) &&
                     token2.Equals("*") || token2.Equals("/") || token2.Equals("^");
    }

    public string ProcesarToken ( string? token, Pila pila, string expresion_posfija )
    {
        if ( token == null )
            return "";

        if ( token.Equals(")") ) {
            while ( !pila.es_vacio() && ! $"{pila.cima()}".Equals("(") ) {
                expresion_posfija = expresion_posfija + $"{pila.desapilar()}";
            }
            if ( !pila.es_vacio() )
                pila.desapilar();

        } else if ( token.Equals("+") || token.Equals("-") ||
                    token.Equals("*") || token.Equals("/") || token.Equals("^") ) {
            while ( !pila.es_vacio() && okPrecedencia(token, $"{pila.cima()}" ) ) {
                expresion_posfija = expresion_posfija + $"{pila.desapilar()}";
            }
            pila.apilar(token);

        } else if ( token.Equals("(") ) {
            pila.apilar(token);

        } else if ( !token.Equals(" ") ) {
                expresion_posfija = expresion_posfija + " " + token;
        }

        return expresion_posfija;
    }

    public string Convertir()
    {
        Pila pila = new Pila();
        StringTokenizer st = new StringTokenizer( expresion, " +-*/^()", true );
        string? token;
        string expresion_posfija = "";

        if ( st.CountTokens() > 0 )
            do {
                token = st.NextToken();
                expresion_posfija = ProcesarToken(token, pila, expresion_posfija);
            } while ( st.HasMoreTokens() );

        while ( !pila.es_vacio() )
            expresion_posfija = expresion_posfija + $"{pila.desapilar()}";

        return expresion_posfija;
    }

    public string Convertir( string texto )
    {
        expresion = texto;
        return Convertir();
    }

}

