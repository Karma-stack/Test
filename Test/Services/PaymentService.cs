namespace Test.Services
{
    public class PaymentService
    {
        private InputParams inputParams;
        static object locker = new object();


        public PaymentService(InputParams inputParams)
        {
            this.inputParams = inputParams;
        }

        public async Task<InputParams> Start()
        {
            this.inputParams.BalanceAmount = this.inputParams.InitAmount;

            List<Task> players = new List<Task>();
            for (var i = 0; i < this.inputParams.CountPeople; i++)
            {
                var task = new Task(TakeAmount);
                players.Add(task);
            }
            players.ForEach(x => x.Start());

            Task.WaitAll(players.ToArray());
            return this.inputParams;
        }

        private void TakeAmount()
        {

            while (true)
            {
                lock (locker)
                {
                    //Delay for data base trunsaction
                    Task.Delay(100);

                    if (CanTakeMore())
                    {
                        this.inputParams.BalanceAmount = this.inputParams.BalanceAmount - 0.1M;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        private bool CanTakeMore()
        {

            if (this.inputParams.BalanceAmount > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
