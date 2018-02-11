using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseTracker : MonoBehaviour {
    LineRenderer lineRenderer;
    public KeyChain keyChain; 
    public Terrain terrain;
    public Player pl;

    public bool trace;
    [Range(0,90)]
    public float angle;
    [Range(1,20)]
    public int casts;

	// Use this for initialization
    void Start () {
        lineRenderer = GetComponent<LineRenderer> ();
        lineRenderer.startColor = lineRenderer.endColor = Color.red;
        lineRenderer.startWidth = lineRenderer.endWidth = 0.1f;
	}
    //previously used to detect walls
    bool intersect(Vector2 a, Vector2 b, Vector2 c, Vector2 d){

        float p0_x = a.x;
        float p0_y = a.y;
        float p1_x = b.x;
        float p1_y = b.y;
        float p2_x = c.x;
        float p2_y = c.y;
        float p3_x = d.x;
        float p3_y = d.y;


       float s1_x = p1_x - p0_x;
       float s1_y = p1_y - p0_y;
       float s2_x = p3_x - p2_x;
       float s2_y = p3_y - p2_y;

        float s, t;
        s = (-s1_y * (p0_x - p2_x) + s1_x * (p0_y - p2_y)) / (-s2_x * s1_y + s1_x * s2_y);
        t = ( s2_x * (p0_y - p2_y) - s2_y * (p0_x - p2_x)) / (-s2_x * s1_y + s1_x * s2_y);

        if (s >= 0 && s <= 1 && t >= 0 && t <= 1)
        {
            return true;
        }

        return false;
    }
    //keep track of when key is visible
    Key[] visibleKey = new Key[2*20-1];
    bool[] seeingKey = new bool[2*20-1];
    float t=0;

	// Update is called once per frame
	void Update () {

        Vector2 worldPoint;
        //for constant sweep
        if (Input.GetMouseButton(1))
        {
            worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPoint+= new Vector2(t, 0);
            t += 0.5f;
        }
        else
        {   //mouse position
            worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
        //for sweep reset
        if (Input.GetMouseButtonUp(1))
            t = 0;
        
        //player postiiont
        Vector2 plPoint = new Vector2(pl.transform.position.x, pl.transform.position.y);

          
        for (int i = 0; i < 2 * casts - 1; i++)
        {
            //rotate ray accordingly
            Vector2 dir = Quaternion.Euler(0,0,Mathf.Pow(-1, i) * ((int)(i+1)/2) * angle / (casts))*(worldPoint - plPoint);

            RaycastHit2D hit = Physics2D.Raycast(plPoint, dir);

            if (hit.collider != null)
            {
                if (trace)
                {
                    lineRenderer.SetPosition(2*i, pl.transform.position);
                    lineRenderer.SetPosition(2*i+1, hit.point);
                }
                else
                {
                    lineRenderer.SetPosition(2*i, Vector2.zero);
                    lineRenderer.SetPosition(2*i+1, Vector2.zero);
                }
                Key key = hit.collider.GetComponent<Key>();
                if (key != null)
                {
                    seeingKey[i] = true;
                    visibleKey[i] = key;
                    visibleKey[i].GetComponent<Renderer>().enabled = true;
                }
                else if (seeingKey[i])
                {
                    seeingKey[i] = false;
                        visibleKey[i].GetComponent<Renderer>().enabled = false;
                    visibleKey[i] = null;
                }
            }
        }
    }
}
