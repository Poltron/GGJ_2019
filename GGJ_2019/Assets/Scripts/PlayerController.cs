using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Player
{
    Player1,
    Player2
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Rigidbody _rigidBody;
    private Transform _transform;

    [SerializeField] private Transform _mesh;
    [SerializeField] private ParticleSystem _deathFX;

    [SerializeField] private Player m_PlayerNumber;
    private List<Item> items;

    public bool IsActive;

    private Vector2 m_Velocity;

    private PlayerSounds m_PlayerSounds;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _transform = transform;

        items = new List<Item>();
        IsActive = false;
        m_PlayerSounds = gameObject.GetComponent<PlayerSounds>();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        Debug.Log(gameObject.name + "object died");
        items.Remove(item);
        Destroy(item.gameObject);

        if (items.Count == 1)
        {
            items[0].GetComponentInChildren<Animator>().SetTrigger("LastItem");
        }
        else if (items.Count == 0)
        {
            GameManager.Instance.PlayerLost(this);
            Debug.Log(gameObject.name + " died By No Items.");
        }
    }

    public void PlayerDied()
    {
        Debug.Log(gameObject.name + " died.");

        m_PlayerSounds.PlayPlayerDeathSound();
        _deathFX.Play();

        GameManager.Instance.PlayerLost(this);
    }

    private void Update()
    {
        if (!IsActive)
            return;

        m_Velocity = new Vector2();

        if (m_PlayerNumber == Player.Player1)
        {
            m_Velocity.x = Input.GetAxisRaw("Horizontal1");
            m_Velocity.y = Input.GetAxisRaw("Vertical1");
        }
        else
        {
            if (!GameManager.Instance.SharedController)
            {
                m_Velocity.x = Input.GetAxisRaw("Horizontal2");
                m_Velocity.y = Input.GetAxisRaw("Vertical2");
            }
            else
            {
                m_Velocity.x = Input.GetAxisRaw("Horizontal2Shared");
                m_Velocity.y = Input.GetAxisRaw("Vertical2Shared");
            }
        }

        m_Velocity.Normalize();

        transform.LookAt(transform.position + new Vector3(m_Velocity.x, 0, m_Velocity.y));
    }

    private void FixedUpdate()
    {
        if (!IsActive)
        {
            _rigidBody.velocity = Vector3.zero;
            return;
        }
        Vector3 movement = new Vector3(m_Velocity.x, 0, m_Velocity.y) * Speed * Time.deltaTime;

        _rigidBody.velocity = Vector3.zero;
        _rigidBody.AddForce(movement);
    }

    public Player GetPlayerNumber()
    {
        return m_PlayerNumber;
    }
}
