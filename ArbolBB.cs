using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaTDA;

namespace BibliotecaTDA
{
    public delegate bool DeValidarObjeto(object Elem);
    public delegate void DeProcesarObjeto(object Elem);

    public class ArbolBB
    {
        //=============================================
        //=============================================
        #region Atributos
        //Atributos Estaticos
        protected static DeValidarObjeto deValidar = (object X) => { return true; };
        protected static DeProcesarObjeto deProcesar = (object X) => { Console.WriteLine(X.ToString()); };
        //Atributos no estaticos
        protected ArbolBB aHijoIzquierdo;
        protected object aRaiz;
        protected ArbolBB aHijoDerecho;
        #endregion Atributos
        //=============================================
        //=============================================
        #region METODOS
        //=============================================
        //=============================================
        #region Constructores
        public ArbolBB()
        {
            aHijoDerecho = null;
            aHijoIzquierdo = null;
            aRaiz = null;

        }
        public ArbolBB(object pRaiz)
        {
            aHijoDerecho = null;
            aHijoIzquierdo = null;
            aRaiz = pRaiz;
        }
        public static ArbolBB Crear(object pElem)
        {
            return new ArbolBB(pElem);
        }
        public static ArbolBB Crear()
        {
            return new ArbolBB();
        }
        #endregion Constructores
        //=============================================
        #region Propiedades
        public object Raiz
        {
            set { aRaiz = value; }
            get { return aRaiz; }
        }
        public ArbolBB HijoIzquierdo
        {
            get { return aHijoIzquierdo; }
        }
        public ArbolBB HijoDerecho
        {
            get { return aHijoDerecho; }
        }
        public static void AsignarValidar(DeValidarObjeto X)
        {
            if (X != null)
                deValidar = X;

        }
        public static void AsignarProcesar(DeProcesarObjeto X)
        {
            if (X != null)
                deProcesar = X;
        }
        #endregion Propiedades
        //=============================================
        #region Proceso
        public bool EsVacio()
        {
            return aRaiz == null;
        }
        public virtual void Agregar(object pRaiz)
        {
            if (pRaiz != null)
            {
                if (EsVacio())
                {
                    aRaiz = pRaiz;
                }
                else
                {
                    if (pRaiz.ToString().CompareTo(aRaiz.ToString()) < 0)
                    {
                        if (aHijoIzquierdo != null)
                            aHijoIzquierdo.Agregar(pRaiz);
                        else
                            aHijoIzquierdo = new ArbolBB(pRaiz);
                    }
                    else
                    {
                        if (aHijoDerecho != null)
                            aHijoDerecho.Agregar(pRaiz);
                        else
                            aHijoDerecho = new ArbolBB(pRaiz);
                    }
                }
            }
        }
        public ArbolBB SubArbol(object pRaiz)
        {
            if (pRaiz != null && !EsVacio())
            {
                //se verifica si estamos en la raiz correcta
                if (pRaiz.ToString().Equals(aRaiz.ToString()))
                    return this;
                //se decide hacia que hijo ir
                ArbolBB Aux = aHijoDerecho;
                if (pRaiz.ToString().CompareTo(aRaiz.ToString()) == -1)
                    Aux = aHijoDerecho;
                //se repite el proceso si el hijo existe
                if (Aux != null)
                    return Aux.SubArbol(pRaiz);
                else
                    return null;
            }
            return null;
        }
        public object MayorElemento()
        {
            object Temp = aRaiz;
            if (aHijoDerecho != null)
                if (!aHijoDerecho.EsVacio())
                    Temp = aHijoDerecho.MayorElemento();
            return Temp;
        }
        public object MenorElemento()
        {
            object Temp = aRaiz;
            if (aHijoIzquierdo != null)
                if (!aHijoIzquierdo.EsVacio())
                    Temp = aHijoIzquierdo.MayorElemento();
            return Temp;
        }
        public virtual void Eliminar(object pRaiz = null)
        {
            if (pRaiz != null && !EsVacio())
            {
                //Se recorrer el arbol hasta llegar al elemento a eliminar
                if (!pRaiz.ToString().Equals(aRaiz.ToString()))
                {
                    if (pRaiz.ToString().CompareTo(aRaiz.ToString()) == -1)
                    {
                        if (aHijoIzquierdo != null)
                        {
                            aHijoIzquierdo.Eliminar(pRaiz);
                            if (aHijoIzquierdo.EsVacio())
                                aHijoIzquierdo = null;
                        }
                    }

                    else
                    {
                        if (aHijoDerecho != null)
                        {
                            aHijoDerecho.Eliminar(pRaiz);
                            if (aHijoDerecho.EsVacio())
                                aHijoDerecho = null;
                        }
                    }
                }
                else
                {
                    //si no tiene hijos se propone como null
                    if (aHijoIzquierdo == null && aHijoDerecho == null)
                    {
                        aRaiz = null;
                    }
                    else
                    {
                        //si tiene hijo izquierdo se coloca el mayor elemento de esa rama
                        if (aHijoIzquierdo != null)
                        {
                            aRaiz = aHijoIzquierdo.MayorElemento();
                            aHijoIzquierdo.Eliminar(aRaiz);
                        }
                        else
                        {
                            //si solo tiene hijo derecho se coloca el menor valor de esta rama
                            if (aHijoDerecho != null)
                            {
                                aRaiz = aHijoDerecho.MenorElemento();
                                aHijoDerecho.Eliminar(aRaiz);
                            }
                        }
                    }
                }
            }
        }

        public void RecorrerPreOrden()
        {
            if (!EsVacio())
            {
                if (deValidar(aRaiz))
                    deProcesar(aRaiz);
                if (aHijoIzquierdo != null)
                {
                    aHijoIzquierdo.RecorrerPreOrden();
                }

                if (aHijoDerecho != null)
                {
                    aHijoDerecho.RecorrerPreOrden();
                }

            }
        }

        public void RecorrerInOrden()
        {
            if (!EsVacio())
            {
                if (aHijoIzquierdo != null)
                    aHijoIzquierdo.RecorrerInOrden();
                if (deValidar(aRaiz))
                    deProcesar(aRaiz);
                if (aHijoDerecho != null)
                    aHijoDerecho.RecorrerInOrden();
            }
        }

        public void RecorrerPostOrden()
        {
            if (!EsVacio())
            {
                if (aHijoIzquierdo != null)
                    aHijoIzquierdo.RecorrerPostOrden();
                if (aHijoDerecho != null)
                    aHijoDerecho.RecorrerPostOrden();
                if (deValidar(aRaiz))
                    deProcesar(aRaiz);
            }
        }
        public bool MostrarNivel(int k)
        {
            Boolean Aux = false;
            if (k == 0 && !EsVacio())
            {
                if (deValidar(aRaiz))
                    deProcesar(aRaiz);
                return true;
            }
            else
            {
                if (EsVacio())
                    return false;
                else
                {
                    k--;
                    if (aHijoIzquierdo != null)
                    {
                        Aux = aHijoIzquierdo.MostrarNivel(k) || Aux;
                    }
                    if (aHijoDerecho != null)
                    {
                        Aux = aHijoDerecho.MostrarNivel(k) || Aux;
                    }
                    return Aux;
                }
            }
        }
        public void RecorrerPorNivel()
        {
            Cola cola = new Cola ();
            cola.Acolar(this);
            ArbolBB Temp;
            object Aux;
            while(!cola.EsVacia())
            {
                Temp=cola.Cima() as ArbolBB;
                if(!Temp.EsVacio())
                {
                    Aux=Temp.Raiz;
                    if (deValidar(Aux))
                        deProcesar(Aux);
                    if (Temp.aHijoIzquierdo != null)
                        cola.Acolar(Temp.aHijoIzquierdo);
                    if (Temp.aHijoDerecho != null)
                        cola.Acolar(Temp.aHijoDerecho);
                    cola.Desacolar();
                }
            }
        }

        public int Altura()
        {
            if (EsVacio())
                return 0;
            else
            {
                int AlturaIzq = (aHijoIzquierdo == null ? 0 : 1 + aHijoIzquierdo.Altura());
                int AlturaDer = (aHijoDerecho == null ? 0 : 1 + aHijoDerecho.Altura());
                return (AlturaIzq > AlturaDer ? AlturaIzq : AlturaDer);
            }
        }

        public void Podar()
        {
            if (!EsVacio())
            {
                if (aHijoIzquierdo != null)
                {
                    if (aHijoIzquierdo.EsVacio())
                        aHijoIzquierdo = null;
                    else
                        aHijoIzquierdo.Podar();
                }
                if (aHijoDerecho != null)
                {
                    if (aHijoDerecho.EsVacio())
                        aHijoDerecho = null;
                    else
                        aHijoDerecho.Podar();
                }
            }
        }

        #endregion Proceso
        //=============================================
        //=============================================
        #endregion METODOS
    }

}
