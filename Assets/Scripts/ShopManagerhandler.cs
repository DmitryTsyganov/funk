using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManagerhandler : MonoBehaviour
{
    public GameObject BallShop;

    private static ShopManagerhandler _instance;
    private static BallShop _ballShop;

    private void Awake()
    {
        if (_instance != null)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
        var shopCanvas = transform.Find("ShopCanvas");
        shopCanvas.gameObject.SetActive(false);
        shopCanvas.gameObject.SetActive(true);
        _ballShop = shopCanvas.GetComponent<BallShop>();
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

    public static ShopManagerhandler GetInstance()
    {
        return _instance;
    }

    public static BallShop GetBallShop()
    {
        return _ballShop;
    }
}
