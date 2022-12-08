using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] Transform camera;

    // Bu deðiþken, takip etme hýzýný belirleyecek
    public float followSpeed = 1.0f;

    void Update()
    {
        // Takip edilecek objenin konumunu al
        Vector3 targetPos = target.position;

        // Kameranýn mevcut konumunu al ve takip edilecek objenin konumuna göre güncelle
        Vector3 cameraPos = camera.position;
        cameraPos.x = targetPos.x;
        cameraPos.z = targetPos.z;

        // Kameranýn konumunu, takip etme hýzýna göre yumuþak bir þekilde güncelle
        camera.position = Vector3.Lerp(camera.position, cameraPos, followSpeed * Time.deltaTime);
    }
}
