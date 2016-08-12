//using System.Xml.Serialization;
//using System.Xml;
//using System.IO;
//using UnityEngine;
//using UnityEngine.UI;
//using Mono.Xml;

//public class LangCreater : MonoBehaviour {

//	public InputField Country;

//	//Main
//	public InputField Play;
//	public InputField Menu;
//	public InputField Lang;

//	//Menu
//	public InputField Linear;
//	public InputField Power;
//	public InputField Root;
//	public InputField Exponental;
//	public InputField Hyperbolic;
//	public InputField Logarithm;
//	public InputField Mixed;
//	public InputField Polinomial;
//	public InputField Special;
//	public InputField Trigonometric;

//	//Game
//	public InputField Run;
//	public InputField  Reset;
//	public InputField  Yes;
//	public InputField  No;
//	public InputField  Add;
//	public InputField  Thanks;
//	public InputField  Hint;
//	public InputField  Answer;
//	public InputField  Hint1;
//	public InputField  Hint2;
//	public InputField  Hint3;

//	//Shop
//	public InputField Continue;
//	public InputField Buy;

//	public void CreateCoutry(){

//		MenuScene menuScene = new MenuScene (Menu.text, Linear.text, Power.text, Root.text, Exponental.text, Hyperbolic.text, Logarithm.text, Mixed.text, Polinomial.text, Special.text, Trigonometric.text);
//		GameScene gameScene = new GameScene (Run.text, Menu.text, Reset.text, Yes.text, No.text, Add.text, Thanks.text, Hint.text, Answer.text, Hint1.text, Hint2.text, Hint3.text);
//		ShopScene shopScene = new ShopScene (Continue.text, Buy.text);
//		SerializeMenu (menuScene);
		
//		SerializeGame (gameScene);
//		SerializeShop (shopScene);
//		print (Country.text + " язык создан!");
//	}

//	void SerializeMain(MainScene g){
//		XmlSerializer serializer = new XmlSerializer(typeof(MainScene));
//		var serializationFile = Path.Combine (Directory.GetCurrentDirectory(),"Assets"
//		                        + Path.DirectorySeparatorChar +
//		                        "Resources" + Path.DirectorySeparatorChar +
//		                        "Lang" + Path.DirectorySeparatorChar +
//			Country.text + Path.DirectorySeparatorChar +
//		                        "MainScene.xml");
//		using (var writer = XmlWriter.Create (serializationFile)) {
//			serializer.Serialize (writer, g);
//		}

//	}
//	void SerializeMenu(MenuScene g){
//		XmlSerializer serializer = new XmlSerializer(typeof(MenuScene));
//		var serializationFile = Path.Combine (Directory.GetCurrentDirectory(),"Assets"
//			+ Path.DirectorySeparatorChar +
//			"Resources" + Path.DirectorySeparatorChar +
//			"Lang" + Path.DirectorySeparatorChar +
//			Country.text + Path.DirectorySeparatorChar +
//			"MenuScene.xml");
//		using (var writer = XmlWriter.Create (serializationFile)) {
//			serializer.Serialize (writer, g);
//		}

//	}
//	void SerializeGame(GameScene g){
//		XmlSerializer serializer = new XmlSerializer(typeof(GameScene));
//		var serializationFile = Path.Combine (Directory.GetCurrentDirectory(),"Assets"
//			+ Path.DirectorySeparatorChar +
//			"Resources" + Path.DirectorySeparatorChar +
//			"Lang" + Path.DirectorySeparatorChar +
//			Country.text + Path.DirectorySeparatorChar +
//			"GameScene.xml");
//		using (var writer = XmlWriter.Create (serializationFile)) {
//			serializer.Serialize (writer, g);
//		}

//	}
//	void SerializeShop(ShopScene g){
//		XmlSerializer serializer = new XmlSerializer(typeof(ShopScene));
//		var serializationFile = Path.Combine (Directory.GetCurrentDirectory(),"Assets"
//			+ Path.DirectorySeparatorChar +
//			"Resources" + Path.DirectorySeparatorChar +
//			"Lang" + Path.DirectorySeparatorChar +
//			Country.text + Path.DirectorySeparatorChar +
//			"ShopScene.xml");
//		using (var writer = XmlWriter.Create (serializationFile)) {
//			serializer.Serialize (writer, g);
//		}

//	}
//}
