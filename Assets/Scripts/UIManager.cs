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
    public TMP_InputField resetPasswordEmail;
    public Text Message;
    public Text UserEmail;
    public Text UserPassword;
    public Text UserAccessCode;
    public Text verifyEmail;

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

    public void deleteLoginInfo(){
        loginEmail.text = "";
        loginPassword.text = "";
        loginAccessCode.text = "";
    }

    public void removePassword(){
        UserPassword.text = "";
    }

    public void removeResetEmail(){
        verifyEmail.text = "";
    }

    public void resetPassword(){
        verifyEmail.text = resetPasswordEmail.text;
        print(verifyEmail.text);
    }
}
 