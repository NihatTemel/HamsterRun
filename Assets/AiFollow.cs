using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform camera;

    // Bu de�i�ken, takip etme h�z�n� belirleyecek
    public float followSpeed = 1.0f;

    void Update()
    {
        // Takip edilecek objenin konumunu al
        Vector3 targetPos = target.position;

        // Kameran�n mevcut konumunu al ve takip edilecek objenin konumuna g�re g�ncelle
        Vector3 cameraPos = camera.position;
        cameraPos.x = targetPos.x;
        cameraPos.z = targetPos.z;

        // Kameran�n konumunu, takip etme h�z�na g�re yumu�ak bir �ekilde g�ncelle
        camera.position = Vector3.Lerp(camera.position, cameraPos, followSpeed * Time.deltaTime);
    }
}
