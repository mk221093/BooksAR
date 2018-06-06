using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GoogleBooksAPI : MonoBehaviour
{

    [System.Serializable]
    public class ImageLinks
    {
        public string smallThumbnail;
    }

    [System.Serializable]
    public class VolumeInfo
    {
        public string title;
        public string[] authors;
        public ImageLinks imageLinks;
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


    private string mySearch;
    public Text tempText;
    public Text tempText2;
    private string imgPath;
    public GameObject bookPic;



    private string query = "garden";
    private static string apiKey = "AIzaSyBQLaLhb8IXaqgXKEvBaWPtntQHIdbQupU";



    public static BookData bData;

    IEnumerator Start()
    {

        string url = "https://www.googleapis.com/books/v1/volumes?q=" + query + "&key=" + apiKey;
        using (WWW www = new WWW(url))
        {
            yield return www;

            bData = JsonUtility.FromJson<BookData>(www.text);
            imgPath = bData.items[0].volumeInfo.imageLinks.smallThumbnail + ".png";

            Debug.Log(www.text);

            tempText.text = "";
            tempText2.text = "";
            tempText.text += "Title: " + bData.items[0].volumeInfo.title + ":\n";
            tempText2.text += "Author: " + bData.items[0].volumeInfo.authors[0] + ":\n";
        }


        Texture2D tex;
        Sprite newSprite = new Sprite();

        tex = new Texture2D(4000, 4000, TextureFormat.DXT1, false);

        using (WWW imgwww = new WWW(imgPath))
        {

            yield return imgwww;

            imgwww.LoadImageIntoTexture(tex);
            newSprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0.5f, 0.5f));
            GetComponent<SpriteRenderer>().sprite = newSprite;

        }
    }
    public void doSearch(string search)
    {
        query = search;
        StartCoroutine("Start");
    }
}

