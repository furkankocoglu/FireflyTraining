using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCreator : MonoBehaviour
{
    [SerializeField] private GameObject pointPrefab;
    [SerializeField] private float destroyerSpeed = 10f;
    [SerializeField] private GameObject lineRenderer1,lineRenderer2;
    float[] xPoint = { 40f, 80f, 120f }, yPoint = { 10f, 30f, 50f };
    float zPoint = 30f;
    public static PointCreator instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {        
        for (int i = 0; i < 100; i++)
        {
            Instantiate(pointPrefab, CreateNewPosition(), Quaternion.identity);            
        }
        CreateLinePoint(0,0);
        CreateLinePoint(1000,1);
    }
   
    private void Update()
    {
        transform.Translate(0, 0, destroyerSpeed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "point")
        {
            if (!other.GetComponent<MeshRenderer>().enabled)
            {
                other.GetComponent<MeshRenderer>().enabled = true;
            }
            other.transform.position = CreateNewPosition();
        }
    }
    Vector3 CreateNewPosition()
    {
        Vector3 newVector = new Vector3(xPoint[Random.Range(0, 3)], yPoint[Random.Range(0, 3)], zPoint);        
        zPoint += 10f;
       
        return newVector;
    }
    public void CreateLinePoint(float lineZPoint,int index)
    {
        if (index==0)
        {
            LineRenderer lr = lineRenderer1.GetComponent<LineRenderer>();
            lr.startWidth = 3f;
            lr.endWidth = 3f;
            for (int i = 0; i < 100; i++)
            {
                lr.SetPosition(i, new Vector3(xPoint[Random.Range(0, 3)], yPoint[Random.Range(0, 3)], lineZPoint));
                lineZPoint += 10f;
            }
            MeshCollider lineMeshCollider = lineRenderer1.GetComponent<MeshCollider>();
            Mesh mesh = new Mesh();
            lr.BakeMesh(mesh, true);
            lineMeshCollider.sharedMesh = mesh;
        }
        else
        {
            LineRenderer lr = lineRenderer2.GetComponent<LineRenderer>();
            lr.startWidth = 3f;
            lr.endWidth = 3f;
            for (int i = 0; i < 100; i++)
            {
                lr.SetPosition(i, new Vector3(xPoint[Random.Range(0, 3)], yPoint[Random.Range(0, 3)], lineZPoint));
                lineZPoint += 10f;
            }

            MeshCollider lineMeshCollider = lineRenderer2.GetComponent<MeshCollider>();
            Mesh mesh = new Mesh();
            lr.BakeMesh(mesh, true);
            lineMeshCollider.sharedMesh = mesh;
        }

        
    }
}
