using UnityEngine;

public class bullet : MonoBehaviour
{
    public int ownerId = -1;
    public float lifeTime = 2f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // 自分の弾が自分に当たっても無視
        var pc = other.GetComponent<PlayerController2D>();
        if (pc != null && pc.playerId != ownerId)
        {
            // スコア加算
            var gm = FindObjectOfType<gamemanager>();
            if (gm != null) gm.AddPoint(ownerId);

            Destroy(gameObject);
        }
        else
        {
            // 壁等に当たったら消える
            if (!other.isTrigger) Destroy(gameObject);
        }
    }
}
