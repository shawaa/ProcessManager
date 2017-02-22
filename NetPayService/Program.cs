using System;
using Ui.Services;

namespace Ui
{
    class Program
    {
        static void Main(string[] args)
        {
            NetPayService netPayService = new NetPayService();
            HmrcService hmrcService = new HmrcService();
            FpsService fpsService = new FpsService();
            EpsService epsService = new EpsService();
            LedgerService ledgerService = new LedgerService();

            Console.ReadLine();
        }
    }
}
