using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CongratilationsScreen : MonoBehaviour
{

    public GameObject CongratilationsText;
    public GameObject BackText;
    public Image CongratilationsImage;

    private const float ButtonSizeCoefficient = 0.5f;
    private const float ButtonYCoefficient = 0.58f;
    protected float buttonSizeCoefficient;
    protected float buttonYCoefficient;

	// Use this for initialization
	void Awake()
	{
	    buttonSizeCoefficient = ButtonSizeCoefficient;
	    buttonYCoefficient = ButtonYCoefficient;
	    print(buttonYCoefficient);
	    setLanguage();
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void AddButton(GameObject buttonOriginal)
    {
        var button = Instantiate(buttonOriginal);
        var item = button.transform.Find("BallShopItem");
        item.gameObject.GetComponent<Button>().onClick = new Button.ButtonClickedEvent();
        var handler = button.transform.Find("BallShopItem").gameObject.GetComponent<BallShopItemHandler>();
        handler.setSelectedState();
        print(handler.Name);
        handler.ObjNameText.text = LanguageManager.getLanguageDynamic()[handler.Name].str;
        var size = CongratilationsImage.sprite.bounds.size;
        print("size "+size);
        button.transform.parent = CongratilationsImage.transform.parent;
        var newSize = CongratilationsImage.GetComponent<RectTransform>().sizeDelta * buttonSizeCoefficient;
        print("newsize " + newSize);
        var rect = button.GetComponent<RectTransform>();
        //rect.position = newSize;
        button.transform.position = new Vector3(Screen.width * 0.5f, Screen.height * buttonYCoefficient, 0);
        rect.sizeDelta = newSize * 0.5f;
        button.transform.localScale = Vector3.one;
        item.Find("NameText").gameObject.GetComponent<Text>().color = Color.black;
        Destroy(item.Find("LockedImage").gameObject);
        //handler.setBoughtState();
        //item.Find("LockedImage").gameObject.SetActive(false);
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
