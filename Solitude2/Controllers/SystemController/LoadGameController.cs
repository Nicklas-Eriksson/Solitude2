using Solitude2.Facade;
using Solitude2.Models;
using Solitude2.Utility;
using Solitude2.Views.SystemView;

namespace Solitude2.Controllers.SystemController
{
    internal static class LoadGameController
    {
        internal static Player Load()
        {
            LoadGameView.Load();
            var savedGames = DbCommunication.SavedGames();
            LoadGameView.ChooseACharacter(savedGames);
            if (savedGames.Count == 0)
            {
                LoadGameView.NoSavedGames();
                return null;
            }
            var option = Helper.GetUserInput(savedGames.Count);
            if (option == 999) { StartGameController.CurrentGame(); }
            return savedGames[option - 1];
        }
    }
}
