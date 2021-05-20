using System;
using Solitude2.Data;
using Solitude2.Views.System;

namespace Solitude2.Controllers.SystemController
{
    internal static class SaveGameController
    {
        internal static bool SaveGame()
        {
            SaveGameView.Save();
            try
            {
                var db = new MyDbContext();
                db.Update(StartGameController.CurrentPlayer);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        } 
    }
}
