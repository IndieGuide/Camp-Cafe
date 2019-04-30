using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]

public class CircleWaveMeshWithEffect : MonoBehaviour
{


    [System.Serializable]
    public class Wave
    {

        public float amplitude;
        public float period;
        public int Tops;
        public bool standingWave;

        public float amplitudeEffectRange;
        public float periodEffectRange;

        public float amplitudeEffectSpeed;
        public float periodEffectSpeed;

        [HideInInspector]
        public float waveLength;
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

        public void RecaulculateWaveLength()
        {
            waveLength = 1 / (float)Tops;
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

    public int points;
    public float radius;

    private float angle;
    private float triangles;

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
            wave.RecaulculateWaveLength();
            wave.EffectUpdate();
        }

        //Converting variables
        angle = 2 * Mathf.PI / (points - 2);
        triangles = points - 2;

        //Declaration verteces
        Vector3[] vertices = new Vector3[points];
        vertices[0] = new Vector3(0, 0, 0);

        //Declaration triangles
        int[] tri = new int[(points - 2) * 3];

        //Moving the vertices
        for (int v = 1; v < points; v++)
        {
            float r = 0;

            for (int i = 0; i < waves.Length; i++)
            {
                if (waves[i].standingWave)
                {
                    float wave = waves[i].randomAmplitude + waves[i].amplitude * Mathf.Sin((Time.time / waves[i].period + waves[i].randomPeriod) + (v * angle) / waves[i].waveLength);
                    float opositeWave = waves[i].randomAmplitude + waves[i].amplitude * Mathf.Sin((Time.time / waves[i].period + waves[i].randomPeriod) - (v * angle) / waves[i].waveLength);
                    r += (wave + opositeWave) / 2;
                }
                else
                {
                    r += waves[i].randomAmplitude + waves[i].amplitude * Mathf.Sin((Time.time / waves[i].period + waves[i].randomPeriod) - (v * angle) / waves[i].waveLength);
                }
            }

            r = r / waves.Length + radius;


            vertices[v] = new Vector3(Mathf.Sin(angle * v) * r, Mathf.Cos(angle * v) * r, 0);
        }

        //Calculating triangles
        for (int t = 0; t < triangles * 3; t++)
        {
            if (t % 3 == 0)
            {
                tri[t] = 0;
            }

            if (t % 3 == 1)
            {
                tri[t] = (t + 2) / 3;
            }

            if (t % 3 == 2)
            {
                tri[t] = ((t + 1) / 3) + 1;
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
