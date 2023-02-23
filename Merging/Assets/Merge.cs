using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merge : MonoBehaviour
{
    public GameObject Obj;
    public Transform parent;
    public bool CanMerge = false;
    private void OnMouseDrag() 
    {
        Vector3 MousePos= new Vector3(Input.mousePosition.x,Input.mousePosition.y, -Camera.main.transform.position.z + transform.position.z);
        Vector3 obJPos = Camera.main.ScreenToWorldPoint(MousePos);
        transform.position = obJPos;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.GetComponentInParent<item>() !=null)
        {
            CanMerge = true;
            if(CanMerge)
            {
                GameObject Go = Instantiate(Obj,parent.transform.position,parent.transform.rotation);
                Destroy(other.gameObject);

            }
        }
    }
}
