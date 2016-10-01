using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelElement : MonoBehaviour {

	public Sprite Lock;
	public Sprite Unlock;
	public int Index{ get; private set;}
	public Text infa;
    public GameObject[] Stars;

	void Start(){
		//GetComponent<Image>().sprite = Saver.isLevelPlayable(Index) ? Unlock : Lock;
	}
		

	public void SetLevelNumber(){
		if(Saver.isLevelPlayable (Index)){
		    ScenesParameters.CurrentLevel = Index;
			SceneManager.LoadScene(3);
		}
	}
	public void SetLevelIndex(int index)
	{
        Index = index;

        if (Saver.isLevelPlayable(index))
        {
            GetComponent<Image>().sprite = Unlock;
            infa.text = index.ToString();

            if (!Saver.isLevelCompletedWithStars(index) && !Saver.isLevelComplete(index))
            {
                for (int i = 0; i < Stars.Length; ++i)
                {
                    Stars[i].SetActive(false);
                }
            } else if (Saver.isLevelCompletedWithStars(index))
            {
                for (int i = Saver.getStarsCollectedOnLevel(index); i < Stars.Length; ++i)
                {
                    Stars[i].GetComponent<Image>().color = Color.black;
                }
            }
        }
	    else
        {
            GetComponent<Image>().sprite = Lock;
	        infa.gameObject.SetActive(false);
	    }
        
	}
}
