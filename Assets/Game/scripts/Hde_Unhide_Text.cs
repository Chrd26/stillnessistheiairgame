using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Hde_Unhide_Text : MonoBehaviour
{
    //Get Text Mesh Pro Component REMEMBER TO USE TMPro in the included files.
    private TMP_Text getText;
    // Start is called before the first frame update
    void Start()
    {
        getText = GetComponent<TMP_Text>();
        getText.fontSize = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isLookingAtInteractable)
        {
            getText.fontSize = 12;
        }
        else
        {
            getText.fontSize = 0;
        }
        
    }
}
