﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BasketCollisionHandler : MonoBehaviour

{
    private LevelCreator level;

    void Start()
    {
        level = GameObject.Find("Level").GetComponent<LevelCreator>();
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
            
            level.hitBasket(gameObject.transform.parent.gameObject);
            var starsCount = level.getHitStarsCount();

            if (level.IsCompleted())
            {
                CompletedScreen.getInstanse().SetActive(true);
               
                if (!Saver.isLevelComplete(ScenesParameters.CurrentLevel) && starsCount == -1)
                {
                    int award = starsCount != -1 ? starsCount : Shop.levelAward;

                    Shop.AddStar(award);
                    Saver.levelComplete();

                    CompletedScreen.showCollectedStarsQuantity(award);
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
                        CompletedScreen.showCollectedStarsQuantity(award);
                    }
                }
            }
        }
    }
}
