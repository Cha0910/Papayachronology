using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using 파파야연대기.Items;
using 파파야연대기.View;

namespace 파파야연대기.Classes
{
    public class Trader
    {
        private int NumItem = 0;

        public ObservableCollection<GameItem> Inventory { get; set; }
        public ObservableCollection<bool> HasItem { get; set; }
        private Player player;
        private Random random;

        public Trader(Player _player)
        {
            Inventory = new ObservableCollection<GameItem>();
            HasItem = new ObservableCollection<bool>();
            player = _player;
            random = new Random();
            for (int i = 0; i < 16; i++)
            {
                HasItem.Add(false);
            }
        }

        public void addItems(GameItem.ShopType shop)
        {
            Inventory.Clear();
            HasItem.Clear();
            NumItem = 0;

            for (int i = 0; i < 16; i++)
            {
                HasItem.Add(false);
            }

            for (int i=0; i< random.Next(7,11); i++)
            {
                int index = random.Next(ItemList.Count());
                int itemID = ItemList.getItemID(index);

                if(ItemList.CreateGameItem(itemID).Shop == shop || ItemList.CreateGameItem(itemID).Shop == GameItem.ShopType.All)
                {
                    Inventory.Add(ItemList.CreateGameItem(itemID));
                    HasItem[NumItem] = true;
                    NumItem++;
                }

                else
                {
                    i--;
                }
            }  
        }

        public void sellItem(int index)
        {
            if(player.Gold >= Inventory[index].Price)
            {
                player.subGold(Inventory[index].Price);
                player.addItem(Inventory[index].ItemID);
                Inventory.RemoveAt(index);
                NumItem--;
                HasItem[NumItem] = false;
            }

            else
            {
                var noticeWindow = new NoticeWindow("골드가 부족합니다!");
                noticeWindow.Owner = Application.Current.MainWindow;
                noticeWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                noticeWindow.ShowDialog();
            }
        }
    }
}
