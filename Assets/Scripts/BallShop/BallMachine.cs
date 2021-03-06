﻿using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.Analytics;

public class BallMachine : InternetDependantHandler {

    public BallShop BallShop;
    public GameObject AnimationContainerStatic;
    public GameObject InfoText;
    public Image MachineImage;

    private SpriteRenderer rendererStatic;
    private Animator animator;
    private AudioSource source;

    private bool isActive = false;

    private const string ActiveString = "Active";

    private void OnEnable()
    {
        if (LanguageManager.getLanguage() != null)
        {
            setLanguage();
        }
        DoStart();
    }

    void Awake()
    {
        rendererStatic = AnimationContainerStatic.GetComponent<SpriteRenderer>();
        animator = AnimationContainerStatic.GetComponent<Animator>();
        source = GetComponent<AudioSource>();
        OnClick += delegate(object sender, EventArgs args) { ActivateBallMachine(); };
    }
 
	// Use this for initialization
	void Start () {
        InfoText.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        HandleCurrentState();
        if (BallShop.BallsToBuy == 0) Destroy(gameObject);
	}

    private void HandleCurrentState()
    {
        MachineImage.sprite = rendererStatic.sprite;
    }

    public void ActivateBallMachine()
    {
        isActive = true;
        animator.SetBool(ActiveString, true);
        StartCoroutine(WaitForAnimation());
        source.Play();
        Analytics.CustomEvent(AnalyticsParameters.BallMachineUsed);
    }

    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(2.5f);
        
        isActive = false;
        RewardedVideoUnityAdsManager.GetInstance().ShowRewardedAd(getBall);
        animator.SetBool(ActiveString, false);
    }

    private void getBall()
    {
        BallShop.getRandomBallForFree();
    }

    private void setLanguage()
    {
        LanguageManager.setLanguageIfNotAlready();
        LanguageManager.setText(InfoText, LanguageManager.getLanguage().ball_machine_help);
    }
}
