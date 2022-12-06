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
    public Text userMessage;
    public Text passwordResetMessage;
    public UIManager uiManager;

    //Registration Functions
    public void registerUser()
    {
        StartCoroutine(registerInfo(email.text, password.text, accessCode.text));
        print("Success sending data!");
        userMessage.text = "Success sending data!";
    }

        IEnumerator registerInfo(string email, string password, string accessCode){
        WWWForm form = new WWWForm();
        form.AddField("emailPost", email);
        form.AddField("passwordPost", password);
        form.AddField("accessCodePost", accessCode);
        UnityWebRequest www = UnityWebRequest.Post("https://kvrdbconnection.azurewebsites.net/register.php", form);
        yield return www.SendWebRequest();
        Debug.Log(www.downloadHandler.text);
        userMessage.text = (www.downloadHandler.text);
    }


    //Login Functions
    public void loginUser()
    {
        StartCoroutine(loginInfo(email.text, password.text, accessCode.text));
        print("Success sending data!");
        userMessage.text = "Success sending data!";
    }
    
    IEnumerator loginInfo(string email, string password, string accessCode) {
        WWWForm form = new WWWForm();
        form.AddField("emailPost", email);
        form.AddField("passwordPost", password);

        using (UnityWebRequest www = UnityWebRequest.Post("https://kvrdbconnection.azurewebsites.net/index.php", form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
                userMessage.text = (www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                userMessage.text = (www.downloadHandler.text);
            }
        }
    }

       
    public void resetPassword()
    {
        StartCoroutine(resetPasswordinfo(email.text));
        print("Data Sent!");
        passwordResetMessage.text = "Data Sent!";
    }

    IEnumerator resetPasswordinfo(string email){
    WWWForm form = new WWWForm();
    form.AddField("emailPost", email);
    UnityWebRequest www = UnityWebRequest.Post("https://kvrdbconnection.azurewebsites.net/ForgotPass.php", form);
    yield return www.SendWebRequest();
    //Debug.Log(www.downloadHandler.text);
    //passwordResetMessage.text = (www.downloadHandler.text);
    passwordResetMessage.text = "Password has been sent to your email";
    }
}
