using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_InputField registerEmail;
    public TMP_InputField registerPassword;
    public TMP_InputField registerAccessCode;
    public TMP_InputField loginEmail;
    public TMP_InputField loginPassword;
    public TMP_InputField loginAccessCode;
    public Text registerMessage;
    public Text UserEmail;
    public Text UserPassword;
    public Text UserAccessCode;

    public void registerButton() {
        UserEmail.text = registerEmail.text;
        UserPassword.text = registerPassword.text;
        UserAccessCode.text = registerAccessCode.text;
    }

    public void loginButton(){
        UserEmail.text = loginEmail.text;
        UserPassword.text = loginPassword.text;
        UserAccessCode.text = loginAccessCode.text;
    }

    public void deleteRegisterInfo(){
        registerEmail.text = "";
        registerPassword.text = "";
        registerAccessCode.text = "";
    }

    public void deleteLoginInfo() {
        loginEmail.text = "";
        loginPassword.text = "";
        loginAccessCode.text = "";
    }

    public void RemovePassword() {
        UserPassword.text = "";
    }
}
 