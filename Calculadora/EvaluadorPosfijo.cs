namespace BibliotecaTDA;

public class EvaluadorPosfijo
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
    public EvaluadorPosfijo()
    {
        expresion = "";
    }

    public EvaluadorPosfijo(string expresion)
    {
        this.expresion = expresion;
    }

    /// Methodos
    public double Potencia(double b, double n)
    {
        return (double)Math.Exp(n * Math.Log(b));
    }

    public void ProcesarToken(string token, Pila pila)
    {
        if ( token.Equals("+") || token.Equals("-") ||
             token.Equals("*") || token.Equals("/") || token.Equals("^") ) {
            double rhs = double.Parse( pila.desapilar().ToString() );
            double lhs = double.Parse( pila.desapilar().ToString() );

            if ( token.Equals("+") )
                pila.apilar( lhs + rhs );
            else if ( token.Equals("-") )
                pila.apilar( lhs - rhs );
            else if ( token.Equals("*") )
                pila.apilar( lhs * rhs );
            else if ( token.Equals("/") )
                pila.apilar( lhs / rhs );
            else if ( token.Equals("^") )
                pila.apilar( Potencia( lhs, rhs ) );
        } else {
            if ( !token.Equals(" ") )
                pila.apilar(token);
        }
    }

    public double Evaluar()
    {
        Pila pila = new Pila();
        StringTokenizer st = new StringTokenizer( expresion, " +-*/^", true );

        string token;
        if ( st.CountTokens() > 0 )
            do {
                token = st.NextToken();
                ProcesarToken( token, pila );
            } while ( st.HasMoreTokens() );

        return double.Parse( pila.cima().ToString() );
    }

    public double Evaluar ( string exp )
    {
        expresion = exp;
        return Evaluar();
    }
}

