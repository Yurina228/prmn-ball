using UnityEngine;

public class RespawnController : MonoBehaviour
{
    public Vector3 warpPosition; // ワープ先の位置
    public float respawnHeight = -10.0f; // この高さより低くなったらワープ
    private Rigidbody rb; // Rididbody


    void Start()
    {
        // Rigidbody を取得
        rb = GetComponent<Rigidbody>();

        // 出現位置を初期化
        warpPosition = transform.position;
    }

    void Update()
    {
        // スペースキーが押されたときにワープする
        if (transform.position.y < respawnHeight)
        {
            WarpToPosition();
        }
    }

    

    // 指定された位置にワープする
    void WarpToPosition()
    {
        rb.velocity = Vector3.zero; // ワープ前に速度をリセット
        rb.angularVelocity = Vector3.zero; // 回転速度もリセット
        transform.position = warpPosition; // 指定した位置に移動
    }
}