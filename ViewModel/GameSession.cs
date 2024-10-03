using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json;
using 파파야연대기.Classes;
using 파파야연대기.Events;
using 파파야연대기.Items;
using 파파야연대기.View;

namespace 파파야연대기.ViewModel
{
    public class GameSession
    {
        public Player player { get; set; }
        public GameText gameText { get; set; }
        public GameEventManager gameEventManager { get; set; }

        [JsonIgnore]
        public Trader trader { get; set; }

        public GameSession(Play play)
        {
            player = new Player();
            player.MaximumHP = 30;
            player.CurrentHP = 30;
            player.CombatPower = 0;
            player.WeaponCombatPower = 0;
            player.ArmorCombatPower = 0;
            player.Strength = 9;
            player.Dexterity = 9;
            player.Stamina = 9;
            player.Intelligence = 9;
            player.Wizdom = 9;
            player.Charm = 9;
            player.Gold = 20;

            player.addItem(StartWeapon());
            player.addItem(4001);
            player.Equip(0);
            player.Equip(0);
           
            gameText = new GameText();
            gameText.TempText = string.Empty;
            gameText.SelectButton1Text = string.Empty;
            gameText.SelectButton2Text = string.Empty;
            gameText.SelectButton3Text = string.Empty;

            trader = new Trader(player);

            gameEventManager = new GameEventManager(player, gameText, trader, play);
        }

        public GameSession(Player _player, GameText _gameText, GameEventManager _gameEventManager, Trader _trader, Play _play)
        {
            player = _player;
            gameText = _gameText;
            trader = _trader;
            gameEventManager = _gameEventManager;
        }

        private int StartWeapon()
        {
            Random rand = new Random();
            int number = rand.Next(3);

            if (number == 0)
            {
                return 3001;
            }

            else if (number == 1)
            {
                return 3008;
            }

            else if (number == 2)
            {
                return 3009;
            }

            return 0;
        }
    }
}
