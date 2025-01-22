

namespace CasinoGame.GameMechanics
{
    public abstract class CasinoGameBase
    {
        public event Action OnWin;
        public event Action OnLoose;
        public event Action OnDraw;

        protected CasinoGameBase()
        {
            FactoryMethod();
        }

        public abstract void PlayGame();

        protected abstract void FactoryMethod();

        protected void OnWinInvoke()
        {
            OnWin?.Invoke();
        }

        protected void OnLooseInvoke()
        {
            OnLoose?.Invoke();
        }

        protected void OnDrawInvoke()
        {
            OnDraw?.Invoke();
        }
        protected void PrintResult(string message)
        {
            Console.WriteLine(message);
        }
    }
}
