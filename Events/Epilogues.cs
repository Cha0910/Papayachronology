using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace 파파야연대기.Events
{
    class Epilogues
    {
        private GameEventManager gameEventManager;
        private Dictionary<int, Action> EventDictionary;

        public Epilogues(GameEventManager _gameEventManager)
        {
            gameEventManager = _gameEventManager;
            EventDictionary = new Dictionary<int, Action>();
            EventDictionary.Add(040000, () => toMainMenu());
            EventDictionary.Add(040100, () => BacksmithEpilogue_040100());
            EventDictionary.Add(040110, () => BacksmithEpilogue_040110());
            EventDictionary.Add(040200, () => SkytenEpilogue_040200());
            EventDictionary.Add(040300, () => TreeEpilogue_040300());
            EventDictionary.Add(040120, () => BacksmithEpilogue_040120());
            EventDictionary.Add(040130, () => BacksmithEpilogue_040130());
            EventDictionary.Add(040210, () => SkytenEpilogue_040210());
            EventDictionary.Add(040310, () => TreeEpilogue_040310());
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
            if(gameEventManager.isBurnTree)
            {
                if(gameEventManager.BlackSmithAlive)
                {
                    gameEventManager.NextEventID = 040100;
                }

                else
                {
                    gameEventManager.NextEventID = 040110;
                }
            }

            else
            {
                if (gameEventManager.BlackSmithAlive)
                {
                    gameEventManager.NextEventID = 040120;
                }

                else
                {
                    gameEventManager.NextEventID = 040130;
                }
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
        }

        public void LastEvent()
        {
            gameEventManager.resetSellectButtons();
            gameEventManager.setSellectButton1("- 에필로그...", string.Empty, string.Empty);
        }
        #endregion

        #region ClearEpilogues...
        private void BacksmithEpilogue_040100()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 어미나무가 불타 사라지고 감옥숲이 점차 좁아진다는 소식을 들은 대장장이는 이드렉스에 있는 자신의 대장간으로 돌아왔다. \n\n" +
                " 대장장이는 마나를 태우는 불이 사라진 것에 당황한 듯했지만 그의 대장간은 마나를 태우는 불로 유명세를 얻어 수많은 사람들이 그의 대장간을 방문한다고 한다.");

            NextEvent(040200);
            LastEvent();
        }

        private void BacksmithEpilogue_040110()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 어미나무가 불타 사라지고 감옥숲이 점차 좁아진다는 소식을 들은 대장장이의 제자는 스승의 장례를 치른 후 이드렉스에 있는 스승의 대장간으로 돌아왔다. \n\n" +
                " 대장간은 마나를 태우는 불로 유명세를 얻었지만 제자는 스승의 대장간을 잇기에는 자신의 실력이 미숙하다 생각해 대장간을 잇지 않았다.");

            NextEvent(040200);
            LastEvent();
        }

        private void SkytenEpilogue_040200()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 어미나무의 묘목을 연구하던 크래블 스카이튼은 당신에게 델트 우드가드의 소식을 듣고 꽤나 상심한 듯 했다.\n\n" +
                " 그는 거름인간이 된 사람들을 모아 관리하고 원래대로 되돌리기 위해 연구소에 박혀 끊임없이 연구하고 있다.");

            NextEvent(040300);
            LastEvent();
        }

        private void TreeEpilogue_040300()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 어미나무를 불태운 후 당신의 집이 있는 엔콜로로 돌아갔다." +
                " 어미나무가 사라지자 거름인간들은 더 이상 움직이지 않았고 감옥숲은 점점 좁아지면서 점차 원래 모습으로 돌아오고 있었다.\n\n" +
                " 어느 날 당신의 집에 한통의 편지가 왔고 발신인은 왕 콜린 4세였다. 당신은 어미나무를 쓰러트리고 감옥숲의 증식을 막은 공로를 인정받아 나라의 공작이 되었고 이드렉스의 영웅이 되었다.");

            gameEventManager.resetSellectButtons();
            gameEventManager.setSellectButton1("- 메인 메뉴로...");
            NextEvent(040000);
        }
        #endregion

        #region FailEpilogues...
        private void BacksmithEpilogue_040120()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 엔콜로에서 휴식을 취하고 있던 대장장이는 감옥숲이 가까이 왔다는 소식을 듣고 당신이 의뢰를 실패했다는 것을 깨달았다.\n\n" +
                " 그는 제자와 함께 계속해서 확장되는 감옥숲을 피해 떠돌이 생활을 하고 있다고 한다.");

            NextEvent(040210);
            LastEvent();
        }

        private void BacksmithEpilogue_040130()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 대장장이의 제사를 치르던 대장장이의 제자는 감옥숲이 가까이 왔다는 소식을 듣고도 대장장이의 무덤을 떠나지 않았다.\n\n" +
                " 모든 사람이 엔콜로에서 피난 가고 난 후 결국 그는 거름인간이 되기 전에 스승의 무덤 옆에 묻혔다고 한다.");

            NextEvent(040210);
            LastEvent();
        }

        private void SkytenEpilogue_040210()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 어미나무의 묘목을 연구하던 크래블 스카이튼은 당신이 오지 않자 어미나무를 쓰러트리지 못했다는 것을 알아차렸다.\n\n" +
                " 그는 연구소로 돌아가 어미나무를 쓰러트릴 방법을 연구했지만 얼마 지나지 않아 연구소에 거름인간들이 습격해왔고 스카이튼도 어미나무에게 흡수되었다.");

            NextEvent(040310);
            LastEvent();
        }

        private void TreeEpilogue_040310()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신을 흡수한 어미나무는 완전체가 되었고 계속해서 숲을 확장해나갔다." +
                " 이드렉스는 모든 사람이 피난 가거나 거름인간이 되어 유령도시가 되었다.\n\n" +
                " 엔콜로 또한 감옥숲에 집어삼켜져 대부분의 모험가가 거름인간이 되거나 도망쳐 더 이상 사람이 없다고 한다.\n\n" +
                " 감옥숲은 전보다 훨씬 빠른 속도로 증식해가고 있고 왕 콜린 4세는 아직도 숲의 증식을 막기 위한 모험가들을 모집하고 있다.");

            gameEventManager.resetSellectButtons();
            gameEventManager.setSellectButton1("- 메인 메뉴로...");
            NextEvent(040000);
        }
        #endregion

        private void toMainMenu()
        {
            SaveService.SaveService.setFinsh();
            var MainWIndow = new View.MainMenu();
            ((View.MainWindow)Application.Current.MainWindow).mainWindow.Children.Clear();
            ((View.MainWindow)Application.Current.MainWindow).mainWindow.Children.Add(MainWIndow);
        }
    }
}
