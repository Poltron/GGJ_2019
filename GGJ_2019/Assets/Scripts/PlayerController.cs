using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Player
{
    Player1,
    Player2
}

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float Speed;
    private Rigidbody _rigidBody;

    [SerializeField] private Player m_PlayerNumber;
    private List<Item> items;

    public bool IsActive;

    private Vector2 m_Velocity;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        items = new List<Item>();
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        Debug.Log(gameObject.name + " died.");
        items.Remove(item);

        if (items.Count == 0)
        {
            GameManager.Instance.PlayerLost(this);
        }
    }

    public void PlayerDied()
    {
        Debug.Log(gameObject.name + " died.");
        GameManager.Instance.PlayerLost(this);
    }

    private void Update()
    {
        m_Velocity = new Vector2();

        if (m_PlayerNumber == Player.Player1)
        {
            m_Velocity.x = Input.GetAxisRaw("Horizontal1");
            m_Velocity.y = Input.GetAxisRaw("Vertical1");
        }
        else
        {
            m_Velocity.x = Input.GetAxisRaw("Horizontal2");
            m_Velocity.y = Input.GetAxisRaw("Vertical2");
        }

        m_Velocity.Normalize();
    }

    private void FixedUpdate()
    {
        if (!IsActive)
            return;

        Vector3 movement = new Vector3(m_Velocity.x, 0, m_Velocity.y) * Speed * Time.deltaTime;

        _rigidBody.velocity = Vector3.zero;
        _rigidBody.AddForce(movement);
    }
}
