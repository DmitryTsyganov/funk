using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;
using System.Xml;


public class LanguageCreatorMeta : MonoBehaviour
{
    public static void saveXmlLanguageFile(Language language, string name)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Language));

        var serializationFile = Path.Combine(Directory.GetCurrentDirectory(),
                                           "Assets"
                                           + Path.DirectorySeparatorChar +
                                           "Resources" + Path.DirectorySeparatorChar +
                                           ScenesParameters.LanguagesDirectory + Path.DirectorySeparatorChar +
                                           Path.DirectorySeparatorChar
                                           + name + ".xml");
        StreamReader stream = new StreamReader(serializationFile);
        serializer.Serialize(stream.BaseStream, language);
        stream.Close();
    }

    public static void saveBinaryLangaugeInFile(Language language, string name)
    {
        var serializationFile = Path.Combine(Directory.GetCurrentDirectory(),
                                           "Assets"
                                           + Path.DirectorySeparatorChar +
                                           "Resources" + Path.DirectorySeparatorChar +
                                           ScenesParameters.LanguagesDirectory + Path.DirectorySeparatorChar +
                                           Path.DirectorySeparatorChar
                                           + name + ".bytes");

        var file = File.Open(serializationFile, FileMode.OpenOrCreate);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(file, language);
    }

    public static void createEnglish()
    {
        var _language = new Language();
        _language.back = "Back";
        _language.buy_hint = "Buy a hint for {0} stars";
        _language.choose_ball = "Tap to choose a ball";
        _language.completed = "Completed!";
        _language.developer = "nochgames presents";
        _language.exponental = "Exponental";
        _language.hyperbolic = "Hyperbolic";
        _language.linear = "Linear";
        _language.logarithm = "Logarithm";
        _language.main_screen = "Main Screen";
        _language.mixed = "Mixed";
        _language.no = "No";
        _language.options = "Options";
        _language.play = "PLAY!";
        _language.polinomial = "Polinomial";
        _language.power = "Power";
        _language.reset = "Reset";
        _language.root = "Root";
        _language.run = "Run";
        _language.sections_menu = "Sections Menu";
        _language.shop = "Shop";
        _language.special = "Special";
        _language.tap_to_continue = "Tap to continue";
        _language.thanks = "Thanks!";
        _language.tip1 = "";
        _language.tip2 = "";
        _language.tip3 = "";
        _language.tip4 = "";
        _language.trigonometric = "Trigonometric";
        _language.yes = "Yes";
        _language.stars = "stars";
        _language.delete_progress = "Delete Progress";
        _language.add = "Add";
        _language.name_1 = "Arthur Khusainov";
        _language.name_2 = "Dmitry Tsyganov";
        _language.name_3 = "Sergey Landyrev";
        _language.position_1 = "Artwork & Idea";
        _language.position_2 = "Lead Dev";
        _language.position_3 = "Jr. Dev";
        saveBinaryLangaugeInFile(_language, "Eng");
    }

    public static void createRussian()
    {
        var _language = new Language();
        _language.back = "Назад";
        _language.buy_hint = "Buy a hint for {0} stars";
        _language.choose_ball = "Tap to choose a ball";
        _language.completed = "Completed!";
        _language.developer = "nochgames presents";
        _language.exponental = "Exponental";
        _language.hyperbolic = "Hyperbolic";
        _language.linear = "Linear";
        _language.logarithm = "Logarithm";
        _language.main_screen = "Main Screen";
        _language.mixed = "Mixed";
        _language.no = "No";
        _language.options = "Options";
        _language.play = "PLAY!";
        _language.polinomial = "Polinomial";
        _language.power = "Power";
        _language.reset = "Reset";
        _language.root = "Root";
        _language.run = "Run";
        _language.sections_menu = "Sections Menu";
        _language.shop = "Shop";
        _language.special = "Special";
        _language.tap_to_continue = "Tap to continue";
        _language.thanks = "Thanks!";
        _language.tip1 = "";
        _language.tip2 = "";
        _language.tip3 = "";
        _language.tip4 = "";
        _language.trigonometric = "Trigonometric";
        _language.yes = "Yes";
        _language.stars = "stars";
        _language.delete_progress = "Delete Progress";
        _language.add = "Add";
        _language.name_1 = "Arthur Khusainov";
        _language.name_2 = "Dmitry Tsyganov";
        _language.name_3 = "Sergey Landyrev";
        _language.position_1 = "Artwork & Idea";
        _language.position_2 = "Lead Dev";
        _language.position_3 = "Jr. Dev";
        saveBinaryLangaugeInFile(_language, "Rus");
    }

    public static Language readXml(string name)
    {
        string path = Application.persistentDataPath + '/' + name + ".xml";

        if (File.Exists(path))
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Language));
            var stream = new StreamReader(path, Encoding.GetEncoding(1251));
            Debug.Log(path);
            
            //stream.Close();
            return (Language)serializer.Deserialize(stream);
        }

        return null;
    }

    public static void transportFromDataToResources()
    {
        saveBinaryLangaugeInFile(readXml("Eng"), "Eng");
        saveBinaryLangaugeInFile(readXml("Rus"), "Rus");
        saveBinaryLangaugeInFile(readXml("Fr"), "Fr");
        saveBinaryLangaugeInFile(readXml("De"), "De");
        saveBinaryLangaugeInFile(readXml("Pl"), "Pl");
        saveBinaryLangaugeInFile(readXml("It"), "It");
        saveBinaryLangaugeInFile(readXml("Es"), "Es");
    }
}
