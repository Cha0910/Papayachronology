using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using 파파야연대기.Classes;

namespace 파파야연대기.Events
{
    class Chapter3Events
    {
        private Player player;
        private bool isSuccess;
        private bool isWin;
        GameEventManager gameEventManager;
        private Dictionary<int, Action> EventDictionary;
        Array values = Enum.GetValues(typeof(Events));
        Random random = new Random();
        private const string STRENGTH = "/Resources/PlayImages/Strength.png";
        private const string DEXTERITY = "/Resources/PlayImages/Dexterity.png";
        private const string STAMINA = "/Resources/PlayImages/Stamina.png";
        private const string INTELLIGENCE = "/Resources/PlayImages/Intelligence.png";
        private const string WIZDOM = "/Resources/PlayImages/Wizdom.png";
        private const string CHARM = "/Resources/PlayImages/Charm.png";

        enum Events
        {
            SeedEvent = 030400,
            HutEvent = 030500,
            FairyEvent = 030600,
            RuinsEvent = 030700,
            DeadbodyEvent = 030800,
            TombEvent = 030900,
            TraderEvent = 031000,
            WyvernEvent = 031100,
            AlterEvent = 031200,
            TrollEvent = 031300,
            SanctuaryEvent = 031400,
            GoldEvent = 031500,
            LakeEvent = 031600,
            CampEvent = 031700,
            StatueEvent = 031800
        }

        public Chapter3Events(GameEventManager _gameEventManager, Player _player)
        {
            player = _player;
            isSuccess = false;
            isWin = false;
            gameEventManager = _gameEventManager;
            EventDictionary = new Dictionary<int, Action>();
            #region EventDictionary.Add...
            EventDictionary.Add(030100, () => WestGateEvent_030100());
            EventDictionary.Add(030101, () => WestGateEvent_030101());
            EventDictionary.Add(030102, () => WestGateEvent_030102());
            EventDictionary.Add(030200, () => TreeEvent_030200());
            EventDictionary.Add(030201, () => TreeEvent_030201());
            EventDictionary.Add(030202, () => TreeEvent_030202());
            EventDictionary.Add(030203, () => TreeEvent_030203());
            EventDictionary.Add(030204, () => TreeEvent_030204());
            EventDictionary.Add(030205, () => TreeEvent_030205());
            EventDictionary.Add(030206, () => TreeEvent_030206());
            EventDictionary.Add(030215, () => TreeEvent_030215());
            EventDictionary.Add(030216, () => TreeEvent_030216());
            EventDictionary.Add(030300, () => TreeEvent_030300());
            EventDictionary.Add(030301, () => TreeEvent_030301());
            EventDictionary.Add(030302, () => TreeEvent_030302());
            EventDictionary.Add(030303, () => TreeEvent_030303());
            EventDictionary.Add(030304, () => TreeEvent_030304());
            EventDictionary.Add(030305, () => TreeEvent_030305());
            EventDictionary.Add(030306, () => TreeEvent_030306());
            EventDictionary.Add(030400, () => SeedEvent_030400());
            EventDictionary.Add(030401, () => SeedEvent_030401());
            EventDictionary.Add(030500, () => HutEvent_030500());
            EventDictionary.Add(030501, () => HutEvent_030501());
            EventDictionary.Add(030502, () => HutEvent_030502());
            EventDictionary.Add(030503, () => HutEvent_030503());
            EventDictionary.Add(030600, () => FairyEvent_030600());
            EventDictionary.Add(030601, () => FairyEvent_030601());
            EventDictionary.Add(030602, () => FairyEvent_030602());
            EventDictionary.Add(030700, () => RuinsEvent_030700());
            EventDictionary.Add(030701, () => RuinsEvent_030701());
            EventDictionary.Add(030702, () => RuinsEvent_030702());
            EventDictionary.Add(030800, () => DeadbodyEvent_030800());
            EventDictionary.Add(030801, () => DeadbodyEvent_030801());
            EventDictionary.Add(030900, () => TombEvent_030900());
            EventDictionary.Add(030901, () => TombEvent_030901());
            EventDictionary.Add(030902, () => TombEvent_030902());
            EventDictionary.Add(031000, () => TraderEvent_031000());
            EventDictionary.Add(031001, () => TraderEvent_031001());
            EventDictionary.Add(031100, () => WyvernEvent_031100());
            EventDictionary.Add(031101, () => WyvernEvent_031101());
            EventDictionary.Add(031102, () => WyvernEvent_031102());
            EventDictionary.Add(031200, () => AlterEvent_031200());
            EventDictionary.Add(031201, () => AlterEvent_031201());
            EventDictionary.Add(031300, () => TrollEvent_031300());
            EventDictionary.Add(031301, () => TrollEvent_031301());
            EventDictionary.Add(031302, () => TrollEvent_031302());
            EventDictionary.Add(031400, () => SanctuaryEvent_031400());
            EventDictionary.Add(031401, () => SanctuaryEvent_031401());
            EventDictionary.Add(031500, () => GoldEvent_031500());
            EventDictionary.Add(031501, () => GoldEvent_031501());
            EventDictionary.Add(031502, () => GoldEvent_031502());
            EventDictionary.Add(031600, () => LakeEvent_031600());
            EventDictionary.Add(031601, () => LakeEvent_031601());
            EventDictionary.Add(031602, () => LakeEvent_031602());
            EventDictionary.Add(031700, () => CampEvent_031700());
            EventDictionary.Add(031701, () => CampEvent_031701());
            EventDictionary.Add(031800, () => StatueEvent_031800());
            EventDictionary.Add(031801, () => StatueEvent_031801());
            EventDictionary.Add(031900, () => DeadEvent_031900());
            EventDictionary.Add(031901, () => toMainMenu());
            #endregion
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

        private void ChooseEvent()
        {
            if(gameEventManager.EventNumber == 10)
            {
                if (gameEventManager.hasSeedling)
                {
                    gameEventManager.NextEventID = 030200;
                    return;
                }

                else if (!gameEventManager.hasSeedling)
                {
                    gameEventManager.NextEventID = 030300;
                    return;
                }
            }
            
            gameEventManager.NextEventID = (int)(Events)values.GetValue(random.Next(values.Length));

            if (!EventDictionary.ContainsKey(gameEventManager.NextEventID))
            {
                ChooseEvent();
            }
        }

        private void NextEvent(int nextEvent)
        {
            if (EventDictionary.ContainsKey(nextEvent))
            {
                gameEventManager.NextEventID = nextEvent;
            }

            if (gameEventManager.NextEventID == 031901)
            {
                return;
            }

            else if (player.isDead())
            {
                gameEventManager.NextEventID = 031900;
                gameEventManager.resetSellectButtons();
                gameEventManager.setSellectButton1("- 영원한 안식", string.Empty, string.Empty);
            }
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

            if (player.isDead())
            {
                gameEventManager.NextEventID = 031900;
                gameEventManager.resetSellectButtons();
                gameEventManager.setSellectButton1("- 영원한 안식", string.Empty, string.Empty);
            }
        }
        #endregion

        #region WestGateEvent_0301...
        private void WestGateEvent_030100()
        {
            FirstEvent();

            if(gameEventManager.hasSeedling)
            {
                gameEventManager.PrintTextBlock(" 당신은 스카이튼의 이야기를 듣고 묘목을 챙기고 다시 서문에 도착했다." +
                   " 서문에는 이전에 보았던 것보다 훨씬 더 많은 수의 거름인간들이 있었다.\n\n");

                gameEventManager.setSellectButton1("- 묘목을 꺼낸다");
            }

            else
            {
                gameEventManager.PrintTextBlock(" 당신은 스카이튼의 이야기를 듣고 나뭇가지를 챙기고 다시 서문에 도착했다." +
                    " 서문에는 이전에 보았던 것보다 훨씬 더 많은 수의 거름인간들이 있었다.\n\n");

                gameEventManager.setSellectButton1("- 나뭇가지를 꺼낸다");
            }

            NextEvent(030101);
        }

        private void WestGateEvent_030101()
        {
            StartEvent();

            if(gameEventManager.hasSeedling)
            {
                gameEventManager.PrintTextBlock(" 당신은 수많은 거름인간들 앞에서 약간 겁먹기도 하였지만" +
                    " 연구소에서의 경험과 스카이튼의 견해를 믿고 가방에서 묘목을 꺼내들고 서문에 다가갔다.\n\n" +
                    " 서문에 다가가자 거름인간들은 달려들지 않았고 오히려 당신을 피하는 듯 보였다.\n\n");

                gameEventManager.setSellectButton1("- 앞으로 향한다");
            }

            else
            {
                gameEventManager.PrintTextBlock(" 당신은 수많은 거름인간들 앞에서 약간 겁먹기도 하였지만" +
                    " 연구소에서의 경험과 스카이튼의 견해를 믿고 가방에서 나뭇가지를 꺼내들고 서문에 다가갔다.\n\n" +
                    " 서문에 다가가자 거름인간들은 달려들지 않았고 오히려 당신을 피하는 듯 보였다.\n\n");

                gameEventManager.setSellectButton1("- 앞으로 향한다");
            }

            NextEvent(030102);
        }

        private void WestGateEvent_030102()
        {
            StartEvent();

                gameEventManager.PrintTextBlock(" 숲의 중심으로 들어갈수록 거름인간의 수는 점점 줄어들었고 더 걷자 주변에 거름인간은 하나도 보이지 않았다.\n\n" +
                    " 뒤를 돌아보니 서문에서 꽤 멀리까지 걸어왔다는 것을 깨달았고 당신은 스카이튼이 알려준 어미나무가 있는 방향으로 향했다.");

            LastEvent();
        }
        #endregion

        #region TreeEvent_0302...
        private void TreeEvent_030200()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 오랜 시간 동안 숲의 중심을 향하여 걸었고 저 멀리 매우 거대한 나무가 보이기 시작했다." +
                " 당신은 모험의 끝이 다가온다는 것을 직감했고 저 나무가 스카이튼이 말한 어미나무임을 확신했다.\n\n");

            gameEventManager.setSellectButton1("- 나무로 향한다");

            NextEvent(030201);
        }

        private void TreeEvent_030201()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 나무가 보이는 방향으로 계속해서 걸었고 마침내 어미나무가 있는 곳에 도달할 수 있었다.\n\n" +
                " 어미나무는 당신이 지금껏 본 어떤 나무보다 거대했고 나무의 중심에는 스카이튼의 동료인 델트 우드가드가 박혀있었다.\n\n");

            gameEventManager.setSellectButton1("- 우드가드에게 다가간다");

            NextEvent(030202);
        }

        private void TreeEvent_030202()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 델트 우드가드에게 다가가 대화를 하고자 하였다." +
                " 나무에게 다가갈수록 대장간에서 가져온 마나를 태우는 불이 미친 듯이 타오르기 시작했고 그것을 본 델트 우드가드가 당신에게 마법을 사용해 공격했다.\n\n");

            gameEventManager.setSellectButton1("- 쳐낸다", STRENGTH, gameEventManager.SuccessProbability(20, 3, player.Strength));
            gameEventManager.setSellectButton2("- 회피한다", DEXTERITY, gameEventManager.SuccessProbability(20,3,player.Dexterity));
            gameEventManager.setSellectButton3("- 상쇄시킨다", INTELLIGENCE, gameEventManager.SuccessProbability(20,3,player.Intelligence));

            NextEvent(030203);
        }

        private void TreeEvent_030203()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                isSuccess = gameEventManager.isSuccess(20, 3, player.Strength);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                isSuccess = gameEventManager.isSuccess(20, 3, player.Dexterity);
            }

            else if(gameEventManager.ButtonNumber == 3)
            {
                isSuccess = gameEventManager.isSuccess(20, 3, player.Intelligence);
            }

            if(isSuccess)
            {
                gameEventManager.SuccessMessage();
                gameEventManager.PrintTextBlock(" 당신은 델트 우드가드의 공격을 무력화 시켰다. 아무래도 델트 우드가드는 어미나무에게 잠식당해 의식이 없는 것 같다.\n\n");

                gameEventManager.setBattleButton(120);
                isWin = gameEventManager.isWin(120);
            }

            else
            {
                gameEventManager.FailMessage();
                gameEventManager.PrintTextBlock(" 델트 우드가드의 공격은 매우 빠르고 강력했고 당신은 그의 공격에 당할 수밖에 없었다." +
                    " 아무래도 델트 우드가드는 어미나무에게 잠식당해 의식이 없는 것 같다.\n\n");

                gameEventManager.setBattleButton(140);
                isWin = gameEventManager.isWin(140);
            }

            NextEvent(030204);
        }

        private void TreeEvent_030204()
        {
            StartEvent();

            if(isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 델트 우드가드의 마법 수준은 매우 뛰어났고 어미나무의 영향으로 마법의 공격력과 속도 또한 매우 월등했다.\n\n" +
                    " 하지만 당신 또한 여기까지 올 동안 매우 많은 전투와 경험을 겪어 강해졌기에 델트 우드가드를 쓰러트릴 수 있었다.\n\n");

                gameEventManager.setSellectButton1("- 어미나무에게 다가간다");

                NextEvent(030205);
            }

            else
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock("  델트 우드가드의 마법 수준은 매우 뛰어났고 어미나무의 영향으로 마법의 공격력과 속도 또한 매우 월등했다.\n\n" +
                    " 당신 또한 여기까지 올 동안 매우 많은 전투와 경험을 겪어왔지만 델트 우드가드를 쓰러트리기에는 역부족이었다.\n\n");

                gameEventManager.setSellectButton1("- 잠시 후...");

                NextEvent(030215);
            }
        }

        private void TreeEvent_030205()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 우드가드를 쓰러트린 후 어미나무에게 다가갔다. 우드가드는 당신의 일격을 맞고 더 이상 움직이지 않았지만 어미나무는 아직도 살아있는 것 같았다.\n\n" +
                " 그때 당신은 허리춤에 있는 랜턴 안의 마나를 태우는 불이 매우 거세게 타오르고 있단 것을 깨달았다.\n\n");

            gameEventManager.setSellectButton1("- 어미나무에 불을 붙인다");

            NextEvent(030206);
        }

        private void TreeEvent_030206()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 마나를 태우는 불을 어미나무에 붙였다. 불은 급속도로 번지기 시작했고 얼마 지나지 않아 어미나무를 전부 다 태워 재만 남겨버렸다.\n\n" +
                " 어미나무가 사라지자 랜턴 안에 있던 마나를 태우는 불도 사그라지고 말았다.\n");
            gameEventManager.SomethigLostText("- 마나를 태우는 불");

            player.deleteItem(player.HasItemindex(1004));

           
            LastEvent();
            gameEventManager.isBurnTree = true;
            gameEventManager.setSellectButton1("- 에필로그...");
            gameEventManager.GameChapterChange();
        }

        private void TreeEvent_030215()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 어미나무의 앞에서 쓰러졌다. 당신은 큰 부상과 극심한 출혈로 인해 의식은 점점 흐려져갔다." +
                " 근처에는 수많은 거름인간들이 다가오고 있었고 당신은 죽음이 다가온 것을 깨달았다.\n\n");

            gameEventManager.setSellectButton1("- 눈을 감는다");

            NextEvent(030216);
        }

        private void TreeEvent_030216()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 죽음을 받아들이고 천천히 눈을 감았다. 거름인간들은 당신을 어미나무에게 옮기고 묘목을 어미나무에게 흡수시켰고 당신 또한 어미나무에게 흡수되었다.\n\n" +
                " 당신은 어미나무에게 흡수되며 죽음을 맞이했다.");

            LastEvent();
            gameEventManager.isBurnTree = false;
            gameEventManager.setSellectButton1("- 에필로그...");
            gameEventManager.GameChapterChange();
        }
        #endregion

        #region TreeEvent_0303...
        private void TreeEvent_030300()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 오랜 시간 동안 숲의 중심을 향하여 걸었고 저 멀리 매우 거대한 나무가 보이기 시작했다." +
                " 당신은 모험의 끝이 다가온다는 것을 직감했고 저 나무가 스카이튼이 말한 어미나무임을 확신했다.\n\n");

            gameEventManager.setSellectButton1("- 나무로 향한다");

            NextEvent(030301);
        }

        private void TreeEvent_030301()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 나무가 보이는 방향으로 계속해서 걸었고 마침내 어미나무가 있는 곳에 도달할 수 있었다. 어미나무는 당신이 지금껏 본 어떤 나무보다 거대했다.\n\n");

            gameEventManager.setSellectButton1("- 어미나무에게 다가간다");

            NextEvent(030302);
        }

        private void TreeEvent_030302()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신이 어미나무에게 다가가자 어미나무는 당신에게 말을 걸었다. 당신은 깜짝 놀랐지만 진정하고 어미나무가 하는 말에 집중했다.\n\n" +
                " \"아.. 드디어 왔군.. 기다리고 있었다..\"\n\n");

            gameEventManager.setSellectButton1("- 이야기를 듣는다");

            NextEvent(030303);
        }

        private void TreeEvent_030303()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" \"숲의 증식을 막으려 하는거겠지... 여기까지 왔으니 마지막으로 기회를 주지... 나에게 흡수되어라, 유능한 모험가이니 무엇이 옳은지 선택할 수 있을거다...\"\n\n");

            gameEventManager.setSellectButton1("- 공격한다");
            gameEventManager.setSellectButton2("- 흡수된다");
            gameEventManager.setSellectButton3("- 우드가드는 어디에?");

            NextEvent(030304);
        }

        private void TreeEvent_030304()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 어미나무의 이야기를 들은 후 어미나무를 공격했다. 어미나무는 당신의 공격을 맞고도 아무런 변화가 없었다.\n\n" +
                    " \"어리석군\"\n\n");

                gameEventManager.setBattleButton(165);

                NextEvent(030305);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 어미나무의 마지막 제안을 받아들였다. 당신은 천천히 어미나무에게 다가갔고 어미나무는 당신을 흡수했다.\n\n" +
                    " 당신의 몸은 전부 나무의 뿌리에 감싸졌고 의식은 점점 흐려져갔다.");

                LastEvent();
                gameEventManager.isBurnTree = false;
                gameEventManager.setSellectButton1("- 에필로그...");
                gameEventManager.GameChapterChange();
            }

            else if(gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.PrintTextBlock(" 당신은 우드가드가 보이지 않는 것을 어미나무에게 물었다.\n\n" +
                    " \"아.. 그 엘프 녀석 말인가... 나에게 흡수되었지, 꽤나 좋은 마력을 갖고 있더군..\"\n\n");

                gameEventManager.setSellectButton1("- 공격한다");
                gameEventManager.setSellectButton2("- 흡수된다");

                NextEvent(030304);
            }
        }

        private void TreeEvent_030305()
        {
            StartEvent();

            isWin = gameEventManager.isWin(165);

            if(isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 어미나무는 인간과는 차원이 다른 마나를 갖고 있었고 마법의 수준 또한 월등히 뛰어났다." +
                    " 하지만 당신 또한 여기까지 올 동안 매우 많은 전투와 경험을 겪어 왔고 어미나무의 공격을 받아치며 어미나무를 끊임없이 공격했다.\n\n" +
                    " 하지만 어미나무는 전혀 피해를 입지 않는 것 같았다. 그때 당신은 허리춤에 있는 랜턴 안의 마나를 태우는 불이 매우 거세게 타오르고 있단 것을 깨달았다.\n\n");

                gameEventManager.setSellectButton1("- 어미나무에 불을 붙인다");

                NextEvent(030306);
            }

            else
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 어미나무는 인간과는 차원이 다른 마나를 갖고 있었고 마법의 수준 또한 월등히 뛰어났다. 당신은 어미나무에게 그 무엇도 할 수 없었고 처참하게 패배하였다.\n\n" +
                    " 당신은 큰 부상과 극심한 출혈로 인해 의식은 점점 흐려져갔다. 어미나무는 쓰러져있는 당신을 흡수했고 뿌리에 감싸진 채 죽음을 맞이했다.\n\n");

                LastEvent();
                gameEventManager.isBurnTree = false;
                gameEventManager.setSellectButton1("- 에필로그...");
                gameEventManager.GameChapterChange();
            }
        }

        private void TreeEvent_030306()
        {
            StartEvent();

            gameEventManager.PrintTextBlock("  당신은 어미나무에게 다가가 마나를 태우는 불을 붙였다." +
                    " 불은 급속도로 번지기 시작했고 어미나무는 매우 크게 소리쳤다. 얼마 지나지 않아 어미나무를 전부 다 태워 재만 남겨버렸다.\n\n" +
                    " 어미나무가 사라지자 랜턴 안에 있던 마나를 태우는 불도 사그라지고 말았다.\n");
            gameEventManager.SomethigLostText("- 마나를 태우는 불");

            player.deleteItem(player.HasItemindex(1004));

            LastEvent();
            gameEventManager.isBurnTree = true;
            gameEventManager.setSellectButton1("- 에필로그...");
            gameEventManager.GameChapterChange();
        }
        #endregion

        #region SeedEvent_0304...
        private void SeedEvent_030400()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 다시 숲을 걷고 있었다. 당신의 앞에 지도를 보면서 걷는 사람이 있었고, 아마 모험가? 인 것 같았다. 그 사람이 당신을 보더니 다가와서 말을 걸었다.\n\n" +
                " \"혹시 빛이 나고 향기가 나는 씨앗을 본 적 있으신가요? 혹시, 갖고 계시다면 제게 주실 수 있을까요?\"\n\n");

            gameEventManager.setSellectButton1("- 씨앗을 준다");
            gameEventManager.setSellectButton2("- 씨앗을 주지 않는다");
            gameEventManager.setSellectButton3("- 씨앗을 찾는 이유를 묻는다");

            int hasItemindex = player.HasItemindex(1003);
            if(hasItemindex == -1)
            {
                gameEventManager.setSellecButton1Disable();
            }

            EventDictionary.Remove(gameEventManager.NowEventID);
            NextEvent(030401);
        }

        private void SeedEvent_030401()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" \"아, 감사합니다. 드디어 여기도 다 모았군요. 감사의 표시로 저희 지역의 무기를 드리죠.\"\n\n" +
                    " 당신은 갖고 있던 씨앗을 모험가?에게 주었다. 그는 감사의 표시로 당신에게 무기와 약간의 골드를 주었다.\n");
                gameEventManager.SomethigLostText("- 씨앗\n");
                gameEventManager.SomethigGetText("+ 소서러\n" +
                    "+ 골드 20");

                int hasItemindex = player.HasItemindex(1003);
                player.deleteItem(hasItemindex);
                player.addItem(3011);
                player.addGold(20);

                LastEvent();
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 그에게 씨앗을 주지 않았다. 그는 아쉬워하며 다시 지도를 보며 떠났다.");

                LastEvent();
            }

            else if(gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.PrintTextBlock(" 당신은 그에게 씨앗을 찾는 이유를 물었다.\n\n" +
                    " \"아, 저는 여러 대륙을 돌아다니면서 이 씨앗을 모으고 있습니다. 지금 이 곳에도 딱 하나 남았는데 통 보이질 않아서..\"\n\n");

                gameEventManager.setSellectButton1("- 씨앗을 준다");
                gameEventManager.setSellectButton2("- 씨앗을 주지 않는다");

                int hasItemindex = player.HasItemindex(1003);
                if (hasItemindex == -1)
                {
                    gameEventManager.setSellecButton1Disable();
                }

                NextEvent(030401);
            }
        }
        #endregion

        #region HutEvent_0305...
        private void HutEvent_030500()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 숲에서 한 허름한 오두막을 발견했다." +
                " 당신은 그 오두막에 다가갔고 멀리서는 허름해 보이기만 하던 오두막이 가까이서 보니 지금 당장이라도 무너질 것 같았다.\n\n");

            gameEventManager.setSellectButton1("- 오두막을 살펴본다");
            gameEventManager.setSellectButton2("- 지나친다");

            NextEvent(030501);
        }

        private void HutEvent_030501()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 오두막의 안을 살펴보았다. 오두막 안에는 전에 살던 사람이 쓰던 물건들이 그대로 있었다." +
                    " 물건들에는 먼지가 쌓여있었고 천장에는 거미줄까지 쳐져있었다. 아무래도 버려진지 오래된 모양이다.\n\n" +
                    " 오두막을 더 살펴보니 침대 밑에 꽤 큰 상자가 하나 있었다. 당신은 침대 밑에서 상자를 꺼냈다. 상자는 다른 물건들에 비해 비교적 깔끔해 보인다.\n\n");

                gameEventManager.setSellectButton1("- 상자를 연다");
                gameEventManager.setSellectButton2("- 상자를 부순다");

                NextEvent(030502);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 귀신이 튀어나올 것 같은 오두막을 무시하고 지나쳤다.");

                LastEvent();
            }
        }

        private void HutEvent_030502()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 상자를 조심히 열어보았다. 그러자 상자에서 갑자기 팔이 나와 당신을 붙잡았고 당신을 집어삼키려했다." +
                    " 당신은 가까스로 빠져나왔지만 미믹은 당신을 절대 놔줄 생각이 없나보다.\n\n");

                gameEventManager.setBattleButton(80);
                isWin = gameEventManager.isWin(80);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 불안감을 느낀 당신은 상자를 열기 전 상자를 공격했다. 그러자 상자에서 갑자기 팔이 나와 도망쳤고 잠시 후 상자는 당신에게 돌진했다.\n\n");

                gameEventManager.setBattleButton(60);
                isWin = gameEventManager.isWin(60);
            }

            NextEvent(030503);
        }

        private void HutEvent_030503()
        {
            StartEvent();

            if(isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 당신은 미믹을 부숴버렸다. 부서져서 쓰러진 미믹은 꽤 보기 흉했으나 당신은 미믹을 열어보았고 그 안에는 꽤 많은 양의 골드가 들어있었다.\n");
                gameEventManager.SomethigGetText("+ 골드 50");

                player.addGold(50);
            }

            else if(!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 당신은 미믹에게 맞섰지만 미믹의 이빨에 물려 출혈이 꽤 심각했다." +
                    " 당신은 오두막에서 빠져나왔고 미믹은 당신을 쫓아왔으나 오두막이 무너져버렸다. 당신은 잔해에 깔린 미믹을 보고 한숨을 돌린 후 오두막을 떠났다.\n");
                gameEventManager.SomethigLostText("- 체력 5");

                player.Damaged(5);
            }

            LastEvent();
        }
        #endregion

        #region FairyEvent_0306...
        private void FairyEvent_030600()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 숲을 다니던 중 무언가 위화감을 느꼈다. 똑같은 길을 계속해서 반복하는 것 같은 기분이었다. 당신이 그것을 깨닫자 어디선가 어린아이의 목소리가 들린다.\n\n" +
                " \"하핫!　그래도 꽤 빨리 알아차렸네~?　더 오래 걸릴 줄 알았는데! 앞으로 가봐~ 세 가지 갈림길이 나올 거야. 맘에 드는 곳으로 골라!\"\n\n" +
                " 앞으로 가보니 정말로 세 갈래 길이 나왔다.\n\n");

            gameEventManager.setSellectButton1("- 왼쪽 길");
            gameEventManager.setSellectButton2("- 가운데 길");
            gameEventManager.setSellectButton3("- 오른쪽 길");

            NextEvent(030601);
        }

        private void FairyEvent_030601()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1 || gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" \"땡~ 아쉽네, 그래도 재밌었어! 다음에 또 봐~\"\n\n" +
                    " 더 이상 목소리는 들리지 않았고 당신은 계속해서 반복하는 길을 빠져나왔다.");

                LastEvent();
            }

            else if(gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.PrintTextBlock(" 당신은 오른쪽 길로 향했고, 그곳에는 한 상자가 있었다.\n\n");

                gameEventManager.setSellectButton1("- 상자를 연다");
                gameEventManager.setSellectButton2("- 상자를 열지 않는다");

                NextEvent(030602);
            }
        }

        private void FairyEvent_030602()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 상자를 열었다. 상자를 열자 목소리가 다시 들렸다. 상자 안에는 약간의 음식과 골드가 들어있었다.\n\n" +
                    " \"오.. 길도 맞추고 상자까지 열다니, 축하해!　재미있었어 다음에 또 봐!\"\n");
                gameEventManager.SomethigGetText("+ 고기\n" +
                    "+ 골드 30");

                player.addItem(2002);
                player.addGold(30);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 상자를 열지 않기로 결정했다. 그러자 목소리가 다시 들렸다.\n\n" +
                    " \"아쉽네! 길은 맞췄는데, 상자를 열었으면 어마어마한 보상이 있었을텐데! 재밌었어 다음에 또 봐!\"");
            }

            LastEvent();
        }
        #endregion

        #region RuinsEvent_0307...
        private void RuinsEvent_030700()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 깊은 숲에 숨겨져있는 유적을 발견했다. 돌로 지어진 유적은 매우 오래된 것 같지만 아직 튼튼해 보인다." +
                " 유적의 입구에는 글이 쓰여있지만 아무래도 고대 언어인 것 같다.\n\n");

            gameEventManager.setSellectButton1("- 안으로 들어간다");
            gameEventManager.setSellectButton2("- 지나친다");
            gameEventManager.setSellectButton3("- 해독한다", INTELLIGENCE, gameEventManager.SuccessProbability(20, 4, player.Intelligence));

            EventDictionary.Remove(gameEventManager.NowEventID);
            NextEvent(030701);
        }

        private void RuinsEvent_030701()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 유적의 안으로 진입했다. 안은 매우 어두웠고 당신은 벽을 짚고 앞으로 나아갔다." +
                    " 당신이 길의 끝에 도달했을 때 유적 안에 있는 횃불들에 불이 들어왔고 당신의 양옆에는 거대한 가고일 두 마리가 움직이기 시작했다.\n\n");

                gameEventManager.setBattleButton(85);

                NextEvent(030702);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 거대한 오래된 유적을 눈으로만 지켜보고 떠났다.");

                LastEvent();
            }

            else if(gameEventManager.ButtonNumber == 3)
            {
                isSuccess = gameEventManager.isSuccess(20, 4, player.Intelligence);

                if(isSuccess)
                {
                    gameEventManager.SuccessMessage();
                    gameEventManager.PrintTextBlock(" 당신은 과거에 읽었던 고대 언어와 관련된 책이 떠올랐고 그 책의 기억으로 이 글을 해독할 수 있었다. 글에는 다음과 같이 적혀있었다.\n\n" +
                    " \"진정으로 강한 자, 시험에 들어라.\"\n\n");
                }

                else if(!isSuccess)
                {
                    gameEventManager.FailMessage();
                    gameEventManager.PrintTextBlock(" 당신은 글을 해독해보려고 하였지만 고대 언어를 전혀 해독할 수 없었다.\n\n");
                }

                gameEventManager.setSellectButton1("- 안으로 들어간다");
                gameEventManager.setSellectButton2("- 지나친다");

                NextEvent(030701);
            }
        }

        private void RuinsEvent_030702()
        {
            isWin = gameEventManager.isWin(85);

            if(isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 당신은 가고일들과 전투했고 두 가고일은 더 이상 움직이지 않는 바위로 돌아갔다." +
                    " 그러자 벽인 줄 알았던 것이 열렸고 안에는 매우 화려한 상자가 있었다. 당신은 상자를 열었고 상자 안에는 강한 힘이 책 한 권이 눃여있었다.\n");
                gameEventManager.SomethigGetText("+ 고대서");

                player.addItem(3014);
            }

            else if(!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 당신은 가고일들과 전투했지만 너무나도 강했고 당신은 도망칠 수밖에 없었다." +
                    " 당신이 도망치자 가고일들은 다시 원래 자리로 돌아갔고 유적의 횃불은 꺼졌다. 유적 밖으로 나오자 유적의 문은 쾅 소리를 내며 굳게 닫혔다.\n");
                gameEventManager.SomethigLostText("- 체력 5");

                player.Damaged(5);
            }

            LastEvent();
        }
        #endregion

        #region DeadbodyEvent_0308...
        private void DeadbodyEvent_030800()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 쓰러져있는 사람을 발견했고 서둘러 그 사람에게 다가갔다. 하지만 그는 이미 죽어있었다. 그의 차림새를 보아하니 아무래도 모험가인 것 같았다.\n\n");

            gameEventManager.setSellectButton1("- 시체를 묻어준다");
            gameEventManager.setSellectButton2("- 가방을 가져간다");
            gameEventManager.setSellectButton3("- 지나친다");

            NextEvent(030801);
        }

        private void DeadbodyEvent_030801()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 이름도 모르는 모험가의 시체와 그의 소지품을 함께 묻어주었다. 무덤에 나뭇가지를 꽂아 간단히 장례를 치른 후 당신은 다시 숲의 중심부로 향했다.\n");
                gameEventManager.SomethigGetText("+ 지능 1\n" +
                    "+ 지혜 1");
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 그의 가방을 챙겼다. 모험가의 가방에는 모험에 이로운 물건들이 많이 들어있었다.\n");
                gameEventManager.SomethigGetText("+ 체력 물약\n" +
                    "+ 은장검\n" +
                    "+ 골드 50");

                player.addItem(2001);
                player.addItem(3013);
                player.addGold(50);
            }

            else if(gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.PrintTextBlock(" 당신은 모험가의 죽음을 안타까워하며 숲의 중심부로 향했다.");
            }

            LastEvent();
        }
        #endregion

        #region TombEvent_0309...
        private void TombEvent_030900()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 매우 거대한 무덤을 발견했다. 여태 본 무덤들 중 가장 거대했고 밖에서 봐도 화려한 것이 한눈에 보일 정도였다. 아무래도 왕의 무덤인 것 같다.\n\n");

            gameEventManager.setSellectButton1("- 무덤에 들어간다");
            gameEventManager.setSellectButton2("- 지나친다");

            EventDictionary.Remove(gameEventManager.NowEventID);
            NextEvent(030901);
        }

        private void TombEvent_030901()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 무덤 안으로 들어갔다. 무덤 안은 매우 넓고 화려했고 마치 왕실 안에 들어온 것 같았다." +
                    " 무덤의 끝에는 계단이 있었고 왕좌가 있을 자리인 계단 위에는 관이 하나 놓여 있었다.\n\n" +
                    " 당신이 관에 다가가기 위해 발을 내딛자 수많은 스켈레톤들이 갑옷을 입은 채 바닥에서 올라와 군대를 이루었고 대장으로 보이는 스켈레톤이 공격명령을 내렸다.\n\n");

                gameEventManager.setBattleButton(90);

                NextEvent(030902);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 거대한 무덤의 주인이 누구인지 궁금해하며 무덤을 떠났다.");

                LastEvent();
            }
        }

        private void TombEvent_030902()
        {
            StartEvent();

            isWin = gameEventManager.isWin(90);

            if(isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 당신은 대장 스켈레톤까지 모든 스켈레톤을 쓰러트렸다." +
                    " 그 후 계단을 올라가 관을 열어보았고 관 안에는 황금갑옷을 입고 있는 해골이 있었다. 당신은 황금갑옷을 챙기고 무덤에서 나왔다.\n");
                gameEventManager.SomethigGetText("+ 황금갑옷");

                player.addItem(4004);
            }

            else if(!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 스켈레톤들은 너무 많았고 하나하나가 뛰어난 전투능력을 갖추고 있었다. 당신은 무덤에서 도망쳤고 뒤를 돌아보니 스켈레톤들은 전투의 승리를 축하하고 있었다.\n");
                gameEventManager.SomethigLostText("- 체력 5");

                player.Damaged(5);
            }

            LastEvent();
        }
        #endregion

        #region TraderEvent_0310...
        private void TraderEvent_031000()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 깊은 산중에서 바위 위에 앉아있는 사람을 발견했다." +
                " 그는 아무래도 잠시 쉬고 있는 것 같았고 그의 옆에는 거대한 보따리가 보인다. 그가 당신을 발견하고는 말을 건네온다.\n\n" +
                " \"아.. 손님이로군.. 난 그저 숲에서 물건을 파는 사람일세. 물건 좀 보고 가게나\"\n\n");

            gameEventManager.setSellectButton1("- 물건을 본다");
            gameEventManager.setSellectButton2("- 떠난다");
            gameEventManager.setSellectButton3("- 어째서 이런 곳에서?");

            NextEvent(031001);
        }

        private void TraderEvent_031001()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.trader.addItems(GameItem.ShopType.Chapter3);
                View.Play.TradeWindowOpen();
                gameEventManager.PrintTextBlock(" 당신은 상인의 물건을 보고나서 상인과 인사를 한 후 떠났다.");

                LastEvent();
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 상인의 물건을 보지 않고 상인과 인사를 한 후 떠났다.");

                LastEvent();
            }

            else if(gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.PrintTextBlock(" 당신은 이런 위험한 곳에서 물건을 파는 이유를 물었다.\n\n" +
                    " \"나도 모험을 했었네, 이제는 자네 같은 사람들에게 도움을 주는 거지.\"\n\n");

                gameEventManager.setSellectButton1("- 물건을 본다");
                gameEventManager.setSellectButton2("- 떠난다");

                NextEvent(031001);
            }
        }
        #endregion

        #region WyvernEvent_0311...
        private void WyvernEvent_031100()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 갑자기 하늘에서 무언가 펄럭이는 소리가 들렸다. 작은 소리를 들은 당신은 하늘을 쳐다보았고 소리는 점점 가까워지고 있었다." +
                " 그러자 하늘에서 와이번이 나타났고 와이번이 당신을 알아차리자 포효한 후 당신에게 돌진한다.\n\n");

            gameEventManager.setBattleButton(90);
            gameEventManager.setSellectButton2("- 받아친다", STRENGTH, gameEventManager.SuccessProbability(30, 3, player.Strength));
            gameEventManager.setSellectButton3("- 자세를 낮춘다", DEXTERITY, gameEventManager.SuccessProbability(30, 3, player.Dexterity));

            NextEvent(031101);
        }

        private void WyvernEvent_031101()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                isWin = gameEventManager.isWin(90);

                NextEvent(031102);
                gameEventManager.RunEvent(1);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                isSuccess = gameEventManager.isSuccess(30, 3, player.Strength);

                if(isSuccess)
                {
                    gameEventManager.SuccessMessage();
                    gameEventManager.PrintTextBlock(" 당신은 와이번의 돌진을 무기로 받아쳤다." +
                        " 와이번의 힘은 엄청났지만 당신 또한 긴 모험으로 단련된 신체로 받아칠 수 있었다. 와이번은 고통에 몸부림쳤고 부상을 입은 것 같다.\n\n");

                    gameEventManager.setBattleButton(75);
                    isWin = gameEventManager.isWin(75);
                }

                else if(!isSuccess)
                {
                    gameEventManager.FailMessage();
                    gameEventManager.PrintTextBlock(" 당신은 와이번의 돌진을 무기로 받아쳤다." +
                        " 하지만 와이번의 힘은 엄청났고 당신은 뒤로 밀려날 수밖에 없었다. 와이번은 당신을 잡아먹기 위해 다시 돌진해온다.\n");
                    gameEventManager.SomethigLostText("- 체력 3\n\n");

                    player.Damaged(3);

                    gameEventManager.setBattleButton(100);
                    isWin = gameEventManager.isWin(100);
                }
            }

            else if(gameEventManager.ButtonNumber == 3)
            {
                isSuccess = gameEventManager.isSuccess(30, 3, player.Dexterity);

                if(isSuccess)
                {
                    gameEventManager.SuccessMessage();
                    gameEventManager.PrintTextBlock(" 당신은 와이번이 날라오자마자 아래로 몸을 숙였고 당신의 머리 바로 위로 와이번의 발톱이 지나갔다." +
                        " 와이번은 제 속도를 버티지 못하고 바닥에 나뒹굴었고 부상을 입은 것 같다.\n\n");

                    gameEventManager.setBattleButton(75);
                    isWin = gameEventManager.isWin(75);
                }

                else if(!isSuccess)
                {
                    gameEventManager.FailMessage();
                    gameEventManager.PrintTextBlock(" 당신은 와이번이 날라오자마자 아래로 몸을 숙였지만 와이번의 발톱에 옷이 걸려버렸다." +
                        " 당신은 뒤로 넘어졌고 와이번은 소리치며 당신에게 돌진해온다.\n\n");
                    gameEventManager.SomethigLostText("- 체력 3\n\n");

                    player.Damaged(3);

                    gameEventManager.setBattleButton(100);
                    isWin = gameEventManager.isWin(100);
                }
            }

            NextEvent(031102);
        }

        private void WyvernEvent_031102()
        {
            StartEvent();

            if(isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 당신은 포악한 와이번을 쓰러트렸다. 생전 처음 본 와이번이었고 지식도 전혀 없었지만 당신은 와이번에게서 약간의 고기와 발톱을 챙길 수 있었다.\n");
                gameEventManager.SomethigGetText("+ 고기\n" +
                    "+ 와이번의 발톱");

                player.addItem(2002);
                player.addItem(3005);
            }

            else if(!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 와이번의 힘은 엄청났고 속도 또한 매우빨랐다." +
                    " 게다가 입에서는 불까지 나오니 어찌 할 방도가 없었다. 당신은 도망칠 수밖에 없었고 나무를 부러트려 쫓아오는 와이번을 막았다.\n");
                gameEventManager.SomethigLostText("- 체력 5");

                player.Damaged(5);
            }

            LastEvent();
        }
        #endregion

        #region AlterEvent_0312...
        private void AlterEvent_031200()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 제단을 발견했다. 제단 안은 이끼로 뒤덮여있었고 아주 오래된 것 같았다." +
                " 제단의 중앙에는 계단이 있었고 계단을 올라가자 꽤나 큰 구멍이 있었다. 아무래도 무언가를 바쳐야 하는 것 같다.\n\n");

            gameEventManager.setSellectButton1("- 팔을 넣는다");
            gameEventManager.setSellectButton2("- 골드를 넣는다");
            gameEventManager.setSellectButton3("- 떠난다");

            if(player.Gold < 150)
            {
                gameEventManager.setSellecButton2Disable();
            }

            EventDictionary.Remove(gameEventManager.NowEventID);
            NextEvent(031201);
        }

        private void AlterEvent_031201()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 구멍 안에 팔을 집어넣었다." +
                    " 그러자 구멍 안에서 수없이 많은 가시들이 나와 당신의 팔을 찔렀고 제단 안에는 당신의 비명소리와 피가 떨어지는 소리밖에 들리지 않았다.\n\n" +
                    " 잠시 후 가시는 다시 들어갔고 당신은 고통에 몸부림치며 팔을 빼냈다. 잠시 후 구멍에서 당신의 피가 묻은 검이 올라왔다.\n");
                gameEventManager.SomethigLostText("- 체력 10\n");
                gameEventManager.SomethigGetText("+ 피 묻은 검");

                player.Damaged(10);
                player.addItem(3006);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 구멍 안에 갖고 있는 골드를 넣었다. 그러자 구멍 안에서는 골드가 짤랑거리는 소리가 들렸고 잠시 후 구멍에서 누군가의 피가 묻은 검이 올라왔다.\n");
                gameEventManager.SomethigLostText("- 골드 150\n");
                gameEventManager.SomethigGetText("+ 피 묻은 검");

                player.subGold(150);
                player.addItem(3006);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 불안하기만 한 제단을 떠났다.");
            }

            LastEvent();
        }
        #endregion

        #region TrollEvent_0313...
        private void TrollEvent_031300()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 앞에서 사람처럼 보이는 실루엣을 발견하고 그쪽으로 다가갔다." +
                " 가까이 가면 갈수록 사람치고는 너무 크다는 느낌이 들었고 실루엣의 정체는 트롤이란 것을 깨달았다. 당신이 트롤이라는 것을 알아차리자 트롤도 당신을 알아차리고 달려온다.\n\n");

            gameEventManager.setSellectButton1("- 해치운다");
            gameEventManager.setSellectButton2("- 도망친다", DEXTERITY, gameEventManager.SuccessProbability(40, 2, player.Dexterity));
            gameEventManager.setSellectButton3("- 타이른다", CHARM, gameEventManager.SuccessProbability(30, 2, player.Charm));

            NextEvent(031301);
        }

        private void TrollEvent_031301()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 이곳을 조금 더 안전한 곳으로 만들기 위해 트롤을 해치우기로 결정했다.\n\n");

                gameEventManager.setBattleButton(100);

                NextEvent(031302);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                isSuccess = gameEventManager.isSuccess(40, 2, player.Dexterity);

                if(isSuccess)
                {
                    gameEventManager.SuccessMessage();
                    gameEventManager.PrintTextBlock(" 당신은 달려오는 트롤을 피해 반대 방향으로 도망쳤다. 얼마나 도망쳤을까 뒤를 돌아보니 트롤은 더 이상 보이지 않았다.");

                    LastEvent();
                }

                else if(!isSuccess)
                {
                    gameEventManager.FailMessage();
                    gameEventManager.PrintTextBlock(" 당신은 달려오는 트롤일 피해 반대 방향으로 도망쳤지만 당신과 트롤의 거리는 너무나도 가까웠고 트롤은 바로 뒤까지 따라와 있었다.\n\n");

                    gameEventManager.setBattleButton(100);

                    NextEvent(031302);
                }
            }

            else if(gameEventManager.ButtonNumber == 3)
            {
                isSuccess = gameEventManager.isSuccess(30, 2, player.Charm);

                if (isSuccess)
                {
                    gameEventManager.SuccessMessage();
                    gameEventManager.PrintTextBlock(" 당신은 달려드는 트롤을 멈춰세우고 타일렀다. 그러자 트롤은 잠깐 생각하는 듯하더니 뒤를 돌아 떠나버렸다.");

                    LastEvent();
                }

                else if (!isSuccess)
                {
                    gameEventManager.FailMessage();
                    gameEventManager.PrintTextBlock(" 당신은 달려드는 트롤을 멈춰세우고 타일렀다. 하지만 트롤은 너무 굶주려있었고 당신을 먹이로만 생각하는듯했다.\n\n");

                    gameEventManager.setBattleButton(100);

                    NextEvent(031302);
                }
            }
        }

        private void TrollEvent_031302()
        {
            StartEvent();
            isWin = gameEventManager.isWin(100);

            if(isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 당신은 달려드는 트롤을 맞받아쳤고 그 충격에 트롤은 들고 있는 망치를 떨어트리며 뒤로 넘어졌다. 당황한 트롤은 그대로 도망쳤다.\n");
                gameEventManager.SomethigGetText("+ 트롤 망치\n" +
                    "+ 골드 30");

                player.addItem(3007);
                player.addGold(30);
            }

            else if(!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 트롤은 인간보다는 훨씬 큰 몸집을 갖고 있었고 힘　또한 상상을 초월했다. 망치에 한 대 맞은 당신은 승산이 없단 걸 깨닫고 도망쳤다.\n");
                gameEventManager.SomethigLostText("- 체력 5");

                player.Damaged(5);
            }

            LastEvent();
        }
        #endregion

        #region SanctuaryEvent_0314...
        private void SanctuaryEvent_031400()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 숲속에서 성소를 발견했다. 거대한 여신상이 있었고 그 앞에는 기도를 하는 공간이 있다." +
                " 당신의 몸은 무의식적으로 성소로 이끌려졌고 여신상 바로 앞에 서있다.\n\n");

            gameEventManager.setSellectButton1("- 기도한다");
            gameEventManager.setSellectButton2("- 여신상을 부순다");
            gameEventManager.setSellectButton3("- 떠난다");

            NextEvent(031401);
        }

        private void SanctuaryEvent_031401()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 여신상 앞에서 무릎을 꿇어 잠깐의 시간 동안 기도했다. 기도가 끝난 후 당신은 정신적으로 편안해짐을 느꼈고 홀가분한 마음으로 성소를 떠났다.\n");
                gameEventManager.SomethigGetText("+ 체력 20");

                player.Heal(20);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 여신상을 부숴 산산조각 내버렸다. 그러자 엄청난 두통이 밀려왔고 처음 듣는 사람들의 목소리가 뒤섞여 섬뜩하게 당신의 머릿속에서 계속해서 울렸다.\n\n" +
                    " 엄청나게 오랜 시간이 지난 후 점점 두통이 나아지면서 목소리가 옅어졌고 정신을 차린 당신의 눈앞에는 가루가 된 여신상의 파편들이 떨어져있었다. 당신은 무언가 깨달음을 얻었다.\n");
                gameEventManager.SomethigLostText("- 체력 10\n");
                gameEventManager.SomethigGetText("+ 지능 5");

                player.Damaged(10);
                player.Intelligence += 5;
            }

            else if(gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.PrintTextBlock(" 당신은 이름 모를 여신상이 있는 성소를 뒤로하고 떠났다.");
            }

            LastEvent();
        }
        #endregion

        #region GoldEvent_0315...
        private void GoldEvent_031500()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 숲을 가던 중에 바닥에 떨어져 있는 금괴를 발견했다. 금괴의 크기는 꽤 컸고 판다면 큰 골드가 될 것 같다.\n\n");

            gameEventManager.setSellectButton1("- 금괴를 가져간다");
            gameEventManager.setSellectButton2("- 그대로 둔다");

            NextEvent(031501);
        }

        private void GoldEvent_031501()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 금괴를 가져가기 위해 허리를 숙여 금괴를 잡았다." +
                    " 금괴를 잡자마자 금괴의 양옆에서 나무뿌리가 튀어나와 당신을 덮쳤고 당신은 가까스로 피했지만 뒤로 넘어질 수밖에 없었다." +
                    " 그러자 땅속에 숨어있던 거름인간이 튀어나왔고 금괴는 거름인간의 목 뒤에 붙어있었다.\n\n");

                gameEventManager.setBattleButton(70);

                NextEvent(031502);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 숲 한가운데에 금괴라니 아무리 봐도 의심스러운 금괴를 그대로 두고 떠났다.");

                LastEvent();
            }
        }

        private void GoldEvent_031502()
        {
            isWin = gameEventManager.isWin(70);

            if(isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 거름인간은 고작 하나밖에 없었기에 손쉽게 이길 수 있었다." +
                    " 거름인간을 쓰러트리고 목뒤에 붙어있는 금괴를 떼낸 후 확인해보니 금괴가 아닌 금괴처럼 보이는 열매였다.\n");
                gameEventManager.SomethigGetText("+ 골드 20");

                player.addGold(20);
            }

            else if(!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 거름인간에게 기습을 당한 당신은 계속되는 뿌리 공격에 속수무책으로 당할 수밖에 없었다. 당신은 계속되는 공격을 피하면서 도망쳤다.\n");
                gameEventManager.SomethigLostText("- 체력 5");

                player.Damaged(5);
            }

            LastEvent();
        }
        #endregion

        #region LakeEvent_0316...
        private void LakeEvent_031600()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 숲속에 있는 작다면 작고 크다면 큰 호수를 발견했다. 호수의 물은 매우 깨끗해 속이 전부 비칠 정도였다.\n\n");

            gameEventManager.setSellectButton1("- 마신다");
            gameEventManager.setSellectButton2("- 낚시한다");
            gameEventManager.setSellectButton3("- 떠난다");

            int hasItemindex = player.HasItemindex(1002);
            if (hasItemindex == -1)
            {
                gameEventManager.setSellecButton2Disable();
            }

            NextEvent(031601);
        }

        private void LakeEvent_031601()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 호수의 깨끗한 물을 마시기 위해 다가갔다. 갑자기 잔잔하던 호수가 요동치기 시작했고 호수의 중앙에서 물의 정령이 나타나 당신에게 다가온다.\n\n");

                gameEventManager.setBattleButton(80);

                NextEvent(031602);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 호수에 낚싯대를 던졌고 미끼를 물기를 기다렸다." +
                    " 하지만 갑자기 잔잔하던 호수가 요동치기 시작했고 호수의 중앙에서 물의 정령이 나타나 당신에게 다가온다.\n\n");

                gameEventManager.setBattleButton(80);

                NextEvent(031602);
            }

            else if(gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.PrintTextBlock(" 당신은 호수를 지나쳤다.");

                LastEvent();
            }
        }

        private void LakeEvent_031602()
        {
            isWin = gameEventManager.isWin(80);

            if(isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 당신은 물의 정령과 전투했다. 전투가 거듭될수록 물의 정령은 점점 형체가 무너져갔고 결국 형체가 전부 무너져 호수로 되돌아갔다." +
                    " 요동치던 호수는 다시 잠잠해졌다. 당신은 호수에서 물을 챙긴 뒤 호수를 떠났다.\n");
                gameEventManager.SomethigGetText("+ 깨끗한 물\n" +
                    "+ 골드 30");

                player.addItem(2010);
                player.addGold(30);
            }

            else if(!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 당신은 물의 정령과 전투했다. 하지만 물의 정령은 모든 공격을 흘려냈다." +
                    " 승산이 없다고 판단한 당신은 도망쳤고 물의 정령은 다시 물속으로 들어갔고 호수는 잔잔해졌다.\n");
                gameEventManager.SomethigLostText("- 체력 5");

                player.Damaged(5);
            }

            LastEvent();
        }
        #endregion

        #region CampEvent_0317...
        private void CampEvent_031700()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 오랜 모험에 지친 당신은 지친 몸을 회복하고 앞으로 있을 큰 전투를 대비하기 위해 갖고 있는 캠프를 쳤다.\n\n");

            gameEventManager.setSellectButton1("- 휴식한다");
            gameEventManager.setSellectButton2("- 요리한다");
            gameEventManager.setSellectButton3("- 명상한다");

            int hasItemIndex = player.HasItemindex(GameItem.ItemType.Food);
            if (hasItemIndex == -1)
            {
                gameEventManager.setSellecButton2Disable();
            }

            NextEvent(031701);
        }

        private void CampEvent_031701()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 캠프에서 잠깐의 단잠을 가진 후 숨의 중심으로 향했다.\n");
                gameEventManager.SomethigGetText("+ 체력 5");

                player.Heal(5);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                int hasItemIndex = player.HasItemindex(GameItem.ItemType.Food);

                gameEventManager.PrintTextBlock(" 당신은 갖고 있는 음식 재료로 요리를 했고 음식을 배불리 먹고 잠깐의 단잠을 가진 후 숲의 중심으로 향했다.\n");
                gameEventManager.SomethigGetText("+ 체력 20\n");
                gameEventManager.SomethigLostText("- " + player.Inventory[hasItemIndex].Name);

                player.Heal(20);
                player.deleteItem(hasItemIndex);
            }

            else if(gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.PrintTextBlock(" 당신은 캠프에서 지금까지 있었던 일들을 회상하고 앞으로 있을 일들을 대비했다. 당신은 모험을 확실히 준비한 다음 캠프를 정리하고 숲의 중심으로 향했다.\n");
                gameEventManager.SomethigGetText("+ 모든 스탯 1");

                player.Strength++;
                player.Dexterity++;
                player.Stamina++;
                player.Intelligence++;
                player.Wizdom++;
                player.Charm++;
            }

            LastEvent();
        }
        #endregion

        #region StatueEvent_0318...
        private void StatueEvent_031800()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 숲에서 석상 세 개를 마주했다." +
                " 석상들은 삼각형을 이루며 서있었고 삼각형의 중심을 보고 있었다. 당신이 삼각형의 중심에 들어가자 석상들이 눈을 뜨며 당신에게 소리쳤다.\n\n" +
                " \"지나가고 싶다면 선택해라!\"\n\n");

            gameEventManager.setSellectButton1("- 안식");
            gameEventManager.setSellectButton2("- 각성");
            gameEventManager.setSellectButton3("- 성장");

            NextEvent(031801);
        }

        private void StatueEvent_031801()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 안식을 선택했다. 석상들은 만족한 듯 미소를 지으며 눈을 감았다. 당신은 마음이 편안해졌다.\n");
                gameEventManager.SomethigGetText("+ 체력 15");

                player.Heal(15);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 각성을 선택했다. 석상들은 만족한 듯 미소를 지으며 눈을 감았다. 당신은 정신적, 신체적으로 각성했다.\n");
                gameEventManager.SomethigGetText("+ 모든 스탯 1");

                player.Strength++;
                player.Dexterity++;
                player.Stamina++;
                player.Intelligence++;
                player.Wizdom++;
                player.Charm++;
            }

            else if(gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.PrintTextBlock(" 당신은 성장을 선택했다. 석상들은 만족한 듯 미소를 지으며 눈을 감았다. 당신은 신체가 성장함을 느꼈다.\n");
                gameEventManager.SomethigGetText("+ 최대 체력 10");

                player.MaximumHP += 10;
            }

            LastEvent();
        }
        #endregion

        #region DeadEvent_0319...
        private void DeadEvent_031900()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 감옥숲 깊숙한 곳에서 죽음을 맞이했다." +
                " 이곳은 사람의 발길이 닿지 않는 곳이었기에 당신의 시체는 썩어 새들이 밥이 되고 나무의 거름이 되었고 결국 뼈만 남게 되었다.\n\n");

            gameEventManager.setSellectButton1("- 메인 메뉴로...");
            NextEvent(031901);
        }

        private void toMainMenu()
        {
            SaveService.SaveService.setFinsh();
            var MainWIndow = new View.MainMenu();
            ((View.MainWindow)Application.Current.MainWindow).mainWindow.Children.Clear();
            ((View.MainWindow)Application.Current.MainWindow).mainWindow.Children.Add(MainWIndow);
        }
        #endregion
    }
}