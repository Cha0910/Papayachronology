using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using 파파야연대기.Items;

namespace 파파야연대기.Classes
{
    public class Player : PropertyChangedNotificationClass
    {
        private int maximumHP, currentHP, combatPower, weaponCombatPower, armorCombatPower;
        private int strength, dexterity, stamina, intelligence, wizdom, charm, gold;
        private int numItem = 0;

        public int MaximumHP
        {
            get { return maximumHP; }
            set
            {
                maximumHP = value;
                OnPropertyChanged();
            }
        }
        public int CurrentHP
        {
            get { return currentHP; }
            set
            {
                currentHP = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public int CombatPower
        { 
            get { return combatPower; }
            set 
            {
                combatPower = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public int WeaponCombatPower
        {
            get { return weaponCombatPower; }
            set
            {
                weaponCombatPower = value;
                OnPropertyChanged();
            }
        }

        [JsonIgnore]
        public int ArmorCombatPower
        {
            get { return armorCombatPower; }
            set
            {
                armorCombatPower = value;
                OnPropertyChanged();
            }
        }

        public int Strength
        {
            get { return strength; }
            set
            {
                strength = value;
                OnPropertyChanged();
                updateCombatPower();
            }
        }
        public int Dexterity
        {
            get { return dexterity; }
            set
            {
                dexterity = value;
                OnPropertyChanged();
                updateCombatPower();
            }
        }
        public int Stamina
        {
            get { return stamina; }
            set
            {
                stamina = value;
                OnPropertyChanged();
                updateCombatPower();
            }
        }
        public int Intelligence
        {
            get { return intelligence; }
            set
            {
                intelligence = value;
                OnPropertyChanged();
                updateCombatPower();
            }
        }
        public int Wizdom
        {
            get { return wizdom; }
            set
            {
                wizdom = value;
                OnPropertyChanged();
                updateCombatPower();
            }
        }
        public int Charm
        {
            get { return charm; }
            set
            {
                charm = value;
                OnPropertyChanged();
                updateCombatPower();
            }
        }
        public int Gold
        {
            get { return gold; }
            set
            {
                gold = value;
                OnPropertyChanged();
            }
        }

        private GameItem weaponSlot;
        private GameItem armorSlot;
        public GameItem WeaponSlot
        {
            get { return weaponSlot; }
            set
            {
                weaponSlot = value;
                OnPropertyChanged();
            }
        }

        public GameItem ArmorSlot
        {
            get { return armorSlot; }
            set
            {
                armorSlot = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<GameItem> Inventory { get; set; }

        [JsonIgnore]
        public ObservableCollection<bool> HasItem { get; set; }

        [JsonIgnore]
        public ItemEffectDictionary ItemEffctDictionary;

        public Player()
        {
            Inventory = new ObservableCollection<GameItem>();
            HasItem = new ObservableCollection<bool>();
            ItemEffctDictionary = new ItemEffectDictionary(this);
            for(int i=0; i<16; i++)
                HasItem.Add(false);
        }

        #region ItemManager...
        public void addItem(int itemID)
        {
            if(numItem == 16)
            {
                return;
            }

            Inventory.Add(ItemList.CreateGameItem(itemID));
            HasItem[numItem] = true;
            numItem++;
        }

        public void deleteItem(int index)
        {
            Inventory.RemoveAt(index);
            numItem--;
            HasItem[numItem] = false;
        }

        public void useItem(int index)
        {
            if(Inventory[index].Type == GameItem.ItemType.Consumable || Inventory[index].Type == GameItem.ItemType.Food)
            {
                if (ItemEffectDictionary.ItemEffects.ContainsKey(Inventory[index].ItemID))
                {
                    ItemEffectDictionary.ItemEffects[Inventory[index].ItemID].Invoke();
                    deleteItem(index);
                }
            }

            else if(Inventory[index].Type == GameItem.ItemType.Weapon || Inventory[index].Type == GameItem.ItemType.Armor)
            {
                Equip(index);
            }
            
        }

        public int HasItemindex(int itemID)
        {
            for(int i=0; i<numItem; i++)
            {
                if(Inventory[i].ItemID == itemID)
                {
                    return i;
                }
            }

            return -1;
        }

        public int HasItemindex(GameItem.ItemType itemType)
        {
            for (int i = 0; i < numItem; i++)
            {
                if (Inventory[i].Type == itemType)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Equip(int index)
        {
            if(Inventory[index].Type == GameItem.ItemType.Weapon)
            {
                if (WeaponSlot != null)
                {
                    takeOffWeapon();
                }

                WeaponSlot = ItemList.CreateGameItem(Inventory[index].ItemID);
                updateCombatPower();
                deleteItem(index);
            }

            else if(Inventory[index].Type == GameItem.ItemType.Armor)
            {
                if (ArmorSlot != null)
                {
                    takeOffArmor();
                }

                ArmorSlot = ItemList.CreateGameItem(Inventory[index].ItemID);
                updateCombatPower();
                deleteItem(index);
            }
        }

        public void takeOffWeapon()
        {
            if (WeaponSlot != null)
            {
                addItem(WeaponSlot.ItemID);
                WeaponSlot = null;
                updateCombatPower();
            }
        }

        public void takeOffArmor()
        {
            if (ArmorSlot != null)
            {
                addItem(ArmorSlot.ItemID);
                ArmorSlot = null;
                updateCombatPower();
            }
        }

        public void updateCombatPower()
        {
            if(WeaponSlot == null)
            {
                WeaponCombatPower = 0;
            }

            else if (WeaponSlot.Stat == GameItem.EquipmentStat.Strength)
            {
                WeaponCombatPower = WeaponSlot.DefalutCombatPoint + WeaponSlot.VarianceCombatPoint * Strength;
            }

            else if (WeaponSlot.Stat == GameItem.EquipmentStat.Dexterity)
            {
                WeaponCombatPower = WeaponSlot.DefalutCombatPoint + WeaponSlot.VarianceCombatPoint * Dexterity;
            }

            else if (WeaponSlot.Stat == GameItem.EquipmentStat.Stamina)
            {
                WeaponCombatPower = WeaponSlot.DefalutCombatPoint + WeaponSlot.VarianceCombatPoint * Stamina;
            }

            else if (WeaponSlot.Stat == GameItem.EquipmentStat.Intelligence)
            {
                WeaponCombatPower = WeaponSlot.DefalutCombatPoint + WeaponSlot.VarianceCombatPoint * Intelligence;
            }

            else if (WeaponSlot.Stat == GameItem.EquipmentStat.Wizdom)
            {
                WeaponCombatPower = WeaponSlot.DefalutCombatPoint + WeaponSlot.VarianceCombatPoint * Wizdom;
            }

            else if (WeaponSlot.Stat == GameItem.EquipmentStat.Charm)
            {
                WeaponCombatPower = WeaponSlot.DefalutCombatPoint + WeaponSlot.VarianceCombatPoint * Charm;
            }

            if (ArmorSlot == null)
            {
                ArmorCombatPower = 0;
            }

            else if (ArmorSlot.Stat == GameItem.EquipmentStat.Strength)
            {
                ArmorCombatPower = ArmorSlot.DefalutCombatPoint + ArmorSlot.VarianceCombatPoint * Strength;
            }

            else if (ArmorSlot.Stat == GameItem.EquipmentStat.Dexterity)
            {
                ArmorCombatPower = ArmorSlot.DefalutCombatPoint + ArmorSlot.VarianceCombatPoint * Dexterity;
            }

            else if (ArmorSlot.Stat == GameItem.EquipmentStat.Stamina)
            {
                ArmorCombatPower = ArmorSlot.DefalutCombatPoint + ArmorSlot.VarianceCombatPoint * Stamina;
            }

            else if (ArmorSlot.Stat == GameItem.EquipmentStat.Intelligence)
            {
                ArmorCombatPower = ArmorSlot.DefalutCombatPoint + ArmorSlot.VarianceCombatPoint * Intelligence;
            }

            else if (ArmorSlot.Stat == GameItem.EquipmentStat.Wizdom)
            {
                ArmorCombatPower = ArmorSlot.DefalutCombatPoint + ArmorSlot.VarianceCombatPoint * Wizdom;
            }

            else if (ArmorSlot.Stat == GameItem.EquipmentStat.Charm)
            {
                ArmorCombatPower = ArmorSlot.DefalutCombatPoint + ArmorSlot.VarianceCombatPoint * Charm;
            }

            CombatPower = WeaponCombatPower + ArmorCombatPower;
        }
        #endregion

        public void Heal(int heal)
        {
            CurrentHP += heal;
            if (CurrentHP > MaximumHP)
                CurrentHP = MaximumHP;
        }

        public void Damaged(int damage)
        {
            CurrentHP -= damage;

            if(CurrentHP <= 0)
            {
                CurrentHP = 0;
            }
        }

        public void subMaximumHP(int HP)
        {
            MaximumHP -= HP;
            if(CurrentHP > MaximumHP)
            {
                CurrentHP = MaximumHP;
            }
        }

        public void addGold(int gold)
        {
            Gold += gold;
        }

        public void subGold(int gold)
        {
            Gold -= gold;
            if(Gold < 0)
            {
                Gold = 0;
            }
        }

        public bool isDead()
        {
            if(CurrentHP <= 0)
            {
                CurrentHP = 0;
                return true;
            }
            return false;
        }
    }
}