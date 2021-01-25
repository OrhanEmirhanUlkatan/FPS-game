using System.Collections;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int _maximumHealth = 100;

    int _currentHealth = 0;

    override public string ToString()
    {
        return _currentHealth + " / " + _maximumHealth;
    }

    public bool IsDead { get { return _currentHealth <= 0; } }

    Renderer _renderer;

    PlayerStats _playerStats;

    void Start()
    {
        _renderer = GetComponentInChildren<Renderer>();
        _currentHealth = _maximumHealth;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        _playerStats = player.GetComponent<PlayerStats>();
    }

    public void Damage(int damageValue)
    {
        _currentHealth -= damageValue;

        if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }

        if (_currentHealth == 0)
        {
            Animation a = GetComponentInChildren<Animation>();
            a.Stop();

            if (tag == "Player")
            {
                Destroy(GetComponent<PlayerMovement>());
                Destroy(GetComponent<PlayerAnimation>());
                Destroy(GetComponent<RifleWeapon>());
            }
            else // its an enemy
            {
                _playerStats.ZombiesKilled++;
                EnemySpawnManager.OnEnemyDeath();
                Destroy(GetComponent<EnemyMovement>());
                Destroy(GetComponentInChildren<EnemyAttack>());
            }

            Destroy(GetComponent<CharacterController>());

            Ragdoll r = GetComponent<Ragdoll>();
            if (r != null)
            {
                r.OnDeath();
            }
        }
    }

    void Update()
    {
        if (IsDead && !_renderer.isVisible)
        {
            Destroy(gameObject);
        }
    }
}