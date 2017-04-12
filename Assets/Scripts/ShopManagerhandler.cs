using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManagerhandler : MonoBehaviour
{
    public GameObject BallShop;

    private static ShopManagerhandler _instance;

    private void Start()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnLevelFinishedLoading;
        OnLevelFinishedLoading(SceneManager.GetActiveScene(), LoadSceneMode.Single);
    }

    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 5 && !BallShop.activeSelf)
        {
            BallShop.SetActive(true);
        }
        if (scene.buildIndex != 5 && BallShop.activeSelf)
        {
            BallShop.SetActive(false);
        }
    }
}
