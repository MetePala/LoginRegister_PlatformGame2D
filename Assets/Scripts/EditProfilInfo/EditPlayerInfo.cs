using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class EditPlayerInfo : MonoBehaviour
{
    [SerializeField] GameObject _changeImagePanel, _changeNamePanel;
    [SerializeField] Text _displayName,_email;
    [SerializeField] Image img;
    string url ;

    [SerializeField] InputField _newDisplayname;

    [SerializeField] Text _infoText;
    bool Register_Async;

    GetPlayerAccountInfo _getplayeraccountinfo;
    private void Awake()
    {
       _getplayeraccountinfo = new GetPlayerAccountInfo();
        _getplayeraccountinfo.GetAccountInfoo();
       
        StartCoroutine(second1());
        GetDisplayName();
        StartCoroutine(baslat());
    }
    IEnumerator second1()
    {
        yield return new WaitForSeconds(1f);
        url = _getplayeraccountinfo._avatarUrl;
        if(url==null)
        {
            url = "https://www.gravatar.com/userimage/221184294/256ee735a7e2f34d7954e3f8d889bc18?size=120";
        }
        _email.text = _getplayeraccountinfo._email;
    }

    public void GetDisplayName()
    {
        

        PlayFabClientAPI.GetPlayerProfile(new GetPlayerProfileRequest()
        {

            PlayFabId = LoginRegister._playerID
        },
        Result =>
        {
       
           _displayName.text = Result.PlayerProfile.DisplayName;
            Debug.Log("Kullanýcý Verileri Çekildi");
           

        },
        Error =>
        {
            Debug.Log("Kullanýcý Verileri Çekilemedi!");
        });
    }

  
    IEnumerator baslat()
    {
        yield return new WaitForSeconds(1f);
        url = url.ToString();
        WWW www = new WWW(url);
        yield return www;
        Debug.Log("Fotoðraf yüklendi!");
        img.sprite = Sprite.Create(www.texture, new Rect(0, 0, www.texture.width, www.texture.height), new Vector2(0, 0));
    }





    public void ImagePanel()
    {
        
        switch (_changeImagePanel.activeInHierarchy)
        {
            case true:
                _changeImagePanel.SetActive(false);
                break;
            default:
                _changeImagePanel.SetActive(true);
                break;
        }


    }
    public void NamePanel()
    {
        switch (_changeNamePanel.activeInHierarchy)
        {
            case true:
                _changeNamePanel.SetActive(false);
                break;
            default:
                _changeNamePanel.SetActive(true);
                break;
        }
    }




    public void ChangeDisplayName()
    {
        PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest()
        {
            DisplayName = _newDisplayname.text

        },
        Result =>
        {
            Debug.Log("DisplayName Deðiþtirildi.");
            Register_Async = true;

        },
        Error =>
        {
            Debug.Log("Hatalý DisplayName!");
            Register_Async = false;
        }); ;
    }


    public void ChangeDisplayNameOnClick()
    {

        StartCoroutine(AsyncControl());
    }


    IEnumerator AsyncControl()
    {

        _infoText.text = "DisplayName Deðiþtiriliyor...";
        ChangeDisplayName();
        yield return new WaitUntil(() => Register_Async);
        _infoText.text = "DisplayName Deðiþtirildi.";
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);
    }



    public void ChangeAvatarImage1()
    {
        PlayFabClientAPI.UpdateAvatarUrl(new UpdateAvatarUrlRequest()
        {
            ImageUrl = "https://www.gravatar.com/userimage/221184294/5efccb3113f6021ef9ccb1af5be8d8de?size=120"

        },
        Result =>
        {
            Debug.Log("Avatar Image Deðiþtirildi");
            url = "https://www.gravatar.com/userimage/221184294/5efccb3113f6021ef9ccb1af5be8d8de?size=120";
            StartCoroutine(baslat());
        },
        Error =>
        {
            Debug.Log("Hatalý Image!");

        });
    }
    public void ChangeAvatarImage2()
    {
        PlayFabClientAPI.UpdateAvatarUrl(new UpdateAvatarUrlRequest()
        {
            ImageUrl = "https://www.gravatar.com/userimage/221184294/5a2f502b451a44bb7f28f837c1921b8b?size=120"

        },
        Result =>
        {
            Debug.Log("Avatar Image Deðiþtirildi");
            url = "https://www.gravatar.com/userimage/221184294/5a2f502b451a44bb7f28f837c1921b8b?size=120";
            StartCoroutine(baslat());

        },
        Error =>
        {
            Debug.Log("Hatalý Image!");

        });
    }
    public void ChangeAvatarImage3()
    {
        PlayFabClientAPI.UpdateAvatarUrl(new UpdateAvatarUrlRequest()
        {
            ImageUrl = "https://www.gravatar.com/userimage/221184294/427162642c90743fb51fea752c9b5011?size=120"

        },
        Result =>
        {
            Debug.Log("Avatar Image Deðiþtirildi");
            url = "https://www.gravatar.com/userimage/221184294/427162642c90743fb51fea752c9b5011?size=120";
            StartCoroutine(baslat());

        },
        Error =>
        {
            Debug.Log("Hatalý Image!");

        });
    }


    public void Startgame()
    {
        SceneManager.LoadScene(2);
    }
}
