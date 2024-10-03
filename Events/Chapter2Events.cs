using System;
using System.Collections.Generic;
using System.Windows;
using 파파야연대기.Classes;

namespace 파파야연대기.Events
{
    class Chapter2Events
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
            BlackGuardEvent = 020500,
            InnEvent = 020600,
            PickpocketEvent = 020700,
            PubEvent = 020800,
            VampireEvent = 020900,
            BardEvent = 021000,
            GrannyEvent = 021100,
            HomelessEvent = 021200,
            SmithyShopEvent = 021300,
            MagicShopEvent = 021400,
            FnaticsEvent = 021500,
            HinorEvent = 021600,
            AddictEvent = 021700,
            SquareEvent = 021800,
            RefugeeEvent = 021900
        }

        public Chapter2Events(GameEventManager _gameEventManager, Player _player)
        {
            player = _player;
            isSuccess = false;
            isWin = false;
            gameEventManager = _gameEventManager;
            EventDictionary = new Dictionary<int, Action>();
            #region EventDictionary.Add...
            EventDictionary.Add(020100, () => SmithyEvent_020100());
            EventDictionary.Add(020101, () => SmithyEvent_020101());
            EventDictionary.Add(020102, () => SmithyEvent_020102());
            EventDictionary.Add(020103, () => SmithyEvent_020103());
            EventDictionary.Add(020104, () => SmithyEvent_020104());
            EventDictionary.Add(020200, () => WestgateEvent_020200());
            EventDictionary.Add(020201, () => WestgateEvent_020201());
            EventDictionary.Add(020202, () => WestgateEvent_020202());
            EventDictionary.Add(020300, () => SkytenEvent_020300());
            EventDictionary.Add(020301, () => SkytenEvent_020301());
            EventDictionary.Add(020302, () => SkytenEvent_020302());
            EventDictionary.Add(020303, () => SkytenEvent_020303());
            EventDictionary.Add(020304, () => SkytenEvent_020304());
            EventDictionary.Add(020305, () => SkytenEvent_020305());
            EventDictionary.Add(020306, () => SkytenEvent_020306());
            EventDictionary.Add(020400, () => LaboratoryEvent_020400());
            EventDictionary.Add(020401, () => LaboratoryEvent_020401());
            EventDictionary.Add(020402, () => LaboratoryEvent_020402());
            EventDictionary.Add(020403, () => LaboratoryEvent_020403());
            EventDictionary.Add(020413, () => LaboratoryEvent_020413());
            EventDictionary.Add(020404, () => LaboratoryEvent_020404());
            EventDictionary.Add(020500, () => BlackGuardEvent_020500());
            EventDictionary.Add(020501, () => BlackGuardEvent_020501());
            EventDictionary.Add(020502, () => BlackGuardEvent_020502());
            EventDictionary.Add(020600, () => InnEvent_020600());
            EventDictionary.Add(020601, () => InnEvent_020601());
            EventDictionary.Add(020700, () => PickpocketEvent_020700());
            EventDictionary.Add(020701, () => PickpocketEvent_020701());
            EventDictionary.Add(020702, () => PickpocketEvent_020702());
            EventDictionary.Add(020800, () => PubEvent_020800());
            EventDictionary.Add(020801, () => PubEvent_020801());
            EventDictionary.Add(020802, () => PubEvent_020802());
            EventDictionary.Add(020900, () => VampireEvent_020900());
            EventDictionary.Add(020901, () => VampireEvent_020901());
            EventDictionary.Add(020902, () => VampireEvent_020902());
            EventDictionary.Add(021000, () => BardEvent_021000());
            EventDictionary.Add(021001, () => BardEvent_021001());
            EventDictionary.Add(021100, () => GrannyEvent_021100());
            EventDictionary.Add(021101, () => GrannyEvent_021101());
            EventDictionary.Add(021102, () => GrannyEvent_021102());
            EventDictionary.Add(021200, () => HomelessEvent_021200());
            EventDictionary.Add(021201, () => HomelessEvent_021201());
            EventDictionary.Add(021202, () => HomelessEvent_021202());
            EventDictionary.Add(021300, () => SmithyShopEvent_021300());
            EventDictionary.Add(021301, () => SmithyShopEvent_021301());
            EventDictionary.Add(021400, () => MagicShopEvent_021400());
            EventDictionary.Add(021401, () => MagicShopEvent_021401());
            EventDictionary.Add(021500, () => FnaticsEvent_021500());
            EventDictionary.Add(021501, () => FnaticsEvent_021501());
            EventDictionary.Add(021502, () => FnaticsEvent_021502());
            EventDictionary.Add(021503, () => FnaticsEvent_021503());
            EventDictionary.Add(021504, () => FnaticsEvent_021504());
            EventDictionary.Add(021505, () => FnaticsEvent_021505());
            EventDictionary.Add(021600, () => HinorEvent_021600());
            EventDictionary.Add(021601, () => HinorEvent_021601());
            EventDictionary.Add(021602, () => HinorEvent_021602());
            EventDictionary.Add(021700, () => AddictEvent_021700());
            EventDictionary.Add(021701, () => AddictEvent_021701());
            EventDictionary.Add(021800, () => SquareEvent_021800());
            EventDictionary.Add(021801, () => SquareEvent_021801());
            if (gameEventManager.RefugeeAlive)
            {
                EventDictionary.Add(021900, () => RefugeeEvent_021900());
                EventDictionary.Add(021901, () => RefugeeEvent_021901());
            }
            EventDictionary.Add(022000, () => DeadEvent_022000());
            EventDictionary.Add(022001, () => toMainMenu());
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
            if(gameEventManager.EventNumber == 1)
            {
                gameEventManager.NextEventID = 020200;
                return;
            }

            else if (gameEventManager.EventNumber == 5)
            {
                gameEventManager.NextEventID = 020300;
                return;
            }

            else if (gameEventManager.EventNumber == 10)
            {
                gameEventManager.NextEventID = 020400;
                return;
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

            if (gameEventManager.NextEventID == 022001)
            {
                return;
            }

            else if (player.isDead())
            {
                gameEventManager.NextEventID = 022000;
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
                gameEventManager.NextEventID = 022000;
                gameEventManager.resetSellectButtons();
                gameEventManager.setSellectButton1("- 영원한 안식", string.Empty, string.Empty);
            }
        }
        #endregion

        #region SmithyEvent_0201...
        private void SmithyEvent_020100()
        {
            FirstEvent();
            gameEventManager.PrintTextBlock(" 당신은 엘프들의 도시인 이드렉스에 도착했다." +
                " 과거 이드렉스는 인간과는 다른 문명을 발전해 화려한 모습을 갖추고 있었지만 현재는 감옥숲의 증식으로 인해 건물에는 나무가 자라 부서져있는 등 과거의 면모는 찾아볼 수가 없었다.\n\n" +
                " 길거리에는 나무로 인해 집을 잃은 사람들과 아직 피난을 가지 못한 사람들이 여럿 있었다.\n\n" +
                " 당신은 대장장이가 알려준 위치로 향하였고 그곳에는 그의 대장간이 있었다.\n\n");

            gameEventManager.setSellectButton1("- 대장간으로 들어간다");

            NextEvent(020101);
        }

        private void SmithyEvent_020101()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 대장간 안으로 들어갔다. 대장간에는 오랫동안 사람이 오지 않아 곳곳에 먼지가 쌓여있었고 숨쉬기조차 힘들었다.\n\n" +
                " 하지만 용광로 안에서는 아직도 푸른 불이 타오르고 있었다. 아무래도 이것이 대장장이가 말한 마나를 태우는 불같다.\n\n");

            gameEventManager.setSellectButton1("- 불을 챙긴다");

            NextEvent(020102);
        }

        private void SmithyEvent_020102()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 책상 위에 있는 등불에 타오르고 있는 불씨를 옮겼다. 불씨를 옮기자마자 등불은 활활 타올랐다. 당신은 등불을 허리춤에 차고 대장간을 나왔다.\n\n" +
                " 숲의 증식을 해결할 방법은커녕 원인조차 모르는 당신은 정보를 얻기 위해 피난민 캠프로 향한다.\n");
            gameEventManager.SomethigGetText("+ 마나를 태우는 불\n\n");

            player.addItem(1004);

            gameEventManager.setSellectButton1("- 캠프로 향한다");

            NextEvent(020103);
        }

        private void SmithyEvent_020103()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 피난민들이 모여있는 캠프에 도착했다." +
                " 집을 잃은 사람들이 캠프를 치고 생활하고 있었고 게시판에는 모험가에게 의뢰를 하는 종이들도 붙어있었다." +
                " 게시판 옆에는 바닥에 앉아있는 늙은 엘프가 있었고 당신은 정보를 얻기 위해 그에게 다가갔다.\n\n");

            gameEventManager.setSellectButton1("- 빵을 준다");
            gameEventManager.setSellectButton2("- 정보를 묻는다",CHARM, gameEventManager.SuccessProbability(40, 3, player.Charm));

            NextEvent(020104);
        }

        private void SmithyEvent_020104()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 그에게 갖고 있는 빵을 나눠주면서 감옥숲에 대한 정보를 물어보았다.\n\n" +
                    " \"허허.. 고맙네, 정보라.. 증식의 시작이 도시의 서쪽에서부터 시작되었네. 이드렉스 서문으로 간다면 무언가 정보를 더 얻을 수 있을 걸세.\"\n\n" +
                    " 당신은 늙은 엘프에게 감사를 전한 후 도시의 서문으로 향했다.");

                LastEvent();
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                isSuccess = gameEventManager.isSuccess(40, 3, player.Charm);

                if(isSuccess)
                {
                    gameEventManager.SuccessMessage();
                    gameEventManager.PrintTextBlock(" \"음.. 정보라.. 증식의 시작이 도시의 서쪽에서부터 시작되었네. 이드렉스 서문으로 간다면 무언가 정보를 더 얻을 수 있을 걸세\"\n\n" +
                        " 당신은 늙은 엘프에게 감사를 전한 후 도시의 서문으로 향했다.");

                    LastEvent();
                }

                else if(!isSuccess)
                {
                    gameEventManager.FailMessage();
                    gameEventManager.PrintTextBlock(" \"흠 글쎄.. 잘 모르겠는걸.\"\n\n" +
                        " 그는 거짓말을 하고 있는 것 같다.\n\n");

                    gameEventManager.setSellectButton1("- 빵을 준다");

                    NextEvent(020104);
                }
            }
        }
        #endregion

        #region WestgateEvent_0202...
        private void WestgateEvent_020200()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 이드렉스의 서문에 도착했다. 서문에는 깜짝 놀랄 만큼 매우 많은 사람들이 있었다. 하지만 그들은 뭔가 이상하게 느껴진다.\n\n");

            gameEventManager.setSellectButton1("- 가까이 다가간다");
            gameEventManager.setSellectButton2("- 공격한다");

            NextEvent(020201);
        }

        private void WestgateEvent_020201()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 가장 가까이 있는 사람에게 다가갔고 어깨를 두드렸다." +
                    " 그는 천천히 뒤를 돌아봤고 당신은 뭔가 괴리감이 느껴진다. 그러자 근처에 있던 다른 사람들도 당신을 공격해온다.\n\n");

                gameEventManager.setBattleButton(40);
                isWin = gameEventManager.isWin(40);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 무언가 이상하다고 느낀 당신은 가장 가까이 있는 사람을 공격해 쓰러트렸다. 그러자 근처에 있던 다른 사람들도 당신을 공격해온다.\n\n");

                gameEventManager.setBattleButton(30);
                isWin = gameEventManager.isWin(30);
            }

            NextEvent(020202);
        }

        private void WestgateEvent_020202()
        {
            StartEvent();

            if(isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 당신은 공격해오는 사람들을 쓰러트렸다. 한 명 한 명은 약했지만 수가 너무 많았고 당신은 정보를 더 얻기 위해 모험가 캠프로 돌아가기로 결정했다.\n");
                gameEventManager.SomethigGetText("+ 골드 30");

                player.addGold(30);
            }

            else if(!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock("  당신은 공격해오는 사람들을 쓰러트렸다. 하지만 수가 너무 많았고 당신은 약간의 부상을 입었다. 정보를 더 얻기 위해 모험가 캠프로 돌아가기로 결정했다.\n");
                gameEventManager.SomethigLostText("- 체력 5");

                player.Damaged(5);
            }

            LastEvent();
        }
        #endregion

        #region SkytenEvent_0203...
        private void SkytenEvent_020300()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 서문에서 있었던 일들에 대해서 물어보기 위해서 다시 피난민 캠프에 들렀다. 당신에게 정보를 알려준 늙은 엘프를 찾았고 그에게 서문에 있는 사람들에 대해서 물어봤다.\n\n" +
                " \"흠.. 나도 잘 모르겠는걸.. 저기 술집 주인장이 많이 아니까 한번 물어봐봐.\"\n\n");

            gameEventManager.setSellectButton1("- 술집으로 향한다");

            NextEvent(020301);
        }

        private void SkytenEvent_020301()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 술집으로 향했고 술집 주인장에게 서문에 있는 사람들에 대해서 물어보았다. 그러자 옆에 있던 한 엘프가 당신에게 말을 걸었다.\n\n" +
                " \"혹시 모험가님, 서문에 갔다 오셨습니까? 저와 이야기 좀 할 수 있을까요?\"\n\n");

            gameEventManager.setSellectButton1("- 이야기한다");

            NextEvent(020302);
        }

        private void SkytenEvent_020302()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 그의 옆에 있는 의자로 자리를 옮겼다.\n\n" +
                " \"우선 제 소개부터 하죠. 제 이름은 크래블 스카이튼입니다. 서문에는 거름인간들이 매우 많은데 용케 잘 살아돌아오셨군요.\"\n\n");

            gameEventManager.setSellectButton1("- 거름인간?");

            NextEvent(020303);
        }

        private void SkytenEvent_020303()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 거름인간이 무엇인지에 대하여 물어보았다.\n\n" +
                " \"예, 저희는 그들을 거름인간이라고 부릅니다. 어미나무에 의해 정신이 잠식된 자들이죠. 우선.. 어미나무에 대해서 먼저 설명드려야겠군요.\"\n\n" +
                " \"현재 감옥숲의 중심에는 거대한 어미나무가 자라고 있습니다. 어미나무는 계속해서 숲을 넓히면서 이 세계의 마나와 에너지들을 흡수하고 있죠." +
                " 거름인간이 된 사람들은 어미나무에게 마나와 에너지를 흡수당해 어미나무의 거름이 될 겁니다.\"\n\n");

            gameEventManager.setSellectButton1("- 어떻게 알고 있나?");

            NextEvent(020304);
        }

        private void SkytenEvent_020304()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 엘프에게 이러한 정보들을 어떻게 알고 있는지 물어보았다.\n\n" +
                " \"저는 어미나무의 묘목을 연구하던 연구원입니다. 숲의 중심에서 묘목을 연구하고 있었는데.." +
                " 나무가 폭주해버렸죠. 그 과정에 저와 같이 연구하던 동료인 델트 우드가드가 어미나무에게 흡수되었고, 현재 이 상태가 된 거죠.\"\n\n");

            gameEventManager.setSellectButton1("- 하고 싶은 말이 뭔가?");

            NextEvent(020305);
        }

        private void SkytenEvent_020305()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 지루하고 긴 대화를 끝내고 싶었다.\n\n" +
                " \"제 의뢰를 받아주셨으면 합니다. 도시의 외곽에 저희 연구소가 있습니다. 그곳에 어미나무의 묘목이 하나 더 있습니다." +
                " 그것만 있다면 이 사태를 해결할 수 있을 텐데.. 아마 어미나무가 거름인간들을 시켜 묘목을 가지러 올 겁니다. 묘목을 갖고 제게 와주셨으면 합니다.\"\n\n");

            gameEventManager.setSellectButton1("- 의뢰를 받는다");

            NextEvent(020306);
        }

        private void SkytenEvent_020306()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 의뢰를 수락했다. 그에게 연구소의 위치가 표시된 지도와 약간의 골드를 받고 도시 외곽에 있는 연구소로 향한다.\n");
            gameEventManager.SomethigGetText("+ 골드 20");

            player.addGold(20);

            LastEvent();
        }
        #endregion

        #region LaboratoryEvent_0204...
        private void LaboratoryEvent_020400()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 스카이튼이 준 지도에 표시되어 있는 연구소에 도착했다." +
                " 연구소에는 당신의 생각보다 훨씬 많은 거름인간들이 있었고 그중에는 유독 눈에 띄는 빛이 나는 묘목이 박힌 거름인간이 있었다.\n\n" +
                " 그 거름인간이 당신을 보고 손짓하자 근처에 있던 다른 거름인간들이 당신에게 달려든다.\n\n");

            gameEventManager.setBattleButton(35);

            NextEvent(020401);
        }

        private void LaboratoryEvent_020401()
        {
            StartEvent();

            isWin = gameEventManager.isWin(35);

            if(isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 거름인간들은 당신의 공격에 나가떨어졌고 당신은 손쉽게 수많은 거름인간들을 물리쳤다. 그러자 묘목이 박힌 거름인간이 분노한 듯 소리치며 달려들었다.\n\n");
            }

            else if(!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 거름인간들은 당신의 공격에 나가떨어졌다." +
                    " 하지만 수많은 거름인간의 공격에 당신은 약간의 상처를 입었다. 그러자 묘목이 박힌 거름인간이 분노한 듯 소리치며 달려들었다.\n");
                gameEventManager.SomethigLostText("- 체력 5\n\n");

                player.Damaged(5);
            }

            gameEventManager.setBattleButton(70);

            NextEvent(020402);
        }

        private void LaboratoryEvent_020402()
        {
            StartEvent();

            isWin = gameEventManager.isWin(70);

            if(isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 당신은 묘목이 박힌 거름인간과 전투했다." +
                    " 그 거름인간은 매우 영리하였지만 오랜 모험으로 실전 경험이 쌓은 당신에게는 상대가 되지 않았다." +
                    " 당신은 공격을 회피한 뒤 거름인간의 뒤로 돌아 목뒤에 박힌 묘목을 뿌리째 뽑아버렸다.\n\n" +
                    " 묘목이 뽑히자 거름인간은 힘없이 쓰러졌고 근처에 있던 거름인간들도 공격을 멈췄다.\n");
                gameEventManager.SomethigGetText("+ 어미나무의 묘목\n\n");

                player.addItem(1005);
                gameEventManager.hasSeedling = true;

                gameEventManager.setSellectButton1("- 스카이튼에게 돌아간다");
                NextEvent(020403);
            }

            else if(!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock("  당신은 묘목이 박힌 거름인간과 전투했다. 그 거름인간은 매우 영리하였고 당신의 공격을 전부 회피했다." +
                    " 당신은 공격을 회피한 뒤 거름인간의 뒤로 돌아 목뒤에 박힌 묘목에 닿았지만 거름인간은 재빨리 뒤돌았다.\n\n" +
                    " 지친 당신은 포기하였지만 거름인간들은 더 이상 당신을 공격하지 않았다. 손을 보니 묘목의 나뭇가지가 부러져 손 안에 있었다.\n");
                gameEventManager.SomethigLostText("- 체력 5\n");
                gameEventManager.SomethigGetText("+ 묘목의 나뭇가지\n\n");

                player.addItem(1006);
                player.Damaged(5);

                gameEventManager.setSellectButton1("- 스카이튼에게 돌아간다");
                NextEvent(020413);
            }
        }

        private void LaboratoryEvent_020403()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 묘목을 갖고 스카이튼에게 돌아왔다. 그리고 묘목을 갖자 거름인간들이 공격을 멈추었다는 것을 전했다.\n\n" +
                " \"공격해오지 않았다고요? 묘목이 있다면 거름인간들이 공격하지 않는 모양이군요. 그렇다면, 묘목을 이용해 서문에 있는 거름인간들을 지나고 숲의 중심으로 갈 수 있을 겁니다." +
                " 묘목이 우리에게 있으니 어미나무의 성장속도가 늦어졌을 것입니다. 숲의 중심으로 가 어미나무를 무찔러 숲의 증식을 막아야합니다.\"\n\n");

            gameEventManager.setSellectButton1("- 숲의 중심부로 향한다");

            NextEvent(020404);
        }

        private void LaboratoryEvent_020413()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 묘목을 얻지 못한 것을 전하러 스카이튼에게 돌아왔다. 그리고 나뭇가지를 갖자 거름인간들이 공격을 멈추었다는 것을 전했다.\n\n" +
                " \"공격해오지 않았다고요? 나뭇가지가 있다면 거름인간들이 공격하지 않는 모양이군요. 그렇다면, 그것을 이용해 서문에 있는 거름인간들을 지나고 숲의 중심으로 갈 수 있을 겁니다." +
                " 묘목은 얻지 못했지만 한시라도 빨리 숲의 중심으로 가 어미나무를 무찔러 숲의 증식을 막아야합니다.\"\n\n");

            gameEventManager.setSellectButton1("- 숲의 중심부로 향한다");

            NextEvent(020404);
        }

        private void LaboratoryEvent_020404()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 숲의 증식을 막기 위해 어미나무가 있는 숲의 중심부로 향했다.");

            LastEvent();
            gameEventManager.GameChapterChange();
        }
        #endregion

        #region BlackGuardEvent_0205...
        private void BlackGuardEvent_020500()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 빨리 이동하기 위해 뒷골목으로 이동하고 있었다. 그러자 앞뒤로 인간 남자 두 명이 당신을 막아섰다.\n\n" +
                " \"여긴 우리 구역이야 형씨, 당장 꺼져.\"\n\n" +
                " 당신은 무시하고 지나가려고 했지만 앞에 있는 남자가 당신을 잡아 멈춰 세웠다.\n\n" +
                " \"꺼지는 건 좋은데.. 있는 건 다 주고 꺼져야지..\"\n\n");

            gameEventManager.setSellectButton1("- 골드를 전부 준다");
            gameEventManager.setSellectButton2("- 얼굴에 주먹을 날린다");
            gameEventManager.setSellectButton3("- 도망친다", DEXTERITY, gameEventManager.SuccessProbability(30, 3, player.Dexterity));

            EventDictionary.Remove(gameEventManager.NowEventID);
            NextEvent(020501);
        }

        private void BlackGuardEvent_020501()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" \"하하하하! 고마워, 좋아 지나가도 돼\"\n\n" +
                " 당신은 가지고 있는 골드를 전부 준 후 지나갔다.\n");
                gameEventManager.SomethigLostText("- 골드 " + player.Gold);

                player.subGold(player.Gold);

                LastEvent();
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신의 주먹에 불량배는 얼굴을 부여잡고 뒤로 크게 넘어졌다.\n\n" +
                    " \"아아악! 이 개x끼가!　야! 이 새x 죽여!\"\n\n");

                gameEventManager.setBattleButton(60);

                NextEvent(020502);
            }

            else if (gameEventManager.ButtonNumber == 3)
            {
                isSuccess = gameEventManager.isSuccess(30, 3, player.Dexterity);

                if (isSuccess)
                {
                    gameEventManager.SuccessMessage();
                    gameEventManager.PrintTextBlock(" 당신은 붙잡고 있는 불량배의 팔을 쳐낸 다음 밀쳐냈고 재빠르게 앞으로 달렸다." +
                        " 당황한 불량배들은 소리를 지르며 당신을 따라왔지만 얼마 지나지 않아 따돌릴 수 있었다.");

                    LastEvent();
                }

                else if (!isSuccess)
                {
                    gameEventManager.FailMessage();
                    gameEventManager.PrintTextBlock(" 당신은 붙잡고 있는 불량배의 팔을 쳐낸 다음 밀쳐냈고 재빠르게 앞으로 달렸지만 불량배의 발에 걸려 넘어지고 말았다.\n\n" +
                        " 불량배들은 당신을 비웃었고 당신은 매우 부끄러웠지만 이 불량배 녀석들을 혼내주기로 마음먹었다.\n\n");

                    gameEventManager.setBattleButton(60);

                    NextEvent(020502);
                }
            }
        }

        private void BlackGuardEvent_020502()
        {
            isWin = gameEventManager.isWin(60);

            if (isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 당신은 이 실력 없는 불량배 녀석들을 혼내줬다. 다신 이런 짓을 하지 말라는 의미로 골드도 좀 챙겨왔다.\n");
                gameEventManager.SomethigGetText("+ 골드 20");

                player.addGold(20);
            }

            else if (!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 실력 없이 까부는 불량배들이라는 당신의 생각은 틀렸었다. 이 불량배들은 꽤 실력이 좋았고 당신은 어쩔 수 없이 골드를 조금 흘린 후 도망칠 수밖에 없었다.\n");
                gameEventManager.SomethigLostText("- 체력 5\n" +
                    "- 골드 5");

                player.Damaged(5);
                player.subGold(5);
            }

            LastEvent();
        }
        #endregion

        #region InnEvent_0206...
        private void InnEvent_020600()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 도심을 돌아다니던 중 여관처럼 보이는 간판을 발견했다. 가까이 가보니 그 여관은 아직 운영 중이었고, 시설도 꽤 좋아보였다.\n\n");

            gameEventManager.setSellectButton1("- 쉬고 간다");
            gameEventManager.setSellectButton2("- 쉬지 않는다", STAMINA, gameEventManager.SuccessProbability(50, 2, player.Stamina));

            if(player.Gold < 10)
            {
                gameEventManager.setSellecButton1Disable();
            }

            NextEvent(020601);
        }

        private void InnEvent_020601()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 여관에서 하루 쉬어가기로 결정했다. 여관에서의 휴식은 꽤 달콤했고 당신은 한결 가벼워진 몸으로 여관을 떠났다.\n");
                gameEventManager.SomethigLostText("- 골드 10\n");
                gameEventManager.SomethigGetText("+ 체력 10");

                player.subGold(10);
                player.Heal(10);
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                isSuccess = gameEventManager.isSuccess(50, 2, player.Stamina);

                if (isSuccess)
                {
                    gameEventManager.SuccessMessage();
                    gameEventManager.PrintTextBlock(" 당신은 여관에서의 휴식이 낭비라고 생각했고, 근처에 있는 공터에서 캠프를 치고 휴식했다. 다음날 당신은 몸이 좀 뻐근하긴 했지만, 다시 모험에 나섰다.");
                }

                else if (!isSuccess)
                {
                    gameEventManager.FailMessage();
                    gameEventManager.PrintTextBlock(" 당신은 여관에서의 휴식이 낭비라고 생각했고, 근처에 있는 공터에서 캠프를 치고 휴식했다." +
                        " 하지만 그날 밤은 매우 센 비바람이 불었고 당신은 전혀 휴식하지 못한 채로 모험에 나섰다.\n");
                    gameEventManager.SomethigLostText("- 체력 5");

                    player.Damaged(5);
                }
            }

            LastEvent();
        }
        #endregion

        #region PickpocketEvent_0207...
        private void PickpocketEvent_020700()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 시장을 돌아다니고 있었다. 시장에서는 아직 피난하지 못한 사람들이 물건을 사고 팔고 있었다." +
                " 갑자기 후드를 쓴 어린 아이가 당신과 부딪혔고 그 아이는 사과를 한 후 지나갔다.\n\n");

            gameEventManager.setSellectButton1("- 주머니를 확인한다");
            gameEventManager.setSellectButton2("- 아이를 붙잡는다", DEXTERITY, gameEventManager.SuccessProbability(40, 2, player.Dexterity));

            EventDictionary.Remove(gameEventManager.NowEventID);
            NextEvent(020701);
        }

        private void PickpocketEvent_020701()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 무언가 이상함을 느낀 당신은 주머니를 확인했고 주머니를 보니 골드가 줄어들어있었다.\n");
                gameEventManager.SomethigLostText("- 골드 10");

                player.subGold(10);

                LastEvent();
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                isSuccess = gameEventManager.isSuccess(40, 2, player.Dexterity);

                if (isSuccess)
                {
                    gameEventManager.SuccessMessage();
                    gameEventManager.PrintTextBlock(" 무언가 이상함을 느낀 당신은 아이를 붙잡았다. 당신이 아이를 붙잡자 아이는 깜짝 놀라 울음을 터트렸다." +
                        " 주머니를 확인해보니 골드가 줄어들어있었다.\n");
                    gameEventManager.SomethigLostText("- 골드 10\n");

                    player.subGold(10);

                    gameEventManager.setSellectButton1("- 아이를 보내준다");
                    gameEventManager.setSellectButton2("- 골드만 돌려받는다");

                    NextEvent(020702);
                }

                else if (!isSuccess)
                {
                    gameEventManager.FailMessage();
                    gameEventManager.PrintTextBlock(" 무언가 이상함을 느낀 당신은 아이를 붙잡으려고 했으나 이미 아이는 인파 속에 묻혀 보이지 않았다. 주머니를 확인해보니 골드가 줄어들어있었다.\n");
                    gameEventManager.SomethigLostText("- 골드 10");

                    player.subGold(10);

                    LastEvent();
                }
            }
        }

        private void PickpocketEvent_020702()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 울고 있는 아이를 잡은 손을 놓아주었다." +
                    " 당신이 손을 놓자마자 아이는 쏜살같이 달려갔고 어느 정도 거리가 멀어지자 아이는 뒤돌아 당신에게 인사한 후 다시 달려갔다.");
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 아이에게 골드를 돌려달라고 부탁했다. 아이는 소매로 눈물을 닦은 뒤 주머니 안에서 골드를 꺼내 당신의 손 위에 올려두었다.\n\n" +
                    " 당신은 아이의 손을 놓아주었고 손을 놓자마자 아이는 쏜살같이 달려갔다. 어느 정도 거리가 멀어지자 아이는 뒤돌아 당신에게 인사한 후 다시 달려갔다.\n");
                gameEventManager.SomethigGetText("+ 골드 10");

                player.addGold(10);
            }

            LastEvent();
        }
        #endregion

        #region PubEvent_0208...
        private void PubEvent_020800()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 오늘 하루를 마무리하기 전에 피로를 풀기 위해 술집에 들렀다." +
                " 구석에 혼자 앉아 술을 마시고 있었는데 갑자기 뒤에서 큰소리가 났고, 뒤를 돌아보니 엘프와 인간이 싸우고 있었다.\n\n");

            gameEventManager.setSellectButton1("- 싸움을 말린다");
            gameEventManager.setSellectButton2("- 조용히 술을 마신다");
            gameEventManager.setSellectButton3("- 떠난다");

            EventDictionary.Remove(gameEventManager.NowEventID);
            NextEvent(020801);
        }

        private void PubEvent_020801()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 오지랖이 넓은 당신은 그 둘의 싸움을 가만히 보고만 있을 수 없었다. 당신은 자리에서 일어나 싸우고 있는 두 남자의 옆에 섰다.\n\n" +
                    " \"뭐야 너? 같은 인간이라고 도와주려는 거야? 좋아, 둘 다 덤벼 인간쯤은 가뿐히 이겨주지.\"\n\n" +
                    " 딱히 인간 편을 들려는 것은 아니었는데, 오해를 산 것 같다.\n\n");

                gameEventManager.setBattleButton(30);

                NextEvent(020802);
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 싸움 구경을 안주로 삼아 술을 마셨다. 술 맛은 훨씬 더 좋았고 당신은 만족하며 테이블에 골드를 놓고 술집을 나왔다.\n");
                gameEventManager.SomethigGetText("+ 체력 5\n");
                gameEventManager.SomethigLostText("- 골드 5");

                player.Heal(5);
                player.subGold(5);

                LastEvent();
            }

            else if (gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.PrintTextBlock(" 당신은 불똥이 튈까봐 테이블에 골드를 올려놓고 술집을 나왔다.\n");
                gameEventManager.SomethigLostText("- 골드 5");

                player.subGold(5);

                LastEvent();
            }
        }

        private void PubEvent_020802()
        {
            isWin = gameEventManager.isWin(30);

            if (isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 당신은 옆에 있는 방심한 인간을 먼저 기절시킨 다음 술에 취한 엘프를 간단히 제압했다." +
                    " 그러자 술집 주인이 당신에게 감사를 표하며 약간의 골드와 통에 담은 술을 주었다\n");
                gameEventManager.SomethigGetText("+ 골드 20\n" +
                    "+ 술통");

                player.addGold(20);
                player.addItem(2005);
            }

            else if (!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 당신은 옆에 있는 방심한 인간을 먼저 기절시킨 다음 술에 취한 엘프와 대치했다." +
                    " 엘프는 술에 취해 있음에도 상당히 민첩했고 마치 당신의 행동을 다 예상하는 것 같았다." +
                    " 당신은 엘프에게 패배해 기절했고 아침에 깨어나니 길거리에 버려져있었다.\n");
                gameEventManager.SomethigLostText("- 체력 5\n" +
                    "- 골드 5");

                player.Damaged(5);
                player.subGold(5);
            }

            LastEvent();
        }
        #endregion

        #region VampireEvent_0209...
        private void VampireEvent_020900()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 한적하고 넓은 길을 걷고 있었고, 근처에는 아무도 보이지 않았다. 갑자기 둔탁한 무언가가 뒤통수를 가격했고, 당신은 바로 기절해버렸다.\n\n");

            gameEventManager.setSellectButton1("- 잠시 후...");

            EventDictionary.Remove(gameEventManager.NowEventID);
            NextEvent(020901);
        }

        private void VampireEvent_020901()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 정신을 차리고 보니 당신은 어두운 방 안에 있었고 근처에는 검은 후드를 쓴 사람들이 당신을 둘러싸고 있었다. 우두머리로 보이는 사람이 당신에게 다가와 말을 건다.\n\n" +
                " \"겉모습을 보아하니 모험가이신 것 같더군요.. 조용한 곳에서 이야기를 해야 해서 폭력적인 방법을 사용할 수밖에 없었습니다." +
                " 우리와 함께하시죠, 지금보다 훨씬 더 강해지고 이 지옥 같은 상황에서 살아남을 수 있을 겁니다.\"\n\n" +
                " 그가 말할 때마다 뾰족하고 긴 송곳니가 돋보였고, 그는 당신에게 창백한 손을 내밀며 검붉은 액체가 담긴 컵을 건넨다.\n\n");

            gameEventManager.setSellectButton1("- 컵을 받는다");
            gameEventManager.setSellectButton2("- 거절한다");
            gameEventManager.setSellectButton3("- 정체를 묻는다");

            NextEvent(020902);
        }

        private void VampireEvent_020902()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 그의 손에 있는 컵을 받아 곧바로 마셨다. 그것을 마시자마자 뱃속이 타는 듯이 아팠고, 당신은 그 자리에서 쓰러져 기절했다." +
                    " 잠시 후 정신을 차리니 당신은 혼자 있었고, 몸에서는 힘이 솟구쳤다.\n");
                gameEventManager.SomethigLostText("- 최대 체력 10\n");
                gameEventManager.SomethigGetText("+ 힘 3\n");
                gameEventManager.SomethigGetText("+ 민첩 3");

                player.subMaximumHP(10);
                player.Strength += 3;
                player.Dexterity += 3;

                LastEvent();
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 그의 권유를 거절했다.\n\n" +
                    " \"뭐, 강요는 하지 않죠.\"\n\n" +
                    "그의 말이 끝나자 당신은 다시 뒤통수를 맞아 기절했고 정신을 차리고 나니 당신은 혼자 있었다.");

                LastEvent();
            }

            else if (gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.PrintTextBlock(" 당신은 그에게 정체를 물었지만, 그는 두리뭉실하게 말할 뿐이었다.\n\n" +
                    " \"흠.. 정체라, 이 지옥 같은 상황에서 독보적으로 진화한 생명체라고 해두죠.\"\n\n");

                gameEventManager.setSellectButton1("- 컵을 받는다");
                gameEventManager.setSellectButton2("- 거절한다");

                NextEvent(020902);
            }
        }
        #endregion

        #region BardEvent_0210...
        private void BardEvent_021000()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 길 한복판에 많은 사람이 모여 있었고 음악소리가 들렸다. 당신은 인파의 중심에 무엇이 있나 확인하였고, 그곳에는 한 음유시인이 악기로 연주를 하고 있었다.\n\n" +
                " 그의 앞에는 골드를 받는 통이 하나 놓여있었고 통 안에는 꽤 많은 골드가 쌓여있었다.\n\n");

            gameEventManager.setSellectButton1("- 음악을 듣는다");
            gameEventManager.setSellectButton2("- 골드를 빼온다", INTELLIGENCE, gameEventManager.SuccessProbability(20, 4, player.Intelligence));
            gameEventManager.setSellectButton3("- 지나친다");

            NextEvent(021001);
        }

        private void BardEvent_021001()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 인파에 섞여 음유시인의 연주를 경청했다. 음유시인의 연주 실력은 매우 뛰어났고 연주가 끝나자 박수소리가 터져 나왔다." +
                    " 당신은 오랜만에 음악을 들으며 휴식했다.\n");
                gameEventManager.SomethigGetText("+ 체력 5");

                player.Heal(5);
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                isSuccess = gameEventManager.isSuccess(20, 4, player.Intelligence);

                if (isSuccess)
                {
                    gameEventManager.SuccessMessage();
                    gameEventManager.PrintTextBlock(" 당신은 통 쪽으로 다가갔고 통 안에 골드를 넣는 척하면서 골드를 빼냈다." +
                        " 당신의 자연스러운 행동에 아무도 골드를 가져간 것을 눈치채지 못했고 당신은 유유히 인파를 빠져나갔다.\n");
                    gameEventManager.SomethigGetText("+ 골드 20");

                    player.addGold(20);
                }

                else if (!isSuccess)
                {
                    gameEventManager.FailMessage();
                    gameEventManager.PrintTextBlock(" 당신은 통 쪽으로 다가갔고 통 안에 골드를 넣는 척하면서 골드를 빼냈다. 하지만 음유시인은 당신의 행동을 눈치채고 연주를 멈춘 후 당신을 쳐다보았다." +
                        " 사람들의 이목이 당신에게 집중되었고 야유가 터져 나왔다. 당신은 인파에서 도망치듯 떠났다.");
                }
            }

            else if (gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.PrintTextBlock(" 음악에 관심이 없는 당신은 인파에서 빠져나갔다.");
            }

            LastEvent();
        }
        #endregion

        #region GrannyEvent_0211...
        private void GrannyEvent_021100()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 길을 가던 중 바구니를 든 한 노파가 당신에게 말을 건네왔다.\n\n" +
                " \"젊은이, 내가 몸에 정~~말로 좋은 약들을 갖고 있는데 함 볼텨?\"\n\n");

            gameEventManager.setSellectButton1("- 약을 산다");
            gameEventManager.setSellectButton2("- 거절한다");

            if(player.Gold < 30)
            {
                gameEventManager.setSellecButton1Disable();
            }

            NextEvent(021101);
        }

        private void GrannyEvent_021101()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" \"붉은 색깔 약, 푸른 색깔 약, 녹색 깔 약 세 가지가 있는데 어떤 거 할텨?\"\n\n");

                gameEventManager.setSellectButton1("- 붉은 색");
                gameEventManager.setSellectButton2("- 푸른 색");
                gameEventManager.setSellectButton3("- 녹색");

                NextEvent(021102);
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" \"에잉.. 쯧.. 알았어\"\n\n" +
                    " 노파는 혀를 차더니 그대로 가버렸다.");

                LastEvent();
            }
        }

        private void GrannyEvent_021102()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.SomethigGetText("+ 붉은 색 약\n");
                player.addItem(2006);
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.SomethigGetText("+ 푸른 색 약\n");
                player.addItem(2007);
            }

            else if (gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.SomethigGetText("+ 녹색 약\n");
                player.addItem(2008);
            }

            gameEventManager.PrintTextBlock(" \"고마우이 젊은이, 또 봐~\"\n\n" +
                " 노파는 당신의 손에 약을 올려놓고 콧노래를 흥얼거리며 떠났다.\n");
            gameEventManager.SomethigLostText("- 골드 30");

            player.subGold(30);

            LastEvent();
        }
        #endregion

        #region HomelessEvent_0212...
        private void HomelessEvent_021200()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 도시를 돌아다니면서 정보를 모으고 있었다. 이 거리에는 사고로 인해 집을 잃은 노숙자들이 거리에 앉아있었다.\n\n" +
                " 당신이 지나갈 때 옆에 있던 누더기 옷을 입은 한 노숙자가 말을 건네며 손을 내밀었다.\n\n" +
                " \"몇 푼만 주실 수 있을까요..\"\n\n");

            gameEventManager.setSellectButton1("- 돈을 준다");
            gameEventManager.setSellectButton2("- 무시하고 지나간다");

            if(player.Gold < 15)
            {
                gameEventManager.setSellecButton1Disable();
            }
            EventDictionary.Remove(gameEventManager.NowEventID);
            NextEvent(021201);
        }

        private void HomelessEvent_021201()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신이 그의 손에 골드 몇 푼을 올려놓자 그는 갑자기 자리에서 일어났고, 깜짝 놀란 당신은 뒤로 주저앉아버렸다." +
                    " 그는 자신이 한 교회의 목사라고 소개했고 모험가들을 도와주고 있다고 말했다.\n\n" +
                    " \"정말 친절한 분이시군요! 제가 몇 가지 가져온 것이 있습니다. 원하는 걸 가져가시죠.\"\n");
                gameEventManager.SomethigLostText("- 골드 15\n\n");

                player.subGold(15);

                gameEventManager.setSellectButton1("- 치료받는다");
                gameEventManager.setSellectButton2("- 단약을 받는다");
                gameEventManager.setSellectButton3("- 방어구를 받는다");

                NextEvent(021202);
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신이 말을 무시하고 지나치자 노숙자는 바닥을 보며 중얼거렸다.\n\n" +
                    " \"너는 절대 이 세상을 구원할 수 없을 거야...\"");

                LastEvent();
            }
        }

        private void HomelessEvent_021202()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 그에게 치료를 부탁했고 그는 흔쾌히 받아들이며 당신의 상처를 치료해주었다.\n");
                gameEventManager.SomethigGetText("+ 체력 15");

                player.Heal(15);
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 그가 들고 있는 단약을 달라고 말했고 그는 당신에게 단약을 넘겨주고는 그대로 떠났다. 그 단약을 먹으니 당신은 무언가 깨달음을 얻은 것 같았다.\n");
                gameEventManager.SomethigGetText("+ 지능 1\n" +
                    "+ 지혜 1");

                player.Intelligence++;
                player.Wizdom++;
            }

            else if (gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.PrintTextBlock(" 당신은 그가 들고 있는 방어구를 달라고 말했고 그는 당신에게 방어구를 넘겨준 후 만족하는 표정을 지으며 떠나갔다.\n");
                gameEventManager.SomethigGetText("+ 성기사단 갑옷");

                player.addItem(4002);
            }

            LastEvent();
        }
        #endregion

        #region SmithyShopEvent_0213...
        private void SmithyShopEvent_021300()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" \"깡! 깡!\"\n\n" +
                " 망치질 소리를 들은 당신은 소리가 나는 방향으로 향했고 그곳에는 아직 운영 중인 대장간이 있었다. 대장간 안에는 상태 좋은 무기와 방어구가 꽤나 있어 보인다.\n\n");

            gameEventManager.setSellectButton1("- 대장간 안으로 들어간다");
            gameEventManager.setSellectButton2("- 지나친다");

            NextEvent(021301);
        }

        private void SmithyShopEvent_021301()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.trader.addItems(GameItem.ShopType.Smithy);
                View.Play.TradeWindowOpen();
                gameEventManager.PrintTextBlock(" 당신은 대장간 안에서 물건들을 본 후 밖으로 나왔다.");
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 대장간에 들어가지 않고 지나쳤다.");
            }

            LastEvent();
        }
        #endregion

        #region MagicShopEvent_0214...
        private void MagicShopEvent_021400()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 갑자기 당신 바로 앞에 포탈이 생겼고 그 안에서 한 엘프가 당신을 바라보면서 나와 말을 건넸다.\n\n" +
                " \"거기 모험가씨 ? 내가 정말정말 좋은 마법 도구들을 갖고 있는데 한번 볼래 ?\"\n\n");

            gameEventManager.setSellectButton1("- 물건을 본다");
            gameEventManager.setSellectButton2("- 거절한다");

            NextEvent(021401);
        }

        private void MagicShopEvent_021401()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.trader.addItems(GameItem.ShopType.MagicShop);
                View.Play.TradeWindowOpen();
                gameEventManager.PrintTextBlock(" 당신은 물건을 보겠다고 말했고, 그녀는 만족한 표정을 지으며 포탈 안에서 다양한 물건들을 꺼내 당신에게 보여주었다." +
                    " 물건을 보고 인사를 한 후 그녀는 다시 포탈 안으로 들어갔다.");
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 물건을 보는 걸 거절했고, 그녀는 아쉬운 표정으로 다시 포탈 안으로 들어갔다.");
            }

            LastEvent();
        }
        #endregion

        #region FnaticsEvent_0215...
        private void FnaticsEvent_021500()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 폐허가 되가는 교회를 지나고 있었다." +
                " 교회 안에서 무언가 이상한 소리가 들렸고 소리를 들은 당신은 교회 문 앞에 다가갔다. 문 앞에 다가가니 더 이상 소리가 들리지 않는다.\n\n");

            gameEventManager.setSellectButton1("- 교회에 들어간다");
            gameEventManager.setSellectButton2("- 잘못 들은 걸 거다");

            EventDictionary.Remove(gameEventManager.NowEventID);
            NextEvent(021501);
        }

        private void FnaticsEvent_021501()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 조심히 문을 열었고 교회 안으로 들어갔다. 교회 안은 칠흑같이 어두웠고 가운데에 빨간 조명만 보일 뿐이었다." +
                    " 조명 근처에는 많은 사람들이 무릎을 꿇고 정신을 잃고 있었고, 조명 중심에는 한 광신도가 사람들을 세뇌하고 있었다.\n\n");

                gameEventManager.setSellectButton1("- 광신도를 대화한다");
                gameEventManager.setSellectButton2("- 광신도를 기습한다");
                gameEventManager.setSellectButton3("- 도망친다");

                NextEvent(021502);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 소리가 멈춘 것을 보고 잘못들은 것이라고 판단한 당신은 교회를 떠났다.");

                LastEvent();
            }
        }

        private void FnaticsEvent_021502()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 조명의 중심으로 다가가 광신도에게 말을 걸었다. 갑작스런 당신의 등장에 놀란 듯 했으나 이내 진정하고 대답했다.\n\n" +
                    " \"당신은 누구시죠?　어째서 이곳에 있는건지...\"\n\n" +
                    " 그는 당신을 경계하고 있는 것 같다.\n\n");

                gameEventManager.setSellectButton1("- 어째서 이런 짓을 하는지?");
                gameEventManager.setSellectButton2("- 공격한다");

                NextEvent(021503);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 의식 중인 광신도를 공격했다. 당황한 그는 급히 무기를 꺼내고 당신에게 달려든다.\n\n");

                gameEventManager.setBattleButton(40);
                isWin = gameEventManager.isWin(40);
                NextEvent(021505);
            }

            else if(gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.PrintTextBlock(" 교회 안의 모습에 당황한 당신은 문을 다시 닫고 교회를 떠났다.");

                LastEvent();
            }
        }

        private void FnaticsEvent_021503()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 광신도에게 어째서 이런 행동을 하는지 물어봤다.\n\n" +
                    " \"현재 상황은 지옥 그 자체입니다. 이것만이 이 사람들이 구원받을 방법입니다. 피난을 간다 한들 결국 숲은 계속해서 퍼져나갈 것이고 전부 다 숲에 먹히겠지요.." +
                    " 이 사람들은 직접 자신이 찾아온 것입니다.\"\n\n");

                gameEventManager.setSellectButton1("- 돌아간다");
                gameEventManager.setSellectButton2("- 공격한다");

                NextEvent(021504);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                NextEvent(021504);
                gameEventManager.RunEvent(2);
            }
        }

        private void FnaticsEvent_021504()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 그의 말을 들은 당신은 수긍하고 교회를 떠났다.");

                LastEvent();
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 무기를 꺼내들었고 전투태세를 갖췄다.\n\n" +
                    " \"좋게 말해도 이해를 못 하시는군요.\"\n\n");

                gameEventManager.setBattleButton(60);
                isWin = gameEventManager.isWin(60);

                NextEvent(021505);
            }
        }

        private void FnaticsEvent_021505()
        {
            StartEvent();

            if(isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 광신도는 꽤나 수준급의 마법을 다루었지만 당신의 실력에는 미치지 못했다." +
                    " 광신도를 쓰러트리니 정신을 잃은 채 쓰러졌다. 당신은 사람들을 그대로 둔 채 교회를 빠져나왔다.\n");
                gameEventManager.SomethigGetText("+ 광신도의 로브\n" +
                    "+ 골드 20");

                player.addItem(4003);
                player.addGold(20);
            }

            else if(!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 광신도는 꽤나 수준급의 마법을 다루었고 당신은 마법에 당해 꽤나 큰 부상을 입었다." +
                    " 당신은 어쩔 수 없이 세뇌 당하고 있는 사람들을 교회에 둔 채 빠져나왔다.\n");
                gameEventManager.SomethigLostText("- 체력 5");

                player.Damaged(5);
            }

            LastEvent();
        }
        #endregion

        #region HinorEvent_0216...
        private void HinorEvent_021600()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 검은 후드를 쓴 왜소한 남자가 성큼성큼 다가온다. 후드의 귀 부분이 약간 튀어나온 것을 보니 엘프인 것 같다.\n\n" +
                " \"이봐, 모험가 혹시 하이놀에 관심 있어?　이것만 있으면 바로 각성할 수 있다고, 처음 보는 녀석이니까 싸게 50골드에 해줄게.\"\n\n" +
                " 그는 가져온 가방을 열어 안에 있는 하이놀을 보여준다.\n\n");

            gameEventManager.setSellectButton1("- 구매한다");
            gameEventManager.setSellectButton2("- 갈취한다");
            gameEventManager.setSellectButton3("- 거절한다");

            if(player.Gold < 50)
            {
                gameEventManager.setSellecButton1Disable();
            }

            EventDictionary.Remove(gameEventManager.NowEventID);
            NextEvent(021601);
        }

        private void HinorEvent_021601()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 하이놀을 구매하기로 결정했다. 후드를 쓴 남자에게 골드를 준 후 가방을 받았다.\n\n" +
                    " \"탁월한 선택이야, 조만간 나를 또 찾게 될 거야. 또 보자고\"\n\n" +
                    " 후드를 쓴 남자는 말을 남기고서는 떠나갔다.\n");
                gameEventManager.SomethigGetText("+ 하이놀\n");
                gameEventManager.SomethigLostText("- 골드 50");

                player.addItem(2009);
                player.subGold(50);

                LastEvent();
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 가방을 들고 있느라 무방비한 후드를 쓴 남자를 공격했지만 그는 간단히 회피했다.\n\n" +
                    " \"내가 너 같은 녀석들한테 한두 번 팔아본 것 같아?\"\n\n" +
                    " 그는 주머니에서 적은 양의 하이놀을 꺼내 흡수한 뒤 싸울 준비를 갖췄다.\n\n");

                gameEventManager.setBattleButton(65);

                NextEvent(021602);
            }

            else if(gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.PrintTextBlock(" 당신은 아무리 봐도 위험해 보이는 하이놀을 구매하지 않기로 했다.\n\n" +
                    " \"뭐, 너 말고도 살 녀석들은 많으니까.\"\n\n" +
                    " 그는 가방을 다시 닫은 후 유유히 떠나갔다.");

                LastEvent();
            }
        }

        private void HinorEvent_021602()
        {
            StartEvent();

            isWin = gameEventManager.isWin(65);

            if(isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 그의 신체능력은 당신이 예상한 것보다 뛰어났다. 하지만 긴 모험으로 단련된 당신에겐 역부족이었고 당신은 그를 쓰러트린 후 가방을 챙겼다.\n\n" +
                    " \"흐흐.. 나..나중에 또 찾게 될 거야.. 그때 보자고..\"\n");
                gameEventManager.SomethigGetText("+ 하이놀");

                player.addItem(2009);
            }

            else if(!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 그의 신체능력은 당신의 상식을 아득히 뛰어 넘었다. 그의 압도적인 힘과 속도에 속수무책으로 당한 당신은 길거리에 쓰러졌다.\n\n" +
                    " \"어때, 성능 확실하지? 뭐, 서비스로 더 싸게 줄게 나중에 또 보자고.\"\n\n" +
                    " 그는 당신의 주머니에서 골드를 가져간 후 하이놀이 든 가방을 놓고 떠났다.\n");
                gameEventManager.SomethigGetText("+ 하이놀\n");
                gameEventManager.SomethigLostText("- 골드 30\n" +
                    "- 체력 5");

                player.addItem(2009);
                player.subGold(30);
                player.Damaged(5);
            }

            LastEvent();
        }
        #endregion

        #region AddictEvent_0217...
        private void AddictEvent_021700()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 저 앞에 음침한 기운을 한 남자가 벽에 기대고 앉아있다. 당신이 그의 옆을 지나갈 때 그는 당신의 손을 붙잡고 말을 건넨다." +
                " 가까이서 보니 그는 온몸이 떨리고 있었고, 눈에 초점이 없었다.\n\n" +
                " \"이... 이봐.. 호..혹시.. 하이놀 좀 있어..? 제발.. 나.. 떠.. 떨림이.. 안 멈춰...\"\n\n");

            gameEventManager.setSellectButton1("- 하이놀을 준다");
            gameEventManager.setSellectButton2("- 골드를 준다");
            gameEventManager.setSellectButton3("- 손을 쳐낸다");

            int hasItemindex = player.HasItemindex(2009);  
            if (hasItemindex == -1)
            {
                gameEventManager.setSellecButton1Disable();
            }

            if(player.Gold < 80)
            {
                gameEventManager.setSellecButton2Disable();
            }

            NextEvent(021701);
        }

        private void AddictEvent_021701()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 그에게 갖고 있던 하이놀을 주었다. 그는 떨리는 손으로 그가 갖고 있던 무기를 건네주었다.\n\n" +
                    " \"고..고마워.. 이..이거라도.. 받아줘..\"\n");
                gameEventManager.SomethigLostText("- 하이놀\n");
                gameEventManager.SomethigGetText("+ 하이놀 중독자의 대검");

                int hasItemindex = player.HasItemindex(2009);
                player.deleteItem(hasItemindex);
                player.addItem(3004);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 그에게 약을 살수 있을 만큼의 골드를 주었다. 그는 떨리는 손으로 그가 갖고 있던 무기를 건네주었다.\n\n" +
                    " \"고..고마워.. 이..이거라도.. 받아줘..\"\n");
                gameEventManager.SomethigLostText("- 골드 80\n");
                gameEventManager.SomethigGetText("+ 하이놀 중독자의 대검");

                player.subGold(80);
                player.addItem(3004);
            }

            else if(gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.PrintTextBlock(" 당신은 붙잡고 있는 그의 손을 쳐냈다. 그는 힘없이 밀려나 벽에 부딪혔고 다시 일어날 힘도 없어 보인다. 당신은 그를 두고 떠났다.");
            }

            LastEvent();
        }
        #endregion

        #region SquareEvent_0218...
        private void SquareEvent_021800()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 마을 광장의 벤치에서 잠깐의 휴식을 가지고 있었다. 광장은 도시가 숲의 증식으로 인하여 황폐화된 것에 비해서 꽤 깔끔했고 다른 사람들도 광장에서 휴식을 갖고 있었다.\n\n" +
                " 평화로운 분위기를 만끽하고 있을 무렵 광장의 끝 편에서 이상한 소리가 들려왔고 당신은 확인을 위해 소리가 들린 곳으로 향했다\n\n" +
                " 그곳에는 거름인간들이 마을 광장으로 들어오려고 하고 있었다. 당신은 광장을 지키기 위해 거름인간들과 맞섰다.\n\n");

            gameEventManager.setBattleButton(50);

            EventDictionary.Remove(gameEventManager.NowEventID);
            NextEvent(021801);
        }

        private void SquareEvent_021801()
        {
            StartEvent();
            isWin = gameEventManager.isWin(50);

            if(isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 당신은 거름인간들을 전부 다 쓰러트린 후 광장으로 돌아갔다. 광장은 아까 그 모습 그대로였으며, 당신은 만족하며 광장을 떠났다.\n");
                gameEventManager.SomethigGetText("+ 골드 20");

                player.addGold(20);
            }

            else if(!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 당신은 거름인간에게 패배해 쓰러졌다. 거름인간들은 당신을 쓰러트린 후 다시 광장을 향해 나아갔고 당신은 그 모습을 쓰러진 채 바라볼 수밖에 없었다.\n");
                gameEventManager.SomethigLostText("- 체력 5");

                player.Damaged(5);
            }

            LastEvent();
        }
        #endregion

        #region RefugeeEvent_0219...
        private void RefugeeEvent_021900()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 도시를 돌아다니던 중 누군가 뒤에서 당신을 툭 쳤고, 당신은 뒤를 돌아보았다. 뒤에는 어디에선가 본 것 같은 엘프가 서있었다.\n\n" +
                " \"저.. 혹시 기억 안 나시나요? 지난번에 숲에서 도움을 받은 사람입니다.\"\n\n" +
                "당신은 그가 숲에서 나무에 묶여있던 엘프였단 것을 떠올렸다.\n\n" +
                " \"지난번엔 정말 감사했습니다. 집에 있는 물건을 챙기고 피난을 가는 중이었습니다. 짐도 많고 하니 저번 일의 감사의 표시라고 생각하시고 받아주셨으면 합니다.\"\n\n");

            gameEventManager.setSellectButton1("- 물건을 받는다");
            gameEventManager.setSellectButton2("- 받지 않는다");

            EventDictionary.Remove(gameEventManager.NowEventID);
            NextEvent(021901);
        }

        private void RefugeeEvent_021901()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 그의 표시를 받아들였다. 그는 물건을 준 후 당신에게 인사를 한 후 도시를 떠났다.\n");
                gameEventManager.SomethigGetText("+ 화려한 단검\n" +
                    "+ 골드 20");

                player.addItem(3003);
                player.addGold(20);
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock("당신은 그의 표시를 받지 않기로 했다. 그러자 그는 당황했고 표시를 받아달라고 부탁했다." +
                    " 하지만 당신은 마음을 정했기에 그의 표시를 거절했다. 그는 아쉬워하며 도시를 떠났다.");
            }

            LastEvent();
        }
        #endregion

        #region DeadEvent_0220...
        private void DeadEvent_022000()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신의 모험은 엘프들의 도시인 이드렉스에서 막을 내렸다. 엘프들은 당신의 시체를 화장시킨 후 납골당에 자리를 내주었다.\n\n" +
                " 시간이 지나면서 감옥숲은 더더욱 넓어져갔고 도시에는 더 이상 아무도 남아있지 않았다. 당신은 관리되지 않는 납골당에 남아 평생 방치될 것이다.");

            gameEventManager.setSellectButton1("- 메인 메뉴로...");
            NextEvent(022001);
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
