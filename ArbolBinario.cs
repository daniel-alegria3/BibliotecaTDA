using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaTDA;

namespace BibliotecaTDA
{
    public delegate bool DelegadoEsValido(object X);
    public delegate void DelegadoProceso(object X);
    public class ArbolBinario
    {
        //===========================================
        //===========================================
        #region Atributos
        //===========================================

        //Atributos de objeto
        protected object aRaiz;
        protected ArbolBinario aHijoDerecho;
        protected ArbolBinario aHijoIzquierdo;

        //Atributos de clase
        protected static DelegadoEsValido deValidar = (object X) => true;
        protected static DelegadoProceso deProcesar = (object X) => { Console.WriteLine(X.ToString()); };

        //===========================================
        #endregion Atributos
        //===========================================
        //===========================================
        #region Constructores
        //===========================================
        public ArbolBinario()
        {
            aRaiz=null;
            aHijoIzquierdo = null;
            aHijoDerecho = null;
        }

        public ArbolBinario(object pRaiz)
        {
            aRaiz = pRaiz;
            aHijoIzquierdo = null;
            aHijoDerecho = null;
        }

        public static ArbolBinario Crear(object pRaiz=null)
        {
            return new ArbolBinario(pRaiz);
        }
        //===========================================
        #endregion Constructores
        //===========================================
        //===========================================
        #region Propiedades
        //===========================================
        public object Raiz
        {
            get { return aRaiz; }
            set { aRaiz = value; }
        }
        public virtual ArbolBinario HijoDerecho
        {
            get { return aHijoDerecho; }
            set { aHijoDerecho = value; }
        }
        public virtual ArbolBinario HijoIzquierdo
        {
            get { return aHijoIzquierdo; }
            set { aHijoIzquierdo = value; }
        }

        public static void AlterarValidar(DelegadoEsValido pDel)
        {
            if(pDel!=null)
                deValidar = pDel;
        }
        public static void AlterarProcesar(DelegadoProceso pDel)
        {
            if (pDel != null)
                deProcesar = pDel;
        }
        //===========================================
        #endregion Propiedades
        //===========================================
        //===========================================
        #region Metodos
        //===========================================
        
        public bool EsVacia()
        {
            return aRaiz == null;
        }
        public override string ToString()
        {
            return aRaiz.ToString();
        }

        public bool EstaCompleto()
        {
            if(!EsVacia())
            {
                bool Completo = true;
                if((aHijoDerecho!=null && aHijoIzquierdo!=null))
                {
                    return Completo && aHijoDerecho.EstaCompleto() && aHijoIzquierdo.EstaCompleto();
                }
                else
                    if((aHijoDerecho==null && aHijoIzquierdo==null))
                        return true;
                    else
                        return false;
            }
            else
                return false;
        }
            
        public virtual void Agregar(object pElem)
        {
            if(pElem!=null)
            {
                if(aRaiz==null)
                    aRaiz = pElem;

                else
                {
                    if (aHijoIzquierdo == null || !aHijoIzquierdo.EsVacia())
                        aHijoIzquierdo = new ArbolBinario(pElem);
                        
                    else
                    {
                        if (aHijoDerecho == null || !aHijoDerecho.EsVacia())
                            aHijoDerecho =  new ArbolBinario(pElem);

                        else
                        {
                            if (aHijoIzquierdo.EstaCompleto())
                            {
                                if (aHijoDerecho.EstaCompleto())
                                    aHijoIzquierdo.Agregar(pElem);
                                else
                                    aHijoDerecho.Agregar(pElem);
                            }
                            else
                                aHijoIzquierdo.Agregar(pElem);
                        }
                    }
                }
            }
        }

        public object Hoja()
        {
            if (aHijoIzquierdo == null || aHijoIzquierdo.EsVacia())
            {
                if (aHijoDerecho == null || aHijoDerecho.EsVacia())
                    return aRaiz;
                else
                    return aHijoDerecho.Hoja();
            }
            else
                return aHijoIzquierdo.Hoja();
            
        }

        public virtual void Eliminar(object pElem)
        {
            if(!EsVacia() && pElem!=null)
            {
                if(pElem.Equals(aRaiz))
                {
                    if(aHijoDerecho==null && aHijoIzquierdo==null)
                       aRaiz = null;
                   
                    else
                    {
                        if(aHijoIzquierdo!=null)
                        {
                            aRaiz = aHijoIzquierdo.Hoja();
                            aHijoIzquierdo.Eliminar(aRaiz);
                        }
                        else
                        {
                            aRaiz= aHijoDerecho.Hoja();
                            aHijoDerecho.Eliminar(aRaiz);
                        }
                    }
                }
                else
                {
                    if (aHijoIzquierdo != null)
                        aHijoIzquierdo.Eliminar(pElem);
                    if (aHijoDerecho != null)
                        aHijoDerecho.Eliminar(pElem);
                }
            }
        }

        public bool RecorrerNivel(int k)
        {
            Boolean Aux = false;
            if (k == 0 && !EsVacia())
            {
                if (deValidar(aRaiz))
                    deProcesar(aRaiz);
                return true;
            }
            else
            {
                if (EsVacia())
                    return false;
                else
                {
                    k--;
                    if (aHijoIzquierdo != null)
                    {
                        Aux = aHijoIzquierdo.RecorrerNivel(k) || Aux;
                    }
                    if (aHijoDerecho != null)
                    {
                        Aux = aHijoDerecho.RecorrerNivel(k) || Aux;
                    }
                    return Aux;
                }
            }
        }


        public virtual ArbolBinario SubArbol(object pRaiz)
        {

            if (!EsVacia() && pRaiz!=null)
            {
                if (aRaiz.ToString().Equals(pRaiz.ToString())) {
                    Console.Write($"{aRaiz}-");
                    return this;
                } else {
                    Console.Write($"{aRaiz}-");
                    ArbolBinario Temp=null;
                    if (aHijoIzquierdo != null)
                        Temp = aHijoIzquierdo.SubArbol(pRaiz);
                    if(Temp==null)
                    {
                        if (aHijoDerecho != null)
                            Temp = aHijoDerecho.SubArbol(pRaiz);
                    }
                    Console.Write("\n");
                    return Temp;
                }
            }
            else {
                Console.Write("\n");
                return null;
            }
        }

        public void Procesar()
        {
            if(!EsVacia())
            {
                if (deValidar(aRaiz))
                    deProcesar(aRaiz);
            }
        }

        public void Procesar(object aElem)
        {
            if (aElem!=null)
            {
                if (deValidar(aElem))
                    deProcesar(aElem);
            }
        }

        //================================================

        public void RecorrerPreOrden()
        {
            Procesar();
            if (aHijoDerecho != null)
                aHijoDerecho.RecorrerPreOrden();
            if (aHijoIzquierdo != null)
                aHijoIzquierdo.RecorrerPreOrden();
        }

        // public void RecorrerInOrden()
        // {
        //    
        //     if (aHijoDerecho != null)
        //         aHijoDerecho.RecorrerInOrden();
        //     Procesar();
        //     if (aHijoIzquierdo != null)
        //         aHijoIzquierdo.RecorrerInOrden();
        // }
        public void RecorrerInOrden()
        {
            
            if (aHijoDerecho != null)
                aHijoDerecho.RecorrerInOrden();
            Procesar();
            if (aHijoIzquierdo != null)
                aHijoIzquierdo.RecorrerInOrden();
        }

        public void RecorrerPosOrden()
        {

            if (aHijoDerecho != null)
                aHijoDerecho.RecorrerPosOrden();
            if (aHijoIzquierdo != null)
                aHijoIzquierdo.RecorrerPosOrden();
            Procesar();
        }
        public void RecorrerPorNiveles()
        {
            if(aRaiz!=null)
            {
                Cola cola = new Cola ();
                cola.Acolar(this);
                ArbolBinario Aux;
                while(!cola.EsVacio())
                {
                    Aux = cola.Cima() as ArbolBinario;
                    Procesar(Aux.Raiz);
                    if (Aux.HijoDerecho != null)
                        cola.Acolar(Aux.HijoDerecho);
                    if (Aux.HijoIzquierdo != null)
                        cola.Acolar(Aux.aHijoIzquierdo);
                    cola.Desacolar();
                }
            }
        }
        
        public int Altura()
        {
            int AltIz=0, AltDer=0 ;
            if (aHijoIzquierdo != null)
                AltIz= 1 + aHijoIzquierdo.Altura();
            if (aHijoDerecho != null)
                AltDer = 1 + aHijoDerecho.Altura();
            return AltIz>AltDer?AltIz:AltDer;
        }
        public void Podar()
        {
            if(!EsVacia())
            {
                if(aHijoIzquierdo!=null)
                {
                    if (aHijoIzquierdo.EsVacia())
                        aHijoIzquierdo = null;
                    else
                        aHijoIzquierdo.Podar();
                }
                if (aHijoDerecho != null)
                {
                    if (aHijoDerecho.EsVacia())
                        aHijoDerecho = null;
                    else
                        aHijoDerecho.Podar();
                }
            }
        }
        //===========================================
        #endregion Metodos
        //===========================================
        //===========================================
    }
}
