using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count : MonoBehaviour
{
    public Text textField;
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        textField.text = count.ToString();
    }

    private void Update()
    {

        textField.text = count.ToString();
    }

    public void CountButton()
    {
        count++;
    }
}