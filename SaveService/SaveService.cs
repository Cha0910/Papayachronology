using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using 파파야연대기.ViewModel;
using 파파야연대기.Classes;
using 파파야연대기.Events;
using System.Windows;

namespace 파파야연대기.SaveService
{
    public static class SaveService
    {
        private const string SAVE_GAME_FILE_NAME = "SaveFile.json";
        private static bool isFinish = false;

        public static void Save(GameSession gameSession)
        {
            File.WriteAllText(SAVE_GAME_FILE_NAME,
                              JsonConvert.SerializeObject(gameSession, Formatting.Indented));
            if(isFinish)
            {
                DeleteSaveFile();
            }    
        }   

        public static void DeleteSaveFile()
        {
            string path = @"SaveFile.json";
            if(File.Exists(path))
            {
                File.Delete(path);
                isFinish = false;
            }           
        }

        public static void setFinsh()
        {
            isFinish = true;
        }

        public static bool isFileExists()
        {
            if (File.Exists(SAVE_GAME_FILE_NAME))
            {
                return true;
            }

            else if (!File.Exists(SAVE_GAME_FILE_NAME))
            {
                return false;
            }
            return false;
        }

        public static GameSession Load(View.Play play)
        {
            if(!isFileExists())
            {
                return new GameSession(play);
            }

            try
            {
                JObject data = JObject.Parse(File.ReadAllText(SAVE_GAME_FILE_NAME));
                Player player = LoadPlayer(data);
                GameText gameText = new GameText();
                gameText.TempText = string.Empty;
                gameText.SelectButton1Text = string.Empty;
                gameText.SelectButton2Text = string.Empty;
                gameText.SelectButton3Text = string.Empty;
                Trader trader = new Trader(player);
                GameEventManager gameEventManager = LoadGameEventManager(data, player, gameText, trader, play);

                return new GameSession(player,gameText, gameEventManager, trader, play);
            }

            catch (Exception ex) 
            {
                View.NoticeWindow noticeWindow = new View.NoticeWindow("파일을 읽어오는 중 오류가 발생했습니다.\n새로운 게임을 시작합니다.");
                noticeWindow.Owner = Application.Current.MainWindow;
                noticeWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                noticeWindow.ShowDialog();
                return new GameSession(play); 
            }
        }

        private static Player LoadPlayer(JObject data)
        {
            Player player = new Player();

            player.MaximumHP = (int)data[nameof(GameSession.player)][nameof(Player.MaximumHP)];
            player.CurrentHP = (int)data[nameof(GameSession.player)][nameof(Player.CurrentHP)];
            player.Strength = (int)data[nameof(GameSession.player)][nameof(Player.Strength)];
            player.Dexterity = (int)data[nameof(GameSession.player)][nameof(Player.Dexterity)];
            player.Stamina = (int)data[nameof(GameSession.player)][nameof(Player.Stamina)];
            player.Intelligence = (int)data[nameof(GameSession.player)][nameof(Player.Intelligence)];
            player.Wizdom = (int)data[nameof(GameSession.player)][nameof(Player.Wizdom)];
            player.Charm = (int)data[nameof(GameSession.player)][nameof(Player.Charm)];
            player.Gold = (int)data[nameof(GameSession.player)][nameof(Player.Gold)];
            player.WeaponCombatPower = 0;
            player.ArmorCombatPower = 0;
            player.CombatPower = 0;

            player.addItem((int)data[nameof(GameSession.player)][nameof(Player.WeaponSlot)][nameof(player.WeaponSlot.ItemID)]);
            player.addItem((int)data[nameof(GameSession.player)][nameof(Player.ArmorSlot)][nameof(player.ArmorSlot.ItemID)]);
            player.Equip(0);
            player.Equip(0);

            foreach (JToken itemToken in (JArray)data[nameof(GameSession.player)]
                        [nameof(Player.Inventory)])
            {
                int itemId = (int)itemToken[nameof(GameItem.ItemID)];

                player.addItem(itemId);
            }

            return player;
        }

        private static GameEventManager LoadGameEventManager(JObject data, Player player, GameText gameText, Trader trader, View.Play play)
        {
            GameEventManager gameEventManager = new GameEventManager(player, gameText, trader, play);

            gameEventManager.GameChapter = (int)data[nameof(GameSession.gameEventManager)][nameof(GameEventManager.GameChapter)];
            gameEventManager.EventNumber = (int)data[nameof(GameSession.gameEventManager)][nameof(GameEventManager.EventNumber)];
            gameEventManager.NowEventID = (int)data[nameof(GameSession.gameEventManager)][nameof(GameEventManager.NowEventID)];
            gameEventManager.NextEventID = (int)data[nameof(GameSession.gameEventManager)][nameof(GameEventManager.NextEventID)];
            gameEventManager.ButtonNumber = (int)data[nameof(GameSession.gameEventManager)][nameof(GameEventManager.ButtonNumber)];
            gameEventManager.RefugeeAlive = (bool)data[nameof(GameSession.gameEventManager)][nameof(GameEventManager.RefugeeAlive)];
            gameEventManager.hasSeedling = (bool)data[nameof(GameSession.gameEventManager)][nameof(GameEventManager.hasSeedling)];
            gameEventManager.BlackSmithAlive = (bool)data[nameof(GameSession.gameEventManager)][nameof(GameEventManager.BlackSmithAlive)];
            gameEventManager.isBurnTree = (bool)data[nameof(GameSession.gameEventManager)][nameof(GameEventManager.isBurnTree)];

            return gameEventManager;
        }
    }
}
