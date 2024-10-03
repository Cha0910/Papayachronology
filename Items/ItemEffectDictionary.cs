using System;
using System.Collections.Generic;
using 파파야연대기.Classes;

namespace 파파야연대기.Items
{
    public class ItemEffectDictionary
    {
        public static Dictionary<int, Action> ItemEffects;
        private Player player;

        public ItemEffectDictionary(Player _player)
        {
            player = _player;
            ItemEffects = new Dictionary<int, Action>();
            ItemEffects.Add(2001, () => HealingPotion());
            ItemEffects.Add(2002, () => Meat());
            ItemEffects.Add(2003, () => Salmon());
            ItemEffects.Add(2004, () => Honey());
            ItemEffects.Add(2005, () => Barrel());
            ItemEffects.Add(2006, () => RedMedicine());
            ItemEffects.Add(2007, () => BlueMedicine());
            ItemEffects.Add(2008, () => GreenMedicine());
            ItemEffects.Add(2009, () => Hinor());
            ItemEffects.Add(2010, () => Water());
        }

        private void HealingPotion()
        {
            player.Heal(10);
        }

        private void Meat()
        {
            player.Heal(5);
        }

        private void Salmon()
        {
            player.Heal(10);
        }

        private void Honey()
        {
            player.Heal(10);
        }

        private void Barrel()
        {
            player.Heal(15);
        }

        private void RedMedicine()
        {
            player.Strength += 2;
        }
        private void BlueMedicine()
        {
            player.Dexterity += 2;
        }

        private void GreenMedicine()
        {
            player.Stamina += 2;
        }

        private void Hinor()
        {
            player.subMaximumHP(10);
            player.Strength += 3;
            player.Dexterity += 3;
        }

        private void Water()
        {
            player.Heal(15);
        }
    }
}
