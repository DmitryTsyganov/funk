using UnityEngine;
using System.Collections;

public class DeleteProgress : MonoBehaviour {
	public void Delete(){
		PlayerPrefs.DeleteAll ();
        BallParametrs.setDefaultBall();
    }
}
