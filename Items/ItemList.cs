using System.Collections.Generic;
using System.Linq;
using 파파야연대기.Classes;

namespace 파파야연대기.Items
{
    public static class ItemList
    {
        private static List<GameItem> GameItems;

        static ItemList()
        {
            GameItems = new List<GameItem>();
            GameItems.Add(new GameItem(1001, GameItem.ItemType.NotConsumable, "횃불", 10, " 어두운 곳을 밝혀주는 믿음직한 친구!", GameItem.ShopType.Chpater1, "/Resources/ItemImages/Torch.png"));
            GameItems.Add(new GameItem(1002, GameItem.ItemType.NotConsumable, "낚싯대", 5, " 나무로 만들어 조잡하지만 제 역할은 한다.", GameItem.ShopType.Chpater1, "/Resources/ItemImages/FishingRod.png"));
            GameItems.Add(new GameItem(1003, GameItem.ItemType.NotConsumable, "씨앗", 0, " 기분 좋은 향기가 솔솔 피어난다.", GameItem.ShopType.NotSell, "/Resources/ItemImages/Seed.png"));
            GameItems.Add(new GameItem(1004, GameItem.ItemType.NotConsumable, "마나를 태우는 불", 0, " 푸르게 불타오르고 있다.\n 숲의 중심으로 갈수록 불길이 세진다.", GameItem.ShopType.NotSell, "/Resources/ItemImages/ManaLantern.png"));
            GameItems.Add(new GameItem(1005, GameItem.ItemType.NotConsumable, "어미나무의 묘목", 0, " 스카이튼이 말한 묘목, 마나가 넘쳐난다.", GameItem.ShopType.NotSell, "/Resources/ItemImages/Seedling.png"));
            GameItems.Add(new GameItem(1006, GameItem.ItemType.NotConsumable, "묘목의 나뭇가지", 0, " 어미나무의 묘목에서 부러진 나뭇가지, 비록 나뭇가지이지만 마나가 넘쳐난다.", GameItem.ShopType.NotSell, "/Resources/ItemImages/Stick.png"));

            GameItems.Add(new GameItem(2001, GameItem.ItemType.Consumable, "체력 물약", 20, " 어디에나 흔히 있는 체력 물약이다.\n\n + 체력 10  \n - 클릭 시 사용", GameItem.ShopType.All, "/Resources/ItemImages/HealingPotion.png"));
            GameItems.Add(new GameItem(2002, GameItem.ItemType.Food, "고기", 10, " 만화...고기..?\n\n + 체력 5 \n - 클릭 시 사용", GameItem.ShopType.All, "/Resources/ItemImages/Meat.png"));
            GameItems.Add(new GameItem(2003, GameItem.ItemType.Food, "연어", 20, " 자연산 연어라 그런가 생선 살이 매우 붉다.\n\n + 체력 10 \n - 클릭 시 사용", GameItem.ShopType.Chpater1, "/Resources/ItemImages/Salmon.png"));
            GameItems.Add(new GameItem(2004, GameItem.ItemType.Food, "꿀", 20, " 너무 달다!\n\n + 체력 10 \n - 클릭 시 사용", GameItem.ShopType.Chpater1, "/Resources/ItemImages/Honey.png"));
            GameItems.Add(new GameItem(2005, GameItem.ItemType.Food, "술통", 0, " 술집 주인이 준 술통, 수제 생맥주가 들어있다.\n\n + 체력 15\n - 클릭 시 사용", GameItem.ShopType.NotSell, "/Resources/ItemImages/Beer.png"));
            GameItems.Add(new GameItem(2006, GameItem.ItemType.Consumable, "붉은 색 단약", 40, " 사탕 같지만 달진 않다.\n\n + 힘 2\n - 클릭 시 사용", GameItem.ShopType.Chapter3, "/Resources/ItemImages/RedMedicine.png"));
            GameItems.Add(new GameItem(2007, GameItem.ItemType.Consumable, "푸른 색 단약", 40, " 사탕 같지만 달진 않다.\n\n + 민첩 2\n - 클릭 시 사용", GameItem.ShopType.Chapter3, "/Resources/ItemImages/BlueMedicine.png"));
            GameItems.Add(new GameItem(2008, GameItem.ItemType.Consumable, "녹색 단약", 40, " 사탕 같지만 달진 않다.\n\n + 체력 2\n - 클릭 시 사용", GameItem.ShopType.Chapter3, "/Resources/ItemImages/GreenMedicine.png"));
            GameItems.Add(new GameItem(2009, GameItem.ItemType.Consumable, "하이놀", 0, " 먹어보면 그 무엇보다 맛있다.\n\n - 최대체력 10\n + 힘 3\n + 민첩 3\n - 클릭 시 사용", GameItem.ShopType.NotSell, "/Resources/ItemImages/Hinor.png"));
            GameItems.Add(new GameItem(2010, GameItem.ItemType.Consumable, "깨끗한 물", 35, " 깨끗하다 못해 투명할 정도이다.\n\n + 체력 15\n - 클릭 시 사용", GameItem.ShopType.Chapter3, "/Resources/ItemImages/Water.png"));

            GameItems.Add(new GameItem(3001, GameItem.ItemType.Weapon, "단검", 30, " 식칼보다는 크고 대검보다는 작다.\n\n - 민첩\n - 클릭 시 장착, 해제", GameItem.ShopType.Chpater1, GameItem.EquipmentStat.Dexterity, 6, 1, "/Resources/ItemImages/Dagger.png"));
            GameItems.Add(new GameItem(3002, GameItem.ItemType.Weapon, "장궁", 40, " 활시위를 당기는데 꽤 힘들다.\n\n - 민첩\n - 클릭 시 장착, 해제", GameItem.ShopType.Chpater1, GameItem.EquipmentStat.Dexterity, 3, 2, "/Resources/ItemImages/Bow.png"));
            GameItems.Add(new GameItem(3003, GameItem.ItemType.Weapon, "화려한 단검", 50, " 엄청 화려하다. 장식용인 것 같다.\n\n - 민첩\n - 클릭 시 장착, 해제", GameItem.ShopType.Smithy, GameItem.EquipmentStat.Dexterity, 10, 2, "/Resources/ItemImages/ColorfulDagger.png"));
            GameItems.Add(new GameItem(3004, GameItem.ItemType.Weapon, "하이놀\n 중독자의 대검", 0, " 중독자의 무기, 무기의 이름조차 묻지 못했다.\n\n - 힘\n - 클릭 시 장착, 해제", GameItem.ShopType.NotSell, GameItem.EquipmentStat.Strength, 11, 2, "/Resources/ItemImages/HinorGreatSword.png"));
            GameItems.Add(new GameItem(3005, GameItem.ItemType.Weapon, "와이번의 발톱", 110, " 죽은 와이번의 발톱 끝에는 독이 묻어있다.\n\n - 민첩\n - 클릭 시 장착, 해제", GameItem.ShopType.Chapter3, GameItem.EquipmentStat.Dexterity, 20, 3, "/Resources/ItemImages/Claw.png"));
            GameItems.Add(new GameItem(3006, GameItem.ItemType.Weapon, "피 묻은 검", 0, " 검에 묻은 피는 지워지지 않는다.\n\n - 힘\n - 클릭 시 장착, 해제", GameItem.ShopType.NotSell, GameItem.EquipmentStat.Strength, 30, 3, "/Resources/ItemImages/BloodSword.png"));
            GameItems.Add(new GameItem(3007, GameItem.ItemType.Weapon, "트롤의 망치", 80, " 인간이 쓰기에는 너무 크다.\n\n - 힘\n - 클릭 시 장착, 해제", GameItem.ShopType.Chapter3, GameItem.EquipmentStat.Strength, 1, 4, "/Resources/ItemImages/TrollHammer.png"));
            GameItems.Add(new GameItem(3008, GameItem.ItemType.Weapon, "대검", 30, " 평범한 대검이다.\n\n - 힘\n - 클릭 시 장착, 해제", GameItem.ShopType.Chpater1, GameItem.EquipmentStat.Strength, 6, 1, "/Resources/ItemImages/GreatSword.png"));
            GameItems.Add(new GameItem(3009, GameItem.ItemType.Weapon, "스태프", 30, " 스태프보다는 마법봉이 어울린다.\n\n - 지능\n - 클릭 시 장착, 해제", GameItem.ShopType.Chpater1, GameItem.EquipmentStat.Intelligence, 8, 1, "/Resources/ItemImages/Staff.png"));
            GameItems.Add(new GameItem(3010, GameItem.ItemType.Weapon, "큰 스태프", 60, " 화려해 보이지만 뭔가 조잡하다.\n\n - 지능\n - 클릭 시 장착, 해제", GameItem.ShopType.MagicShop, GameItem.EquipmentStat.Intelligence, 14, 2, "/Resources/ItemImages/BigStaff.png"));
            GameItems.Add(new GameItem(3011, GameItem.ItemType.Weapon, "소서러", 0, " 씨앗을 모으는 모험가가 준 무기, 처음보는 형식이다.\n\n - 지능\n - 클릭 시 장착, 해제", GameItem.ShopType.NotSell, GameItem.EquipmentStat.Intelligence, 20, 4, "/Resources/ItemImages/Sorcerer.png"));
            GameItems.Add(new GameItem(3012, GameItem.ItemType.Weapon, "성기사단 대검", 80, " 갑옷과 세트이다.\n\n - 힘\n - 클릭 시 장착, 해제", GameItem.ShopType.Smithy, GameItem.EquipmentStat.Strength, 15, 2, "/Resources/ItemImages/PaldinGreatSword.png"));
            GameItems.Add(new GameItem(3013, GameItem.ItemType.Weapon, "은장검", 80, " 모험가가 흔히 사용하는 은장검, 가볍지만 강하다.\n\n - 민첩\n - 클릭 시 장착, 해제", GameItem.ShopType.Chapter3, GameItem.EquipmentStat.Dexterity, 15, 3, "/Resources/ItemImages/SilverSword.png"));
            GameItems.Add(new GameItem(3014, GameItem.ItemType.Weapon, "고대서", 0, " 고대어로 쓰인 책, 읽을 줄 만 알면 강한 마법을 사용한다.\n\n - 지능\n - 클릭 시 장착, 해제", GameItem.ShopType.NotSell, GameItem.EquipmentStat.Intelligence, 10, 4, "/Resources/ItemImages/AcientBook.png"));

            GameItems.Add(new GameItem(4001, GameItem.ItemType.Armor, "천갑옷", 30, " 300골드보다 싸다.\n\n - 체력\n - 클릭 시 장착, 해제", GameItem.ShopType.Chpater1, GameItem.EquipmentStat.Stamina, 1, 1, "/Resources/ItemImages/ClothArmor.png"));
            GameItems.Add(new GameItem(4002, GameItem.ItemType.Armor, "성기사단 갑옷", 70, " 갑옷에서 신성함이 느껴진다.\n\n - 지혜\n - 클릭 시 장착, 해제", GameItem.ShopType.Smithy, GameItem.EquipmentStat.Wizdom, 10, 2, "/Resources/ItemImages/PaldinArmor.png"));
            GameItems.Add(new GameItem(4003, GameItem.ItemType.Armor, "광신도의 로브", 70, " 입으면 미칠 것 같다.\n\n - 지능\n - 클릭 시 장착, 해제", GameItem.ShopType.MagicShop, GameItem.EquipmentStat.Intelligence, 10, 2, "/Resources/ItemImages/Robe.png"));
            GameItems.Add(new GameItem(4004, GameItem.ItemType.Armor, "황금갑옷", 0, " 거대한 무덤에 있던 갑옷, 입으면 왕이 된 것 같다.\n\n - 체력\n - 클릭 시 장착, 해제", GameItem.ShopType.NotSell, GameItem.EquipmentStat.Stamina, 30, 3, "/Resources/ItemImages/GoldArmor.png"));
        }

        public static GameItem CreateGameItem(int itemID)
        {
            GameItem gameItem = GameItems.FirstOrDefault(item => item.ItemID == itemID);

            if (gameItem != null)
            {
                return gameItem.Clone(itemID);
            }

            return null;
        }

        public static int Count()
        {
            return GameItems.Count();
        }

        public static int getItemID(int index)
        {
            return GameItems[index].ItemID;
        }
    }  
}
