using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class BasketCollisionHandler : MonoBehaviour

{
    private LevelCreator _levelCreator;
    private CompletedScreen _completedScreen;

    void Awake()
    {
        _completedScreen = GameObject.Find("GameMechanicsInputs")
            .GetComponentInChildren<CompletedScreen>(true);
        _levelCreator = GameObject.Find("Level").GetComponent<LevelCreator>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        var x = col.transform.position.x - gameObject.transform.position.x;
        var y = col.transform.position.y - gameObject.transform.position.y;

        Vector2 localBallPosition = new Vector2(x * Mathf.Cos(gameObject.transform.eulerAngles.z / 180 * Mathf.PI) +
                                                y * Mathf.Sin(gameObject.transform.eulerAngles.z / 180 * Mathf.PI),
                                                -x * Mathf.Sin(gameObject.transform.eulerAngles.z / 180 * Mathf.PI) +
                                                y * Mathf.Cos(gameObject.transform.eulerAngles.z / 180 * Mathf.PI));

        localBallPosition.y = localBallPosition.y - gameObject.GetComponent<Collider2D>().offset.y * 
                                gameObject.transform.parent.transform.localScale.y;

        //print("local position " + localBallPosition);

        if (localBallPosition.y > 0)
        {
            //print("Level complete");
            
            _levelCreator.hitBasket(gameObject.transform.parent.gameObject);
            var starsCount = _levelCreator.getHitStarsCount();

            if (_levelCreator.IsCompleted() && _levelCreator.IsActive())
            {
                HintButton.PlayHintAnimation = false;
                _levelCreator.Deactivate();
                _completedScreen.gameObject.SetActive(true);
               
                if (!Saver.isLevelComplete(ScenesParameters.CurrentLevel) &&
                    ScenesParameters.LevelsNumber == ScenesParameters.CurrentLevel && !Saver.isSectionComplete(ScenesParameters.Section))
                {
                    Saver.completeSection(ScenesParameters.Section);
                    CompletedScripts.ShowRateTheGameScreen = true;
                }

                if (!Saver.isLevelCompletedWithStars())
                {
                    Analytics.CustomEvent(AnalyticsParameters.LevelComplete +
                                          (ScenesParameters.CurrentLevel + ScenesParameters.ScenesOrder[ScenesParameters.Section] * 20));
                }

                if (!Saver.isLevelComplete(ScenesParameters.CurrentLevel) && starsCount == -1)
                {
                    int award = starsCount != -1 ? starsCount : Shop.levelAward;

                    Shop.AddStar(award);
                    Saver.levelComplete();

                    Analytics.CustomEvent(AnalyticsParameters.LevelComplete +
                                          (ScenesParameters.CurrentLevel + ScenesParameters.ScenesOrder[ScenesParameters.Section] * 20));

                    _completedScreen.ShowCollectedStarsQuantity(award);
                }
                else if (!Saver.isLevelComplete(ScenesParameters.CurrentLevel) && starsCount != -1)
                {
                    var previousStarsCount = Saver.getStarsCollectedOnLevel();
                    if (previousStarsCount < starsCount)
                    {
                        Saver.saveCompletedLevelWithStars(starsCount);

                        var award = previousStarsCount == -1
                            ? starsCount
                            : starsCount - previousStarsCount;

                        Shop.AddStar(award);

                        if (!Saver.sawFirstBall() && ShopManagerhandler.GetBallShop().CanBuyCheapestBall())
                        {
                            _levelCreator.ShowCanBuyBallCanvas();
                        }

                        _completedScreen.ShowCollectedStarsQuantity(award);
                        _completedScreen.ShowStars(starsCount, false);
                        
                    } else
                    {
                        _completedScreen.ShowStars(previousStarsCount, true);
                        _completedScreen.DisableText();
                    }
                }
            }
        }
    }
}
