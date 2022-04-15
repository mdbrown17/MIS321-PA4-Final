using MySql.Data.MySqlClient;
using System;
using System.IO;
using api.Models;
using api.Interfaces;
using System.Collections.Generic;

namespace api.Database
{
    public class FavoriteSongsDB : IUpdateSongs
    {
        public void Favorite(int id)
        {
            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);

            try{
                con.Open();
                string stm = $"UPDATE songs SET isFavorited = 'y' WHERE id = {id}";

                using var cmd = new MySqlCommand(stm, con);
                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch{
                Console.WriteLine($"ERROR: Could not locate id to favorite");
            }
        }
    }
}