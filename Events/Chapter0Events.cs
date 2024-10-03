using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using 파파야연대기.Classes;

namespace 파파야연대기.Events
{
    class Chapter0Events
    {
        Player player;
        View.Play play;
        private GameEventManager gameEventManager;
        private Dictionary<int, Action> EventDictionary;

        public Chapter0Events(GameEventManager _gameEventManager, Player _player, View.Play _play)
        {
            player = _player;
            play = _play;
            gameEventManager = _gameEventManager;
            EventDictionary = new Dictionary<int, Action>();
            EventDictionary.Add(000100, () => CharacterMakeEvent_000100());
            EventDictionary.Add(000101, () => CharacterMakeEvent_000101());
            EventDictionary.Add(000102, () => CharacterMakeEvent_000102());
            EventDictionary.Add(000103, () => CharacterMakeEvent_000103());
            EventDictionary.Add(000200, () => QuestEvent_000200());
            EventDictionary.Add(000201, () => QuestEvent_000201());
            EventDictionary.Add(000202, () => QuestEvent_000202());
            EventDictionary.Add(000203, () => QuestEvent_000203());
        }

        #region EventHelper...
        public void RunEvent(int _ButtonNumber)
        {
            gameEventManager.ButtonNumber = _ButtonNumber;
            gameEventManager.NowEventID = gameEventManager.NextEventID;            
            EventDictionary[gameEventManager.NextEventID].Invoke();
        }

        public void LoadStartEvent()
        {
            EventDictionary[gameEventManager.NowEventID].Invoke();
        }

        public void ChooseEvent()
        {
            if(gameEventManager.EventNumber == 1)
            {
                gameEventManager.NextEventID = 000200;
            }
        }

        public void NextEvent(int nextEvent)
        {
            gameEventManager.NextEventID = nextEvent;
        }

        public void FirstEvent()
        {
            gameEventManager.resetEventText();
            gameEventManager.resetSellectButtons();
            View.MainWindow.PlaySEUri(@"Resources/Musics/BookFlip.wav");
        }
        public void StartEvent()
        {
            gameEventManager.setEventText();
            gameEventManager.resetSellectButtons();
        }

        public void LastEvent()
        {
            gameEventManager.resetSellectButtons();
            gameEventManager.setSellectButton1("- 다음 장으로...", string.Empty, string.Empty);
            gameEventManager.EventNumber++;
            ChooseEvent();
        }
        #endregion

        #region CharacterMakeEvent_0001...
        public void CharacterMakeEvent_000100()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock("나는?");
            gameEventManager.setSellectButton1("- 산짐승들이 뛰어다니는 숲에서 자랐다");
            gameEventManager.setSellectButton2("- 사람들이 북적이는 도시에서 자랐다");
            gameEventManager.setSellectButton3("- 평화롭고 한가한 농촌에서 자랐다");

            NextEvent(000101);
        }

        public void CharacterMakeEvent_000101()
        {
            play.ButtonsPanel.Visibility = Visibility.Hidden;

            if (gameEventManager.ButtonNumber == 1)
            {
                Run run = new Run(" 나는 산짐승들이 뛰어다니는 숲에서 자랐다.\n");
                play.EventTextBlock.Inlines.Add(run);
                player.Dexterity++;
                player.Wizdom++;
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                Run run = new Run(" 나는 사람들이 북적이는 도시에서 자랐다.\n");
                play.EventTextBlock.Inlines.Add(run);
                player.Intelligence++;
                player.Charm++;
            }

            else if(gameEventManager.ButtonNumber == 3)
            {
                Run run = new Run(" 나는 평화롭고 한가한 농촌에서 자랐다.\n");
                play.EventTextBlock.Inlines.Add(run);
                player.Strength++;
                player.Stamina++;
            }

            gameEventManager.PrintTextBlock("\n나의 아버지는?");

            gameEventManager.setSellectButton1("- 몰락한 가문의 귀족이다");
            gameEventManager.setSellectButton2("- 퇴역한 군인이다");
            gameEventManager.setSellectButton3("- 물건을 파는 행상인이었다");

            NextEvent(000102);
        }

        public void CharacterMakeEvent_000102()
        {
            play.ButtonsPanel.Visibility = Visibility.Hidden;

            if (gameEventManager.ButtonNumber == 1)
            {
                Run run = new Run("나의 아버지는 몰락한 가문의 귀족이었으며,\n");
                play.EventTextBlock.Inlines.Add(run);
                player.Intelligence += 2;
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                Run run = new Run("나의 아버지는 퇴역한 군인이었으며,\n");
                play.EventTextBlock.Inlines.Add(run);
                player.Strength += 2;
            }

            else if (gameEventManager.ButtonNumber == 3)
            {
                Run run = new Run("나의 아버지는 물건을 파는 행상인이었으며,\n");
                play.EventTextBlock.Inlines.Add(run);
                player.Charm += 2;
            }

            gameEventManager.PrintTextBlock(" \n모험을 시작하는 이유는?");

            gameEventManager.setSellectButton1("- 큰 돈을 벌기위해");
            gameEventManager.setSellectButton2("- 악인을 처단해 명예를 얻기 위해");
            gameEventManager.setSellectButton3("- 새로운 지식의 탐구를 위해");

            NextEvent(000103);
        }

        public void CharacterMakeEvent_000103()
        {

            if (gameEventManager.ButtonNumber == 1)
            {
                Run run = new Run("모험을 시작하는 이유는 큰 돈을 벌기위해 떠난다.");
                play.EventTextBlock.Inlines.Add(run);
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                Run run = new Run("모험을 시작하는 이유는 악인을 처단해 명예를 얻기 위해 떠난다.");
                play.EventTextBlock.Inlines.Add(run);
            }

            else if (gameEventManager.ButtonNumber == 3)
            {
                Run run = new Run("모험을 시작하는 이유는 새로운 지식의 탐구를 위해 떠난다.");
                play.EventTextBlock.Inlines.Add(run);
            }

            gameEventManager.PrintTextBlock(" ", 1);
            LastEvent();
        }
        #endregion

        #region QuestEvent_0002...
        public void QuestEvent_000200()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 엘프 왕국의 감옥숲의 증식을 막으려고 모험가를 모집한다는 위대한 왕 콜린 4세의 공고문을 보고 엘프 접경지역인 엔콜로에 도착했다." +
                " 엔콜로의 모험가 길드는 전국에서 모인 사람들로 매우 시끌벅적하다.\n\n");
            gameEventManager.setSellectButton1("- 의뢰를 찾는다");

            NextEvent(000201);
        }

        public void QuestEvent_000201()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 수행할 임무를 찾던 중 감옥숲에서 실종된 대장장이를 찾는다는 의뢰를 발견하였고, 의뢰인인 대장장이의 제자를 찾아 마을의 대장간으로 향했다. " +
                "당신은 그곳에서 의뢰인인 실종된 대장장이의 제자를 만났다.\n\n");
            gameEventManager.setSellectButton1("- 설명을 듣는다");
            gameEventManager.setSellectButton2("- 종이를 가지고 나간다");

            NextEvent(000202);
        }

        public void QuestEvent_000202()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 그는 감옥 숲의 증식으로 대피 하던 중 스승과 헤어지게 되었고 스승이 아직까지 마을로 돌아오지 않았다고 설명했다.\n\n " +
                "그는 스승의 간단한 인상착의가 그려진 종이와 감옥숲의 지도를 주며 의뢰를 부탁했다.\n\n");
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 설명하려는 그를 무시하고 당신은 책상 위에 있던 인상착의가 그려진 종이와 감옥숲의 지도를 챙기고 대장간을 나왔다.\n\n");
            }

            gameEventManager.setSellectButton1("- 인상착의를 확인한다");
            gameEventManager.setSellectButton2("- 감옥 숲으로 향한다");

            NextEvent(000203);
        }

        public void QuestEvent_000203()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 인상착의를 확인한 당신은 종이와 지도를 주머니에 넣고 감옥숲으로 향한다.");
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 종이와 지도를 대충 훑어본 후 감옥숲으로 향한다.");
            }

            LastEvent();
            gameEventManager.GameChapterChange();
        }
        #endregion
    }
}
