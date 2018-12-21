using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Security.Policy;
using Put_me_on_the_list_chief.Models;

namespace Put_me_on_the_list_chief.Controllers
{
    public class APIController : Controller
    {


        Url characterURL = new Url("https://www.anapioficeandfire.com/api/Characters/");
        // this tells the program what browsers its compatable with. Making a const so we only have to call the variable and can update it in one place. 
        const string userAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64; rv:47.0) Gecko/20100101 Firefox/47.0";
        // GET: API

        public ActionResult ShowRawGOTData()
        {
            //this is a test to show the API is working- pulling up Jon Snow #583
            HttpWebRequest request = WebRequest.CreateHttp($"https://www.anapioficeandfire.com/api/Characters/583");
            request.UserAgent = userAgent;

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            if (response.StatusCode == HttpStatusCode.OK)
            {
                StreamReader data = new StreamReader(response.GetResponseStream());
                ViewBag.RawData = data.ReadToEnd();
            }
            return View();
        }

        [HttpGet]
        public ActionResult ShowCharacterData()
        {
            var character = new CharacterModel();
            var characNumber = new List<int>{ 583, 339, 16, 27, 206, 271 };
            for (int i = 0; i < characNumber.Count; i++)
            {



                HttpWebRequest request =
                    WebRequest.CreateHttp($"https://www.anapioficeandfire.com/api/characters/{i}");

                request.UserAgent = userAgent;


                HttpWebResponse response =
                    (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader data = new StreamReader(response.GetResponseStream());
                    JObject dataObject = JObject.Parse(data.ReadToEnd());
                    character.name = dataObject["name"].ToString();
                    character.gender = dataObject["gender"].ToString();


                }
            }
            return View();
        }

    }
}