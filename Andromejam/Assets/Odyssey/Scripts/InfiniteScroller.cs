using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScroller : MonoBehaviour {

    public GameObject Target;

    private Rigidbody2D targetBody;

	// Use this for initialization
	void Start () {
        float x = GetComponent<SpriteRenderer>().bounds.size.x;
        float y = GetComponent<SpriteRenderer>().bounds.size.y;

        GameObject[] neigbours = new GameObject[]
        {
            CreateNeighbour(Vector3.up * y),CreateNeighbour(Vector3.down * y),
            CreateNeighbour(Vector3.left * x), CreateNeighbour(Vector3.right * x),
            CreateNeighbour( Vector3.left * x + Vector3.up *y ), CreateNeighbour(Vector3.left * x + Vector3.down * y),
            CreateNeighbour(Vector3.right * x + Vector3.up * y), CreateNeighbour(Vector3.right *x + Vector3.down * y)
        };
        foreach (GameObject go in neigbours)
            SetParent(go);
	}
	
    private GameObject CreateNeighbour(Vector3 increment)
    {
        GameObject neighbour = Instantiate(gameObject);
        neighbour.transform.position += increment;
        return neighbour;
    }

    private void SetParent(GameObject child)
    {
        child.transform.parent = transform;
    }


	// Update is called once per frame
	void Update () {
        if (Target == null) return;

        var spr = GetComponent<SpriteRenderer>();

        Rect re = new Rect(spr.bounds.center - (spr.bounds.size / 2), spr.bounds.size);
        Vector2 pos2d = Target.transform.position;

        if (re.Contains(pos2d)) return;

        Vector3 increment = Vector3.zero;

        if(pos2d.x < re.xMin)
            increment += Vector3.left * re.size.x;
        else if(pos2d.x > re.xMax)
            increment += Vector3.right * re.size.x;

        if(pos2d.y < re.yMin)
            increment += Vector3.down * re.size.y;
        else if(pos2d.y > re.yMax)
            increment += Vector3.up * re.size.y;

        transform.position += increment;
    }
}
