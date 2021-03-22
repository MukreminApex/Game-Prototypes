using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlingshotController : MonoBehaviour {

    public int shots;
    float drawback;
    float maxPower;
    public GameObject ball;
    public Transform ballSpawn;
    public LineRenderer lr;
    public Text ballsText;
    public int targetScore;

    private Rigidbody2D ballRb;
    private Vector2 direction;
    private Vector2 startPos;
    private Vector2 endPos;
    private float power;
    private bool goal = false;

    float scaleFactor = 1;

    // Use this for initialization
    void Start () {
        scaleFactor = 1f / Screen.height * 1080;
        ballRb = ball.GetComponent<Rigidbody2D>();
        GameManager.balls = shots;
        SetBallsText();
        drawback = GameManager.Instance.drawback;
        maxPower = GameManager.Instance.maxPower;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition* scaleFactor;
        }

        if (Input.GetMouseButton(0) && shots > 0)
        {
            endPos = Input.mousePosition* scaleFactor;
            float distance = Vector2.Distance(startPos, endPos);
            float pow = distance / drawback;
            if (distance > drawback)
                pow = 1;
            power = pow * maxPower;
            direction = startPos - endPos;
            lr.enabled = true;
            var predict = PlotCurveForCollider(ballRb, ballSpawn.position, direction.normalized * power, 0);
            lr.positionCount = predict.Count;
            lr.SetPositions(predict.ToArray());
        }
        else
        {
            lr.enabled = false;
        }

        SetTargetText();
        SetScoreText();

        if (Input.GetMouseButtonUp(0))
        {
            endPos = Input.mousePosition* scaleFactor;
            float distance = Vector2.Distance(startPos, endPos);
            float pow = distance / drawback;
            if (distance > drawback)
                pow = 1;
            power = pow * maxPower;
            GameManager.balls = shots;
            if (shots >= 1)
            {
                Shoot(startPos, endPos, pow * maxPower);
                shots--;
                GameManager.balls--;
                SetBallsText();
            }
            if (shots == 0)
            {
                Invoke("EndGame", 5);
            }
        }
    }

    void EndGame()
    {
        if (GameManager.playerPoints >= targetScore)
        {
            goal = true;
            PanelController.Instance.LvlComplete.SetActive(true); // lvl complete panel
            gameObject.SetActive(false);
        }
        else
        {
            PanelController.Instance.GameOver.SetActive(true);    // activate gameover panel IF goal is not achieved with last shot 
            gameObject.SetActive(false);
        }
    }

    void Shoot(Vector2 start, Vector2 end, float power)
    {
        direction = start - end;
        GameObject tempBall = Instantiate(ball) as GameObject;
        tempBall.transform.position = ballSpawn.position;
        tempBall.GetComponent<Rigidbody2D>().velocity = direction.normalized * power; //.AddForce(direction.normalized * power);
    }

    private void OnDrawGizmos()
    {
        ballRb = ball.GetComponent<Rigidbody2D>();
        var predict = PlotCurveForCollider(ballRb, ballSpawn.position, direction.normalized * power, 0);
        for (int i = 0; i < predict.Count-1; i++)
        {
            Gizmos.DrawLine(predict[i], predict[i + 1]);
        }
    }

    List<Vector3> PlotCurveForCollider(Rigidbody2D rigidbody, Vector2 pos, Vector2 velocity, float endY)
    {
        List<Vector3> v = new List<Vector3>();
        var y = endY;
        Vector2 result = new Vector2();
        float timestep = Time.fixedDeltaTime / Physics2D.velocityIterations;
        Vector2 gravityAccel = Physics2D.gravity * rigidbody.gravityScale * timestep *timestep;
        float drag = 1f - timestep * rigidbody.drag;
        Vector2 moveStep = velocity * timestep;
        Vector2 lastStep = moveStep;
        for (int i = 0; i < 750; i++)
        {
            moveStep += gravityAccel;
            moveStep *= drag;
            pos += moveStep;
            result = pos;

            v.Add(pos);
            lastStep = moveStep;
        }
        return v;
    }

    void SetBallsText()
    {
        PanelController.Instance.InGameUI.transform.GetChild(0).GetComponent<Text>().text = "Balls: " + GameManager.balls.ToString();
        // ballsText.text = "Balls: " + GameManager.balls.ToString();
    }
    void SetTargetText()
    {
        PanelController.Instance.InGameUI.transform.GetChild(1).GetComponent<Text>().text = "Target Score: " + targetScore.ToString();
    }
    void SetScoreText()
    {
        PanelController.Instance.InGameUI.transform.GetChild(2).GetComponent<Text>().text = "Score: " + GameManager.playerPoints.ToString();
    }
}
