using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyControl : MonoBehaviour
{
    [SerializeField] private float scrollSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private GameObject map1, map2;
    private float targetXPoint;
    private float targetYPoint;

    private void Start()
    {
        map1 = GameObject.Find("map1");
        map2 = GameObject.Find("map2");
        targetXPoint = transform.position.x;
        targetYPoint = transform.position.y;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,0,moveSpeed*Time.deltaTime);
        CheckControl();       
        MoveToPoint();
    }
    void MoveToPoint()
    {
        transform.position = new Vector3(Mathf.MoveTowards(transform.position.x, targetXPoint, scrollSpeed), Mathf.MoveTowards(transform.position.y, targetYPoint, scrollSpeed), transform.position.z);
    }
    void CheckControl()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            switch (transform.position.x)
            {
                case 80:
                    targetXPoint = 40f;
                    break;
                case 120:
                    targetXPoint = 80f;
                    break;
                default:
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            switch (transform.position.x)
            {
                case 40:
                    targetXPoint = 80f;
                    break;
                case 80:
                    targetXPoint = 120f;
                    break;
                default:
                    break;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            switch (transform.position.y)
            {
                case 10:
                    targetYPoint = 30f;
                    break;
                case 30:
                    targetYPoint = 50f;
                    break;
                default:
                    break;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            switch (transform.position.y)
            {
                case 30:
                    targetYPoint = 10f;
                    break;
                case 50:
                    targetYPoint = 30f;
                    break;
                default:
                    break;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="point")
        {
            other.GetComponent<MeshRenderer>().enabled = false;
        }
        if (other.name=="map1")
        {
            other.transform.position = new Vector3(other.transform.position.x,other.transform.position.y,map2.transform.position.z+1000f);
            PointCreator.instance.CreateLinePoint(map2.transform.position.z+1000f,0);
        }
        else if(other.name == "map2")
        {
            other.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, map1.transform.position.z + 1000f);
            PointCreator.instance.CreateLinePoint(map1.transform.position.z + 1000f, 1);
        }
    }    
}
