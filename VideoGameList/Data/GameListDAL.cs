using VideoGameList.Interface;
using VideoGameList.Models;

namespace VideoGameList.Data
{
    public class GameListDAL : IDataAccessLayer
    {
        /*private static List<Games> Gamelist = new List<Games>
        {
            new Games("Stardew Valley", "PC, PS4, Xbox One, Switch", "Indie, RPG, Simulation", 'E', 2016, "stardew.jpg","", null),
            new Games("Slime Rancher", "PC, PS4, Xbox One", "Action, Adventure, Indie", 'E', 2017, "slimerancher.jpg", "", null),
            new Games("Spirtfarer", "PC, PS4, Switch, Xbox One", "Adventure, Indie, Simulation", 'T', 2020, "spiritfarer.jpg", "", null),
            new Games("Satisfactory","PC", "Adventure, Indie, Strategy", null, 2020, "satifactory.jpg", "", null),
            new Games("House Flipper", "PC", "Indie, Simulation", 'E', 2018, "houseflipper.jpg", "", null),
            new Games("Stray", "PC, PS4 & 5", "Adventure, Indie", 'E', 2022, "stray.jpg", "", null)
        };*/

        private AppDbContext db;
        public GameListDAL(AppDbContext indb)
        {
            db = indb;
        }

        public void AddGame(Games game)
        {
            db.Add(game);
            db.SaveChanges();
        }

        public bool EditGame(Games game)
        {
            if (game == null)
            {
                return false;
            }
            db.games.Update(game);
            db.SaveChanges();
            return true;
        }

        public Games GetGame(int? id)
        {
            return db.games.Where(m => m.Id == id).FirstOrDefault();
        }

        public int GetGameCount()
        {
            return db.games.Count();
        }

        public IEnumerable<Games> FilterGames(string genre, string rating)
        {
            if (genre == null)
                genre = "";

            if (rating == null)
                rating = string.Empty;

            if (genre == "" && rating == "")
                return GetGames();  //if they didn't enter anything, return whole list

            IEnumerable<Games> lstgames = GetGames().Where
                (m => (!string.IsNullOrEmpty(m.Genre) && m.Genre.ToLower().Contains(genre.ToLower()))).ToList();
            IEnumerable<Games> lstgames2 = lstgames.Where(m => (!string.IsNullOrEmpty(m.Rating) && m.Rating.ToLower().Equals(rating.ToLower()))).ToList();

            if (lstgames2.Count() == 0)
                return lstgames;

            return lstgames2;
        }

        public IEnumerable<Games> GetGames()
        {
            return db.games.OrderBy(m => m.Title).ToList();
        }

        public void LoanGame(int? id, string name)
        {
            DateTime dt = DateTime.Now;
            Games onegame = GetGame(id);
            onegame.LoanedTo = name;
            onegame.LoanedDate = dt;
        }

        public void RemoveGame(int? id)
        {
            Games foundgame = GetGame(id);
            db.games.Remove(foundgame);
            db.SaveChanges();
        }

        public void ReturnGame(int? id)
        {
            Games onegame = GetGame(id);
            onegame.LoanedDate = null;
            onegame.LoanedTo = null;
        }
    }
}
