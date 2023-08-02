using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaTDA;

namespace BibliotecaTDA
{
    public delegate bool DelegadoValidar(object X);
    public delegate void DelegadoProcesar(object X);
    public class Arbol
    {
        //================================================================
        //================================================================
        #region ATRIBUTOS
        //================================================================
        //================================================================

        private object aRaiz;
        private Arbol aPrimerHijo;
        private Arbol aSgteHermano;


        //Atributos de clase
        protected static DelegadoValidar deValidar = (object X) => true;
        protected static DelegadoProcesar deProcesar = (object X) => { Console.WriteLine(X.ToString()); };
        //================================================================
        //================================================================
        #endregion ATRIBUTOS
        //================================================================
        //================================================================
        #region CONSTRUCTORES
        //================================================================
        //================================================================

        public Arbol()
        {
            aRaiz = null;
            aPrimerHijo = null;
            aSgteHermano = null;
        }

        public Arbol(object pRaiz)
        {
            aRaiz = pRaiz;
            aPrimerHijo = null;
            aSgteHermano = null;
        }

        public static Arbol Crear()
        {
            return new Arbol();
        }

        public static Arbol Crear(object pRaiz)
        {
            return new Arbol(pRaiz);
        }

        //=============================================================================
        //=============================================================================
        #endregion CONSTRUCTORES
        //=============================================================================
        //=============================================================================
        #region PROPIEDADES
        //=============================================================================
        //=============================================================================

        public object Raiz
        {
            set { aRaiz = value; }
            get { return aRaiz; }
        }

        public Arbol PrimerHijo
        {
            set { aPrimerHijo = value; }
            get { return aPrimerHijo; }
        }

        public Arbol SgteHermano
        {
            set { aSgteHermano = value; }
            get { return aSgteHermano; }

        }

        public static void CambiarValidar(DelegadoValidar X)
        {
            if (X != null)
            {
                deValidar = X;
            }
        }

        public static void CambiarProcesar(DelegadoProcesar X)
        {
            if (X != null)
            {
                deProcesar = X;
            }
        }
        //=============================================================================
        //=============================================================================
        #endregion PROPIEDADES
        //=============================================================================
        //=============================================================================
        #region METODOS
        //=============================================================================
        //=============================================================================

        public bool EsVacia()
        {
            return (aRaiz == null);
        }

        public Arbol AgregarHermano(object Hermano)
        {
            if (aSgteHermano == null)
            {
                aSgteHermano = new Arbol(Hermano);
                return aSgteHermano;
            }
            else
            {
                return aSgteHermano.AgregarHermano(Hermano);
            }
        }

        public Arbol AgregarHijo(object Hijo)
        {

            if (aPrimerHijo == null)
            {
                aPrimerHijo = new Arbol(Hijo);
                return aPrimerHijo;
            }
            else
            {
                return aPrimerHijo.AgregarHermano(Hijo);
            }
        }

        public Arbol Agregar(Arbol SubArbolPadre, object Hijo)
        {
            if ((SubArbolPadre == null) && (EsVacia()))
            {
                aRaiz = Hijo;
                return this;
            }
            else
            {
                if (SubArbolPadre == SubArbol(SubArbolPadre.Raiz))
                {
                    return SubArbolPadre.AgregarHijo(Hijo);
                }
                else
                {
                    return null;
                }
            }
        }
        public Arbol Agregar(object Hijo, string Padre = "")
        {
            if (Padre == "" && EsVacia())
            {
                aRaiz = Hijo;
                return this;
            }
            else
            {
                Arbol PadreAux = SubArbol(Padre);
                if (PadreAux != null)
                {
                    return PadreAux.AgregarHijo(Hijo);
                }
                else
                {
                    return null;
                }
            }
        }

        public Arbol SubArbol(object pRaiz)
        {
            if (!EsVacia())
            {
                if (aRaiz.ToString().Equals(pRaiz.ToString())) {
                    Console.Write($"| {aRaiz}-");
                    return this;
                } else {
                    Console.Write($"{aRaiz}-");
                    Arbol ArbolAux = null;
                    if (aPrimerHijo != null)
                        ArbolAux = aPrimerHijo.SubArbol(pRaiz);
                    if ((ArbolAux == null) && (aSgteHermano != null))
                        ArbolAux = aSgteHermano.SubArbol(pRaiz);
                    return ArbolAux;
                }
            }
            else
                return null;
        }

        public Arbol Padre(object Hijo)
        {
            if (EsVacia())
                return null;
            else
            {
                if (EsHijo(Hijo))
                    return this;
                else
                {
                    Arbol ArbolAux = null;
                    if (aPrimerHijo != null)
                        ArbolAux = aPrimerHijo.Padre(Hijo);
                    if ((ArbolAux == null) && (aSgteHermano != null))
                        ArbolAux = aSgteHermano.Padre(Hijo);
                    return ArbolAux;
                }
            }
        }

        public bool EsHijo(object Hijo)
        {
            if ((EsVacia()) || (aPrimerHijo == null))
                return false;
            else
                return (aPrimerHijo.Raiz.Equals(Hijo) ? true : aPrimerHijo.EsHermano(Hijo));
        }

        public bool EsHermano(object Hermano)
        {
            if ((EsVacia()) || (aSgteHermano == null))
                return false;
            else
                return (aSgteHermano.Raiz.Equals(Hermano) ? true : aSgteHermano.EsHermano(Hermano));
        }

        public void Eliminar(Arbol pArbol)
        {
            if ((pArbol != null) && (pArbol == SubArbol(pArbol.Raiz)))
            {
                //Se quiere eliminaa la raiz
                Arbol ArbolPadre = Padre(pArbol.Raiz);
                if (ArbolPadre == null)
                {
                    aRaiz = null;
                    aPrimerHijo = null;
                    aSgteHermano = null;
                }
                else
                {
                    if (pArbol == ArbolPadre.aPrimerHijo)
                    {
                        Arbol ArbolAux = ArbolPadre.PrimerHijo.SgteHermano;
                        PrimerHijo = ArbolAux;
                    }
                    else
                    {
                        ArbolPadre.PrimerHijo.EliminarHermano(pArbol);
                    }
                }
            }
        }

        protected void EliminarHermano(Arbol pArbol)
        {
            if (pArbol == aSgteHermano)
                SgteHermano = SgteHermano.SgteHermano;
            else
                aSgteHermano.EliminarHermano(pArbol);
        }

        public void Procesar()
        {
            if (deValidar(Raiz))
                deProcesar(Raiz);
        }

        //=================================================================

        public void RecorrerPreOrden()
        {
            if (!EsVacia())
            {
                Procesar();
                if (aPrimerHijo != null)
                {
                    aPrimerHijo.RecorrerPreOrden();
                    aPrimerHijo.RecorrerHermanoPreOrden();
                }
            }
        }
        public void RecorrerHermanoPreOrden()
        {
            if (aSgteHermano != null)
            {
                aSgteHermano.RecorrerPreOrden();
                aSgteHermano.RecorrerHermanoPreOrden();
            }
        }

        //=================================================================

        //=================================================================

        public void RecorrerPosOrden()
        {
            if (!EsVacia())
            {
                if (aPrimerHijo != null)
                {
                    aPrimerHijo.RecorrerPosOrden();
                    aPrimerHijo.RecorrerHermanoPosOrden();
                }
                Procesar();
            }
        }
        public void RecorrerHermanoPosOrden()
        {
            if (aSgteHermano != null)
            {
                aSgteHermano.RecorrerPosOrden();
                aSgteHermano.RecorrerHermanoPosOrden();
            }
        }

        //=================================================================

        //=================================================================
        public void RecorrerInOrden()
        {
            if (!EsVacia())
            {
                if (aPrimerHijo != null)
                {
                    aPrimerHijo.RecorrerPosOrden();
                }
                Procesar();
                if (aPrimerHijo != null)
                {
                    aPrimerHijo.RecorrerHermanoInOrden();
                }
            }
        }
        public void RecorrerHermanoInOrden()
        {
            if (aSgteHermano != null)
            {
                aSgteHermano.RecorrerInOrden();
                aSgteHermano.RecorrerHermanoInOrden();
            }
        }
        //=================================================================

        public void RecorrerPorNiveles()
        {
            Pila Pila1 = new Pila ();
            Pila Pila2 = new Pila ();
            Arbol Aux;
            Pila1.Apilar(this);
            while (!Pila1.EsVacia())
            {
                Aux = Pila1.Cima() as Arbol;
                Pila1.Desapilar();
                if (deValidar(Aux.Raiz))
                    deProcesar(Aux.Raiz);
                if (Aux.SgteHermano != null)
                    Pila1.Apilar(Aux.aSgteHermano);
                if (Aux.PrimerHijo != null)
                    Pila2.Apilar(Aux.PrimerHijo);
                if (Pila1.EsVacia())
                {
                    while (!Pila2.EsVacia())
                    {
                        Pila1.Apilar(Pila2.Cima());
                        Pila2.Desapilar();
                    }
                }
            }
        }
        public int Altura()
        {
            if (EsVacia())
                return 0;
            else
            {
                if (aPrimerHijo != null)
                {
                    int Altura1 = 1 + aPrimerHijo.Altura();
                    int Altura2 = 1 + aPrimerHijo.AlturaHermanos();
                    return (Altura1 > Altura2 ? Altura1 : Altura2);
                }
                else { return 0; }//ARBOL ES UNA HOJA
            }
        }

        protected int AlturaHermanos()
        {
            if (aSgteHermano == null)
                return 0;
            else
            {
                int Altura1 = aSgteHermano.Altura();
                int Altura2 = aSgteHermano.AlturaHermanos();
                return (Altura1 > Altura2 ? Altura1 : Altura2);
            }
        }
        public void Podar()
        {
            if (aPrimerHijo != null && aPrimerHijo.EsVacia())
                aPrimerHijo = null;
            else
                aPrimerHijo.Podar();
            if (aSgteHermano != null && aSgteHermano.EsVacia())
                aSgteHermano = null;
            else
                aSgteHermano.Podar();
        }
        //===============================================================================
        //===============================================================================
        #endregion METODOS
    }
}
