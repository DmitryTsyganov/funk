using System.Xml.Serialization;
using System.Xml;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class XMLParser {

    XmlSerializer serializer = new XmlSerializer(typeof(FullLevel));



    public object parse(string filename)
    {
        TextAsset textAsset = (TextAsset)Resources.Load(
                                            ScenesParameters.LevelsDirectory +
                                            '/' + ScenesParameters.Section +
                                             '/' + filename);
        
        System.IO.StringReader stringReader = new System.IO.StringReader(textAsset.text);
        System.Xml.XmlReader reader = System.Xml.XmlReader.Create(stringReader);

        return (FullLevel)serializer.Deserialize(reader);
    }

    public void makeLevel(object level)
    {
        var serializationFile = Path.Combine(Directory.GetCurrentDirectory(),
                                            "Assets"
                                            + Path.DirectorySeparatorChar +
                                            "Resources" + Path.DirectorySeparatorChar +
                                            ScenesParameters.LevelsDirectory + Path.DirectorySeparatorChar 
                                            + ScenesParameters.Section + 
                                            Path.DirectorySeparatorChar + ScenesParameters.LevelName 
                                            + ScenesParameters.LevelsNumber + ".xml");

        using (var writer = XmlWriter.Create(serializationFile))
        {
            serializer.Serialize(writer, level);
        }
    }

    public void makeLevelFromCurrentState()
    {
        var balls = GameObject.FindGameObjectsWithTag("Ball");

		var baskets = GameObject.FindGameObjectsWithTag("Basket");

        var triangleObsticles = GameObject.FindGameObjectsWithTag("TriangleObsticle");

        var stars = GameObject.FindGameObjectsWithTag("Star");

        GameObject inputFieldGo = GameObject.Find("RequiredInputField");
        var inputFieldCo = inputFieldGo.GetComponent<InputField>();

        GameObject inputFieldDefGo = GameObject.Find("DefaultInputField");
        var inputFieldDefCo = inputFieldDefGo.GetComponent<InputField>();

		string hintString = GameObject.Find ("hintField").GetComponent<InputField>().text;

        if (string.IsNullOrEmpty(inputFieldDefCo.text))
        {
            Debug.Log("Please, specify default function\n");
            return;
        }

        if (string.IsNullOrEmpty(inputFieldCo.text))
        {
            Debug.Log("Please, specify required function\n");
            return;
        }

        if (balls.Length > 0 && baskets.Length > 0)
        {
            ++ScenesParameters.LevelsNumber;

            FullLevel level = new FullLevel(balls,baskets,triangleObsticles, stars, inputFieldCo.text, inputFieldDefCo.text, hintString);
            makeLevel(level);

            var configPass = Path.Combine(Directory.GetCurrentDirectory(),
                                            "Assets" + Path.DirectorySeparatorChar +
                                            "Resources"
                                            + Path.DirectorySeparatorChar +
                                            ScenesParameters.LevelsDirectory 
                                            + Path.DirectorySeparatorChar
                                            + ScenesParameters.Section +
                                            Path.DirectorySeparatorChar + "config.txt");

            FileStream fcreate = File.Open(configPass, FileMode.Create);
            var stream = new StreamWriter(fcreate);
            stream.WriteLine(ScenesParameters.LevelsNumber);
            stream.Close();
            fcreate.Close();
            Debug.Log("Level " + ScenesParameters.LevelsNumber + " created successfully.\n");
        } else
        {
            Debug.Log("Ball and Basket are required");
        }
    }
}
