using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class ModalPanel : MonoBehaviour
{
    public TextMeshProUGUI infotext;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private static ModalPanel modalPanel;

    public static ModalPanel Instance()
    {
        if (!modalPanel)
        {
            modalPanel = FindObjectOfType(typeof(ModalPanel)) as ModalPanel;
            if (!modalPanel)
                Debug.LogError("Besoin d'avoir un panel actif pour fonctionner!");
        }

        return modalPanel;
    }


    public void ClosePanel()
    {
        this.gameObject.SetActive(false);
    }
}
