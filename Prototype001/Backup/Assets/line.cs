using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class line : MonoBehaviour {
    private bool isMousePressed;
    public GameObject lineDrawPrefab;
    private GameObject lineDraw;
    private LineRenderer lineRenderer;
    private EdgeCollider2D EdgeCol;
    private List<Vector3> drawPoints = new List<Vector3>();
    private List<Vector2> edgePoints = new List<Vector2>();
    private Vector3 prevMosPos;
    public float res;
    private float tid;
    public float cd;
    public float noDrawCenterRadius;

	// Use this for initialization
	void Start () {
        isMousePressed = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
        { 
            isMousePressed = true;
            lineDraw = GameObject.Instantiate(lineDrawPrefab) as GameObject;
            lineRenderer = lineDraw.GetComponent<LineRenderer>();
            EdgeCol = lineDraw.GetComponent<EdgeCollider2D>();
            lineRenderer.positionCount = 0;
            tid = cd;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isMousePressed = false;
            if (drawPoints.Count <= 1)
            {
                Destroy(lineDraw);
            }
            drawPoints.Clear();
            edgePoints.Clear();

            // stop drawing?
        }
        tid -= Time.deltaTime;


        if (isMousePressed)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;

            if (mousePos.magnitude > noDrawCenterRadius)
            {
                if (Vector3.Distance(prevMosPos, mousePos) > res && tid > 0)
                {
                    drawPoints.Add(mousePos);
                    edgePoints.Add(mousePos);
                    lineRenderer.positionCount = drawPoints.Count;
                    lineRenderer.SetPosition(drawPoints.Count - 1, mousePos);
                    EdgeCol.points = edgePoints.ToArray();
                    prevMosPos = mousePos;
                }
            }
        }
	}
}
