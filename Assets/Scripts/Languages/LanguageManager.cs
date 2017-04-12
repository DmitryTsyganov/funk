using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

public class LanguageManager
{
    private static Language language = null;
    private static JSONObject languageDynamic = null;

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

    public static JSONObject getLanguageDynamic()
    {
        return languageDynamic;
    }

    public static void setLanguage(string languageName)
    {
        languageDynamic = new JSONObject(Resources.Load<TextAsset>(
            ScenesParameters.LanguagesDynamicDirectory + '/' + languageName).text);
        var text = Resources.Load(ScenesParameters.LanguagesDirectory + '/' + languageName) as TextAsset;
        Stream s = new MemoryStream(text.bytes);
        BinaryReader br = new BinaryReader(s);
        Saver.savePreferedLanguage(languageName);

        language = (Language)formatter.Deserialize(br.BaseStream);
    }

    public static void setLanguageIfNotAlready()
    {
        if (language != null) return;

        string savedLanguage = Saver.getPreferedLanguage();

        if (!String.IsNullOrEmpty(savedLanguage))
        {
            setLanguage(savedLanguage);
        }
    }
}
