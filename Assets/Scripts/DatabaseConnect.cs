using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

//Used video at this link: https://www.youtube.com/watch?v=SO6KLuz_S8M

public class DatabaseConnect : MonoBehaviour
{
    public Text email;
    public Text password;
    public Text accessCode;

    //Registration Functions
    public void RegisterInfo()
    {
        StartCoroutine(CreateUser(email.text, password.text, accessCode.text));
        print("Success sending data!");
    }

        IEnumerator CreateUser(string email, string password, string accessCode){
        WWWForm form = new WWWForm();
        form.AddField("emailPost", email);
        form.AddField("passwordPost", password);
        form.AddField("accessCodePost", accessCode);
        UnityWebRequest www = UnityWebRequest.Post("https://kvrdbconnection.azurewebsites.net/register.php", form);
        yield return www.SendWebRequest();
        Debug.Log(www.downloadHandler.text);
    }


    //Login Functions
    public void LoginInfo()
    {
        StartCoroutine(LoginUser(email.text, password.text, accessCode.text));
        print("Success sending data!");
    }

    IEnumerator LoginUser(string email, string password, string accessCode)
    {
        WWWForm form = new WWWForm();
        form.AddField("emailPost", email);
        form.AddField("passwordPost", password);

        using (UnityWebRequest www = UnityWebRequest.Post("https://kvrdbconnection.azurewebsites.net/index.php", form))
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
