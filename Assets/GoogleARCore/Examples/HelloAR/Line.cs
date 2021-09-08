using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UIElements;

public class Line : MonoBehaviour
{
    public LineRenderer line;
    public List<GameObject> lines;
    LineRenderer activeLine;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
    }
    bool active;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && !active)
        {
            activeLine = Instantiate(line);
            lines.Add(activeLine.gameObject);
            active = true;
            Debug.Log(active);
        }
        else if (Input.GetMouseButtonUp(0))
        {

            active = false;
            Debug.Log(active);
        }
        if (Input.GetMouseButton(0) && active)
        {
            activeLine.positionCount++;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            Debug.Log(hit.transform.name);
            activeLine.SetPosition(activeLine.positionCount - 1, hit.point);

        }



    }
    public void Reset()
    {
        for (int i = 0; i < lines.Count; i++)
        {
            Destroy(lines[i]);
        }

    }

}

