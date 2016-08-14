using UnityEngine;
using UnityEngine.UI;
using ExpressionParser;
using System.Collections.Generic;

public class DrawGraph : MonoBehaviour
{
    public Material material;
    private GameObject inputFieldGo;
    private GameObject setUp;
    private InputField inputFieldCo;

    private static Texture2D _staticRectTexture;
    private static GUIStyle _staticRectStyle;

    private ExpressionParser.ExpressionParser parser;
    private Camera cam;
    private Transform DotPrefab;

    List<BoxCollider2D> graphDots = new List<BoxCollider2D>();
    List<LineRenderer> lines = new List<LineRenderer>();


    // Use this for initialization
    void Start()
    {
        inputFieldGo = GameObject.Find("InputField");
        inputFieldCo = inputFieldGo.GetComponent<InputField>();

        parser = new ExpressionParser.ExpressionParser();
       
    }

    private LineRenderer createLine()
    {
        LineRenderer line;

        line = new GameObject("Line").AddComponent<LineRenderer>();

        line.SetWidth(0.06f, 0.06f);
       
        line.material = this.material;

        line.material.SetColor("_Color", new Color(0.8824f, 0.1843f, 0.0413f));

        line.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        line.SetColors(new Color(0.8824f, 0.1843f, 0.0413f), new Color(0.8824f, 0.1843f, 0.0413f));

        line.SetVertexCount(2);

        return line;
    }

    // Update is called once per frame
    void Update()
    {
         
    }

    private bool goodNumbers(params double[] nums)
    {
        foreach (double n in nums)
        {
            if (double.IsInfinity(n) || double.IsNaN(n))
                return false;
        }
        return true;
    }

    private void buildSegment(double x, double y, double prevX, double prevY)
    {
        var newDotPosition = new Vector2((float)x, (float)y);
        var lastDotPosition = new Vector2((float)prevX, (float)prevY);

        //Transform dot = (Transform)Instantiate(DotPrefab, newDotPosition, Quaternion.identity);

        var colliderKeeper = new GameObject("collider");

        var line = createLine();

        line.SetPosition(0, lastDotPosition);
        line.SetPosition(1, newDotPosition);

        lines.Add(line);

        colliderKeeper.transform.position = Vector2.Lerp(newDotPosition, lastDotPosition, 0.5f);
        var diff = lastDotPosition - newDotPosition;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        colliderKeeper.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        BoxCollider2D bc = colliderKeeper.AddComponent<BoxCollider2D>();

        float length = Mathf.Abs(Mathf.Sqrt(Mathf.Pow((float) (x - prevX), 2) + Mathf.Pow((float) (y - prevY), 2)));

        bc.size = new Vector2(0.06f, length);

        graphDots.Add(bc);
    }

    private void BuildPlot(ExpressionDelegate fun)
    {

        deleteLines();

        foreach (BoxCollider2D dot in graphDots)
        {
            Destroy(dot.gameObject);
        }
        graphDots.Clear();

        if (fun != null)
        {
            float firstX = -7;
            float lastX = 7;

            double firstY = fun(firstX);

            while ((firstY > 6 || firstY < -6) && firstX < 0)
            {
                firstX += 0.005f;
                firstY = fun(firstX);
            }

            double lastY = fun(lastX);

            while ((lastY > 6 || lastY < -6) && lastX > 0)
            {
                lastX -= 0.005f;
                lastY = fun(lastX);
            }

            double PrevX = firstX;
            double PrevY = fun(PrevX);
            double x;
            double y;

            //print("first x " + firstX);
            //print("last x " + lastX);

            int stepsTotal = 260;

            double stepLength = (-firstX + lastX) / stepsTotal;

            for (double i = 0; i <= stepsTotal; ++i)
            {
                x = firstX + i * stepLength;
                y = fun(x);
                if (y < 6 && y > -6 && PrevY < 6 && PrevY > -6)
                {
                    buildSegment(x, y, PrevX, PrevY);
                }

                PrevX = x;
                PrevY = y;
            }
        }
    }

    private void deleteLines()
    {
        foreach (LineRenderer line in lines)
        {
            Destroy(line.gameObject);
        }

        lines.Clear();
    }

    public void GetText()
    {

        if (ScenesParameters.isValid) {
            try
            {
                string rawExp = inputFieldCo.text.Replace("<color=#E12F0BFF>", "").Replace("</color>", "");
                Expression exp = parser.EvaluateExpression(rawExp);
                ExpressionDelegate fun = exp.ToDelegate("x");
                BuildPlot(fun);
            }
            catch (KeyNotFoundException e)
            {
                Expression exp = parser.EvaluateExpression(inputFieldCo.text);
                ExpressionDelegate fun = exp.ToDelegate();
                BuildPlot(fun);
            }
            catch (ExpressionParser.ExpressionParser.ParseException ex)
            {
                BuildPlot(null);
            }
        }
    }
}