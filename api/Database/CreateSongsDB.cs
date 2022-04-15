using System;
using System.IO;
using System.Collections.Generic;
using api.Models;
using MySql.Data.MySqlClient;
using api.Interfaces;

namespace api.Database
{
    public class CreateSongsDB : ICreateSongs
    {
        public void Create(Song song)
        {
            Console.WriteLine($"Made it here.");
            
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);

            con.Open();

            string stm = @$"INSERT INTO songs(title, dateAdded, isDeleted, isFavorited) VALUES(@title, @date, @deleted, @favorited)";

            using var cmd = new MySqlCommand(stm, con);

            cmd.Parameters.AddWithValue("@title", song.SongTitle);
            cmd.Parameters.AddWithValue("@date", song.SongTimestamp);
            cmd.Parameters.AddWithValue("@deleted", song.Deleted);
            cmd.Parameters.AddWithValue("@favorited", song.Favorited);


            cmd.Prepare();

            cmd.ExecuteNonQuery();

            con.Close();
        }
    }
}