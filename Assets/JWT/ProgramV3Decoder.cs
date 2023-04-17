using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JWT;

public class ProgramV3Decoder : MonoBehaviour
{
    public ProgramV3 webToken;
    [HideInInspector]
    public string jsonPayload;
    [HideInInspector]
    public string token;

    public void Decoder()//This allows for the decoder to run with a push of a button
    {
        Decode();
    }

    private void Decode()
    {
        string token = webToken.token;
        var secretKey = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";//Need to hide this somewhere better. Also need to make a unique one as well
        try
        {
            jsonPayload = JsonWebToken.Decode(token, secretKey, false);//This is where the web token is decoded
            Debug.Log("Payload after decrypting: " + jsonPayload);//This is for debuging purposes. Remove before deploying to product
        }

        catch (SignatureVerificationException)
        {
            Debug.Log("Invalid token!");
        }
    }

    public string DecodeTest(string token, string secretKey)//This is for unit testing. Should keep this as close to the actual code used for encryption
    {
        //var secretKey = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
        try
        {
            jsonPayload = JsonWebToken.Decode(token, secretKey, false);
            Debug.Log("Payload after decrypting" + jsonPayload);
            return jsonPayload;
        }

        catch (SignatureVerificationException)
        {
            Debug.Log("Invalid token!");
            return null;
        }
    }
}
