using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public Text playerDisplay;
    public Text scoreDisplay;

    private void Awake()
    {
        if (DBManager.username == null)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        playerDisplay.text = "player: " + DBManager.username;
        scoreDisplay.text = "score: " + DBManager.score;
    }

    public void CallSaveDate()
    {
        StartCoroutine(SavePlayerDate());
    }

    IEnumerator SavePlayerDate()
    {
        WWWForm from = new WWWForm();
        from.AddField("name", DBManager.username);
        from.AddField("score", DBManager.score);

        WWW www = new WWW("http://gameproject.nl/savedate.php",from);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Game Saved.");
        }
        else
        {
            Debug.Log("Save Failed. Error #" + www.text);
        }
        DBManager.LogOut();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);


    }
    
    public void IncreaseScore()
    {
        DBManager.score++;
        scoreDisplay.text = "score: " + DBManager.score;
    }
}