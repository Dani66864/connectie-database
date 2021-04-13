using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Registreren : MonoBehaviour
{
    public InputField nameField;
    public InputField password;
    public Button submitButton;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", nameField.text);
        form.AddField("password", password.text);
        WWW www = new WWW("http://gameproject.nl/register.php", form);
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("user createt sucessvolley");
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        else
        {
            Debug.Log("User creation failed .Error #" + www.text); 
        }
    }
    public void VerifyInputs()
    {
        submitButton.interactable = (nameField.text.Length >= 8 && password.text.Length >= 8);
    }
}

