namespace WpfMultithreadingPractice.P080_List1o13
{
    public class PoorSecurityGateV080
    {
        private int counter = 0;

        public void Enter()
        {
            this.counter++;
        }

        public void Exit()
        {
            this.counter--;
        }

        public int GetCounter()
        {
            return counter;
        }
    }
}
