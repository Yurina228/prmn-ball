using UnityEngine;

public class Rotator : MonoBehaviour
{
    // 回転速度を指定するためのパブリック変数
    public Vector3 rotationSpeed = new Vector3(15, 30, 45);

    void Update()
    {
        // 指定された速度で回転
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}