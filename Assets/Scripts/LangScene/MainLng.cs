using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

public class MainLng : MonoBehaviour {

	/*public Text Play;
	public Text Menu;
	public Text MoreStars;
    public Text Options;
    public Text Shop;


	void Start() {
		MainScene g = Parse ();
		Play.text = g.Play;
		Menu.text = g.Menu;
		Options.text = g.Options;
        Shop.text = g.Shop;
	}

	private MainScene Parse(){
		XmlSerializer serializer = new XmlSerializer (typeof(MainScene));
		TextAsset textAsset = (TextAsset)Resources.Load(
			"Lang"+'/'+GameParametrs.Lang+
			'/' + "MainScene");

		System.IO.StringReader stringReader = new System.IO.StringReader(textAsset.text);
		System.Xml.XmlReader reader = System.Xml.XmlReader.Create(stringReader);
		return (MainScene)serializer.Deserialize (reader);
	}*/
}
