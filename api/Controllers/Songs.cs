using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api.Database;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Cors;

namespace api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Songs : ControllerBase
    {
        // GET: api/Songs -async -- GET ALL SONGS
        [EnableCors("OpenPolicy")]
        [HttpGet]
        public List<Song> Get()
        {
            IReadSongs songs = new ReadSongsDB();
            List<Song> mySongs = songs.GetAll();

            foreach(Song song in mySongs)
            {
                Console.WriteLine(song.SongTitle);
            }
            return mySongs;
        }

        // GET: api/Songs -async/5 -- GET A SONG
        [HttpGet("{id}", Name = "Get")]
        public Song Get(int id)
        {
            IReadSongs song = new ReadSongsDB();
            return song.GetOne(id);
        }

        // POST: api/Songs -async -- ADD A SONG
        [EnableCors("OpenPolicy")]
        [HttpPost]
        public void Post([FromBody] Song mySong)
        {            
            ICreateSongs createSong = new CreateSongsDB();
            createSong.Create(mySong);
            Console.WriteLine(mySong.SongTitle);   
        }

        // PUT: api/Songs -async/5 -- EDIT A SONG -- ask about -async weirdness
        [EnableCors("OpenPolicy")]
        [HttpPut("{id}")] // ID SHOULD AUTO_INCREMENT
        public void Put(int id)
        {
            IUpdateSongs updateSong = new FavoriteSongsDB(); 
            updateSong.Favorite(id);
        }

        // DELETE: api/Songs -async/5 -- DELETE A SONG
        [EnableCors("OpenPolicy")]
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            IDeleteSongs instance = new DeleteSongsDB(); 
            instance.Delete(id);
            Console.WriteLine($"DELTED_________________________________________" + id);
            
        }
        // FAVORITE: api/Songs -async/5 -- FAVORITE A SONG
        // [EnableCors("OpenPolicy")]
        // [HttpDelete("{id}")]
        // public void FAVORITE(int id)
        // {
        //     IFavoriteSongs instance = new FavoriteSongsDB(); 
        //     instance.Favorite(id);
        //     Console.WriteLine($"FAVORITED_________________________________________" + id);
            
        // }
    }
}
