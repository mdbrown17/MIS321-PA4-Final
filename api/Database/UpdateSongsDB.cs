using System;
using System.IO;
using System.Collections.Generic;
using api.Models;
using MySql.Data.MySqlClient;
using api.Interfaces;

namespace api.Database
{
    public class UpdateSongsDB //: IUpdateSongs
    {
        // public void Update(Song song)
        // {
        //     ConnectionString myConnection = new ConnectionString();
        //     string cs = myConnection.cs;

        //     using var con = new MySqlConnection(cs);

        //     try
        //     {
        //         con.Open();

        //         string stm = @$"UPDATE songs SET title = @title WHERE id = @id";

        //         using var cmd = new MySqlCommand(stm, con);

        //         cmd.Parameters.AddWithValue("@title", song.SongTitle);
        //         cmd.Parameters.AddWithValue("@dateadded", song.SongTimestamp);
        //         cmd.Parameters.AddWithValue("@id", song.SongID);
        //         cmd.Parameters.AddWithValue("@isFavorited", song.Favorited);


        //         cmd.ExecuteNonQuery();

        //         con.Close();
        //     }
        //     catch(Exception){}
        // }
        
    }
}