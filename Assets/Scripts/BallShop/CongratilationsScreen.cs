using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CongratilationsScreen : MonoBehaviour
{

    public GameObject CongratilationsText;
    public GameObject BackText;
    public Image CongratilationsImage;

	// Use this for initialization
	void Start () {
	    setLanguage();
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void AddButton(GameObject buttonOriginal)
    {
        var button = Instantiate(buttonOriginal);
        var size = CongratilationsImage.sprite.bounds.size;
        print("size "+size);
        button.transform.parent = CongratilationsImage.transform.parent;
        var newSize = CongratilationsImage.GetComponent<RectTransform>().sizeDelta/2;
        print("newsize " + newSize);
        var rect = button.GetComponent<RectTransform>();
        //rect.position = newSize;
        button.transform.position = new Vector3(Screen.width/2, Screen.height*0.54f, 0);
        rect.sizeDelta = newSize/2;
        button.transform.Find("NameText").gameObject.GetComponent<Text>().color = Color.black;
        
    }

    public void Back()
    {
        Destroy(gameObject);
    }

    private void setLanguage()
    {
        LanguageManager.setLanguageIfNotAlready();
        LanguageManager.setText(CongratilationsText, LanguageManager.getLanguage().congratilation_new_ball);
        LanguageManager.setText(BackText, LanguageManager.getLanguage().back);
    }
}
