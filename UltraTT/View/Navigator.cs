using UltraTT.View.Game;
using UltraTT.View.Login;

namespace UltraTT.View
{
    public class Navigator
    {
        private static Navigator _navigator;

        private IContentHolder _currentHolder;


        private Navigator()
        {
        }

        public static Navigator GetInstance()
        {
            return _navigator ?? (_navigator = new Navigator());
        }

        public void Start(IContentHolder contentHolder)
        {
            _currentHolder = contentHolder;
            _currentHolder.ShowContent(new AuthPageView());
        }

        public void AuthCompleted()
        {
            var gamePage = new GameHostPageView();
            _currentHolder.ShowContent(gamePage);
            _currentHolder = gamePage;
            _currentHolder.ShowContent(new Game.WelcomePageView());
        }

        public void Show(object content)
        {
            _currentHolder.ShowContent(content);
        }
    }
}