using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRipple2 : MonoBehaviour {

    // Overall length
    public float Length;
    // Number of horizontal segments
    public int SegmentResolution;

    public Vector3[] _VertexArray;

    public float StartPosition;
    public MeshFilter filter;
    public float angle = 0;

    
    // Use this for initialization
    void Start ()
    {
        filter = GetComponent<MeshFilter>();

        _VertexArray = new Vector3[SegmentResolution * 2];

        int iterations = _VertexArray.Length / 2 - 1;
        var triangles = new int[(_VertexArray.Length - 2) * 3];

        for (int i = 0; i < iterations; i++)
        {
            int i2 = i * 6;
            int i3 = i * 2;

            triangles[i2] = i3 + 2;
            triangles[i2 + 1] = i3 + 1;
            triangles[i2 + 2] = i3 + 0;

            triangles[i2 + 3] = i3 + 2;
            triangles[i2 + 4] = i3 + 3;
            triangles[i2 + 5] = i3 + 1;
        }

        // Create colors array. For now make it all white.
        var colors = new Color32[_VertexArray.Length];
        for (int i = 0; i < colors.Length; ++i)
        {
            colors[i] = new Color32(255, 255, 255, 255);
        }

        Mesh mesh = filter.mesh;
        mesh.Clear();

        mesh.vertices = _VertexArray;
        mesh.triangles = triangles;

        GenerateSegment(ref mesh);

        var edgeCollider = filter.GetComponent<EdgeCollider2D>();
        var vertices = mesh.vertices;
        var collisionVerts = new Vector2[SegmentResolution];
        /*
        for (int i = 0; i < SegmentResolution; i++)
        {
            collisionVerts[i].x = vertices[i * 2].x;
            collisionVerts[i].y = vertices[i * 2].y;
        }

        edgeCollider.points = collisionVerts;
        */

        //for(int i=0; i<20; i++) {
        //    _VertexArray[i*2] = new Vector3(_VertexArray[i*2].x, 4, _VertexArray[i*2].z);
        //    _VertexArray[i * 2+1] = new Vector3(_VertexArray[i * 2 + 1].x, 3, _VertexArray[i * 2 + 1].z);
        //}

        mesh.vertices = _VertexArray;





        //_VertexArray[0].y = -1;
        //_VertexArray[SegmentResolution * 2 - 1].y = -1;


        vertices = mesh.vertices;
        for (int i = 0; i < SegmentResolution; i++)
        {
            collisionVerts[i].x = vertices[i * 2].x;
            collisionVerts[i].y = vertices[i * 2].y;
        }

        edgeCollider.points = collisionVerts;

    }

    public void GenerateSegment(ref Mesh mesh)
    {
        float step = Length / (SegmentResolution - 1);

        for (int i = 0; i < SegmentResolution; ++i)
        {
            // get the relative x position
            float xPos = step * i;

            // top vertex
            float yPosTop = GetHeight(StartPosition + xPos); // position passed to GetHeight() must be absolute
            _VertexArray[i * 2] = new Vector3(xPos, yPosTop, 0);

            // bottom vertex always at y=0
            _VertexArray[i * 2 + 1] = new Vector3(xPos, 0, 0);
        }

        mesh.vertices = _VertexArray;

        // need to recalculate bounds, because mesh can disappear too early
        mesh.RecalculateBounds();
    }

    private float GetHeight(float position)
    {
        return Mathf.Sin(position) + 1.5f;
    }

    // Update is called once per frame


    //public float TEST = 0;
    void Update ()
    {


        //_VertexArray[0].y = TEST;
        //_VertexArray[SegmentResolution * 2 - 1].y = TEST;
        Mesh mesh = filter.mesh;
        var edgeCollider = filter.GetComponent<EdgeCollider2D>();
        var vertices = mesh.vertices;
        var collisionVerts = new Vector2[SegmentResolution];

        float step = Length / (SegmentResolution - 1);

        //for (int i = 0; i < SegmentResolution; ++i)
        //{
        //    //if (i == 0 || i==SegmentResolution-1)
        //    //{
        //    //    continue;
        //    //}
        //    // get the relative x position
        //    float xPos = step * i;

        //    // top vertex
        //    float yPosTop = GetHeight(StartPosition + xPos + angle); // position passed to GetHeight() must be absolute
        //    _VertexArray[i * 2] = new Vector3(xPos, yPosTop, 0);

        //    // bottom vertex always at y=0
        //    _VertexArray[i * 2 + 1] = new Vector3(xPos, 0, 0);
        //}


        for (int i = 0; i < SegmentResolution/2; ++i)
        {
            
           // get the relative x position
            float xPos = step * i;

            // top vertex
            float yPosTop = GetHeight(StartPosition + xPos + angle); // position passed to GetHeight() must be absolute
            _VertexArray[i * 2] = new Vector3(xPos, yPosTop, 0);

            // bottom vertex always at y=0
            _VertexArray[i * 2 + 1] = new Vector3(xPos, 0, 0);

            _VertexArray[(SegmentResolution - i) * 2 - 1].y = _VertexArray[i * 2 + 1].y;
            _VertexArray[(SegmentResolution - i) * 2 - 2].y = _VertexArray[i * 2].y;
        }

        mesh.vertices = _VertexArray;
        angle += 0.01f;

        vertices = mesh.vertices;
        for (int i = 0; i < SegmentResolution; i++)
        {
            collisionVerts[i].x = vertices[i * 2].x;
            collisionVerts[i].y = vertices[i * 2].y;
        }

        edgeCollider.points = collisionVerts;


    }
}
