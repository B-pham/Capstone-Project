using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//Used video at this link: https://www.youtube.com/watch?v=SO6KLuz_S8M

public class DatabaseConnect : MonoBehaviour
{
    public Text username;
    public Text password;

    public void PublicLogin()
    {
        StartCoroutine(Login(username.text, password.text));
    }

    IEnumerator Login(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("LoginUser", username);
        form.AddField("LoginPass", password);

        using (UnityWebRequest www = UnityWebRequest.Post("https://kvrdbconnection.azurewebsites.net", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
