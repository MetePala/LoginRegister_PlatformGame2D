using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetPlayerDisplayName : MonoBehaviour
{
    [SerializeField] Text _displayName;

    private void Awake()
    {
       GetDisplayName();
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
            Debug.Log("Kullan�c� DisplayName �ekildi.");


        },
        Error =>
        {
            Debug.Log("Kullan�c� Verileri �ekilemedi!");
        });
    }
}
