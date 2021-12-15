using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody2D RB;
    public Animator AC;
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float jumpPower = 5.0f;

    private bool isJump = false;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();

        RB.velocity = new Vector2(4 * speed, RB.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Instance.ItemCountInc(other.gameObject);

        if(other.gameObject.CompareTag("F"))
        {
            UIManager.Instance.DecHeart(GameManager.Instance.GetHeartCount());

            if (GameManager.Instance.GetHeartCount() == 3)
                GameManager.Instance.GameOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJump = false;
            if (!AC.GetBool("IsGround"))
                AC.SetBool("IsGround", true);
        }
        if (collision.gameObject.CompareTag("EndGround"))
            GameManager.Instance.GameClear();
    }

    public void Jump()
    {
        if(!isJump)
        {
            RB.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            isJump = true;
            AC.SetBool("IsGround", false);
        }
    }
}
