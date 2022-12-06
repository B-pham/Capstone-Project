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
    public Text UserEmail;
    public Text UserPassword;
    public Text UserAccessCode;
    public Text verifyEmail;
    public DatabaseConnect databaseConnect;

    //Menu's
    [Header("Menu References")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject registerMenu;
    [SerializeField] private GameObject loginMenu;
    [SerializeField] private GameObject passwordResetMenu;
    [SerializeField] private GameObject userMenu;

    private void Start(){
        setUpMainMenuButtons();
        setUpRegisterMenuButtons();
        setUpLoginMenuButtons();
        setUpPasswordResetMenuButtons();
        setUpUserMenuButtons();
    }

    #region MainMenu Functions
        [Header("Main Menu Variables")]
        [SerializeField] private Button mainMenuRegisterButton;
        [SerializeField] private Button mainMenuLoginButton;
 
        private void setUpMainMenuButtons(){
            mainMenuRegisterButton.onClick.AddListener(registerButtonClicked);
            mainMenuLoginButton.onClick.AddListener(loginButtonClicked);
        }

        private void registerButtonClicked(){
            mainMenu.SetActive(false);
            registerMenu.SetActive(true);
        }

        private void loginButtonClicked(){
            mainMenu.SetActive(false);
            loginMenu.SetActive(true);
        }
    #endregion

    #region RegisterMenu Functions
        [Header("Register Variables")]
        [SerializeField] private Button RegisterMenuRegisterButton;
        [SerializeField] private Button RegisterMenuReturnButton;
 
        private void setUpRegisterMenuButtons(){
            RegisterMenuRegisterButton.onClick.AddListener(registerMenuRegisterButtonClicked);
            RegisterMenuReturnButton.onClick.AddListener(registerMenuReturnButtonClicked);
        }

        private void registerMenuRegisterButtonClicked(){
            registerMenu.SetActive(false);
            userMenu.SetActive(true);
            registerButton();
            deleteRegisterInfo();
            databaseConnect.registerUser();
        }

        private void registerMenuReturnButtonClicked(){
            registerMenu.SetActive(false);
            mainMenu.SetActive(true);
            deleteRegisterInfo();
        }
    #endregion

    #region LoginMenu Functions

        [Header("Login Variables")]
        [SerializeField] private Button LoginMenuLoginButton;
        [SerializeField] private Button LoginMenuReturnButton;
        [SerializeField] private Button LoginMenuForgotPasswordButton;
 
        private void setUpLoginMenuButtons(){
            LoginMenuLoginButton.onClick.AddListener(LoginMenuLoginButtonClicked);
            LoginMenuReturnButton.onClick.AddListener(LoginMenuReturnButtonClicked);
            LoginMenuForgotPasswordButton.onClick.AddListener(LoginMenuForgotPasswordButtonClicked);
        }

        private void LoginMenuLoginButtonClicked(){
            loginMenu.SetActive(false);
            userMenu.SetActive(true);
            loginButton();
            deleteLoginInfo();
            databaseConnect.loginUser();
        }

        private void LoginMenuReturnButtonClicked(){
            loginMenu.SetActive(false);
            mainMenu.SetActive(true);
            deleteLoginInfo();
        }

        private void LoginMenuForgotPasswordButtonClicked(){
        loginMenu.SetActive(false);
        passwordResetMenu.SetActive(true);
        deleteLoginInfo();
    }
    #endregion
    
    #region PasswordResetMenu Functions
        [Header("PasswordReset Variables")]
        [SerializeField] private Button PasswordResetMenuSubmitButton;
        [SerializeField] private Button PasswordResetMenuReturnButton;
 
        private void setUpPasswordResetMenuButtons(){
            PasswordResetMenuSubmitButton.onClick.AddListener(PasswordResetMenuSubmitButtonClicked);
            PasswordResetMenuReturnButton.onClick.AddListener(PasswordResetMenuReturnButtonClicked);
        }

        private void PasswordResetMenuSubmitButtonClicked(){
            resetPassword();
            databaseConnect.resetPassword();
            removeResetEmail();
        }

        private void PasswordResetMenuReturnButtonClicked(){
            passwordResetMenu.SetActive(false);
            mainMenu.SetActive(true);
            removeResetEmail();
        }
    #endregion

    #region UserMenu Functions
        [Header("UserMenu Variables")]
        [SerializeField] private Button UserMenuStartButton;
        [SerializeField] private Button UserMenuLogoutButton;
 
        private void setUpUserMenuButtons(){
            UserMenuStartButton.onClick.AddListener(UserMenuStartButtonClicked);
            UserMenuLogoutButton.onClick.AddListener(UserMenuLogoutButtonClicked);
        }

        private void UserMenuStartButtonClicked(){
            removePassword();
        }

        private void UserMenuLogoutButtonClicked(){
            userMenu.SetActive(false);
            mainMenu.SetActive(true);
            removePassword();
        }
    #endregion

    #region Button Functions
        public void registerButton() {
            UserEmail.text = registerEmail.text;
            UserPassword.text = registerPassword.text;
            UserAccessCode.text = registerAccessCode.text;
            print("RegisterButton Function");
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
            print("DeleteRegisterInfo Function");
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
            resetPasswordEmail.text = "";
        }

        public void resetPassword(){
            verifyEmail.text = resetPasswordEmail.text;
            print(verifyEmail.text);
        }
    #endregion


    
}
 