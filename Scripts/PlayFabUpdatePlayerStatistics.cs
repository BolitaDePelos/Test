using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
public class PlayFabUpdatePlayerStatistics 
{
    public void UpdatePlayerStatistics(string leaderboardName, int score) {

        var request = new UpdatePlayerStatisticsRequest
        {

            Statistics = new List<StatisticUpdate> {
         new StatisticUpdate{
         StatisticName=leaderboardName,
         Value=score
         }
         },
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnUpdatePlayerStatisticSuccess,
            OnUpdatePlayerStatisticsFailure);
    }
    private void OnUpdatePlayerStatisticsFailure(PlayFabError error) {
        Debug.LogError("Error");
    }
    private void OnUpdatePlayerStatisticSuccess(UpdatePlayerStatisticsResult result) {
        Debug.Log("Updated");

    }
}
