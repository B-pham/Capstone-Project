using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public InputField registerEmail;
    public InputField registerPassword;
    public InputField registerAccessCode;
    public InputField loginEmail;
    public InputField loginPassword;
    public InputField loginAccessCode;
    public Text registerMessage;
    public Text loginMessage;
    public Text accessCodeMessage;

    public void registerButton() {
        loginMessage.text = registerEmail.text;
        accessCodeMessage.text = registerAccessCode.text;
    }

    public void loginButton(){
        loginMessage.text = loginEmail.text;
        accessCodeMessage.text = loginAccessCode.text;
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
}
 