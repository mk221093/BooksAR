using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GoogleBooksAPI : MonoBehaviour
{

    [System.Serializable]
    public class VolumeInfo
    {
        public string title;
        public string[] authors;
        //public string imageLinks;
    }

    [System.Serializable]
    public class Items
    {
        public VolumeInfo volumeInfo;
    }

    [System.Serializable]
    public class BookData
    {
        public Items[] items;
    }




    public Text tempText;

    private static string apiKey = "AIzaSyBQLaLhb8IXaqgXKEvBaWPtntQHIdbQupU";    

    private static string url = "https://www.googleapis.com/books/v1/volumes?q=flowers+inauthor:keyes&key=" + apiKey;
        


    public BookData bData;

    IEnumerator Start()
    {
        using (WWW www = new WWW(url))
        {
            yield return www;

            bData = JsonUtility.FromJson<BookData>(www.text);

            Debug.Log(www.text);


                tempText.text += "Data for " + bData.items[0].volumeInfo.title + ":\n";
             //   tempText.text += "Data for " + bData.items[0].volumeInfo.imageLinks + ":\n";


            //        tempText.text += bData.name + "s landkode er " + bData.sys.country + ".\n";
            //        tempText.text += "Temperaturen er " + wData.main.temp + " grader.\n";
            //        tempText.text += "Fugtbarheden er " + wData.main.humidity + "%.\n";
            //        if (wData.main.humidity > 65)
            //        {
            //            tempText.text += "Det er pisse klamt og fugtigt. Mine hænder er helt fedtede..\n";
            //        }
            //        tempText.text += "Vind hastigheden " + wData.wind.speed + " m/s.\n";
            //        tempText.text += "Det er " + wData.clouds.all + "% overskyet.\n";
        }
    }
}
