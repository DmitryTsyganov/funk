using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class LanguageManager
{
    private static Language language = null;

    static BinaryFormatter formatter = new BinaryFormatter();

    public static bool setText(string goName, string text)
    {
        var go = GameObject.Find(goName);
        return setText(go, text);
    }

    public static bool setText(GameObject go, string text)
    {
        if (go != null)
        {
            go.GetComponent<Text>().text = text;
            return true;
        }
        else
        {
            return false;
        }
    }

    public static Language getLanguage()
    {
        return language;
    }

    public static void setLanguage(string languageName)
    {
        var text = Resources.Load(ScenesParameters.LanguagesDirectory + '/' + languageName) as TextAsset;
        Stream s = new MemoryStream(text.bytes);
        BinaryReader br = new BinaryReader(s);

        language = (Language)formatter.Deserialize(br.BaseStream);
    }

    public static void setLanguageIfNotAlready()
    {
        if (language != null) return;

        string savedLanguage = Saver.getPreferedLanguage();

        if (savedLanguage != null)
        {
            setLanguage(savedLanguage);
        }
        else
        {
            setLanguage("Eng");
        }
    }
}
