using System;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Media;
using Newtonsoft.Json;
using 파파야연대기.Classes;
using 파파야연대기.View;

namespace 파파야연대기.Events
{
    public class GameEventManager : PropertyChangedNotificationClass
    {
        public int GameChapter;
        public int EventNumber;
        public int NextEventID;
        public int NowEventID;
        public int ButtonNumber;
        private Player player;
        private GameText gameText;
        [JsonIgnore]
        public Trader trader;
        Play play;
        Chapter0Events chapter0Events;
        Chapter1Events chapter1Events;
        Chapter2Events chapter2Events;
        Chapter3Events chapter3Events;
        Epilogues epilogues;

        Random random = new Random();
        public bool RefugeeAlive = false;
        public bool BlackSmithAlive = false;
        public bool hasSeedling = false;
        public bool isBurnTree = false;

        public GameEventManager(Player _player, GameText _gameText, Trader _trader, Play _play)
        {
            GameChapter = 0;
            EventNumber = 0;
            NextEventID = 000100;
            NowEventID = 000100;
            ButtonNumber = 0;
            player = _player;
            gameText = _gameText;
            trader = _trader;
            play = _play;
            chapter0Events = new Chapter0Events(this, _player, _play);
            chapter1Events = new Chapter1Events(this, _player);
            chapter2Events = new Chapter2Events(this, _player);
            chapter3Events = new Chapter3Events(this, _player);
            epilogues = new Epilogues(this);
        }
        #region setEvent...
        public void StartEvent()
        {
            if (GameChapter == 0)
            {
                chapter0Events.LoadStartEvent();
            }

            else if (GameChapter == 1)
            {
                if (NextEventID == 010100 || NextEventID == 010200)
                {
                    EventNumber--;
                }

                chapter1Events.LoadStartEvent();
            }

            else if (GameChapter == 2)
            {
                if (NextEventID == 020200 || NextEventID == 020300 || NextEventID == 020400)
                {
                    EventNumber--;
                }

                chapter2Events.LoadStartEvent();
            }

            else if (GameChapter == 3)
            {
                if(NextEventID == 030200 || NextEventID == 030300)
                {
                    EventNumber--;
                }

                chapter3Events.LoadStartEvent();
            }

            else if (GameChapter == 4)
            {
                epilogues.LoadStartEvent();
            }
        }

        public void RunEvent(int buttonNumber)
        {
            if(GameChapter == 0)
            {
                chapter0Events.RunEvent(buttonNumber);
            }
                
            else if(GameChapter == 1)
            {
                chapter1Events.RunEvent(buttonNumber);
            }
                
            else if(GameChapter == 2)
            {
                chapter2Events.RunEvent(buttonNumber);
            }

            else if(GameChapter == 3)
            {
                chapter3Events.RunEvent(buttonNumber);
            }

            else if (GameChapter == 4)
            {
                epilogues.RunEvent(buttonNumber);
            }
        }

        public void GameChapterChange()
        {
            GameChapter++;
            EventNumber = 0;

            if(GameChapter == 1)
            {
                NextEventID = 010000;
                NowEventID = NextEventID;
            }
            
            else if(GameChapter == 2)
            {
                NextEventID = 020100;
                NowEventID = NextEventID;
            }

            else if(GameChapter == 3)
            {
                NextEventID = 030100;
                NowEventID = NextEventID;
            }

            else if(GameChapter == 4)
            {
                epilogues.ChooseEvent();
                return;
            }

            Play.StatUpWindowOpen();
        }
        #endregion

        #region setEventText...
        public void setEventText()
        {
            Run run = new Run(gameText.TempText);
            play.EventTextBlock.Inlines.Add(run);

            for(int i=0; i<play.ColorTextBlock.Inlines.Count; i++)
            {
                string text = (play.ColorTextBlock.Inlines.ToArray()[i] as Run).Text;
                Brush brush = (play.ColorTextBlock.Inlines.ToArray()[i] as Run).Foreground;
                run = new Run(text);
                run.Foreground = brush;
                play.EventTextBlock.Inlines.Add(run);
            }
            play.ColorTextBlock.Inlines.Clear();
            gameText.TempText = string.Empty;   
        }

        public void resetEventText()
        {
            play.EventTextBlock.Inlines.Clear();
            play.ColorTextBlock.Inlines.Clear();
            gameText.TempText = string.Empty;
        }

        public void PrintTextBlock(string text)
        {
            gameText.TempText = text;
            play.TypewriteTextblock(text, 50);
        }

        public void PrintTextBlock(string text, int delay)
        {
            gameText.TempText = text;
            play.TypewriteTextblock(text, delay);
        }

        public void SomethigGetText(string text)
        {
            Run run = new Run(text);
            run.Foreground = Brushes.Green;
            play.ColorTextBlock.Inlines.Add(run);
        }

        public void SomethigLostText(string text)
        {
            Run run = new Run(text);
            run.Foreground = Brushes.Red;
            play.ColorTextBlock.Inlines.Add(run);
        }

        public void SuccessMessage()
        {
            Run run = new Run("<성공>\n");
            run.Foreground = Brushes.Green;
            play.EventTextBlock.Inlines.Add(run);
            MainWindow.PlaySEUri(@"Resources/Musics/Success.wav");
        }

        public void FailMessage()
        {
            Run run = new Run("<실패>\n");
            run.Foreground = Brushes.Red;
            play.EventTextBlock.Inlines.Add(run);
            MainWindow.PlaySEUri(@"Resources/Musics/Fail.wav");
        }

        public void WinMessage()
        {
            Run run = new Run("<승리!>\n");
            run.Foreground = Brushes.Green;
            play.EventTextBlock.Inlines.Add(run);
            MainWindow.PlaySEUri(@"Resources/Musics/Win.wav");
        }

        public void LoseMessage()
        {
            Run run = new Run("<패배...>\n");
            run.Foreground = Brushes.Red;
            play.EventTextBlock.Inlines.Add(run);
            MainWindow.PlaySEUri(@"Resources/Musics/Fail.wav");
        }
        #endregion

        #region setSellectButton...
        public void resetSellectButtons()
        {
            setSellectButton1(string.Empty, string.Empty, string.Empty);
            setSellectButton2(string.Empty, string.Empty, string.Empty);
            setSellectButton3(string.Empty, string.Empty, string.Empty);
        }

        public void setSellectButton1(string text)
        {
            gameText.SelectButton1Text = text;

            if (text == string.Empty)
            {
                play.selectButton1.IsEnabled = false;
                return;
            }

            play.selectButton1.IsEnabled = true;
        }

        public void setSellectButton1(string text, string image, string Probability)
        {
            gameText.SelectButton1Text = text;
            gameText.SelectButton1Image = image;
            gameText.SelectButton1Probability = Probability;

            if (text == string.Empty)
            {
                play.selectButton1.IsEnabled = false;
                return;
            }

            play.selectButton1.IsEnabled = true;
        }

        public void setSellecButton1Disable()
        {
            play.selectButton1.IsEnabled = false;
        }

        public void setSellectButton2(string text)
        {
            gameText.SelectButton2Text = text;

            if (text == string.Empty)
            {
                play.selectButton2.IsEnabled = false;
                return;
            }

            play.selectButton2.IsEnabled = true;
        }

        public void setSellectButton2(string text, string image, string Probability)
        {
            gameText.SelectButton2Text = text;
            gameText.SelectButton2Image = image;
            gameText.SelectButton2Probability = Probability;

            if (text == string.Empty)
            {
                play.selectButton2.IsEnabled = false;
                return;
            }

            play.selectButton2.IsEnabled = true;
        }

        public void setSellecButton2Disable()
        {
            play.selectButton2.IsEnabled = false;
        }

        public void setSellectButton3(string text)
        {
            gameText.SelectButton3Text = text;

            if (text == string.Empty)
            {
                play.selectButton3.IsEnabled = false;
                return;
            }

            play.selectButton3.IsEnabled = true;
        }

        public void setSellectButton3(string text, string image, string Probability)
        {
            gameText.SelectButton3Text = text;
            gameText.SelectButton3Image = image;
            gameText.SelectButton3Probability = Probability;

            if (text == string.Empty)
            {
                play.selectButton3.IsEnabled = false;
                return;
            }

            play.selectButton3.IsEnabled = true;
        }

        public void setSellecButton3Disable()
        {
            play.selectButton3.IsEnabled = false;
        }

        public void setBattleButton(int enemyCombatPower)
        {
            setSellectButton1("- 전투!", "/Resources/PlayImages/Battle.png", WinProbability(enemyCombatPower));
        }
        #endregion

        #region Probabilitys...
        public string SuccessProbability(int defaultProbability, int varianceProbability, int stat)
        {
            int successProbability = defaultProbability + varianceProbability * stat;

            if (successProbability > 90)
            {
                successProbability = 90;
            }

            return successProbability.ToString() + "%";
        }

        public bool isSuccess(int defaultProbability, int varianceProbability, int stat)
        {
            int successProbability = defaultProbability + varianceProbability * stat;
            int randomValue = random.Next(100);

            if(successProbability > 90)
            {
                successProbability = 90;
            }

            if (randomValue < successProbability)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public string WinProbability(int enemyCombatPower)
        {
            double winProbability = ((double)player.CombatPower / (double)enemyCombatPower) * 50.0;

            if(winProbability > 90.0)
            {
                winProbability = 90.0;
            }

            return "적 전투력 " + enemyCombatPower.ToString() + " " + winProbability.ToString("F") + "%";
        }
        
        public bool isWin(int enemyCombatPower)
        {
            double winProbability = ((double)player.CombatPower / (double)enemyCombatPower) * 50.0;
            double randomValue = random.NextDouble() * 100.0;

            if (winProbability > 90.0)
            {
                winProbability = 90.0;
            }

            if (randomValue < winProbability)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
        #endregion
    }
}
