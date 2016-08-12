using System;
using UnityEngine;
using System.Collections;
using System.IO;
using System.Xml.Serialization;

public class LevelsMeta : MonoBehaviour
{
    string[] sections =
       {
            "linear", "power", "root", "Exponental", "Hyperbolic",
            "Logarithm", "Mixed", "Polinomial", "Special", "Trigonometric"
        };

    public void completeAllLevels()
    {
        for (int i = 0; i < sections.Length; i++)
        {
            ScenesParameters.Section = sections[i];

            TextAsset config = Resources.Load("Levels" + '/'
            + sections[i] + '/' + "config") as TextAsset;

            int levelsQuantity = Int32.Parse(config.text);

            int lastSavedLevel = Saver.getSectionLevelsComplete();

            for (int j = lastSavedLevel; j < levelsQuantity; ++j)
            {
                ScenesParameters.CurrentLevel = j;
                Saver.levelComplete();
            }
        }
    }


    public void transformOldLevelsToFullLevels()
    {
        var xmlFormat = ".xml";

        for (int i = 0; i < sections.Length; ++i)
        {
            var serializationPath = Path.Combine(Directory.GetCurrentDirectory(),
                                            "Assets"
                                            + Path.DirectorySeparatorChar +
                                            "Resources" + Path.DirectorySeparatorChar +
                                            "Levels" + Path.DirectorySeparatorChar
                                            + sections[i] +
                                            Path.DirectorySeparatorChar);

            TextAsset config = Resources.Load("Levels" + '/'
            + sections[i] + '/' + "config") as TextAsset;

            int levelsQuantity = Int32.Parse(config.text);

            for (int j = 1; j <= levelsQuantity; ++j)
            {
                string path = serializationPath + ScenesParameters.LevelName + j + xmlFormat;
                //print(path);
                if (File.Exists(path))
                {
                    string levelString = File.ReadAllText(path);
                    if (isOldLevel(levelString))
                    {
                        File.WriteAllText(path, transformToFullLevel(levelString));
                    }
                }
            }
        }
    }

    private string transformToFullLevel(string levelString)
    {
        string ballsArray = "Balls";
        string ball = "Ball";

        string basketsArray = "Baskets";
        string basket = "Basket";

        string bricksArray = "BrickObsticles";
        string brick = "ObsticleBrick";

        if (!levelString.Contains(openTag(ballsArray)))
        {
            levelString = levelString.Replace(openTag(ball), openTag(ballsArray) + openTag(ball));
            levelString = levelString.Replace(closeTag(ball), closeTag(ball) + closeTag(ballsArray));

            levelString = levelString.Replace(openTag(basket), openTag(basketsArray) + openTag(basket));
            levelString = levelString.Replace(closeTag(basket), closeTag(basket) + closeTag(basketsArray));

            levelString = levelString.Replace(openTag(brick), openTag(bricksArray) + openTag(brick));
            levelString = levelString.Replace(closeTag(brick), closeTag(brick) + closeTag(bricksArray));
        }

        return levelString;
    }

    private string closeTag(string name)
    {
        return "</" + name + ">";
    }

    private string openTag(string name)
    {
        return "<" + name + ">";
    }

    private bool isOldLevel(string levelString)
    {
        return !levelString.Contains(openTag("Balls")) && !levelString.Contains(openTag("Baskets"));
    }
}
