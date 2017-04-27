using UnityEngine;
using UnityEngine.UI;
using ExpressionParser;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class DrawGraph : MonoBehaviour
{
    public Material GraphMaterial;
    public Material MapMaterial;

    public GameObject Colliders;
    public GameObject Lines;
    public InputFieldHandler inputFieldCo;

    private GameObject inputFieldGo;
    private GameObject setUp;

    private static Texture2D _staticRectTexture;
    private static GUIStyle _staticRectStyle;

    private ExpressionParser.ExpressionParser parser;
    private Camera cam;
    private Transform DotPrefab;
    private const int mappingQuantity = 5;
    private const float mapLenght = 0.3f;
    private const float lineWidth = 0.06f;

    private Color lineColor = new Color(225, 1, 1);
    private Color mapColor = new Color(255f, 255f, 255f);

    private float offsetY;

    List<BoxCollider2D> graphDots = new List<BoxCollider2D>();
    List<LineRenderer> lines = new List<LineRenderer>();


    // Use this for initialization
    void Start()
    {
        offsetY = ScenesParameters.LevelOffsetY;

        parser = new ExpressionParser.ExpressionParser();

        createMapping();
    }

    private void createMapping()
    {
        for (int i = -mappingQuantity; i <= mappingQuantity; ++i)
        {
            if (i == 0)
                continue;

            var line = createLine(MapMaterial);
            line.SetPosition(0, new Vector2(i, -mapLenght / 2 + offsetY));
            line.SetPosition(1, new Vector3(i, mapLenght / 2 + offsetY));
            
            line.material.SetColor("_Color", mapColor);

            line = createLine(MapMaterial);
            line.SetPosition(0, new Vector2(-mapLenght / 2, i + offsetY));
            line.SetPosition(1, new Vector3(mapLenght / 2, i + offsetY));

            line.material.SetColor("_Color", mapColor);
        }
    }

    private LineRenderer createLine(Material material)
    {
        var line = new GameObject("Line").AddComponent<LineRenderer>();
        line.transform.SetParent(Lines.transform);

        line.startWidth = line.endWidth = lineWidth;
       
        line.material = material;

        //line.material.SetColor("_Color", lineColor);

        line.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;

        line.startColor = line.endColor = lineColor;

        line.numPositions =2;

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
        colliderKeeper.transform.SetParent(Colliders.transform);

        var line = createLine(GraphMaterial);

        line.SetPosition(0, lastDotPosition);
        line.SetPosition(1, newDotPosition);

        lines.Add(line);

        colliderKeeper.transform.position = Vector2.Lerp(newDotPosition, lastDotPosition, 0.5f);
        var diff = lastDotPosition - newDotPosition;
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;

        colliderKeeper.transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        BoxCollider2D bc = colliderKeeper.AddComponent<BoxCollider2D>();

        float length = Mathf.Abs(Mathf.Sqrt(Mathf.Pow((float) (x - prevX), 2) + Mathf.Pow((float) (y - prevY), 2)));

        bc.size = new Vector2(lineWidth, length);

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
            const float halfPlotInterval = 5.65f;
            const float step = 0.005f;
            const int stepsTotal = 260;
            const int halfPlotSize = 6;

            float maxY = halfPlotSize + offsetY;
            float minY = -halfPlotSize + offsetY;

            float firstX = -halfPlotInterval;
            float lastX = halfPlotInterval;

            double firstY = fun(firstX) + offsetY;

            while ((firstY > maxY || firstY < minY) && firstX < 0)
            {
                firstX += step;
                firstY = fun(firstX) + offsetY;
            }

            double lastY = fun(lastX) + offsetY;

            while ((lastY > maxY || lastY < minY) && lastX > 0)
            {
                lastX -= step;
                lastY = fun(lastX) + offsetY;
            }

            double PrevX = firstX;
            double PrevY = fun(PrevX) + offsetY;
            double x;
            double y;

            //print("first x " + firstX);
            //print("last x " + lastX);

            double stepLength = (-firstX + lastX) / stepsTotal;

            for (double i = 0; i <= stepsTotal; ++i)
            {
                x = firstX + i * stepLength;
                y = fun(x) + offsetY;
                if (y < maxY && y > minY && PrevY < maxY && PrevY > minY)
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

    public void Draw()
    {
        if (ScenesParameters.isValid) {
            try
            {
                inputFieldCo.Input.text = Regex.Replace(inputFieldCo.Input.text, @"\^0\d+", "^0");
                string rawExp = inputFieldCo.Input.text.Replace("<color=#E12F0BFF>", string.Empty)
                                .Replace("</color>", string.Empty).Replace(" ", string.Empty);

                //rawExp = Regex.Replace(rawExp, @"(?<=\/)[\-\+]\d*\.?\d*(([a-z])?(?![a-z])|([a-z]){3}\(.+?\))", "($0)");
                //49 steps faster WOW WOW
                rawExp = Regex.Replace(rawExp, @"([\/\*])([\-\+]\d*\.?\d*(([a-z])?(?![a-z])|([a-z]){3}\(.+?\)))", "$1($2)");
                //rawExp = Regex.Replace(rawExp,@"([\/\*])([\-\+]\d*\.?\d*(([a-z])?(?![a-z])|([a-z]*\(([^()]|(?5))*\))))", "$1($2)");

                rawExp = Regex.Replace(rawExp, @"(\d(?=[a-z\(])|[x\)](?=\d))", "$0*");
                rawExp = Regex.Replace(rawExp, @"(?<![0-9\.])0[0-9]+", "0");

                Expression exp = parser.EvaluateExpression(rawExp);
                ExpressionDelegate fun = exp.ToDelegate("x");
                BuildPlot(fun);
            }
            catch (KeyNotFoundException e)
            {
                Expression exp = parser.EvaluateExpression(inputFieldCo.Input.text);
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