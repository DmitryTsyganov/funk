using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class DeleteRedPartNotification : MonoBehaviour
{
	public GameObject Notification;
	public const uint MaxShowTimes = 8;

	public void RedPartDeletingAttempt()
	{
		if (Notification.activeSelf || Saver.redPartNotificationShown() >= MaxShowTimes)
			return;
	
		Notification.SetActive(true);
		Saver.showRedPartNotification();
	}
}
