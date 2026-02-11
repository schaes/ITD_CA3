using TMPro;
using UnityEngine;

public class userVerification : MonoBehaviour
{
    [SerializeField]
    TMP_InputField username;
    [SerializeField]
    TMP_InputField password;
    [SerializeField]
    TMP_Text result;
    string user;
    string pass;

    public GameObject CA4;
    public GameObject LoginPanel;

    public void Start()
    {
        CA4.SetActive(false);
        LoginPanel.SetActive(true);
        result.text = "use user for user,  pass for password.";
    }
    public void UserVerify()
    {
        user = "user";
        pass = "pass";
        if (username != null && password != null)
        {
            if (username.text == user && password.text == pass)
            {
                result.text = "Login Successful";
                result.color = Color.green;
                Debug.Log("Login Successful");

                CA4.SetActive(true);
                LoginPanel.SetActive(false);
            }
            else
            {
                result.text = "Login Failed";
                result.color = Color.red;
                Debug.Log("Login Failed");
            }
        }
        else
        {
            Debug.Log("Error");
        }
    }
}