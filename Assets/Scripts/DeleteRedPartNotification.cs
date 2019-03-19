using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DeleteRedPartNotification : MonoBehaviour
{
	public GameObject NotificationText;
	public GameObject Notification;
	private const int MaxShowTimes = 5;
	
	// Use this for initialization
	void Start () {
		setLanguage();
	}

	public void RedPartDeletingAttempt()
	{
		if (Notification.activeSelf || Saver.redPartNotificationShown() >= MaxShowTimes)
			return;
		
		Notification.SetActive(true);
		Saver.showRedPartNotification();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void setLanguage()
	{
		LanguageManager.setLanguageIfNotAlready();
		LanguageManager.setText(NotificationText, LanguageManager.getLanguage().red_part_warning);
	}
}
