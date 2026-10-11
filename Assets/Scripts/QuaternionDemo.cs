using UnityEngine;
using TMPro;

/// <summary>
/// Quaternion rotation demo script
/// Mount on DemoManager
/// Function: Drag mouse to rotate cube, display quaternion and euler angles
/// </summary>
public class QuaternionDemo : MonoBehaviour
{
    [Header("Target Object to Rotate")]
    public Transform targetObj;

    [Header("TMP Text for Info Display")]
    public TMP_Text infoText;

    private Vector2 lastMousePosition;

    void Start()
    {
        lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector2 mouseDelta = (Vector2)Input.mousePosition - lastMousePosition;

            float rotateY = mouseDelta.x * 0.5f;
            float rotateX = -mouseDelta.y * 0.5f;

            Quaternion deltaRotation = Quaternion.Euler(rotateX, rotateY, 0);
            targetObj.rotation = deltaRotation * targetObj.rotation;
        }
        lastMousePosition = Input.mousePosition;

        Quaternion currentQuat = targetObj.rotation;
        Vector3 currentEuler = currentQuat.eulerAngles;

        infoText.text =
            $"===== QUATERNION DEMO =====\n" +
            $"Quaternion Q:\n" +
            $"x:{currentQuat.x:F3}, y:{currentQuat.y:F3}\n" +
            $"z:{currentQuat.z:F3}, w:{currentQuat.w:F3}\n\n" +
            $"Euler Angles:\n" +
            $"X:{currentEuler.x:F1}бу, Y:{currentEuler.y:F1}бу, Z:{currentEuler.z:F1}бу";
    }
}
