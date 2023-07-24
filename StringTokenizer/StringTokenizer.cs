using System.Collections;
namespace BibliotecaTDA;

public class StringTokenizer
{
    private string texto;
    public ArrayList lista;
    private int indice;

    /// Constructores
    public StringTokenizer ( string texto )
    {
        this.texto = texto;
        GenerarListaTokens( " \n\r\t", true );
    }

    public StringTokenizer ( string texto, string delimitadores )
    {
        this.texto = texto;
        GenerarListaTokens( delimitadores, true );
    }

    public StringTokenizer ( string texto, string delimitadores, bool retorna_tokens )
    {
        this.texto = texto;
        GenerarListaTokens(delimitadores, retorna_tokens);
    }

    /// Methods
    private void GenerarListaTokens ( string delimitadores, bool retorna_tokens )
    {
        lista = new ArrayList();

        char [] caracteres = texto.ToCharArray();
        string token = "";
        for ( int k = 0; k < caracteres.Length; k++ ) {
            if ( delimitadores.IndexOf( caracteres[k] ) == -1 ) {
                token = token + caracteres[k].ToString();
            } else {
                if ( !token.Equals("") )
                    lista.Add( token );
                if ( retorna_tokens )
                    lista.Add( caracteres[k].ToString() );
                token = "";
            }
        }

        if ( !token.Equals("") )
            lista.Add( token );

        indice = 0;
    }

    public int CountTokens ( )
    {
        return lista.Count;
    }

    public bool HasMoreTokens ( )
    {
        return indice < lista.Count;
    }

    public string? NextToken ( )
    {
        if ( indice < lista.Count )
            return lista[indice++].ToString();
        else
            return null;
    }
}

