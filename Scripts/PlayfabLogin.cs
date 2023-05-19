using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
/*
[SerializeField]
public class InitialUserData {
    public int InitialSoftCurrency;
    public bool TestBool;
}

[SerializeField]
public class TestInfo {
    public bool isEnabled;
}

[SerializeField]
public class InitializedUser
{
    public bool isInitialized;
}
*/

public class PlayfabLogin
{
    public event Action<string> OnSuccess;

    public void Login()
    {
        if (string.IsNullOrEmpty(PlayFabSettings.staticSettings.TitleId))
        {
            /*
            Please change the titleId below to your own titleId from PlayFab Game Manager.
            If you have already set the value in the Editor Extensions, this can be skipped.
            */
            PlayFabSettings.staticSettings.TitleId = "42";
        }


#if UNITY_ANDROID
        var androidRequest = new LoginWithAndroidDeviceIDRequest
        {
            AndroidDeviceId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithAndroidDeviceID(androidRequest,OnLoginSuccess,OnLoginFailure);
#elif UNITY_IOS
        var iosRequest = new LoginWithIOSDeviceIDRequest
        {
            DeviceId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithIOSDeviceID(iosRequest, OnLoginSuccess, OnLoginFailure);
#else
        var request = new LoginWithCustomIDRequest { CustomId = "GettingStartedGuide", CreateAccount = true };
        PlayFabClientAPI.LoginWithCustomID(request, OnLoginSuccess, OnLoginFailure);
#endif
    }

    private void OnLoginSuccess(LoginResult result)
    {
        /*
        PlayFabClientAPI.GetUserData(new GetUserDataRequest { Keys = new List<string> { "IsInitialized" } }, resultCallback: dataResult =>
           {
               if (!dataResult.Data.ContainsKey("IsInitialized")) {
                   InitializeUser();
               }
               
           }, errorCallback: error => { });
        */
        Debug.Log("Congratulations, you made your first successful API call!");
        OnSuccess?.Invoke(result.PlayFabId);

    }
    /*
    private void InitializeUser()
    {

        GetTitleDataRequest request = new GetTitleDataRequest
        {
            Keys = new List<string>() { "InitialUserData" }
        };
        PlayFabClientAPI.GetTitleData(request, resultCallback: dataResult =>
        {
            var data = dataResult.Data["InitialUserData"];
            var initialUserData = JsonUtility.FromJson<InitialUserData>(data);

            PlayFabClientAPI.AddUserVirtualCurrency(
                new AddUserVirtualCurrencyRequest
                { Amount = initialUserData.InitialSoftCurrency, VirtualCurrency = "SC" },
                resultCallback: result => { }, 
                errorCallback: error => { });

            PlayFabClientAPI.UpdateUserData(new UpdateUserDataRequest
            {
                Data = new Dictionary<string, string> {
                { "Test", JsonUtility.ToJson(new TestInfo{isEnabled=initialUserData.TestBool } )},
                { "IsInitialized", JsonUtility.ToJson(new InitializedUser{isInitialized=true })}
            }
            }, resultCallback: result => { }, errorCallback: error => { });
        },errorCallback: error => { });        //Debug.Log(message: dataResult.Data.ContainsKey("IsInitialized"));
    }*/
    private void OnLoginFailure(PlayFabError error)
    {
        Debug.LogWarning("Something went wrong with your first API call.  :(");
        Debug.LogError("Here's some debug information:");
        Debug.LogError(error.GenerateErrorReport());
    }


  
}

