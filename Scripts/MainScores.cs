using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using PlayFab;
using PlayFab.ClientModels;

public class MainScores : MonoBehaviour
{
    [SerializeField] private Button leadboard;
    [SerializeField] private Button aroundPLayer;
    [SerializeField] private Button playerScore;
    [SerializeField] private Button addPlayerScore;
    [SerializeField] private TMP_Text results;

    private const string Leaderboard = "LeaderboardTest";

    private string playerID;

    private PlayfabLogin playFabLogin;
    private PlayFabUpdatePlayerStatistics playFabPlayerStatistics;
    private PlayFabGetLeaderboardAroundPlayer playFabLeaderboardAroundPlayer;
    private PlayFabGetLeaderboard playFabLeaderboard;

    // Start is called before the first frame update
    void Start()
    {
        AddListeners();
        CreatePlayFabServices();
        DoLogin();
    }
    private void CreatePlayFabServices(){
        playFabLogin = new PlayfabLogin();
        //playFabLogin.OnSuccess += playerID => playerId;

        playFabPlayerStatistics = new PlayFabUpdatePlayerStatistics();
        playFabLeaderboardAroundPlayer = new PlayFabGetLeaderboardAroundPlayer();
        playFabLeaderboard = new PlayFabGetLeaderboard();
    }
    private void DoLogin(){}
    // Update is called once per frame
    private void AddListeners() {
        //Leaderboard.onClick.AddListener(OnGetLeaderboardButtonPressed);
      //  aroundPLayer.onClick.AddListener(OnGetLeaderboardAroundPlayerButtonPressed);
        //playerScore.onClick.AddListener(OnGetPlayerScoreButtonPressed);
       // addPlayerScore.onClick.AddListener(OnGetAddPlayerScoreButtonPressed);
    
    }
}
