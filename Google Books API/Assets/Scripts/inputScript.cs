using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inputScript : MonoBehaviour
{
    private string result;
    private GameObject API;
    // Use this for initialization
    void Start()
    {
        API = GameObject.Find("API");
        var textInput = GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        textInput.onEndEdit.AddListener(SubmitName);
    }

    public void SubmitName(string arg0)
    {
        // call method from API
        API.GetComponent<GoogleBooksAPI>().doSearch(arg0);

    }
}
