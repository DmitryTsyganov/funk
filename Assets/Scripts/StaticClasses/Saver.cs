using System;
using UnityEngine;
using System.Collections;

public class Saver : MonoBehaviour
{
    private static string preferedLanguage = "pref_language";

    private const string sawTraining = "saw_training";
    private const string sawBuyFirstBall = "saw_first_ball";
    private const string hintSave = "hint_";
    private const string isBallBoughtKey = "Buyed";
    private const string selectedBall = "sb";
    private const string addons = "addons";
    private const string rated = "rated";
    private const char addonsSeparator = ' ';
    private const string soundOn = "sound";
    private const string sectionComplete = "_complete";
    private const string redPartNotification = "red_part_shown";

    private static string getLevelName(int num = -1)
    {
        num = num < 0 ? ScenesParameters.CurrentLevel : num;
        return "level_" + ScenesParameters.Section + "_" + num;
    }
    private static string getLevelCompletedName(int num = -1)
    {
        return getLevelName(num) + "_comleted";
    }
    private static string getLevelCompletedWithStarsName(int num = -1)
    {
        return getLevelName(num) + "_comleted_stars";
    }
    public static bool getLevelComplete(int num = -1)
    {
        return PlayerPrefs.GetInt(getLevelCompletedName(num), 0) == 1;
    }
    public static void setLevelComplete(int num = -1)
    {
        PlayerPrefs.SetInt(getLevelCompletedName(num), 1);
    }

    private static string getSectionName()
    {
        return "section_" + ScenesParameters.Section;
    }
    public static int getSectionLevelsComplete()
    {
        return PlayerPrefs.GetInt(getSectionName(), 0);
    }
    private static void setSectionLevelsComplete(int c)
    {
        PlayerPrefs.SetInt(getSectionName(), c);
    }

    public static void levelComplete()
    {
        if (!getLevelComplete()) {
            setSectionLevelsComplete(getSectionLevelsComplete() + 1);
        }

        setLevelComplete();
    }
    public static bool isLevelComplete(int num)
    {
        return getLevelComplete(num);
    }
    public static bool isLevelPlayable(int num)
    {
        return num == 1 || getLevelComplete(num - 1) || isLevelCompletedWithStars(num - 1);
    }

    public static void savePreferedLanguage(int langugeNumber)
    {
        PlayerPrefs.SetInt(preferedLanguage, langugeNumber);
    }

    public static void savePreferedLanguage(string language)
    {
        PlayerPrefs.SetString(preferedLanguage, language);
    }

    public static string getPreferedLanguage()
    {
        return PlayerPrefs.GetString(preferedLanguage, null);
    }

    public static void dontShowTraining()
    {
        PlayerPrefs.SetInt(sawTraining, 1);
    }

    public static int hasShownTraining()
    {
        return PlayerPrefs.GetInt(sawTraining, 0);
    }

    public static void dontShowFirstBall()
    {
        PlayerPrefs.SetInt(sawBuyFirstBall, 1);
    }

    public static bool sawFirstBall()
    {
        return PlayerPrefs.GetInt(sawBuyFirstBall, 0) == 1;
    }

    private static string getHintString()
    {
        return hintSave + ScenesParameters.Section + '_' + ScenesParameters.CurrentLevel;
    }

    public static void saveHint()
    {
        if (isHintBought() != 1)
        {
            PlayerPrefs.SetInt(getHintString(), 1);
        }
    }

    public static int isHintBought()
    {
        return PlayerPrefs.GetInt(getHintString(), 0);
    }

    public static void saveCompletedLevelWithStars(int starsCount)
    {
        PlayerPrefs.SetInt(getLevelCompletedWithStarsName(), starsCount);
    }

    public static bool isLevelCompletedWithStars(int num = -1)
    {
        return getStarsCollectedOnLevel(num) != -1;
    }

    public static int getStarsCollectedOnLevel(int num = -1)
    {
        return PlayerPrefs.GetInt(getLevelCompletedWithStarsName(num), -1);
    }

    public static void buyBall(string name)
    {
        PlayerPrefs.SetString(name, isBallBoughtKey);
    }

    public static bool isBallBought(string name)
    {
        return PlayerPrefs.GetString(name) == isBallBoughtKey;
    }

    public static void saveBallSelection(string ball)
    {
        PlayerPrefs.SetString(selectedBall, ball);
    }

    public static string getSavedBall()
    {
        return PlayerPrefs.GetString(selectedBall, null);
    }

    public static bool isBallSelectionSaved()
    {
        return PlayerPrefs.GetString(selectedBall, string.Empty) == string.Empty;
    }

    public static string[] getChosenAddons()
    {
        string addonsString = PlayerPrefs.GetString(addons, string.Empty);
        return addonsString.Split(addonsSeparator);
    }

    public static void addChosenAddon(string addon)
    {
        string addonsString = PlayerPrefs.GetString(addons, string.Empty);
        if (!addons.Contains(addon))
            PlayerPrefs.SetString(addons, addonsString + addon + addonsSeparator);
    }

    public static void removeChosenAddon(string addon)
    {
        string addonsString = PlayerPrefs.GetString(addons, string.Empty);
        if (addonsString.Contains(addon + addonsSeparator))
        {
            PlayerPrefs.SetString(addons, addonsString.Replace(addon + addonsSeparator, string.Empty));
        }
    }

    public static bool HasRated()
    {
        return PlayerPrefs.GetInt(rated, -1) == 1;
    }

    public static void SetRated()
    {
        PlayerPrefs.SetInt(rated, 1);
    }

    public static void turnSound(bool on)
    {
        int boolOn = on ? 1 : 0;
        PlayerPrefs.SetInt(soundOn, boolOn);
    }

    public static bool isSoundOn()
    {
        return PlayerPrefs.GetInt(soundOn, 1) == 1;
    }

    public static void completeSection(string section)
    {
        PlayerPrefs.SetInt(section + sectionComplete, 1);
    }

    public static bool isSectionComplete(string section)
    {
        return PlayerPrefs.GetInt(section + sectionComplete, 0) == 1;
    }

    public static int redPartNotificationShown()
    {
        return PlayerPrefs.GetInt(redPartNotification, 0);
    }

    public static void showRedPartNotification()
    {
        PlayerPrefs.SetInt(redPartNotification, PlayerPrefs.GetInt(redPartNotification, 0) + 1);
    }
}
