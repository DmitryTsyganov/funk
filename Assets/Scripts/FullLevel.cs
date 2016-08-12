using UnityEngine;
using System.Collections;
using System.Xml.Serialization;

[XmlRoot("Level")]
public class FullLevel {

    [XmlElement("Funk")]
    public string Funk { get; set; }

    [XmlElement("DefaultFunk")]
    public string DefaultFunk { get; set; }

    [XmlElement("Hint")]
    public string HintText { get; set; }

    [XmlArray("Balls")]
    public Ball[] balls { get; set; }

    [XmlArray("Baskets")]
    public Basket[] baskets { get; set; }

    [XmlArray("BrickObsticles")]
    public ObsticleBrick[] obsticleBricks { get; set; }

    public FullLevel()
    {
        
    }

    public FullLevel(Ball[] balls, Basket[] baskets, ObsticleBrick[] obsticleBricks, 
                        string funk, string defFunk, string hint)
    {
        this.balls = balls;
        this.baskets = baskets;
        this.obsticleBricks = obsticleBricks;
        this.Funk = funk;
        this.DefaultFunk = defFunk;
        this.HintText = hint;
    }

    public FullLevel(GameObject[] balls, GameObject[] baskets, GameObject[] obsticles, string funk, string defFunk, string hint)
    {
        this.balls = new Ball[balls.Length];

        for (int i = 0; i < balls.Length; ++i)
        {
            this.balls[i] = new Ball(balls[i].transform.position.x,
                            balls[i].transform.position.y,
                            balls[i].transform.localScale.x,
                            null);
        }

        this.baskets = new Basket[baskets.Length];

        for (int i = 0; i < baskets.Length; ++i)
        {
            this.baskets[i] = new Basket(baskets[i].transform.position.x,
                            baskets[i].transform.position.y,
                            baskets[i].transform.localScale.x,
                            baskets[i].transform.eulerAngles.z);
        }

        if (obsticles.Length > 0)
        {
            this.obsticleBricks = new ObsticleBrick[obsticles.Length];

            for (int i = 0; i < obsticles.Length; ++i)

            this.obsticleBricks[i] = new ObsticleBrick(obsticles[i].transform.position.x,
                                                obsticles[i].transform.position.y,
                                                obsticles[i].transform.localScale.x,
                                                obsticles[i].transform.eulerAngles.z);
        }

        this.Funk = funk;
        this.DefaultFunk = defFunk;
        this.HintText = hint;
    }
}
