using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelElement : MonoBehaviour {

	public Sprite Lock;
	public Sprite Unlock;
	public int Index{ get; private set;}
	public Text infa;

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
        }
	    else
        {
            GetComponent<Image>().sprite = Lock;
	        infa.gameObject.SetActive(false);
	    }
        
	}
}
