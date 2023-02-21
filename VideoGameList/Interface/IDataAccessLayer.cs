﻿using VideoGameList.Models;

namespace VideoGameList.Interface
{
    public interface IDataAccessLayer
    {
        IEnumerable<Games> GetGames();
        void AddGame(Games game);
        void RemoveGame(int? id);
        Games GetGame(int? id);
        void EditGame(Games game);
        IEnumerable<Games> FilterGames(string genre, string mparating);
        int GetGameCount();
        void LoanGame(int? id, string name);
        void ReturnGame(int? id);
    }
}
