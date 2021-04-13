using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebTest : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        WWW request = new WWW("http://gameproject.nl/webtest.php");
        yield return request;
        string[] webResult = request.text.Split('\t');
        Debug.Log(webResult[0]);
        int webNummer = int.Parse(webResult[1]);
        webNummer *= 2;
        Debug.Log(webNummer);
    }
}
