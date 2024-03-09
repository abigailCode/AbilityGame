using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMobileControls : MonoBehaviour
{
    [SerializeField] GameObject mobilePanel;

    // Start is called before the first frame update
    void Start()
    {
        #if UNITY_ANDROID
            mobilePanel.SetActive(true);
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
