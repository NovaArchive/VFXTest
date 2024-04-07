using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.VFX;

[Serializable]
public class SlashTrailSetting
{
    public string name;
    public float duration = 0.2f;
    public float size = 1.5f;
    [ColorUsageAttribute(true,true)]
    public Color color;
}

public class ReaperController : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private VisualEffect weaponTrailEffect;
    [SerializeField] private List<SlashTrailSetting> trailSettings;
    
    [Header("Projectile")]
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private Transform shootPoint;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Pressed Melee");
            animator.SetTrigger("Melee");
        }

        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Pressed Ranged");
            animator.SetTrigger("Ranged");
        }
    }

    public void StartSlash(string settingName)
    {
        SlashTrailSetting setting = trailSettings.Find(s => s.name == settingName);
        if (setting == null) return;
        
        weaponTrailEffect.SetVector4("OuterColor", setting.color);
        weaponTrailEffect.SetFloat("SlashSize", setting.size);
        weaponTrailEffect.SetFloat("SlashDuration", setting.duration);
        
        weaponTrailEffect.gameObject.SetActive(true);
        weaponTrailEffect.Play();
        DOVirtual.DelayedCall(setting.duration, () => weaponTrailEffect.gameObject.SetActive(false));
    }

    public void ShootProjectile()
    {
        Projectile projectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
        projectile.Init(shootPoint.forward);
    }
}
