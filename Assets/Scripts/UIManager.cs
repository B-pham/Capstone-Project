using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("References")]
    public ChangeSceneWithButton changeScene;
    public GameObject keyboard;
    private bool emailCondition;
    private bool passwordCondition;
    
    [Header("Text Variables")]
    public TMP_InputField registerEmail;
    public TMP_InputField registerPassword;
    public TMP_InputField registerAccessCode;
    public TMP_InputField loginEmail;
    public TMP_InputField loginPassword;
    public TMP_InputField loginAccessCode;
    public TMP_InputField resetPasswordEmail;
    //public TMP_InputField verificationCode;
    public Text email;
    public Text password;
    public Text accessCode;
    public Text passwordResetEmail;

    [Header("Menu References")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject registerMenu;
    [SerializeField] private GameObject loginMenu;
    [SerializeField] private GameObject passwordResetMenu;
    //[SerializeField] private GameObject verificationMenu;
    [SerializeField] private GameObject userMenu;

    private void Start(){
        setUpMainMenuButtons();
        setUpRegisterMenuButtons();
        setUpLoginMenuButtons();
        setUpPasswordResetMenuButtons();
        //setUpVerificationMenuButtons();
        setUpUserMenuButtons();
        //AddTriggerEvent(LoginMenuEmailInput);
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
        [Header("Register Menu Variables")]
        [SerializeField] private Button RegisterMenuRegisterButton;
        [SerializeField] private Button RegisterMenuReturnButton;
        [SerializeField] private GameObject RegisterMenuTextbox;
        [SerializeField] public Text RegisterMenuTextboxMessage;
 
        private void setUpRegisterMenuButtons(){
            RegisterMenuRegisterButton.onClick.AddListener(registerMenuRegisterButtonClicked);
            RegisterMenuReturnButton.onClick.AddListener(registerMenuReturnButtonClicked);
        }

        private void registerMenuRegisterButtonClicked(){
            //Password Verification
            emailCondition = false;
            passwordCondition = false;
            if(string.IsNullOrEmpty(registerPassword.text)){
                RegisterMenuTextbox.SetActive(true);
                RegisterMenuTextboxMessage.text = "The password field is required. Please enter a password.";
            }
            else{
                passwordCondition = true;
            }  

            //Email Verification
            if(string.IsNullOrEmpty(registerEmail.text)){
                RegisterMenuTextbox.SetActive(true);
                RegisterMenuTextboxMessage.text = "The email field is required. Please enter an email.";
            }
            else if(!registerEmail.text.Contains("@")){
                RegisterMenuTextbox.SetActive(true);
                RegisterMenuTextboxMessage.text = "Please enter a valid Email.";
            } 
            else{
                emailCondition = true;
            }
            
            //Email and Password Verification
            if((emailCondition == true) && (passwordCondition == true)){
                updateRegisterInfo();
                registerUser();
                if(string.IsNullOrEmpty(registerAccessCode.text)){
                    accessCode.text = "0000";
                }
            }
        }

        private void registerMenuReturnButtonClicked(){
            registerMenu.SetActive(false);
            mainMenu.SetActive(true);
            clearRegisterInfo();
            RegisterMenuTextbox.SetActive(false);
        }
    #endregion

    #region LoginMenu Functions
        [Header("Login Menu Variables")]
        [SerializeField] private Button LoginMenuLoginButton;
        [SerializeField] private Button LoginMenuReturnButton;
        [SerializeField] private Button LoginMenuForgotPasswordButton;
        [SerializeField] private GameObject LoginMenuTextbox;
        [SerializeField] private Text LoginMenuTextboxMessage;
        //[SerializeField] public GameObject LoginMenuEmailInput;
 
        private void setUpLoginMenuButtons(){
            LoginMenuLoginButton.onClick.AddListener(LoginMenuLoginButtonClicked);
            LoginMenuReturnButton.onClick.AddListener(LoginMenuReturnButtonClicked);
            LoginMenuForgotPasswordButton.onClick.AddListener(LoginMenuForgotPasswordButtonClicked);
        }

        private void LoginMenuLoginButtonClicked(){
            //Password Verification
            emailCondition = false;
            passwordCondition = false;
            if(string.IsNullOrEmpty(loginPassword.text)){
                LoginMenuTextbox.SetActive(true);
                LoginMenuTextboxMessage.text = "The password field is required. Please enter a password.";
            }
            else{
                passwordCondition = true;
            }  

            //Email Verification
            if(string.IsNullOrEmpty(loginEmail.text)){
                LoginMenuTextbox.SetActive(true);
                LoginMenuTextboxMessage.text = "The email field is required. Please enter an email.";
            }
            else if(!loginEmail.text.Contains("@")){
                LoginMenuTextbox.SetActive(true);
                LoginMenuTextboxMessage.text = "Please enter a valid Email.";
            } 
            else{
                emailCondition = true;
            }
            
            //Email and Password Verification
            if((emailCondition == true) && (passwordCondition == true)){
                updateLoginInfo();
                loginUser();  
                if(string.IsNullOrEmpty(loginAccessCode.text)){
                    accessCode.text = "0000";
                }
            }
        }

        private void LoginMenuReturnButtonClicked(){
            loginMenu.SetActive(false);
            mainMenu.SetActive(true);
            clearLoginInfo();
            LoginMenuTextbox.SetActive(false);
        }

        private void LoginMenuForgotPasswordButtonClicked(){
            loginMenu.SetActive(false);
            passwordResetMenu.SetActive(true);
            clearLoginInfo();
            LoginMenuTextbox.SetActive(false);
        }

        /*
        private void AddTriggerEvent(GameObject input){
            if(input.GetComponent<EventTrigger>() == null){
                input.AddComponent<EventTrigger>();
            }
            EventTrigger trigger = input.GetComponent<EventTrigger>();
            EventTrigger.Entry entry = new EventTrigger.Entry();
            entry.eventID = EventTriggerType.PointerClick;
            entry.callback.AddListener((functionIWant) => { LoginMenuEmailInputClicked(); });
            trigger.triggers.Add(entry);
        }

        private void LoginMenuEmailInputClicked(){
           keyboard.SetActive(true);
        }
        */
        
    #endregion
    
    #region PasswordReset Menu Functions
        [Header("PasswordReset Menu Variables")]
        [SerializeField] private Button PasswordResetMenuSubmitButton;
        [SerializeField] private Button PasswordResetMenuReturnButton;
        [SerializeField] private GameObject PasswordResetMenuTextbox;
        [SerializeField] private Text PasswordResetMenuTextboxMessage;
 
        private void setUpPasswordResetMenuButtons(){
            PasswordResetMenuSubmitButton.onClick.AddListener(PasswordResetMenuSubmitButtonClicked);
            PasswordResetMenuReturnButton.onClick.AddListener(PasswordResetMenuReturnButtonClicked);
        }

        private void PasswordResetMenuSubmitButtonClicked(){
            emailCondition = false;

            //Email Verification
            if(string.IsNullOrEmpty(resetPasswordEmail.text)){
                PasswordResetMenuTextbox.SetActive(true);
                PasswordResetMenuTextboxMessage.text = "The email field is required. Please enter an email.";
            }
            else if(!resetPasswordEmail.text.Contains("@")){
                PasswordResetMenuTextbox.SetActive(true);
                PasswordResetMenuTextboxMessage.text = "Please enter a valid Email.";
            } 
            else{
                emailCondition = true;
            }
            
            //Email and Password Verification
            if(emailCondition == true){
                PasswordResetMenuTextbox.SetActive(true);
                updatePasswordResetInfo();
                clearResetEmail();
                resetPassword();
                PasswordResetMenuTextboxMessage.text = "Password reset email has been sent!";
                //passwordResetMenu.SetActive(false);
                //verificationMenu.SetActive(true);
            }            
        }

        private void PasswordResetMenuReturnButtonClicked(){
            passwordResetMenu.SetActive(false);
            mainMenu.SetActive(true);
            clearResetEmail();
            PasswordResetMenuTextbox.SetActive(false);
        }
    #endregion

    #region UserMenu Functions
        [Header("User Menu Variables")]
        [SerializeField] private Button UserMenuStartButton;
        [SerializeField] private Button UserMenuLogoutButton;
        [SerializeField] private GameObject UserMenuTextbox;
        [SerializeField] private Text UserMenuTextboxMessage;
 
        private void setUpUserMenuButtons(){
            UserMenuStartButton.onClick.AddListener(UserMenuStartButtonClicked);
            UserMenuLogoutButton.onClick.AddListener(UserMenuLogoutButtonClicked);
        }

        private void UserMenuStartButtonClicked(){
            clearPassword();
            if((emailCondition == true) && (passwordCondition == true)){
                changeScene.SingleLoadSceneFromManager("Lobby");
                UserMenuTextbox.SetActive(false);
            }
            else{
                UserMenuTextbox.SetActive(true);
                UserMenuTextboxMessage.text = "Error: No Login Detected, Please return to main menu and attempt login again.";
            }
        }

        private void UserMenuLogoutButtonClicked(){
            userMenu.SetActive(false);
            mainMenu.SetActive(true);
            clearPassword();
            UserMenuTextbox.SetActive(false);
        }
    #endregion

    #region Update Text Functions
        public void updateRegisterInfo() {
            email.text = registerEmail.text;
            password.text = registerPassword.text;
            accessCode.text = registerAccessCode.text;
        }

        public void clearRegisterInfo(){
            registerEmail.text = "";
            registerPassword.text = "";
            registerAccessCode.text = "";
        }

        public void updateLoginInfo(){
            email.text = loginEmail.text;
            password.text = loginPassword.text;
            accessCode.text = loginAccessCode.text;
        }

        public void clearLoginInfo(){
            loginEmail.text = "";
            loginPassword.text = "";
            loginAccessCode.text = "";
        }

        public void clearPassword(){
            password.text = "";
        }

        public void clearResetEmail(){
            resetPasswordEmail.text = "";
        }

        public void updatePasswordResetInfo(){
            passwordResetEmail.text = resetPasswordEmail.text;
        }
    #endregion

    /*#region Verification Functions
        [Header("Verification Menu Variables")]
        [SerializeField] private Button VerificationMenuResendCodeButton;
        [SerializeField] private Button VerificationMenuSubmitButton;
        [SerializeField] private Button VerificationMenuReturnButton;
        [SerializeField] private GameObject VerificationMenuTextbox;
        [SerializeField] private Text VerificationMenuTextboxMessage;
        private int randomVerificationCode;

        private void setUpVerificationMenuButtons(){
            VerificationMenuResendCodeButton.onClick.AddListener(VerificationMenuResendCodeButtonClicked);
            VerificationMenuSubmitButton.onClick.AddListener(VerificationMenuSubmitButtonClicked);
            VerificationMenuReturnButton.onClick.AddListener(VerificationMenuReturnButtonClicked);
            randomVerificationCode = Random.Range(100000,999999);
        }

        private void VerificationMenuSubmitButtonClicked(){
            //VerifyResetCode
            if(verificationCode.text == randomVerificationCode.ToString()){
                verificationMenu.SetActive(false);
                VerificationMenuTextbox.SetActive(false);
                loginMenu.SetActive(true);
                LoginMenuTextbox.SetActive(true);
                LoginMenuTextboxMessage.text = "Password has been reset! Please try logging in.";
            } 
            else{
                VerificationMenuTextbox.SetActive(true);
                VerificationMenuTextboxMessage.text = "Verification Code was incorrect. Please try again.";
            }
        }

        private void VerificationMenuReturnButtonClicked(){
            verificationMenu.SetActive(false);
            mainMenu.SetActive(true);
            VerificationMenuTextbox.SetActive(false);
        }

        private void VerificationMenuResendCodeButtonClicked(){
            randomVerificationCode = Random.Range(100000,999999);
            resetPassword();
            VerificationMenuTextbox.SetActive(true);
            VerificationMenuTextboxMessage.text = "Verification code has been resent to your email.";
        }
    #endregion
    */

    #region DatabaseConnect Functions
        //Register Functions
        public void registerUser()
        {
            StartCoroutine(registerInfo(email.text, password.text, accessCode.text));
        }
        IEnumerator registerInfo(string email, string password, string accessCode){
            WWWForm form = new WWWForm();
            form.AddField("emailPost", email);
            form.AddField("passwordPost", password);
            form.AddField("accessCodePost", accessCode);
            UnityWebRequest www = UnityWebRequest.Post("https://kvrdbconnection.azurewebsites.net/app/register.php", form);
            yield return www.SendWebRequest();
            Debug.Log(www.downloadHandler.text);
            RegisterMenuTextboxMessage.text = (www.downloadHandler.text);

            //Check for register success or failure
            if(RegisterMenuTextboxMessage.text.Contains("Success")){
                registerMenu.SetActive(false);
                RegisterMenuTextbox.SetActive(false);
                userMenu.SetActive(true);
                UserMenuTextbox.SetActive(true);
                UserMenuTextboxMessage.text = "Account has been created!";
                clearRegisterInfo();
            }
            else if(RegisterMenuTextboxMessage.text.Contains("Error")){
                RegisterMenuTextbox.SetActive(true);
                RegisterMenuTextboxMessage.text = "This email already has an account. Please try again or try signing in.";
                clearRegisterInfo();
            }
        }

        //Login Functions
        public void loginUser()
        {
            StartCoroutine(loginInfo(email.text, password.text, accessCode.text));
        }
        
        IEnumerator loginInfo(string email, string password, string accessCode) {
            WWWForm form = new WWWForm();
            form.AddField("emailPost", email);
            form.AddField("passwordPost", password);

            using (UnityWebRequest www = UnityWebRequest.Post("https://kvrdbconnection.azurewebsites.net/app/callLogin.php", form))
            {
                yield return www.SendWebRequest();

                if(www.result != UnityWebRequest.Result.Success){
                    Debug.Log(www.error);
                    LoginMenuTextboxMessage.text = (www.error);
                }
                else{
                    Debug.Log(www.downloadHandler.text);
                    LoginMenuTextboxMessage.text = (www.downloadHandler.text);

                    //Check for login success or failure
                    if(LoginMenuTextboxMessage.text.Contains("Password is correct!")){
                        loginMenu.SetActive(false);
                        LoginMenuTextbox.SetActive(false);
                        userMenu.SetActive(true);
                        UserMenuTextbox.SetActive(true);
                        UserMenuTextboxMessage.text = "You have successfully signed in!";
                        clearLoginInfo();
                    }
                    else if(LoginMenuTextboxMessage.text.Contains("Could not find an account for email. Please try again.")){
                        LoginMenuTextbox.SetActive(true);
                        LoginMenuTextboxMessage.text = "Could not find an account for email. Please try again.";
                        clearLoginInfo();
                    }
                    else if(LoginMenuTextboxMessage.text.Contains("incorrect")){
                        LoginMenuTextbox.SetActive(true);
                        LoginMenuTextboxMessage.text = "Password is incorrect. Please try again with another email or password.";
                        clearLoginInfo();
                    }
                    else
                        LoginMenuTextbox.SetActive(true);
                }
            }
        }

        //Password Reset Functions
        public void resetPassword()
    {
        StartCoroutine(resetPasswordinfo(passwordResetEmail.text));
    }
    
        IEnumerator resetPasswordinfo(string passwordResetEmail){
            WWWForm form = new WWWForm();
            form.AddField("passwordResetEmailPost", passwordResetEmail);
            //form.AddField("verificationCodePost", verificationCode);
            UnityWebRequest www = UnityWebRequest.Post("https://kvrdbconnection.azurewebsites.net/app/ForgotPass.php", form);
            yield return www.SendWebRequest();
            Debug.Log(www.downloadHandler.text);
            //VerificationMenuTextbox.SetActive(true);
            //VerificationMenuTextboxMessage.text = "Verification code and password reset link has been sent to your email";
        }
    #endregion

}
 