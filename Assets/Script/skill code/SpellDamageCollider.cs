using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SG
{
    
    public class SpellDamageCollider : DamageCollider
    {
        public GameObject impactParticles;
        public GameObject projectileParticles;
        public GameObject muzzleParticales;

        bool hasCollided = false;

        CharacterStats spellTarget;
        Rigidbody rigidbody;

        Vector3 impactNormal;

        private void Awake()
        {
            rigidbody = GetComponent<Rigidbody>();
        }

        private void Start()
        {
            projectileParticles = Instantiate(projectileParticles, transform.position, transform.rotation);
            projectileParticles.transform.parent = transform;

            if (muzzleParticales)
            {
                muzzleParticales = Instantiate(muzzleParticales, transform.position, transform.rotation);
                Destroy(muzzleParticales, 2f);
            }
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!hasCollided)
            {
                spellTarget = other.transform.GetComponent<CharacterStats>();

                if (spellTarget != null)
                {
                    spellTarget.TakeDamage(currentWeaponDamage);
                }
                hasCollided = true;
                impactParticles = Instantiate(impactParticles, transform.position, Quaternion.FromToRotation(Vector3.up, impactNormal));

                Destroy(impactParticles);
                Destroy(impactParticles, 2f);
                Destroy(gameObject, 2f);
            }
        }
    }
}
