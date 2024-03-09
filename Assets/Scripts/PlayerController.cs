using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] InputActionReference moveActionToUse;
    [SerializeField] float speed = 1;
    [SerializeField] GameObject losePanel;

    void Start()
    {
        #if UNITY_EDITOR
            GameObject.Find("PlatformText").GetComponent<TMP_Text>().text = "Platform: Unity Editor";
        #elif UNITY_STANDALONE_WIN
            GameObject.Find("PlatformText").GetComponent<TMP_Text>().text = "Platform: Windows";
        #elif UNITY_ANDROID
            GameObject.Find("PlatformText").GetComponent<TMP_Text>().text = "Platform: Android";
        #endif
    }

    void Update()
    {
        Vector2 moveDirection = moveActionToUse.action.ReadValue<Vector2>();
        GetComponent<CharacterController>().SimpleMove(moveDirection * speed);

        #if UNITY_EDITOR
            GetComponent<CharacterController>().SimpleMove(Vector3.right * speed * Input.GetAxis("Horizontal"));
        #elif UNITY_STANDALONE_WIN
            GetComponent<CharacterController>().SimpleMove(Vector3.right * speed * Input.GetAxis("Horizontal"));
        #elif UNITY_ANDROID
        #endif
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            Time.timeScale = 0;
            losePanel.SetActive(true);
            Destroy(gameObject);
        }
    }   
}