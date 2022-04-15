const baseUrl = "https://localhost:5001/api/songs";
var songList = [];
var mySong = {};

function handleOnLoad() {
    getSongs();
}

function getSongs(){
    fetch(baseUrl).then(function(response){
        console.log(response);
        return response.json();
    }).then(function(json){

        let html = "";
        var songCount = 0;

        html +=  '<div id="cards" class="container"> <div class="row">';
                // '<div id="cards" class="container"><div class="row"></div>';

        json.forEach((song) => {

            console.log(song.songTitle); // test note

            var cardInfo = song.songID + ": " + song.songTitle;

            if(song.favorited == 'y'){
                cardInfo += "(FAVORITE)";
            };

            if(songCount %3 == 0){
                html +=  '<div class="row"></div>';
            };

            // console.log(song.title)
            html += `<div class="card col-md-4 bg-dark text-white">`;
            html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
            html += `<div class="card-img-overlay">`;
            html += `<h5 class="card-title">`+cardInfo+`</h5>`;
            html += `</div>`;
            html += `</div>`;
            songCount ++;
        });
            document.getElementById("cards").innerHTML = html;

    }).catch(function(error){
            console.log(error);
    });
}
function wait(milliseconds) {
    return new Promise((resolve) => setTimeout(resolve, milliseconds));
  }

function favoriteASong(){
    console.log("made it");

    const favoriteMe = document.getElementById("favoriteID").value;

    const specificUrl = baseUrl + "/" + favoriteMe;

    fetch(specificUrl, {
        method: "PUT",
        headers: {
            "Accept": 'application/json',
            "Content-Type":'application/json',
        }
        // ,
        // body: JSON.stringify({
        //     favorited: 'y'
        // })
    }).then((response) =>{
        console.log(response);
    });    
    console.log(favoriteMe);
    wait(2000);
    getSongs();
}


function deleteSong(){
    const deleteMe = document.getElementById("DeleteID").value;

    const specificUrl = baseUrl + "/" + deleteMe;
    
    fetch(specificUrl, {
        method: "DELETE",
        headers: {
            "Accept": 'application/json',
            "Content-Type":'application/json',
        },
    }).then((response) =>{
        console.log(response);
    });    
    console.log(deleteMe);
    wait(2000);
    getSongs();
}

function postSong() {
    const songTitle = document.getElementById("title").value;
    
    fetch(baseUrl, {
        method: "POST",
        headers: {
            "Accept": 'application/json',
            "Content-Type":'application/json',
        },
        body: JSON.stringify({
            songTitle: songTitle,
            songTimestamp: new Date().toISOString(),
            deleted: 'n',
            favorited: 'n'
        })
        
    }).then((response) =>{
        console.log(response);
    });    wait(2000);
    getSongs();
}

function findSongs(){
    var url = "https://www.songsterr.com/a/ra/songs.json?pattern="
    let searchString = document.getElementById("searchSong").value;

    url += searchString;

    console.log(searchString)

    fetch(url).then(function(response) {
		console.log(response);
		return response.json();
	}).then(function(json) {
        console.log(json)
        let html = ``;
		json.forEach((song) => {
            console.log(song.title)
            html += `<div class="card col-md-4 bg-dark text-white">`;
			html += `<img src="./resources/images/music.jpeg" class="card-img" alt="...">`;
			html += `<div class="card-img-overlay">`;
			html += `<h5 class="card-title">`+song.title+`</h5>`;
            html += `</div>`;
            html += `</div>`;
		});
		
        if(html === ``){
            html = "No Songs found :("
        }
		document.getElementById("searchSongs").innerHTML = html;

	}).catch(function(error) {
		console.log(error);
	})
    

}