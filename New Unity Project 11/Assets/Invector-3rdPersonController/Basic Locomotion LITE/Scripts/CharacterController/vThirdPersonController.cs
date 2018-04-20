using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Invector.CharacterController
{
    public class vThirdPersonController : vThirdPersonAnimator
    {
        public float Health = 100f;
        public Button sprintBtn;

        protected virtual void Start()
        {
#if !UNITY_EDITOR
                Cursor.visible = false;
#endif
        }

        protected virtual void Update()
        {
            if (Health <= 0f)
            {
                Health = 0f;
                Death();
            }
            else if (Health <= 75f && Health >= 30f)
            {
                // поменять анимацию на еле ходящего
            }
            else
            {
                // поменять анимацию на ползающего 
            }
        }

        private void Death()
        {
            GameManager.Instance.PlayerDeath(this.gameObject);
        }

        public void DoDamage(float damage)
        {
            Debug.Log(string.Format("DoDamage. {0} - {1} = {2}", Health, damage, Health - damage));

            Health -= damage;
        }

        public void SprintButtonClick()
        {
            isSprinting = !isSprinting;

            if (isSprinting)
                sprintBtn.GetComponentInChildren<Text>().text = "Sprint ON";
            else
                sprintBtn.GetComponentInChildren<Text>().text = "Sprint OFF";
        }

        public virtual void Sprint(bool value)
        {                                   
            isSprinting = value;            
        }

        public virtual void Strafe()
        {
            if (locomotionType == LocomotionType.OnlyFree) return;
            isStrafing = !isStrafing;
        }

        public virtual void Jump()
        {
            // conditions to do this action
            bool jumpConditions = isGrounded && !isJumping;
            // return if jumpCondigions is false
            if (!jumpConditions) return;
            // trigger jump behaviour
            jumpCounter = jumpTimer;            
            isJumping = true;
            // trigger jump animations            
            if (_rigidbody.velocity.magnitude < 1)
                animator.CrossFadeInFixedTime("Jump", 0.1f);
            else
                animator.CrossFadeInFixedTime("JumpMove", 0.2f);
        }

        public virtual void RotateWithAnotherTransform(Transform referenceTransform)
        {
            var newRotation = new Vector3(transform.eulerAngles.x, referenceTransform.eulerAngles.y, transform.eulerAngles.z);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(newRotation), strafeRotationSpeed * Time.fixedDeltaTime);
            targetRotation = transform.rotation;
        }
    }
}