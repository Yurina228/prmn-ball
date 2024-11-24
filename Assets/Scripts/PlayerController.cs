using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed; // 動く速さ
    public TextMeshProUGUI scoreText; // スコアの UI
    public TextMeshProUGUI winText; // リザルトの UI
    public Vector3 warpPosition; // ワープ先の位置

    private Rigidbody rb; // Rididbody
    private int score; // スコア

    public AudioSource audioSource; // 効果音用のAudio Source
    public AudioClip soundEffect;   // 再生したい効果音

    void Start()
    {
        // Rigidbody を取得
        rb = GetComponent<Rigidbody>();

        // UI を初期化
        score = 0;
        SetCountText();
        winText.text = "";
    }

    void Update()
    {
        // カーソルキーの入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        // カーソルキーの入力に合わせて移動方向を設定
        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        // Ridigbody に力を与えて玉を動かす
        rb.AddForce(movement * speed);


        // バックスペースキーが押されたときにワープする
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            WarpToPosition();
        }

        
    }

    // 玉が他のオブジェクトにぶつかった時に呼び出される
    void OnTriggerEnter(Collider other)
    {
        // ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("Pick Up"))
        {
            // その収集アイテムを非表示にします
            other.gameObject.SetActive(false);

            // スコアを加算します
            score = score + 1;

            // UI の表示を更新します
            SetCountText ();
        }
    }

    // UI の表示を更新する
    void SetCountText()
    {
        // スコアの表示を更新
        scoreText.text = "Count: " + score.ToString();

        // すべての収集アイテムを獲得した場合
        if (score >= 1)
        {
            // リザルトの表示を更新
            winText.text = "You Win!";

            // 効果音を再生
            audioSource.PlayOneShot(soundEffect);
        
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