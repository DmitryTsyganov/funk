using UnityEngine;

class Shop
{

    public const int levelAward = 3;
    public const int ballPrice = 50;
    public const int hintPrice = 30;

    public const int StarsUltimate = 1000000;

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

    public static void BuyForFree(string name)
    {
        Saver.buyBall(name);
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
