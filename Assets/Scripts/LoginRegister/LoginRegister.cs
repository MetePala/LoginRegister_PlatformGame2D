using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;

public class LoginRegister : MonoBehaviour
{

    [SerializeField]
    InputField _usernameRegister, _emailRegister, _passwordRegister, _repeatPasswordRegister;
    [SerializeField]
    InputField _usernameAndEmailLogin , _passwordLogin;
    [SerializeField]
    Button _RegisterButton, _LoginButton;
   
    [SerializeField]
    Text _resultText;

    [Header("Guest Login Settings")]
    [SerializeField]
    bool _guestLogin;

    [SerializeField]
    GameObject _registerPanel, _loginPanel;

    [SerializeField] Animator _animator;
    [SerializeField] Toggle _saveUser;

    public static string _playerID;
    string guestID;
    private void Awake()
    {
        _usernameAndEmailLogin.text= PlayerPrefs.GetString("emailOrUsername");
        _passwordLogin.text = PlayerPrefs.GetString("passowrd");
    }

    private void Start()
    {
        SwitchLoginOrRegister();
    }

    #region RegisterLogin System

    public void LoginEmail()
    {
        PlayFabClientAPI.LoginWithEmailAddress(new LoginWithEmailAddressRequest()
        {
            Email = _usernameAndEmailLogin.text,
            Password = _passwordLogin.text
            
        },
        Result =>
        {
            Debug.Log("Giris basarili");
            _playerID = Result.PlayFabId;
            SceneManager.LoadScene(1);
        },
        Error =>
        {
            Debug.Log("Giris Basarisiz");

        });
    }


    public void LoginUsername()
    {
        PlayFabClientAPI.LoginWithPlayFab(new LoginWithPlayFabRequest()
        {
            Username = _usernameAndEmailLogin.text,
            Password = _passwordLogin.text
            
        },
        Result =>
        {
            Debug.Log("Giris basarili");
            _playerID =  Result.PlayFabId;
            SceneManager.LoadScene(1);
        },
        Error =>
        {
            Debug.Log("Giris Basarisiz");

        }); ;
    }

    public void SwitchLoginType()
    {
        if (_saveUser.isOn == true)
            RememberMe();

        if (_usernameAndEmailLogin.text.IndexOf('@') > 0)
            LoginEmail();

        else
            LoginUsername();

    }


    public void Register()
    {
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest()
        {
            Username = _usernameRegister.text,
            Email = _emailRegister.text,
            Password = _passwordRegister.text,
            DisplayName = _usernameRegister.text
        },
        Result =>
        {
            Debug.Log("Kayit basarili");
           

        },
        Error =>
        {
            Debug.Log("Kayit Basarisiz");
           
        }); ;

    }

    public void RememberMe()
    {

        
        PlayerPrefs.SetString("emailOrUsername", _usernameAndEmailLogin.text);
        PlayerPrefs.SetString("passowrd", _passwordLogin.text);

    }



    public void PlayGuest()
    {
        PlayFabClientAPI.LoginWithAndroidDeviceID(new LoginWithAndroidDeviceIDRequest()
        {
            CreateAccount = _guestLogin,
            AndroidDeviceId = SystemInfo.deviceUniqueIdentifier
        },
        Result =>
        {
            Debug.Log("Misafir Girisi basarili");
            GuestDisplayName();
        },
        Error =>
        {
            Debug.Log("Misafir Girisi basarisiz");
        });
    }
    public void GuestDisplayName()
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest()
        {
            DisplayName = "Guest"+Random.Range(1,1000).ToString()

        },
        Result =>
        {
            SceneManager.LoadScene(2);
        },
        Error =>
        {
            Debug.Log("Hatalý Giris");
        }); ;

    }

    public void SwitchLoginOrRegister()
    {
        switch (_registerPanel.activeInHierarchy)
        {
            case true:
                _loginPanel.SetActive(true);
                _registerPanel.SetActive(false);
                break;
            default:
                _loginPanel.SetActive(false);
                _registerPanel.SetActive(true);
                break;
        }
    }


    #endregion


}
