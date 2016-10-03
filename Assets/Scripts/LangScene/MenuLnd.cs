using UnityEngine;
using UnityEngine.UI;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

public class MenuLnd : MonoBehaviour {

	/*public Text Menu;
	public Text Linear;
	public Text Power;
	public Text Root;
	public Text Exponental;
	public Text Hyperbolic;
	public Text Logarithm;
	public Text Mixed;
	public Text Polinomial;
	public Text Special;
	public Text Trigonometric;


	void Start(){
		MenuScene g = Parse ();
		Menu.text = g.Menu;
		Linear.text = g.Linear;
		Power.text = g.Power;
		Root.text = g.Root;
		Exponental.text = g.Exponential;
		Hyperbolic.text = g.Hyperbolic;
		Logarithm.text = g.Logarithm;
		Mixed.text = g.Mixed;
		Polinomial.text = g.Polinomial;
		Special.text = g.Special;
		Trigonometric.text = g.Trigonometric;

	}

	private MenuScene Parse(){
		XmlSerializer serializer = new XmlSerializer (typeof(MenuScene));
		TextAsset textAsset = (TextAsset)Resources.Load(
			"Lang/"+GameParametrs.Lang+
			'/' + "MenuScene");

		System.IO.StringReader stringReader = new System.IO.StringReader(textAsset.text);
		System.Xml.XmlReader reader = System.Xml.XmlReader.Create(stringReader);
		return (MenuScene)serializer.Deserialize (reader);
	}*/
}
