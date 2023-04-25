using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JWT;

public class ProgramV3 : MonoBehaviour
{
    double JSONts;
    double exp;
    [HideInInspector]
    public string token;
    [HideInInspector]
    public string secretKey = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";//Need to hide this somewhere better. Also need to make a unique one as well

    // public TestData test = new TestData();
    // Start is called before the first frame update

    public void Encrypt(string Username, string Password)
    {
        //IDictionary<string, object> extraHeader = new Dictionary<string, object>();

        //This block is too create headers exp and iat
        /*DateTime date1 = new DateTime(1970, 1, 1, 00, 00, 00);//year, month, day, hour, minute, second
        DateTime localDate = DateTime.UtcNow;
        TimeSpan ts = localDate - date1;
        JSONts = ts.TotalSeconds;
        exp = JSONts + 1000;//Gives the user a little over 15 minutes before the web token expires(16.67 minutes)
        Debug.Log("ts: " + ts.TotalSeconds);
        Debug.Log("JSONts: " + JSONts);
        Debug.Log("exp: " + exp);*/

        var test = new TestData();//This is what will be encoded as the payload for the web token

        //Set of data in the object for the web token
        test.username = Username;
        test.password = Password;
        var secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";

        //This is where the token is encoded
        token = JsonWebToken.Encode(test, secret, JwtHashAlgorithm.HS256);
        //token = JsonWebToken.Encode(extraHeader, payload, secret, JwtHashAlgorithm.HS256);//Add additional headers to the web token
        Debug.Log(token);
        File.WriteAllText(Application.dataPath + "/JsonWebToken.json", token);
    }

    public string TestEncrypt()//This is for unit testing. Should keep this as close to the actual code used for encryption
    {
        var test = new TestData();
        test.username = "test@test.gmail.com";
        test.password = "Hello there!";
        var secret = "GQDstcKsx0NHjPOuXOYg5MbeJ1XT0uFiwDVvVBrk";
        string Testtoken = JsonWebToken.Encode(test, secret, JwtHashAlgorithm.HS256);
        return Testtoken;
    }

    [System.Serializable]
    public class TestData
    {
        public string username;
        public string password;
    }

}
