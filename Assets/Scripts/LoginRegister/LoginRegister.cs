using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.SceneManagement;
using System.Text.RegularExpressions;

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
    private void Awake()
    {
        _usernameAndEmailLogin.text= PlayerPrefs.GetString("emailOrUsername");
        _passwordLogin.text = PlayerPrefs.GetString("passowrd");
    }

    private void Start()
    {
        SwitchLoginOrRegister();
        RegisterControls();
        LoginControls();
    }

    #region RegisterLogin System

    public void LoginEmail()
    {
        _resultText.text = "Logging In...";
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
            _resultText.text = "The email or password incorrect!";

        });
    }


    public void LoginUsername()
    {
        _resultText.text = "Logging In...";
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
            _resultText.text = "The username or password incorrect!";

        }); ;
    }

    public void SwitchLoginType()
    {
            RememberMe();
        if (_usernameAndEmailLogin.text.IndexOf('@') > 0 && _usernameAndEmailLogin.text.IndexOf('.') > 0)
            LoginEmail();

        else
            LoginUsername();

        PlayerPrefs.SetInt("Diamond", 0);
        PlayerPrefs.SetInt("level", 1);

    }


    public void Register()
    {
        _resultText.text = "Registering User...";
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
            StartCoroutine(RegisterLoad());
        },
        Error =>
        {
            Debug.Log("Kayit Basarisiz");
            _resultText.text = "Registration Failed!";
        }); ;

    }
    IEnumerator RegisterLoad()
    {
        _resultText.text = "Registration Success";
        yield return new WaitForSeconds(1f);
        _usernameAndEmailLogin.text=_usernameRegister.text;
        _passwordLogin.text = _passwordRegister.text;
        _registerPanel.SetActive(false);
        _resultText.text = "";
        _loginPanel.SetActive(true);
    }

    public void RememberMe()
    {

        if(_saveUser.isOn)
        {
            PlayerPrefs.SetString("emailOrUsername", _usernameAndEmailLogin.text);
            PlayerPrefs.SetString("passowrd", _passwordLogin.text);
        }
       

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


    public void RegisterControls()
    {
        if (_emailRegister.text.IndexOf('@') < 0 || _emailRegister.text.IndexOf('.') < 0 || _passwordRegister.text != _repeatPasswordRegister.text || _passwordRegister.text.Length < 6 )
        {
            _RegisterButton.interactable = false;

        }
        else
        {
            _RegisterButton.interactable = true;
        }
        _usernameRegister.text = Regex.Replace(_usernameRegister.text, "[^\\w\\._]", "");
        _usernameRegister.text = Regex.Replace(_usernameRegister.text, "[ç, ý, ü, ð, ö, þ, Ý, Ð, Ü, Ö, Þ, Ç,.]", "");
        _passwordRegister.text = Regex.Replace(_passwordRegister.text, "[ç, ý, ü, ð, ö, þ, Ý, Ð, Ü, Ö, Þ, Ç]", "");
    }
    public void LoginControls()
    {
        if ( _passwordLogin.text.Length < 6)
        {
            _LoginButton.interactable = false;

        }
        else
        {
            _LoginButton.interactable = true;
        }

        _passwordLogin.text = Regex.Replace(_passwordLogin.text, "[ç, ý, ü, ð, ö, þ, Ý, Ð, Ü, Ö, Þ, Ç]", "");
    }

    #endregion


}
