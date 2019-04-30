using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]

public class WaveMeshWithEffect : MonoBehaviour
{
    [System.Serializable]
    public class Wave
    {

        public float amplitude;
        public float period;
        public bool standingWave;
        public float waveLength;

        public float amplitudeEffectRange;
        public float periodEffectRange;

        public float amplitudeEffectSpeed;
        public float periodEffectSpeed;

        [HideInInspector]
        public float randomAmplitude;
        [HideInInspector]
        public float randomPeriod;
        [HideInInspector]
        public float xPos;
        [HideInInspector]
        public float yPos;

        public void Initialize()
        {
            xPos = Random.Range(0f, 1000f);
            yPos = Random.Range(0f, 1000f);
        }

        public void EffectUpdate()
        {
            xPos += amplitudeEffectSpeed * 0.01f;
            yPos += periodEffectSpeed * 0.01f;

            randomAmplitude = (Mathf.PerlinNoise(xPos, xPos) - 0.5f) * 2 * amplitudeEffectRange * 0.01f;
            randomPeriod = (Mathf.PerlinNoise(yPos, yPos)) * periodEffectRange * 0.01f;
        }
    }

    private MeshFilter mf;
    private Mesh m;

    private float distanceBetweenPoints;
    public int points;

    private float angle;
    private float triangles;

    public float width, height, tilt;
    public float pointConcetration;

    public int segments;

    public Wave[] waves;

    // Use this for initialization
    void Start()
    {

        mf = this.gameObject.GetComponent<MeshFilter>();
        m = new Mesh();
        mf.mesh = m;

        //RandomEffect
        foreach (Wave wave in waves)
        {
            wave.Initialize();
        }

    }

    // Update is called once per frame
    void Update()
    {
        //RandomEffect
        foreach (Wave wave in waves)
        {
            wave.EffectUpdate();
        }

        //Converting variables
        distanceBetweenPoints = 1 / pointConcetration;
        segments = Mathf.RoundToInt(width / distanceBetweenPoints);
        points = 6 * segments;

        //Declaration verteces
        Vector3[] vertices = new Vector3[points + 2];
        vertices[0] = new Vector3(0, 0, 0);
        vertices[1] = new Vector3(width, 0, 0);

        //Declaration triangles
        int[] tri = new int[points * 3];

        //Moving the vertices
        for (int v = 0; v < points / 3; v++)
        {

            float xPosition = v * distanceBetweenPoints;
            float yPosition = 0;
            if (v % 2 == 0)
            {

                float r = 0;

                for (int i = 0; i < waves.Length; i++)
                {


                    if (waves[i].standingWave)
                    {
                        float wave = (waves[i].randomAmplitude + waves[i].amplitude + Mathf.Sin(2 * Mathf.PI * ((Time.time / waves[i].period + waves[i].randomPeriod) - v * distanceBetweenPoints / waves[i].waveLength)));
                        float opositeWave = (waves[i].randomAmplitude + waves[i].amplitude * Mathf.Sin(2 * Mathf.PI * ((Time.time / waves[i].period + waves[i].randomPeriod) + v * distanceBetweenPoints / waves[i].waveLength)));
                        r += (wave + opositeWave) / 2;
                    }
                    else
                    {
                        r += waves[i].randomAmplitude + waves[i].amplitude * Mathf.Sin(2 * Mathf.PI * ((Time.time / waves[i].period + waves[i].randomPeriod) - (v * distanceBetweenPoints) / waves[i].waveLength)) + height;
                    }

                }
                yPosition = r / (float)waves.Length + (float)height;
                vertices[v] = new Vector3(xPosition + tilt, yPosition, 0);
            }
            else
            {
                vertices[v] = new Vector3(xPosition - distanceBetweenPoints, 0, 0);
            }

        }

        //Assigning vertices to triangles
        for (int t = 0; t < points; t++)
        {
            if (t % 3 == 0)
            {
                if ((t / 3) % 2 == 1)
                    tri[t] = t / 3 + 1;
                else
                    tri[t] = t / 3;
            }
            if (t % 3 == 1)
            {
                tri[t] = (t + 5) / 3;
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