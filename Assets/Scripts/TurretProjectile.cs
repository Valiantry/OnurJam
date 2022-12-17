using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TurretProjectile : MonoBehaviour
{
    [SerializeField] private Transform projectileSpawnPosition;
    [SerializeField] private float delayBtwAttacks = 2f;

    private float _nextAttackTime;
    private ObjectPooler _pooler;
    private Turret _turret;
    private Projectile _currentProjectileLoaded;
    private void Start()
    {
        _turret = GetComponent<Turret>();
        _pooler = GetComponent<ObjectPooler>();
        LoadProjectile();
    }
    private void Update()
    {
        if (IsTurretEmpty())
        {
            LoadProjectile();
        }
        if (Time.time > _nextAttackTime)
        {
            if (_turret.CurrentEnemyTarget != null && _currentProjectileLoaded != null && _turret.CurrentEnemyTarget.GetComponent<EnemyHealth>().CurrentHealth > 0f)
            {
                _currentProjectileLoaded.transform.parent = null;
                _currentProjectileLoaded.SetEnemy(_turret.CurrentEnemyTarget);
            }
            _nextAttackTime = Time.time + delayBtwAttacks;
        }

        
    }
    private void LoadProjectile()
    {
        GameObject newInstance = _pooler.GetInstanceFromPool();
        newInstance.transform.localPosition = projectileSpawnPosition.position;
        newInstance.transform.SetParent(projectileSpawnPosition);

        _currentProjectileLoaded = newInstance.GetComponent<Projectile>();
        _currentProjectileLoaded.TurretOwner = this;
        _currentProjectileLoaded.ResetProjectile();

        newInstance.SetActive(true);
    }
    private bool IsTurretEmpty()
    {
        return _currentProjectileLoaded == null;
    }
    public void ResetTurretProjectile()
    {
        _currentProjectileLoaded = null;
    }
   
}

    




