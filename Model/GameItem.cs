using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace 파파야연대기.Classes
{
    public class GameItem
    {
        public enum ItemType
        {
            NotConsumable,
            Consumable,
            Food,
            Weapon,
            Armor
        }

        public enum ShopType
        { 
            All,
            NotSell,
            Chpater1,
            Smithy,
            MagicShop,
            Chapter3
        }

        public enum EquipmentStat
        {
            Strength,
            Dexterity,
            Stamina,
            Intelligence,
            Wizdom,
            Charm
        }

        public int ItemID { get; set; }
        [JsonIgnore] public ItemType Type { get; set; }
        [JsonIgnore] public string Name { get; set; }
        [JsonIgnore]  public int Price { get; set; }
        [JsonIgnore]  public string Information { get; set; }
        [JsonIgnore]  public ShopType Shop { get; set; }
        [JsonIgnore]  public string ImageUri { get; set; }

        [JsonIgnore]  public EquipmentStat Stat { get; set; }
        [JsonIgnore]  public int DefalutCombatPoint { get; set; }
        [JsonIgnore]  public int VarianceCombatPoint { get; set; }

        public GameItem(int itemID, ItemType type, string name, int price, string information, ShopType shop, string imageUri)
        {
            ItemID = itemID;
            Type = type;
            Name = name;
            Price = price;
            Information = information;
            Shop = shop;
            ImageUri = imageUri;
        }

        public GameItem(int itemID, ItemType type, string name, int price, string information, ShopType shop, EquipmentStat stat, int defalutCombatPoint, int varianceCombatPoint, string imageUri)
        {
            ItemID = itemID;
            Type = type;
            Name = name;
            Price = price;
            Information = information;
            Shop = shop;
            Stat = stat;
            DefalutCombatPoint = defalutCombatPoint;
            VarianceCombatPoint = varianceCombatPoint;
            ImageUri = imageUri;
        }

        public GameItem Clone(int itemID)
        {
            if(itemID > 3000)
            {
                return new GameItem(ItemID, Type, Name, Price, Information, Shop, Stat, DefalutCombatPoint, VarianceCombatPoint, ImageUri);
            }

            else if(itemID > 1000)
            {
                return new GameItem(ItemID, Type, Name, Price, Information, Shop, ImageUri);
            }

            else
            {
                return null;
            }   
        }

        public static explicit operator GameItem(JToken v)
        {
            throw new NotImplementedException();
        }
    }
}
