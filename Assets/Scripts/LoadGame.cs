﻿using UnityEngine;
using System.Collections;

public class LoadGame : MonoBehaviour {

    public GameObject loadingImage;

	public void LoadScene(int level)
    {
        loadingImage.SetActive(true);
        Application.LoadLevel(level);
    }
}
