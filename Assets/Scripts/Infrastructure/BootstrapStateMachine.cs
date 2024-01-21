namespace Infrastructure
{
    public class BootstrapStateMachine
    {
        private BootstrapState _bootstrapState;
        private LoadingState _loadingState;
        private GameState _gameState;
        private WinState _winState;
        private LoseState _loseState;

        public BootstrapStateMachine(BootstrapState bootstrapState, LoadingState loadingState, GameState gameState, WinState winState, LoseState loseState)
        {
            _bootstrapState = bootstrapState;
            _loadingState = loadingState;
            _gameState = gameState;
            _winState = winState;
            _loseState = loseState;
        }

        public void Start()
        {
            _gameState.Enter();
        }
    }
}