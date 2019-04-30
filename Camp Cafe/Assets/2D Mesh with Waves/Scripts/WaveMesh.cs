using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter),typeof(MeshRenderer))]

public class WaveMesh : MonoBehaviour {

    private MeshFilter mf;
    private Mesh m;
    private float distanceBetweenPoints;
    private int segments;
    private int points;

    public float width, height;
    public float period;
    public float amplitude;
    public float waveLength;
    public float pointConcetration;
    public bool standingWave;
    public float movement;
    public float tilt;

	// Use this for initialization
	void Start () {

        mf = this.gameObject.GetComponent<MeshFilter>();
        m = new Mesh();
        mf.mesh = m;

	}
	
	// Update is called once per frame
	void Update () {

        //Converting variables
        distanceBetweenPoints = 1/ pointConcetration;
        segments = Mathf.RoundToInt(width / distanceBetweenPoints);
        points = 6 * segments;

	    //Declaration verteces
        Vector3[] vertices = new Vector3[points + 2];
        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(width, 0, 0);

        //Declaration triangles
        int[] tri = new int[points*3];

        //Moving the vertices
        for(int v = 0; v < points/3; v++)
        {
            float xPosition = v * distanceBetweenPoints;
            float yPosition = 0;
            if (v % 2 == 0)
            {
                if(!standingWave)
                {
                    yPosition = amplitude * Mathf.Sin(2 * Mathf.PI * (Time.time / period - (v * distanceBetweenPoints) / waveLength)) + height;
                    vertices[v] = new Vector3(xPosition + tilt, yPosition, 0);
                }
                else
                {
                    float wave = (amplitude * Mathf.Sin(2 * Mathf.PI * (Time.time / period - v * distanceBetweenPoints / waveLength)));
                    float opositeWave = (amplitude * Mathf.Sin(2 * Mathf.PI * (Time.time / (period/(-movement+1)) + v * distanceBetweenPoints / waveLength)));
                    yPosition = (wave + opositeWave)/2 + height;
                    vertices[v] = new Vector3(xPosition + tilt, yPosition, 0);
                }
            }
            else
            {
                vertices[v] = new Vector3(xPosition - distanceBetweenPoints, 0, 0);
            }
            
        }
        
        //Assigning vertices to triangles
        for (int t = 0; t < points;t++ )
        {
            if(t%3==0)
            {
                if ((t / 3) % 2 == 1)
                    tri[t] = t / 3 + 1;
                else
                    tri[t] = t / 3; 
            }
            if(t%3==1)
            {
                tri[t] = (t +5)/3; 
            }
            if (t % 3 == 2)
            {
                if (((t + 1) / 3) % 2 == 0)
                    tri[t] = (t + 1) / 3 - 1;
                else
                    tri[t] = (t + 1) / 3; 
            }
            
        }

        //Creating UVs
        Vector2[] uvs = new Vector2[m.vertexCount];

        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(vertices[i].x, vertices[i].y);
        }
        m.uv = uvs;

        //Creating Mesh
        m.vertices = vertices;
        m.triangles = tri;
       
	}
}