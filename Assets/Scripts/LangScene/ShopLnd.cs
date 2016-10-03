using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

public class ShopLnd : MonoBehaviour {

	/*public Text Continue;
	public Text Buy;

	void Start () {
		ShopScene g = Parse ();
		Continue.text = g.Continue;
		Buy.text = g.Buy;
	}
	
	private ShopScene Parse(){
		XmlSerializer serializer = new XmlSerializer (typeof(ShopScene));
		TextAsset textAsset = (TextAsset)Resources.Load(
			"Lang/"+GameParametrs.Lang+
			'/' + "ShopScene");

		System.IO.StringReader stringReader = new System.IO.StringReader(textAsset.text);
		System.Xml.XmlReader reader = System.Xml.XmlReader.Create(stringReader);
		return (ShopScene)serializer.Deserialize (reader);
	}*/
}
