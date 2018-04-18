using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Public Variables

    public static GameManager Instance = null;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }

    #endregion

    #region Public Methods

    public void PlayerDeath(GameObject player)
    {
        Destroy(player);

        // spawn new camera and show UI about death for notify user
    }

    #endregion
}
