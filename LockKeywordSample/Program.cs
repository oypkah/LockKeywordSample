using System;
using System.Threading.Tasks;

namespace LockKeywordSample
{
    class Program
    {
        delegate void AsnycMethodHandler();
        static void Main(string[] args)
        {
            AsnycMethodHandler asnycMethod = () =>
            {
                ////Run this without locking
                Logger withoutLock = Logger.CreateWithoutLock();

                ////Run this with locking
                //Logger withLock = Logger.CreateWithLock();
            };

            #region If you're using .Net Core run these
            Task.Run(() => asnycMethod.Invoke());
            Task.Run(() => asnycMethod.Invoke());
            Task.Run(() => asnycMethod.Invoke());
            Task.Run(() => asnycMethod.Invoke());
            Task.Run(() => asnycMethod.Invoke());
            #endregion

            #region If you're using .Net run these
            //asnycMethod.BeginInvoke(new AsyncCallback((x) => { }), new object());
            //asnycMethod.BeginInvoke(new AsyncCallback((x) => { }), new object());
            //asnycMethod.BeginInvoke(new AsyncCallback((x) => { }), new object());
            //asnycMethod.BeginInvoke(new AsyncCallback((x) => { }), new object());
            //asnycMethod.BeginInvoke(new AsyncCallback((x) => { }), new object());
            #endregion

            Console.ReadLine();
        }
    }
}
