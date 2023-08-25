using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Rendering;
using TMPro;

public class LineControl : MonoBehaviour
{

   
    public LineRenderer lineRenderer;
    public List<Transform> selectedLetters = new List<Transform>();
    public GameObject lettersText;


    private void Update()
    {
        if(Input.GetMouseButton(0))

        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.CompareTag("Letter") )
            {
                if (selectedLetters.Contains(hit.transform) == false)
                {

                    selectedLetters.Add(hit.transform);


                    UpdateLineRenderer();
                }
            }

        }


        if (Input.GetMouseButtonUp(0))
        {
            ClearSelectedLetters();
        }
    }

    public void UpdateLineRenderer()
    {
        lineRenderer.positionCount = selectedLetters.Count;
        for (int i = 0; i < selectedLetters.Count; i++)
        {
        
            lineRenderer.SetPosition(i, selectedLetters[i].position);
        }
    }

    public void ClearSelectedLetters()
    {
        // Kelimeyi kabul edebilirsiniz veya işleme göre geçerli seçimi temizleyebilirsiniz.
        selectedLetters.Clear();
        lineRenderer.positionCount = 0;
    }

}
