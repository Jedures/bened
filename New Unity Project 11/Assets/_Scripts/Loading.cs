using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum LoadingScene
{
    Main,
    LoadLevel,
    GameScene,
    Game2,
    Game3
}

public class Loading : MonoBehaviour
{
    public Text Progress; // REMAKE

    private static LoadingScene _nextScene { get; set; }

    private AsyncOperation async;

    public Slider LoadProgress;

    private void Start()
    {
        StartCoroutine(LoadAsync());
    }

    private void Update()
    {
        float progress = async.progress * 100;
        Progress.text = "Loading: " + progress.ToString() + "/100";
        LoadProgress.value = progress;
    }

    private IEnumerator LoadAsync()
    {
        string scene = "MainScene";

        if (_nextScene == LoadingScene.LoadLevel)
            scene = "GameScene";
        else if (_nextScene == LoadingScene.Game2)
            scene = "Level2";

        async = SceneManager.LoadSceneAsync(scene);

        yield return true;
    }

    public static void Load(LoadingScene scene)
    {
        _nextScene = scene;

        SceneManager.LoadScene("LoadingScene");
    }

    public void StartG()
    {
        Load(LoadingScene.LoadLevel);
    }


    public void Level2()
    {
        Load(LoadingScene.Game2);
    }

    public void Level3()
    {
        Load(LoadingScene.Game3);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void UI()
    {

    }
}