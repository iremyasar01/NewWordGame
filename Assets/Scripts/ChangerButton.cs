using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChangerButton : MonoBehaviour

{
    public List<Transform> buttons;
    public List<string> Letters;
    public List<int> index;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void rand()
    {
        int i;
        index.Clear();
        for (i = 0; i < Letters.Count; i++)
        {
            index.Add(-1);
        }
        i = 0;
        while (true)
        {
            if (i == Letters.Count)
            {
                break;
            }
            int ran = Random.Range(0, Letters.Count);
            int num = 0;
            for (int j = 0; j < Letters.Count; j++)
            {
                if (index[j] == ran)
                {
                    num++;
                    break;
                }

            }
            if (num > 0)
            {
                continue;
            }
            else
            {
                index[i] = ran;
                i++;
            }
        }
        for (i = 0; i < Letters.Count; i++)
        {
            buttons[i].GetComponent<TextMeshPro>().text = Letters[index[i]];
        }
    }
    public void OnMouseDown()
    {
        rand();
    }
}
