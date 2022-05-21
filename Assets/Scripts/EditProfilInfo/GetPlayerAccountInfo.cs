using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class GetPlayerAccountInfo
{
    public string _displayName, _avatarUrl, _playfabID, _email;

    public DateTime _createdDate;
    public void GetAccountInfoo()
    {

        PlayFabClientAPI.GetAccountInfo(new GetAccountInfoRequest()
        {
            PlayFabId = LoginRegister._playerID

       },
        Result =>
        {
          //  _displayName = Result.AccountInfo.TitleInfo.DisplayName;
            _avatarUrl = Result.AccountInfo.TitleInfo.AvatarUrl;
            _createdDate = Result.AccountInfo.TitleInfo.Created.Date;
            _playfabID = Result.AccountInfo.PlayFabId;
            _email = Result.AccountInfo.PrivateInfo.Email;
            Debug.Log("Veriler Çekildi");

        },
        Error =>
        {

        }) ;
    }
}