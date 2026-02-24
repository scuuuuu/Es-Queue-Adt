using Es_pila;

namespace Es_Queue_Adt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CQueue<string> coda = new CQueue<string>();
            CPila<char> pila = new CPila<char>();

            string espressione = "35+17*(40-9)-7";
            int i = 0;

            while (i < espressione.Length)
            {
                char c = espressione[i];

                // 1️⃣ NUMERO
                if (char.IsDigit(c))
                {
                    string numero = "";
                    while (i < espressione.Length && char.IsDigit(espressione[i]))
                    {
                        numero += espressione[i];
                        i++;
                    }
                    coda.Enqueue(numero);
                    continue;
                }

                // 2️⃣ PARENTESI APERTA
                if (c == '(')
                {
                    pila.Push(c);
                }

                // 3️⃣ PARENTESI CHIUSA
                else if (c == ')')
                {
                    while (!pila.IsEmpty() && pila.Peek() != '(')
                    {
                        coda.Enqueue(pila.Pop().ToString());
                    }
                    pila.Pop(); // elimina '('
                }

                // 4️⃣ OPERATORI
                else if (c == '+' || c == '-' || c == '*' || c == '/')
                {
                    while (!pila.IsEmpty() &&
                          (pila.Peek() == '+' || pila.Peek() == '-' ||
                           pila.Peek() == '*' || pila.Peek() == '/') &&
                           Precedenza(pila.Peek()) >= Precedenza(c))
                    {
                        coda.Enqueue(pila.Pop().ToString());
                    }
                    pila.Push(c);
                }

                i++;
            }

            // 5️⃣ SVUOTA PILA
            while (!pila.IsEmpty())
            {
                coda.Enqueue(pila.Pop().ToString());
            }

            Console.WriteLine("Espressione postfissa:");
            while (!coda.IsEmpty())
            {
                Console.Write(coda.Dequeue() + " ");
            }
        }

        static int Precedenza(char op)
        {
            if (op == '+' || op == '-') return 1;
            if (op == '*' || op == '/') return 2;
            return 0;
        }
    }
}