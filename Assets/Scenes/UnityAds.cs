using System;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
public class UnityAds : MonoBehaviour, IUnityAdsListener
{
    string Google_Play_Id = "3814525";
    string TestReward = "video";
    string RealReward = "rewardedVideo";

    public bool isTargetPlayStore;
    public bool isTestAd;

    private void Start()
    {
        Advertisement.AddListener(this);
        InitializeAdvertisment();
    }

    private void InitializeAdvertisment()
    {
        if(isTargetPlayStore)
        {
            Advertisement.Initialize(Google_Play_Id, isTestAd);
            return;
        }
        Advertisement.Initialize(Google_Play_Id, isTestAd);
    }
    public void PlayInterestitialAd()
    {
        if (!Advertisement.IsReady(TestReward))
            return;
        Advertisement.Show(TestReward);
    }

    public void PlaywRewardedVideoAd()
    {
        if (!Advertisement.IsReady(RealReward))
            return;
        Advertisement.Show(RealReward);
        
    }

    public void OnUnityAdsReady(string placementId)
    {
       throw new NotImplementedException();
    }

    public void OnUnityAdsDidError(string message)
    {
      throw new NotImplementedException();
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        throw new NotImplementedException();
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch(showResult)
        {
            case ShowResult.Finished:
                if(placementId==RealReward)
                {
                    GameObject.FindGameObjectWithTag("Coin").GetComponent<CoinScript>().AddCoin(50);
                }
                break;

        }
    }
}
