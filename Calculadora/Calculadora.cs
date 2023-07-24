namespace BibliotecaTDA;

public class Calculadora
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
    public Calculadora()
    {
        expresion = "";
    }

    public Calculadora(string expresion)
    {
        this.expresion = expresion;
    }

    /// Methodos
    public double Evaluar ( )
    {
        string expresion_posfijo;
        ConvertidorAPosfijo conv = new ConvertidorAPosfijo();
        expresion_posfijo = conv.Convertir(expresion);
        EvaluadorPosfijo eval = new EvaluadorPosfijo();
        return eval.Evaluar(expresion_posfijo);
    }

    public double Evaluar ( string texto )
    {
        expresion = texto;
        return Evaluar();
    }
}

