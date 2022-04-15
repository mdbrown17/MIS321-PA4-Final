using api.Interfaces;
using System.IO;
using System;
using System.Collections.Generic;
using api.Models;
using MySql.Data.MySqlClient;

namespace api.Database
{
    public class ReadSongsDB : IReadSongs
    {
        public List<Song> GetAll() 
        {
            List<Song> mySongs = new List<Song>(); // list to return

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);

            try {
                con.Open();

                string stm = @$"select * from songs where isdeleted != 'y' order by dateadded desc";

                using var cmd = new MySqlCommand(stm, con);

                using MySqlDataReader reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    mySongs.Add(new Song() { 
                        SongID = reader.GetInt32(0), 
                        SongTitle = reader.GetString(1), 
                        SongTimestamp = reader.GetDateTime(2), 
                        Deleted = reader.GetString(3),
                        Favorited = reader.GetString(4)
                    });
                } 
                con.Close();
                return mySongs;
            }
            catch(Exception)
            {
                return mySongs;
            }
        }
        public Song GetOne(int id)
        {
            Song mySong = new Song();

            ConnectionString myConnection = new ConnectionString();
            string cs = myConnection.cs;

            using var con = new MySqlConnection(cs);
            con.Open();
            string stm = $"SELECT * FROM songs where id = {id}";

            using var cmd = new MySqlCommand(stm, con);
            cmd.Parameters.AddWithValue("@id", id);

            using MySqlDataReader reader = cmd.ExecuteReader();

            if(reader.Read()){
                mySong.SongID = reader.GetInt32(0);
                mySong.SongTitle = reader.GetString(1);
                mySong.SongTimestamp = reader.GetDateTime(2);
                mySong.Deleted = reader.GetString(3);
                mySong.Favorited = "n";
            }             

            con.Close();
            return mySong;
        }
    }
}