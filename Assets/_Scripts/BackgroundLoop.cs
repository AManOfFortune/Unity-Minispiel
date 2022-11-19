using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{
    public GameObject[] levels;
    private Camera mainCamera;
    private Vector2 screenBounds;
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
        foreach(GameObject myObject in levels)
        {
            loadChildObjects(myObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void loadChildObjects(GameObject myObject)
    {
        float objectWidth = myObject.GetComponent<SpriteRenderer>().bounds.size.x;
        int childsNeeded = (int)Mathf.Ceil(screenBounds.x * 2 / objectWidth);
        GameObject clone = Instantiate(myObject) as GameObject;
        for(int i=0; i<=childsNeeded; i++)
        {
            GameObject myClone = Instantiate(clone) as GameObject;
            myClone.transform.SetParent(myObject.transform);
            myClone.transform.position = new Vector3(objectWidth * i, myObject.transform.position.y, myObject.transform.position.z);
            myClone.name = myObject.name + i;
        }
        Destroy(clone);
        Destroy(myObject.GetComponent<SpriteRenderer>());
    }

    void repositionChildObjects(GameObject myObject)
    {
        Transform[] children = myObject.GetComponentsInChildren<Transform>();
        if(children.Length > 1)
        {
            GameObject firstChild = children[1].gameObject;
            GameObject lastChild = children[children.Length - 1].gameObject;
            float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x;
            if(transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth)
            {
                firstChild.transform.SetAsLastSibling();
                firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
            } 
            else if(transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth) 
            {
                lastChild.transform.SetAsFirstSibling();
                lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
            }

        }
    }

    private void LateUpdate()
    {
        foreach(GameObject myObject in levels)
        {
            repositionChildObjects(myObject);
        }
    }
}
