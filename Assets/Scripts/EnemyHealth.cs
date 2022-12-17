using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public static Action OnEnemyKilled;
    
    [SerializeField] private GameObject healthBarPrefab;
    [SerializeField] private Transform barPosition;
    [SerializeField] private float initialHealth = 10f;
    [SerializeField] private float maxHealth = 10f;

    public float CurrentHealth { get; set; }

    private Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        CreateHealthBar();
        CurrentHealth = initialHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            DealDamage(5f);
            Debug.Log(CurrentHealth);
        }
        healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, CurrentHealth / maxHealth, Time.deltaTime * 1f);
    }
    // Update is called once per frame
    private void CreateHealthBar()
    {
        GameObject newBar = Instantiate(healthBarPrefab, barPosition.position, Quaternion.identity);
        newBar.transform.SetParent(transform);

        EnemyHealthContainer container = newBar.GetComponent<EnemyHealthContainer>();
        healthBar = container.FillAmountImage;
    }

    public void DealDamage(float damageRecieved)
    {
        CurrentHealth -= damageRecieved;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
        }
    }
    public void ResetHealth()
    {
        CurrentHealth = initialHealth;
        healthBar.fillAmount = 1f;
    }
    private void Die()
    {
        ResetHealth();
        OnEnemyKilled?.Invoke();
        ObjectPooler.ReturnToPool(gameObject);
    }
}
