using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asakuma
{
    [CreateAssetMenu(menuName = "Items/Consumables/Flask")]
    public class FlaskItem : ConsumableItem
    {
        [Header("Flask Type")]
        public bool estusFlask;
        public bool ashenFlask;

        [Header("Recoverry Amount")]
        public int healthRecoverAmount;
        public int focusPointsRecoverAmount;

        [Header("Recovery FX")]
        public GameObject recoveryFX;

        public override void AttemptToConsumeItem
            (PlayerAnimatorManager playerAnimatorManager, WeaponSlotManager weaponSlotManager, PlayerEffectsManager playerEffectsManager)
        {
            base.AttemptToConsumeItem(playerAnimatorManager, weaponSlotManager, playerEffectsManager);
            GameObject flask = Instantiate(itemModel, weaponSlotManager.rightHandSlot.transform);


            //  �̗͂��񕜂���FX�Đ�
            playerEffectsManager.currentParticleFX = recoveryFX;
            playerEffectsManager.amountBeHealed = healthRecoverAmount;

            //  �t���X�R���������C���X�^���X�����ăh�����Nanim�Đ�
            playerEffectsManager.instantiatedFXModel = flask;
            weaponSlotManager.rightHandSlot.UnloadWeapon();

            //  �q�b�g�����Ɉ���ł���ꍇ��/��FX���Đ�����
        }
    }
}