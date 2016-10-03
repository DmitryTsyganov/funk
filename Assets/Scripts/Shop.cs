using UnityEngine;
using System.Collections;

class Shop
{

    public static int levelAward = 3;
    public static int ballPrice = 50;
    public static int hintPrice = 10;

    private static int starScore;
	public static int StarScore{ 
		get{ 
			starScore = PlayerPrefs.GetInt ("StarScore");
			return starScore;
		}
		set{ 
			starScore = value;
			PlayerPrefs.SetInt ("StarScore", starScore);
		}
	}

    public static bool BuyForPrice(string name, int price)
    {
        if (StarScore >= price)
        {
            StarScore -= price;
            Saver.buyBall(name);
            return true;
        }
        return false;
    }

    public static bool Buy(string name)
	{
	    return BuyForPrice(name, ballPrice);
	}

	public static bool BuyHint(){
		if (StarScore>= 0) {
			StarScore = StarScore - hintPrice;
			return true;
		} else {
			return false;
		}
	}
	public static bool CanBuyHint()
	{
	    return StarScore >= hintPrice;
	}


	public static void AddStar(int starIndex){
		StarScore = StarScore + starIndex;
	}
}
