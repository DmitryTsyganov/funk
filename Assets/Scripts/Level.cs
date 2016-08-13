using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System;

[XmlRoot("Level")]
public class Level
{

    [XmlElement("Funk")]
    public string Funk { get; set; }

    [XmlElement("DefaultFunk")]
    public string DefaultFunk { get; set; }

    [XmlElement("Hint")]
    public string HintText { get; set; }

    [XmlElement("Ball")]
    public Ball ball { get; set; }

    [XmlElement("Basket")]
    public Basket basket { get; set; }

    [XmlElement("TriangleObsticle")]
    public ObsticleBrick ObsticleBrick { get; set; }

    public Level() {}

	public Level(GameObject _ball, GameObject _basket, GameObject _obsticle, string funk, string defFunk,string hint)
    {
        ball = new Ball(_ball.transform.position.x,
                        _ball.transform.position.y,
                        _ball.transform.localScale.x,
                        null);

        basket = new Basket(_basket.transform.position.x,
                            _basket.transform.position.y,
                            _basket.transform.localScale.x,
                            _basket.transform.eulerAngles.z);

        if (_obsticle != null)
        {
            ObsticleBrick = new ObsticleBrick(_obsticle.transform.position.x,
                                                _obsticle.transform.position.y,
                                                _obsticle.transform.localScale.x,
                                                _obsticle.transform.eulerAngles.z);
        }

        this.Funk = funk;
        this.DefaultFunk = defFunk;
		this.HintText = hint;
    }



	public Level(Ball ball, Basket basket, ObsticleBrick ObsticleTriangle, string funk, string defFunk,string hint) {
        this.ball = ball;
        this.basket = basket;
        this.ObsticleBrick = ObsticleTriangle;
        this.Funk = funk;
        this.DefaultFunk = defFunk;
		this.HintText = hint;
    }



    public IEnumerator GetEnumerator()
    {
        throw new NotImplementedException();
    }
}


public class BasicLevelItem
{
    public BasicLevelItem() {}

    public BasicLevelItem(float x, float y, float scale)
    {
        this.x = x;
        this.y = y;
        this.scale = scale;
    }

    
    public float x { get; set; }
    
    public float y { get; set; }

    public float scale { get; set; }
}

public class LevelItemWithAngle : BasicLevelItem
{
    public LevelItemWithAngle() {}

    public LevelItemWithAngle(float x, float y, float scale, float angle) :
        base(x, y, scale)
    {
        this.angle = angle;
    }

    
    public float angle { get; set; }
}

public class Basket : LevelItemWithAngle
{
    Basket() {}

    public Basket(float x, float y, float scale, float angle) :
        base(x, y, scale, angle) { }
}

public class Ball : BasicLevelItem
{
    public Ball() {}

    public Ball(float x, float y, float scale, string _image) : base(x, y, scale) {
        image = _image;
    }

    public string image { get; set; }
}

public class Star : LevelItemWithAngle
{
    public Star() { }

    public Star(float x, float y, float scale, float angle) :
        base(x, y, scale, angle) { }
}

public class ObsticleBrick : LevelItemWithAngle
{
    public ObsticleBrick() {}

    public ObsticleBrick(float x, float y, float scale, float angle) :
        base(x, y, scale, angle) { }
}
