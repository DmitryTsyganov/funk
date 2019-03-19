using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPartNotificationText : MonoBehaviour {

	public GameObject NotificationText;
	private const uint JokesNumber = 3;
	private const uint DefaultTextTimes = DeleteRedPartNotification.MaxShowTimes - JokesNumber - 1;
	
	private void OnEnable()
	{
		setLanguage();
	}

	void setLanguage()
	{
		LanguageManager.setLanguageIfNotAlready();
		LanguageManager.setText(NotificationText, 
			getNotificationText((uint) Saver.redPartNotificationShown()));
	}

	string getNotificationText(uint shownTimes)
	{
		if (shownTimes <= DefaultTextTimes)
			return LanguageManager.getLanguage().red_part_warning;

		uint jokeNumber = shownTimes - DefaultTextTimes;
		Debug.Log("joke number " + jokeNumber);
		switch (jokeNumber)
		{
			case 1:
				Debug.Log(LanguageManager.getLanguage().red_part_warning_joke_1);
				return LanguageManager.getLanguage().red_part_warning_joke_1;
			case 2:
				Debug.Log(LanguageManager.getLanguage().red_part_warning_joke_2);
				return LanguageManager.getLanguage().red_part_warning_joke_2;
			case 3:
				Debug.Log(LanguageManager.getLanguage().red_part_warning_joke_3);
				return LanguageManager.getLanguage().red_part_warning_joke_3;
		}

		return "";
	}
}
