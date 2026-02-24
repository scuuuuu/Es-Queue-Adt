using Es_pila;

namespace Es_Queue_Adt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CQueue<string> coda = new CQueue<string>();
            CPila<char> pila = new CPila<char>();
            Console.WriteLine("Inserisci l'espressione");
            string espressione = Console.ReadLine();
            string numero = "";

            foreach (char c in espressione)
            {
                if (char.IsDigit(c))//se è cifra
                {
                    numero += c;
                    continue;
                }
                else if (numero != "")//se è un numero completo
                {
                    coda.Enqueue(numero);//inserisco il numero nella coda
                    numero = "";
                }
                if (c == '(')
                {
                    pila.Push(c);
                }
                else if (c == ')')//se è una parentesi chiusa, svuoto la pila fino a trovare la parentesi aperta
                {
                    while (!pila.IsEmpty() && pila.Peek() != '(')
                    {
                        coda.Enqueue(pila.Pop().ToString());//inserisco l'operatore nella coda
                    }
                    pila.Pop(); //rimuovo la parentesi aperta
                }
                else if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    if (c == '+' || c == '-')//se bassa orecedenza
                    {
                        while (!pila.IsEmpty() && pila.Peek() != '(')//svuoto la pila fino a trovare una parentesi aperta
                        {
                            coda.Enqueue(pila.Pop().ToString());//inserisco l'operatore nella coda
                        }
                    }
                    else
                    {
                        while (!pila.IsEmpty() && (pila.Peek() == '*' || pila.Peek() == '/'))//se alta precedenza
                        {
                            coda.Enqueue(pila.Pop().ToString());//inserisco l'operatore nella coda
                        }
                    }
                    pila.Push(c);//inserisco l'operatore nella pila
                }
            }
            if (numero != "")//se è un numero completo alla fine dell'espressione
            {
                coda.Enqueue(numero);//inserisco il numero nella coda
            }
            while (!pila.IsEmpty())
            {
                coda.Enqueue(pila.Pop().ToString());//inserisco gli operatori rimanenti nella coda
            }
            Console.WriteLine("Espressione postfissa:");
            while (!coda.IsEmpty())
            {
                Console.Write(coda.Dequeue() + " ");
            }
        }
    }
}