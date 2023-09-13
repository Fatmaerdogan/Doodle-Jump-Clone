using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Platform : MonoBehaviour {

	public PlatformType PlatformType;
	public List<Sprite> Sprites;
	[SerializeField] private SpriteRenderer spriteRenderer;
	[SerializeField] private GameObject Jett;
	float jumpForce = 10f;

    private void Start()
    {
        Jett = transform.GetChild(0).gameObject;
        Movement();
    }
    public void SpriteSet(PlatformType platformType)
	{
        spriteRenderer = GetComponent<SpriteRenderer>();
        PlatformType = platformType;
		spriteRenderer.sprite = Sprites[(int)PlatformType];

        if(PlatformType==PlatformType.jetted)
            Jett.SetActive(true);
	}
    void OnCollisionEnter2D(Collision2D collision)
	{
		switch (PlatformType)
		{
			case PlatformType.standard:
            case PlatformType.movement:
                StandartJump(collision);
				break;
            case PlatformType.broken:
                StandartJump(collision);
                BrokenPlatform();
                break;
            case PlatformType.jetted:
                WearJet(collision);
                break;
        }
        ScoreSet();

    }
    public void ScoreSet()
    {
        int score =(int) transform.position.y * 100;
        GameManager.instance.Score(score);
    }
    private void Movement()
    {
        if (PlatformType == PlatformType.movement)
        {
            transform.DOMove(new Vector3(-4, transform.position.y, transform.position.z), 5).OnComplete(() =>
            {
                transform.DOMove(new Vector3(4, transform.position.y, transform.position.z), 5).OnComplete(() =>
                {
                    Movement();
                });
            });
        }
    }
    void StandartJump(Collision2D collision)
	{
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }
    }
    void BrokenPlatform()
    {
        gameObject.AddComponent<Rigidbody2D>();
    }
    void WearJet(Collision2D collision)
    {
        Jett.transform.parent=collision.transform;
        Jett.transform.localPosition=Vector3.zero;
        collision.collider.GetComponent<Player>().FlyJett();
    }
}
public enum PlatformType { standard=0 , broken=1 , jetted = 2 , movement=3}
