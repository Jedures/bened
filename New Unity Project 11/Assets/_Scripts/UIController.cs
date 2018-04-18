//using AppodealAds.Unity.Api;
using UnityEngine;

public class UIController : MonoBehaviour
{

    public void Start()
    {
        /*string appKey = " f2ed0b69fb371eaeb8637b588bb6b242eefef7ae0338f79c";
        Appodeal.disableLocationPermissionCheck();
        Appodeal.initialize(appKey, Appodeal.INTERSTITIAL | Appodeal.NON_SKIPPABLE_VIDEO);
        DontDestroyOnLoad(gameObject);*/
    }

    public void PlayButtonClick()
    {
     //   Appodeal.show(Appodeal.INTERSTITIAL);
        Loading.Load(LoadingScene.LoadLevel);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
