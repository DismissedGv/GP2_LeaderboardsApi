using System.Collections.Generic;
using System.Linq;
using GP2_LeaderboardsApi.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GP2_LeaderboardsApi.Controllers
{
    [Route("api/[controller]")]
    public class PlayerController : Controller
    {
        private static List<Player> Players = new List<Player>()
        {
            new Player
            {
                Name = "Sinan",
                Score = 150
            },
            new Player
            {
                Name = "Alexander",
                Score = 90
            },
            new Player
            {
                Name = "William",
                Score = 70
            },
			new Player
			{
				Name = "Martin",
				Score = -10
			}
		};

        // GET api/players
        [HttpGet]
        public JsonResult Get()
        {
            return Json(Players);
        }

        //// GET api/players/5
        //[HttpGet("{id:int}")]
        //public JsonResult Get(int id)
        //{
        //    try
        //    {
        //        Player player = Players.Single(p => p.ID == id);
        //        return Json(player);
        //    }catch (Exception ex) { return  Json(null); }
        //}

        // POST api/players
        [HttpPost]
        public JsonResult Post([FromBody] Player newPlayer) 
        {
            if (Players.Count < 5)
            {
                Players.Add(newPlayer);

				// Bubble sort
				for (int i = 0; i < Players.Count; i++)
				{
					for (int j = i + 1; j < Players.Count; j++)
					{
						if (Players[j].Score > Players[i].Score)
						{
                            // Swap
                            (Players[j], Players[i]) = (Players[i], Players[j]);
						}
					}
				}
                return Json(Players);
			}

            for (var i = Players.Count-1; i > 0; i--)
            {
                if (Players[i].Score < newPlayer.Score)
                {
                    Players[i] = newPlayer;
                    break;
                }
            }
            return Json(Players);
        }

		////PUT api/players/5
		//[HttpPut("{id:int}")]
		//public JsonResult Put(int id, [FromBody] float newScore) 
		//{
		//    Player player = Players.Single(p => p.ID == id);
		//    player.Score = newScore;
		//    return Json(Players);
		//}

		//// DELETE api/players/5
		//[HttpDelete("{id:int}")]
		//public void Delete(int id) 
		//{
		//    Player player = Players.Single(p => p.ID == id);
		//    Players.Remove(player);
		//}
		
  //      [HttpDelete("{key:string}")]
		//public void Delete(string key)
  //      {
  //          if(key == "key")
  //          {
  //              Players.Clear();
  //          }
  //      }
    }
}
