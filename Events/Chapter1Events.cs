using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using 파파야연대기.Classes;
using 파파야연대기.Items;

namespace 파파야연대기.Events
{
    class Chapter1Events
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
            TraderEvent = 010300,
            CampEvnet = 010400,
            RefugeeEvent = 010500,
            MushroomEvent = 010600,
            ThiefEvent = 010700,
            HunterEvent = 010800,
            CarriageEvent = 010900,
            BearEvent = 011000,
            MudGolemEvent = 011100,
            RiverEvent = 011200,
            CemetryEvent = 011300,
            BeeEvent = 011400,
            SeedEvent = 011500,
            MoldEvent = 011600,
            SilmeEvent = 011700
        }

        public Chapter1Events(GameEventManager _gameEventManager, Player _player)
        {
            player = _player;
            isSuccess = false;
            isWin = false;
            gameEventManager = _gameEventManager;
            EventDictionary = new Dictionary<int, Action>();
            #region EventDictionary.Add...
            EventDictionary.Add(010000, () => BlacksmithTracksEvent_010000());
            EventDictionary.Add(010001, () => BlacksmithTracksEvent_010001());
            EventDictionary.Add(010002, () => BlacksmithTracksEvent_010002());
            EventDictionary.Add(010100, () => ForestSpiderEvent_010100());
            EventDictionary.Add(010101, () => ForestSpiderEvent_010101());
            EventDictionary.Add(010102, () => ForestSpiderEvent_010102());
            EventDictionary.Add(010103, () => ForestSpiderEvent_010103());
            EventDictionary.Add(010200, () => CaveSpiderEvent_010200());
            EventDictionary.Add(010201, () => CaveSpiderEvent_010201());
            EventDictionary.Add(010202, () => CaveSpiderEvent_010202());
            EventDictionary.Add(010212, () => CaveSpiderEvent_010212());
            EventDictionary.Add(010213, () => CaveSpiderEvent_010213());
            EventDictionary.Add(010222, () => CaveSpiderEvent_010222());
            EventDictionary.Add(010223, () => CaveSpiderEvent_010223());
            EventDictionary.Add(010234, () => CaveSpiderEvent_010234());
            EventDictionary.Add(010235, () => CaveSpiderEvent_010235());
            EventDictionary.Add(010236, () => CaveSpiderEvent_010236());
            EventDictionary.Add(010237, () => CaveSpiderEvent_010237());
            EventDictionary.Add(010244, () => CaveSpiderEvent_010244());
            EventDictionary.Add(010245, () => CaveSpiderEvent_010245());
            EventDictionary.Add(010300, () => TraderEvent_010300());
            EventDictionary.Add(010301, () => TraderEvent_010301());
            EventDictionary.Add(010400, () => CampEvent_010400());
            EventDictionary.Add(010401, () => CampEvent_010401());
            EventDictionary.Add(010500, () => RefugeeEvent_010500());
            EventDictionary.Add(010501, () => RefugeeEvent_010501());
            EventDictionary.Add(010600, () => MushroomEvent_010600());
            EventDictionary.Add(010601, () => MushroomEvent_010601());
            EventDictionary.Add(010700, () => ThiefEvent_010700());
            EventDictionary.Add(010701, () => ThiefEvent_010701());
            EventDictionary.Add(010702, () => ThiefEvent_010702());
            EventDictionary.Add(010800, () => HunterEvent_010800());
            EventDictionary.Add(010801, () => HunterEvent_010801());
            EventDictionary.Add(010802, () => HunterEvent_010802());
            EventDictionary.Add(010900, () => CarriageEvent_010900());
            EventDictionary.Add(010901, () => CarriageEvent_010901());
            EventDictionary.Add(011000, () => BearEvent_011000());
            EventDictionary.Add(011001, () => BearEvent_011001());
            EventDictionary.Add(011002, () => BearEvent_011002());
            EventDictionary.Add(011100, () => MudGolemEvent_011100());
            EventDictionary.Add(011101, () => MudGolemEvent_011101());
            EventDictionary.Add(011102, () => MudGolemEvent_011102());
            EventDictionary.Add(011200, () => RiverEvent_011200());
            EventDictionary.Add(011201, () => RiverEvent_011201());
            EventDictionary.Add(011300, () => CemetryEvent_011300());
            EventDictionary.Add(011301, () => CemetryEvent_011301());
            EventDictionary.Add(011302, () => CemetryEvent_011302());
            EventDictionary.Add(011303, () => CemetryEvent_011303());
            EventDictionary.Add(011400, () => BeeEvent_011400());
            EventDictionary.Add(011401, () => BeeEvent_011401());
            EventDictionary.Add(011402, () => BeeEvent_011402());
            EventDictionary.Add(011500, () => SeedEvent_011500());
            EventDictionary.Add(011501, () => SeedEvent_011501());
            EventDictionary.Add(011600, () => MoldEvent_011600());
            EventDictionary.Add(011601, () => MoldEvent_011601());
            EventDictionary.Add(011700, () => SlimeEvent_011700());
            EventDictionary.Add(011701, () => SlimeEvent_011701());
            EventDictionary.Add(011800, () => DeadEvent_011800());
            EventDictionary.Add(011801, () => toMainMenu());
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
            if (gameEventManager.EventNumber == 5)
            {
                gameEventManager.NextEventID = 010100;
                return;
            }

            else if (gameEventManager.EventNumber == 10)
            {
                gameEventManager.NextEventID = 010200;
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

            if(gameEventManager.NextEventID == 011801)
            {
                return;
            }

            else if (player.isDead())
            {
                gameEventManager.NextEventID = 011800;
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

            if(player.isDead())
            {
                gameEventManager.NextEventID = 011800;
                gameEventManager.setSellectButton1("- 영원한 안식", string.Empty, string.Empty);
            }
        }
        #endregion

        #region BlacksmithTracksEvent_0100...
        private void BlacksmithTracksEvent_010000()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 제자가 준 지도를 보며 계속 걸었고, 지도에 표시된 지점에 도착했다. 바닥에는 사람들의 피난으로 인한 많은 발자국과 여러 짐들, " +
                "그리고 그 위로 뻗어져나간 나무뿌리들이 보였다.\n\n" + " 당신은 덩굴들을 헤치며 발자국을 조사하던 중, 드워프의 것으로 보이는 발자국을 발견했고, " +
                "발자국의 깊이와 모양으로 이것이 대장장이의 발자국인 것을 알아냈다.\n\n");

            gameEventManager.setSellectButton1("- 발자국을 따라간다");
            gameEventManager.setSellectButton2("- 다른 흔적을 더 찾아본다");
            NextEvent(010001);
        }

        private void BlacksmithTracksEvent_010001()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 대장장이를 찾기 위해 발자국이 난 방향인 동쪽으로 향했다.");
                LastEvent();
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 다른 흔적을 더 찾아보기로 했지만, 대장장이의 또 다른 흔적은 찾을 수 없었고, 피난 중에 버려진 것 같은 가방을 발견했다.\n\n");
                gameEventManager.setSellectButton1("- 가방을 열어본다");
                gameEventManager.setSellectButton2("- 가방을 열지 않는다");
                NextEvent(010002);
            }
        }

        private void BlacksmithTracksEvent_010002()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 가방 안에는 회복용으로 보이는 포션과 약간의 골드가 들어있었다. 물건들을 가방 안에 넣은 후, 대장장이를 찾기 위해 발자국이 난 방향인 동쪽으로 향했다.\n");
                gameEventManager.SomethigGetText("+ 힐링 포션\n" +
                    "+ 골드 10");
                player.addItem(2001);
                player.addGold(10);
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 어떠한 위험이 있을지 모른다고 판단한 당신은 가방을 두고 대장장이를 찾기 위해 발자국이 난 방향인 동쪽으로 향했다.");
            }

            LastEvent();
        }
        #endregion

        #region ForestSpiderEvent_0101...
        private void ForestSpiderEvent_010100()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 동쪽으로 흔적을 찾으며 탐색을 이어온 당신은 어느덧 숲 깊숙한 곳까지 들어왔다. " +
                "발에 걸리는 덩굴들과 왠지 모르게 점점 많아지는 거미줄은 당신을 불편하게 했지만, 당신은 대수롭지 않게 여기며 계속 앞으로 나아갔다.\n\n" +
                " 하지만 나아가면 나아갈수록 거미줄은 계속해서 늘어났고, 결국 당신은 몸을 움직이기 힘들 정도로 거미줄에 갇혀 버렸다.\n\n");

            gameEventManager.setSellectButton1("- 거미줄을 힘으로 제거한다", STRENGTH, gameEventManager.SuccessProbability(30, 3, player.Strength));
            gameEventManager.setSellectButton2("- 거미줄을 불에 태운다");

            int hasItemindex = player.HasItemindex(1001);
            if (hasItemindex == -1)
            {
                gameEventManager.setSellecButton2Disable();
            }

            NextEvent(010101);
        }

        private void ForestSpiderEvent_010101()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                isSuccess = gameEventManager.isSuccess(30, 3, player.Strength);

                if (isSuccess)
                {
                    gameEventManager.SuccessMessage();
                    gameEventManager.PrintTextBlock(" 거미줄은 당신에 손에 쉽게 뜯어졌다. 그러자 나무 위에서 치이익거리는 소리와 함께 커다란 거미가 모습을 드러냈다.\n\n");

                    gameEventManager.setBattleButton(30);
                    isWin = gameEventManager.isWin(30);
                }

                else if (!isSuccess)
                {
                    gameEventManager.FailMessage();
                    gameEventManager.PrintTextBlock(" 당신은 거미줄에 몸에 묶인 거미줄을 푸려 발버둥 쳤지만, 당신의 힘으로는 불가능했다. " +
                        "곧이어 나무 위에서 치이익거리는 소리와 함께 커다란 거미가 모습을 드러내며 다가왔다.\n\n");

                    gameEventManager.setBattleButton(40);
                    isWin = gameEventManager.isWin(40);
                }
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                int hasItemindex = player.HasItemindex(1001);

                gameEventManager.PrintTextBlock(" 거미줄은 불에 타 사그라들었고, 당신은 손쉽게 거미줄을 빠져나올 수 있었다. " +
                    "그때, 나무 위에서 치이익거리는 소리와 함께 커다란 거미가 모습을 드러내며 다가왔다.\n");
                gameEventManager.SomethigLostText("- 횃불\n\n");
                player.deleteItem(hasItemindex);

                gameEventManager.setBattleButton(30);
                isWin = gameEventManager.isWin(30);
            }

            NextEvent(010102);
        }

        private void ForestSpiderEvent_010102()
        {
            StartEvent();

            if (isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 거미는 당신의 공격에 비명을 지르며 쓰러졌다. 그러자 숲을 뒤덮고 있었던 거미줄도 녹아내리기 시작했고, 거미줄 때문에 보이지 않았던 곳들이 보이기 시작했다.\n\n" +
                    " 당신은 쓰러져있는 한 사람을 발견했고, 그에게 다가갔다. 얼마 후, 그가 깨어나자 당신은 그에게 상황을 물었다.\n\n" +
                    " \"저는 약초를 캐는 약초꾼입니다.원래 이 거미들은 동굴에서만 생활하던 녀석들인데, 최근 들어 숲이 커지기 시작하면서 거미들이 밖으로 나오기 시작했습니다. " +
                    "모험가님은 어쩐 이유로 이 깊숙한 곳까지 들어오시게 된 건가요?\"\n\n");
                gameEventManager.SomethigGetText("+ 골드 30\n");

                player.addGold(30);
            }

            else if (!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 당신은 거미에 공격에 쓰러지고 말았지만, 치명상을 입히는데 성공했고 더 이상의 싸움을 원치 않았던 거미는 자리를 물러났다. " +
                    "당신은 정신을 잃고 쓰러졌고, 정신을 차리고 나니 당신 옆에 한 남자가 당신을 치료하고 있었다.\n\n" +
                    " \"일어나셨군요. 저는 약초를 캐는 약초꾼입니다. 길에 쓰러져 계시길래 치료를 해드렸습니다. " +
                    "원래 이 거미들은 동굴에서만 생활하던 녀석들인데, 최근 들어 숲이 커지면서 거미들이 밖으로 나오기 시작하더군요. " +
                    "모험가님은 어쩐 이유로 이 깊숙한 곳까지 들어오시게 된 건가요?\"\n");
                gameEventManager.SomethigLostText("- 체력 10\n");

                player.Damaged(10);
            }

            gameEventManager.setSellectButton1("- 드워프를 찾고있다");

            NextEvent(010103);
        }

        private void ForestSpiderEvent_010103()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" \"드워프요 ? 제가 어제 거미가 묶인 드워프를 들고 이동하는 것을 봤습니다. 아마 동굴로 데려간 것 같은데, 제가 동굴의 위치를 알려드리겠습니다.\"\n\n" +
                " 당신은 약초꾼에게 감사를 표한 뒤 동굴을 향해 발걸음을 옮겼다.");

            LastEvent();
        }
        #endregion

        #region CaveSpiderEvent_0102...
        private void CaveSpiderEvent_010200()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 약초꾼이 지도에 표시해 준 곳으로 걸었고, 거미가 있다는 동굴에 도착했다. 동굴 안쪽은 거미줄로 가득했고, 퀴퀴한 냄새가 났다.\n\n");

            gameEventManager.setSellectButton1("- 동굴 안쪽으로 들어간다");

            NextEvent(010201);
        }

        private void CaveSpiderEvent_010201()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 동굴 안쪽으로 들어가자, 밖에서는 보이지 않았던 생전 처음 보는 수정들이 빛을 내고 있었고 덕분에 횃불 없이도 시야를 확보할 수 있었다.\n\n" +
                " 계속하여 앞으로 걷자 갈림길이 나왔고 당신은 그 앞에 멈춰 섰다. 한쪽은 거미줄로 가득했고, 다른 한쪽은 깨끗해 보인다.\n\n");

            gameEventManager.setSellectButton1("- 거미줄이 가득한 길");
            gameEventManager.setSellectButton2("- 깨끗한 길");

            NextEvent(010202);
        }

        private void CaveSpiderEvent_010202()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                NextEvent(010212);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                NextEvent(010222);
            }
            gameEventManager.RunEvent(0);
        }

        private void CaveSpiderEvent_010212()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신의 목표는 거미였기에, 거미줄이 가득한 길로 향했다." +
                " 거미줄이 옷에 달라붙어 움직이기가 힘들었지만 저번의 경험으로 당신은 손쉽게 떼어낼 수 있었다.\n\n" +
                " 거미줄을 헤쳐나가며 동굴의 끝부분에 도착했고 그곳에는 당신이 찾던 드워프가 쓰러져 있었다.\n\n" +
                " 그는 의뢰인이 주었던 그림과는 달리 매우 야위어있었고, 간신히 숨만 붙어있는 상태였다. 당신은 그를 구하기 위해 다가갔고, 그를 부축하기 위해 자세를 낮췄다.\n\n" +
                " 그러자 뒤에서 스스슥거리는 소리가 났고 뒤를 돌아보니 저번에 만난 거미와는 비교도 되지 않을 만큼 큰 거미가 나타났다, 아무래도 거미의 함정에 걸려든 것 같다.\n\n");

            gameEventManager.setBattleButton(55);

            NextEvent(010213);
        }

        private void CaveSpiderEvent_010213()
        {
            StartEvent();
            isWin = gameEventManager.isWin(55);

            if(isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 커다란 거미는 당신의 무기 아래 쓰러졌다. 당신은 드워프를 부축해 동굴 밖으로 나와 엔콜로로 돌아갔다.\n");
                gameEventManager.SomethigGetText("+ 골드 30\n\n");

                player.addGold(30);

                gameEventManager.setSellectButton1("- 엔콜로로 향한다");
                NextEvent(010234);
            }

            else if(!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 동굴의 거미는 숲의 거미보다 훨씬 강했고, 드워프를 지키면서 싸우기에는 당신의 실력으로는 역부족이었다.\n\n" +
                    " 당신은 점차 벽 쪽으로 밀려났고 바로 뒤에는 드워프가 쓰러져있어 더 이상 뒤로 갈 수 없었다." +
                    " 그때 드워프가 힘없는 목소리로 당신에게 말을 건네왔다.\n\n" +
                    " \"내 대장간에 숲의 증식을 막을 물건이 있네, 자네마저 여기서 죽는다면 아무도 모르게 되니 자네라도 여기서 빠져나가 엘프 도시 이드렉스에 있는 내 대장간으로...\"\n\n" +
                    " 말끝이 점점 흐려지더니 드워프는 말을 끝마치지 못하고 숨을 거두었다.\n");
                gameEventManager.SomethigLostText("- 체력 10\n\n");

                player.Damaged(10);

                gameEventManager.setSellectButton1("- 빠져나간다");

                NextEvent(010244);
            }

            
        }

        private void CaveSpiderEvent_010244()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 거미의 공격을 쳐낸 다음 죽을힘을 다해 도망쳤고 거미는 잠깐 당신을 따라오는가 싶더니 다시 동굴 안쪽으로 들어갔다.\n\n" +
                    " 동굴에서 빠져나온 당신은 드워프를 구하지는 못했지만 그의 유언을 전해주러 엔콜로로 돌아갔다.\n\n");

            gameEventManager.setSellectButton1("- 엔콜로로 향한다");

            NextEvent(010245);
        }

        private void CaveSpiderEvent_010222()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 지난번의 숲에서 만난 거미의 기억이 떠오른 당신은 거미줄을 헤쳐나가는 것이 얼마나 힘든 일인지 잘 알고 있었고, 거미줄이 없는 깨끗한 길로 향했다.\n\n" +
                " 동굴 안쪽으로 들어갈수록 수정의 수가 줄어들었고 결국 아무것도 보이지 않는 곳까지 들어오고 말았다.\n\n" +
                " 그때 머리 위에서 뭔가 지나가는 느낌이 들었고 위를 보니 수많은 박쥐들의 눈이 보인다.\n\n");

            gameEventManager.setBattleButton(25);

            NextEvent(010223);
        }

        private void CaveSpiderEvent_010223()
        {
            StartEvent();

            isWin = gameEventManager.isWin(25);

            if(isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 당신은 소리에 집중해 날아오는 박쥐들을 하나하나 쳐냈고 시끄러웠던 날개 소리가 점차 줄어들어갔다. 얼마 후 동굴에는 물방울이 떨어지는 소리밖에 들리지 않았다.\n\n" +
                    " 이곳에는 거미가 없을 것이라고 판단한 당신은 왔던 길로 되돌아가 갈림길 앞에 도착했다.\n");
                gameEventManager.SomethigGetText("+ 골드 10\n\n");

                player.addGold(10);
            }

            else if(!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 눈에 보이지 않는 박쥐들은 당신을 집요하게 공격했고 할 수 있는 것이라곤 왔던 길로 도망가는 것뿐이었다.\n\n " +
                    " 수정이 다시 보이고 빛이 보일 때 뒤를 돌아보니 박쥐들은 더 이상 따라오지 않았다.\n\n" +
                    " 박쥐들에게 호되게 당한 당신은 다시 갈림길 앞에 도착했다.\n");
                gameEventManager.SomethigLostText("- 체력 5\n\n");

                player.Damaged(5);
            }

            gameEventManager.setSellectButton1("- 거미줄이 가득한 길");

            NextEvent(010212);
        }

        private void CaveSpiderEvent_010234()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 엔콜로로 돌아온 당신은 의뢰인인 대장장이의 제자에게 향했다. 그에게 드워프를 넘겨준 후 보상을 받았다. 당신은 임무를 성공했다.\n");
            gameEventManager.SomethigGetText("+ 골드 50\n\n");

            player.addGold(50);

            gameEventManager.setSellectButton1("- 얼마 후...");

            NextEvent(010235);
        }

        private void CaveSpiderEvent_010235()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 임무를 끝마친 당신은 엔콜로에서 잠깐의 휴식을 갖고 있었다." +
                " 당신이 모험가 길드를 둘러보고 있을 때 대장장이의 제자가 당신을 찾아왔고 그의 스승인 드워프가 당신을 찾고 있다고 말했다.\n\n");

            gameEventManager.setSellectButton1("- 드워프에게 간다");

            NextEvent(010236);
        }

        private void CaveSpiderEvent_010236()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" \"아, 왔군. 자네에게 할 이야기가 있어 불렀네. 우선, 감사를 전하지 못한 것이 마음에 걸려서.." +
                " 정말 고맙네. 그리고 하나 더, 자네에게 부탁할 것이 있다네. 아니, 의뢰할 것이 있네." +
                " 엘프들의 도시인 이드렉스에 있는 내 대장간에 마나를 태우는 불이 있다네 그것을 이용하면 숲의 증식을 막을 수 있을 걸세 그 불을 가지고 이 사태를 막아주었으면 하네.\"\n\n");

            gameEventManager.setSellectButton1("- 의뢰를 받는다");
            gameEventManager.setSellectButton2("- 방법을 묻는다");

            NextEvent(010237);
        }

        private void CaveSpiderEvent_010237()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 제자의 의뢰를 성공적으로 마친 당신은 이번에는 대장장이의 의뢰를 받고 엘프들의 도시인 이드렉스로 향한다.");

                LastEvent();
                gameEventManager.GameChapterChange();
                gameEventManager.BlackSmithAlive = true;
            }
            
            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" \"미안하지만... 그건 나도 모른다네. 하지만, 동굴 안에서 본 갑자기 거대해진 거미들과 반짝이는 수정들은 분명 숲이 확장되면서 나무에서부터 나온 마나의 영향일 걸세." +
                    " 부탁이네, 숨의 증식을 막는 것을 도와주게.\"\n\n");

                gameEventManager.setSellectButton1("- 의뢰를 받는다");

                NextEvent(010237);
            }
        }

        private void CaveSpiderEvent_010245()
        {
            StartEvent();

            gameEventManager.PrintTextBlock(" 당신은 의뢰인인 대장장이의 제자에게 찾아가 스승의 사망 소식을 알려주었다. 그는 큰 충격을 받은 것 같았지만, 이내 입을 열었다.\n\n" +
                " \"그래도... 정말 감사합니다. 스승님의 장례를 치를 수 있겠군요..\"\n\n" +
                " 당신은 의뢰인에게 약간의 보수를 받고 대장장이의 마지막 유언을 지켜주기 위해 엘프들의 도시인 이드렉스로 향했다\n");
            gameEventManager.SomethigGetText("+ 골드 50");

            player.addGold(50);

            LastEvent();
            gameEventManager.GameChapterChange();
            gameEventManager.BlackSmithAlive = false;
        }
        #endregion

        #region TraderEvent_0103...
        private void TraderEvent_010300()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 숲을 따라 길을 가던 중 저 멀리 맞은편에서 걸어오는 사람을 발견했다. 그는 매우 큰 가방을 메고 있었고 얼핏 보면 피난 가는 것 같기도 했다.\n\n" +
                "그가 당신을 보더니 손을 흔들며 달려왔고, 자신을 물건을 파는 상인이라고 소개했다.\n\n" +
                " \"피난민분들을 위한 물건을 팔고 있습니다. 물론, 모험가분들을 위한 물건도 판매하고 있죠!\"\n\n");

            gameEventManager.setSellectButton1("- 물건을 본다");
            gameEventManager.setSellectButton2("- 가던 길 간다");
            gameEventManager.setSellectButton3("- 골드를 훔친다", DEXTERITY, gameEventManager.SuccessProbability(50, 1, player.Dexterity));

            NextEvent(010301);
        }

        private void TraderEvent_010301()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.trader.addItems(GameItem.ShopType.Chpater1);
                View.Play.TradeWindowOpen();
                gameEventManager.PrintTextBlock(" 당신은 상인의 물건을 보고 나서 다시 발걸음을 옮겼다.");
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 상인에게 인사를 한 후 실망스러워하는 그를 뒤로하고 다시 발걸음을 옮겼다.");
            }

            else if (gameEventManager.ButtonNumber == 3)
            {
                isSuccess = gameEventManager.isSuccess(50, 1, player.Dexterity);

                if (isSuccess)
                {
                    gameEventManager.SuccessMessage();
                    gameEventManager.PrintTextBlock(" 당신은 상인에게 물건을 보지 않겠다고 말했고, 실망스러워하며 떠나는 그의 뒤에 묶여있던 돈주머니를 훔쳤다. " +
                                        "아직 눈치채지 못한 그를 뒤로하고 다시 발걸음을 옮겼다.\n");
                    gameEventManager.SomethigGetText("+ 골드 30");

                    player.addGold(30);
                }

                else if (!isSuccess)
                {
                    gameEventManager.FailMessage();
                    gameEventManager.PrintTextBlock(" 당신은 상인에게 물건을 보지 않겠다고 말했고, 실망스러워하며 떠나는 그의 뒤에 묶여있던 돈주머니를 훔치려 했으나, " +
                        "이상한 감촉에 뒤를 돌아본 상인과 눈이 마주친 당신은 무안해하며 황급히 자리를 떠났다.");
                }
            }

            LastEvent();
        }
        #endregion

        #region CampEvent_0104...
        private void CampEvent_010400()
        {
            FirstEvent();
            gameEventManager.PrintTextBlock(" 당신은 흔적을 찾아 떠돌던 중 빈 캠프를 발견했다. 캠프 안을 대충 훑어보니, 캠프 안은 텅 비어있었고 아무래도 버려진 캠프 같았다.\n\n");

            gameEventManager.setSellectButton1("- 쉬고 간다");
            gameEventManager.setSellectButton2("- 훈련한다");
            gameEventManager.setSellectButton3("- 쉬지 않는다");

            NextEvent(010401);
        }

        private void CampEvent_010401()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 계속된 모험으로 지친 당신은 버려진 캠프에서 잠깐 쉬어가기로 결정했다.\n\n " +
                "모닥불을 다시 피운 후 감옥숲 안에서 잠깐의 휴식을 가진 당신은 대장장이를 찾아 캠프를 떠났다.\n");
                gameEventManager.SomethigGetText("+ 체력 10");

                player.Heal(10);
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 캠프에서 앞으로 있을 모험에 대비해 훈련하기로 결정했다. " +
                    "비록 휴식은 하지 못하고 몸은 지쳤지만, 이전보다 강해진 느낌을 가지고 대장장이를 찾아 캠프를 떠났다.\n");
                gameEventManager.SomethigLostText("- 체력 5\n");
                gameEventManager.SomethigGetText("+ 힘 1\n" +
                    "+ 민첩 1");

                player.Damaged(5);
                player.Strength++;
                player.Dexterity++;
            }

            else if (gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.PrintTextBlock(" 시간이 없다고 판단한 당신은 버려진 캠프를 무시하고 대장장이를 찾아 계속 걸었다.");
            }

            LastEvent();
        }
        #endregion

        #region RefugeeEvent_0105...
        private void RefugeeEvent_010500()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 조용한 숲을 가던 중 어딘가에서 흐느끼는듯한 소리가 들렸다. 당신은 그 소리를 듣고 곧바로 소리가 난 곳으로 향했고, " +
                "피난민으로 보이는 사람이 늘어난 나무뿌리에 묶여있었다.\n\n" +
                " \"드디어..... 제발... 도와..주세요....\"\n\n" +
                " 자세히 보니 그의 상황은 꽤 심각했다. 며칠은 굶은 듯이 초췌한 몰골을 하고 있었고, 나무뿌리에 단순히 묶인 것이 아니라 몇몇 뿌리들은 몸을 관통하고 있었다.\n\n");

            gameEventManager.setSellectButton1("- 치료해준다");
            gameEventManager.setSellectButton2("- 죽인다");
            gameEventManager.setSellectButton3("- 도망친다");

            EventDictionary.Remove(gameEventManager.NowEventID);
            NextEvent(010501);
        }

        private void RefugeeEvent_010501()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                int hasItemindex = player.HasItemindex(2001);
                if (hasItemindex != -1)
                {
                    gameEventManager.PrintTextBlock(" 당신은 황급히 가방에 있는 체력 물약을 꺼내 그에게 먹이고, 그를 묶고 있던 나무뿌리들을 쳐낸 후 휴식을 취하게끔 해주었다.\n\n"
                    + " \"정말 감사합니다... 저는 도시를 향하고 있었습니다. 잠깐 나무에 기대어 쉬고 있었는데 갑자기 뿌리가 자라나더군요. 나중에 다시 뵙게 된다면 제가 꼭 보답하겠습니다.\"\n\n"
                    + " 그는 당신에게 감사인사를 마친 후 도시 방향으로 떠났다.\n");
                    gameEventManager.SomethigLostText("- 체력 물약");
                    player.deleteItem(hasItemindex);
                    gameEventManager.RefugeeAlive = true;
                }

                else
                {
                    gameEventManager.PrintTextBlock("  마땅한 치료방법이 없던 당신은 황급히 그를 묶고 있던 나무뿌리들을 잘라냈지만, 더 이상 그의 흐느끼는 소리가 들리지 않았다.");
                }
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 이유야 어찌 되었든 간에, 당신은 그의 기나긴 고통을 끝내주었다. 옆에 있던 그의 가방에서 약간의 골드를 챙긴 후 온 길로 되돌아갔다.\n");
                gameEventManager.SomethigGetText("+ 골드 20");
                player.addGold(20);
            }

            else if (gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.PrintTextBlock("그의 모습에 겁먹은 당신은 온 길로 황급히 도망쳤다. 뒤에서 작게 목소리가 들리는 듯했지만 당신에게는 들리지 않았고, " +
                    "잠깐 숨을 고르며 그가 있던 방향에 집중해보았지만 더 이상 소리는 들리지 않았다.");
            }

            LastEvent();
        }
        #endregion

        #region MushroomEvent_0106...
        private void MushroomEvent_010600()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 꽤 오랫동안 숲을 거닐며 탐사를 지속한 당신은 오늘 하루 동안 아무것도 먹지 못했다는 것을 깨달았고, 극심한 허기를 느꼈다.\n\n " +
                "잠시 쉬어야겠다고 생각한 당신은 커다란 나무 밑동에서 자란 버섯을 발견했다. 노란색의 동그란 버섯은 커다랗고 꽤 먹음직스러워 보인다.\n\n");

            gameEventManager.setSellectButton1("- 버섯을 먹는다", INTELLIGENCE, gameEventManager.SuccessProbability(30, 3, player.Intelligence));
            gameEventManager.setSellectButton2("- 독버섯일 수 있다. 먹지 않는다");

            NextEvent(010601);
        }

        private void MushroomEvent_010601()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                isSuccess = gameEventManager.isSuccess(30, 3, player.Intelligence);

                if (isSuccess)
                {
                    gameEventManager.SuccessMessage();
                    gameEventManager.PrintTextBlock(" 버섯은 꽤 맛있었고 양도 넉넉해서 충분히 배를 불릴 수 있었다. 배를 채운 당신은 기운을 차리고 일어나 다시 탐사를 시작했다.\n");
                    gameEventManager.SomethigGetText("+ 체력 5");

                    player.Heal(5);
                }

                else if (!isSuccess)
                {
                    gameEventManager.FailMessage();
                    gameEventManager.PrintTextBlock(" 버섯을 먹자 배가 찢어지는듯한 고통을 느꼈고, 정신을 잃으며 쓰러졌다.\n\n" +
                        " 시간이 한참 지나고 나서야 정신을 차릴 수 있었고, 버섯을 전부 토해낸 당신은 굶주린 배를 움켜잡고 다시 탐사를 시작했다.\n");
                    gameEventManager.SomethigLostText("- 체력 5");

                    player.Damaged(5);
                }
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 색이 화려한 버섯은 독버섯이라는 어딘가에서 들은 이야기가 생각난 당신은 먹음직스러워 보이는 버섯을 뒤로하고 다시 탐사를 나섰다.");
            }

            LastEvent();
        }
        #endregion

        #region ThiefEvent_0107...
        private void ThiefEvent_010700()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 나뭇잎으로 가려져 있는 덫을 발견했다. 관찰력이 뛰어난 자신을 칭찬하며 안도의 한숨을 내쉬었다. " +
                "그런데, 덫을 자세히 보니 야생동물을 잡으려고 설치한 것이 아니라 마치 사람을 잡기 위한 덫 같았다.\n\n");

            gameEventManager.setSellectButton1("- 피해 간다");
            gameEventManager.setSellectButton2("- 덫을 해제한다", INTELLIGENCE, gameEventManager.SuccessProbability(45, 2, player.Intelligence));

            EventDictionary.Remove(gameEventManager.NowEventID);
            NextEvent(010701);
        }

        private void ThiefEvent_010701()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 위험해 보이는 덫에 굳이 어울려줄 필요 없다고 생각한 당신은 다른 곳으로 돌아가기로 결정했다.\n\n" +
                    " 다른 길로 가던 중 갑자기 뒤에서 단검이 날아왔고, 다행히도 당신은 그 단검을 피했다.\n\n 도적단의 두목은 당황한 듯 보였지만 다시 단검을 꺼내고 도적들과 함께 당신에게 다가온다.\n\n");

                gameEventManager.setBattleButton(25);
                isWin = gameEventManager.isWin(25);

                NextEvent(010702);
            }

            if (gameEventManager.ButtonNumber == 2)
            {
                isSuccess = gameEventManager.isSuccess(45, 2, player.Intelligence);

                if (isSuccess)
                {
                    gameEventManager.SuccessMessage();
                    gameEventManager.PrintTextBlock(" 뛰어난 관찰력으로 덫의 구조를 금방 파악한 당신은 덫을 해제하는데 성공했다. 다른 사람들이 안전하길 바라며 해제한 덫을 뒤로하고 떠나갔다.");

                    LastEvent();
                }

                else if (!isSuccess)
                {
                    gameEventManager.FailMessage();
                    gameEventManager.PrintTextBlock(" 당신은 덫을 해제하려고 했지만 덫의 구조는 생각보다 복잡했고 덫을 해제하던 중 실수로 인해 덫이 발동되었다.\n\n" +
                        " 당신은 고통에 큰 소리를 질렀고 그 소리를 들은듯한 도적들이 비웃으며 다가왔다.\n");
                    gameEventManager.SomethigLostText("- 체력 5\n\n");

                    player.Damaged(5);

                    gameEventManager.setBattleButton(35);
                    isWin = gameEventManager.isWin(35);

                    NextEvent(010702);
                }
            }
        }

        private void ThiefEvent_010702()
        {
            StartEvent();

            if (isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 한낱 도적은 당신의 상대가 안됐고, 바로 두목의 숨통을 끊었다. 그 모습에 겁을 먹은 도적들은 도망쳤고 당신은 약간의 골드를 챙기고 떠났다.\n");
                gameEventManager.SomethigGetText("+ 골드 30");

                player.addGold(30);
            }

            else if (!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 도적의 두목은 꽤나 날렵했고 큰 상처를 입은 당신은 당황한 상태로 도망쳤고, 그 과정에서 약간의 골드를 떨어트렸다.\n");
                gameEventManager.SomethigLostText("- 체력 5\n" +
                                                "- 골드 10");

                player.Damaged(5);
                player.subGold(10);
            }

            LastEvent();
        }
        #endregion

        #region HunterEvent_0108...
        private void HunterEvent_010800()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 숲을 가던 중 갑작스레 귀 옆으로 화살이 지나가 앞에 있는 나무에 박혔다. 당황한 당신이 뒤를 돌아보기도 전에 뒤에서 누군가가 말을 걸었다.\n\n" +
                " \"뭐야 너? 인간 녀석이 여기가 어디라고 들어와?\"\n\n" +
                " 뒤를 돌아보니 한 엘프가 활시위를 당긴 채로 당신을 노려보고 있었다.\n\n");

            gameEventManager.setSellectButton1("- 상황을 설명한다");
            gameEventManager.setSellectButton2("- 무기를 꺼낸다");

            EventDictionary.Remove(gameEventManager.NowEventID);
            NextEvent(010801);
        }

        private void HunterEvent_010801()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 엘프에게 숲이 확장되고 있다는 것과 숲에 들어온 이유를 설명했다.\n\n" +
                    " \"흐음.. 확실히 요즘 숲이 좀 이상하긴 했었는데.. 알려줘서 고마워, 숲 안에만 있으니 소식을 잘 알 수가 없으니.. 무례한 행동에 대해선 사과할게 이 근처에 도적단이 있어서 말이야.\"\n\n" +
                    " 엘프는 사과의 표시로 가지고 있던 활 하나를 주고 떠나갔다.\n");
                gameEventManager.SomethigGetText("+ 장궁");
                player.addItem(3002);

                LastEvent();
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 이 버릇없는 엘프를 혼쭐 내주기로 했다. 무기를 꺼낸 당신을 본 엘프는 혀를 찼다.\n\n" +
                    " \"하여간 인간새끼들은...\"\n\n");

                gameEventManager.setBattleButton(50);

                NextEvent(010802);
            }
        }

        private void HunterEvent_010802()
        {
            StartEvent();

            isWin = gameEventManager.isWin(50);
            if (isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 당신은 날아오는 화살을 피한 후 엘프를 공격했고, 그 결과 승리할 수 있었다. 기절 한 엘프를 그대로 두고 당신은 다시 나아갔다.");
                gameEventManager.SomethigGetText("+ 골드 15");

                player.addGold(15);
            }

            else if (!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 엘프의 버릇없는 태도에는 그를 뒷받침하는 확실한 실력이 있었다. 당신은 엘프에게 패배해 바닥에 쓰러졌다.\n\n" +
                    " \"다신 알짱거리지 말라고.\"\n\n" +
                    " 엘프는 당신에게 으름장을 놓으며 떠나갔다.");
            }

            LastEvent();
        }
        #endregion

        #region CarriageEvent_0109...
        private void CarriageEvent_010900()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 길을 가던 중 버려진 마차를 발견했다. 마차는 부서져서 넘어져있었고, 아직 안에는 화물이 남아있어 보인다.\n\n");

            gameEventManager.setSellectButton1("- 살펴본다", WIZDOM, gameEventManager.SuccessProbability(40, 2, player.Wizdom));
            gameEventManager.setSellectButton2("- 지나친다");

            NextEvent(010901);
        }

        private void CarriageEvent_010901()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                isSuccess = gameEventManager.isSuccess(40, 2, player.Wizdom);

                if (isSuccess)
                {
                    gameEventManager.SuccessMessage();
                    gameEventManager.PrintTextBlock(" 마차 안에는 화물이 많이 남아있었다. 화물은 대부분 식료품이었고 약간의 골드가 있었다. " +
                        "아무래도 피난민들의 마차 같았다. 상태가 좋은 식료품과 골드를 조금 챙긴 후 마차에서 내렸다.\n");
                    gameEventManager.SomethigGetText("+ 고기 2\n" +
                                                    "+ 골드 5");
                    player.addItem(2002);
                    player.addItem(2002);
                    player.addGold(5);
                }

                else if (!isSuccess)
                {
                    gameEventManager.FailMessage();
                    gameEventManager.PrintTextBlock(" 마차는 보기보다 더 많이 부서져있었고 당신이 올라타자마자 무너져 내렸다." +
                        " 잔해에서 빠져나온 당신은 다 부서진 화물을 보고 아쉬워하며 마차였던 것에서 떠나갔다.\n");
                    gameEventManager.SomethigLostText("- 체력 5");

                    player.Damaged(5);
                }
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 버려진 마차를 지나치기로 했다.");
            }

            LastEvent();
        }
        #endregion

        #region BearEvent_0110...
        private void BearEvent_011000()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 근처 나무에 긁힌 자국이 많이 보인다. 그 자국을 본 당신은 이 구역이 곰의 구역이라는 것을 깨달았고 서둘러 다른 곳으로 가기 위해 방향을 틀었다." +
                " 하지만 이미 곰은 당신의 눈앞에 있었다.\n\n");

            gameEventManager.setBattleButton(45);
            gameEventManager.setSellectButton2("- 기선제압!", CHARM, gameEventManager.SuccessProbability(20, 3, player.Charm));
            gameEventManager.setSellectButton3("- 도망친다", DEXTERITY, gameEventManager.SuccessProbability(35, 2, player.Dexterity));

            EventDictionary.Remove(gameEventManager.NowEventID);
            NextEvent(011001);
        }

        private void BearEvent_011001()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                isWin = gameEventManager.isWin(45);
                NextEvent(011002);
                RunEvent(1);
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                isSuccess = gameEventManager.isSuccess(20, 3, player.Charm);

                if (isSuccess)
                {
                    gameEventManager.SuccessMessage();
                    gameEventManager.PrintTextBlock(" 당신은 곰을 노려보자 곰은 잠시 주춤하더니 그대로 뒷걸음질 치며 물러났다.");
                    LastEvent();
                }

                else if (!isSuccess)
                {
                    gameEventManager.FailMessage();
                    gameEventManager.PrintTextBlock(" 당신은 곰을 노려보았으나, 곰은 소리를 지르며 당신에게 달려들었다. 아무래도 곰은 더 화가 난 것 같다.\n\n");

                    gameEventManager.setBattleButton(50);
                    isWin = gameEventManager.isWin(50);
                    NextEvent(011002);
                }
            }

            else if (gameEventManager.ButtonNumber == 3)
            {
                isSuccess = gameEventManager.isSuccess(35, 2, player.Dexterity);

                if (isSuccess)
                {
                    gameEventManager.SuccessMessage();
                    gameEventManager.PrintTextBlock(" 당신은 곰과 마주치자마자 반대방향으로 최선을 다해 달렸고, 뒤를 돌아보자 곰은 더 이상 보이지 않았다.");
                    LastEvent();
                }

                else if (!isSuccess)
                {
                    gameEventManager.FailMessage();
                    gameEventManager.PrintTextBlock(" 당신은 곰과 마주치자마자 반대 방향으로 최선을 다해 달렸지만, 인간의 달리기 속도로는 곰을 따돌릴 수 없었다.\n\n");

                    gameEventManager.setBattleButton(45);
                    isWin = gameEventManager.isWin(45);
                    NextEvent(011002);
                }
            }
        }

        private void BearEvent_011002()
        {
            StartEvent();

            if (isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 당신은 달려드는 곰을 옆으로 피한 후 곰의 무방비한 뒤통수를 공격했다. 당신의 회심의 일격을 맞은 곰은 그대로 쓰러졌다.\n");
                gameEventManager.SomethigGetText("+ 골드 20");

                player.addGold(20);
            }

            else if (!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 달려오는 곰과 그대로 부딪힌 당신은 죽을듯한 고통을 느꼈다. 고통으로 움직여지지 않는 몸을 이끌고 당신은 온 힘을 다해 도망쳤다.\n");
                gameEventManager.SomethigLostText("- 체력 5");

                player.Damaged(5);
            }

            LastEvent();
        }
        #endregion

        #region MudGolemEvent_0111...
        private void MudGolemEvent_011100()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 잠시 앉아 휴식을 취하며 앞으로의 모험을 대비하고 있었다. 그 순간 엄청난 기세로 땅이 흔들렸고, 마치 지진이 일어난 듯했다.\n\n" +
                " 당황한 당신은 자리에서 일어나 갑작스러운 사고를 대비했다. 얼마 지나지 않아 지진은 멈췄고 숲에는 다시 정적이 흘렀다.\n\n");

            gameEventManager.setSellectButton1("- 더 휴식한다");
            gameEventManager.setSellectButton2("- 나아간다");
            gameEventManager.setSellectButton3("- 도망친다");

            EventDictionary.Remove(gameEventManager.NowEventID);
            NextEvent(011101);
        }


        private void MudGolemEvent_011101()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당황한 당신은 좀 더 생각을 정리할 시간이 필요했고 다시 주저앉아 휴식을 취했다.\n\n" +
                    " 얼마 후 땅이 살짝 흔들리면서 앞에서 큰 소리가 들렸고 앞을 보니 거대한 진흙 골렘이 보였다.\n\n");

                gameEventManager.setBattleButton(40);
                isWin = gameEventManager.isWin(40);

                NextEvent(011102);
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 갑작스러운 지진에 당황한 당신은 가만히 앉아서 휴식을 취할 수 있는 상태가 아니었다." +
                    " 당신은 앞으로 나아갔고 그곳에는 땅속에서 방금 나온 진흙 골렘이 기다리고 있었다.\n\n");

                gameEventManager.setBattleButton(40);
                isWin = gameEventManager.isWin(40);

                NextEvent(011102);
            }

            else if (gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.PrintTextBlock(" 당신은 당황했지만 혹시 모를 여진을 대비해 서둘러 자리를 피했다.");

                LastEvent();
            }
        }

        private void MudGolemEvent_011102()
        {
            StartEvent();

            if (isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 진흙 골렘은 매우 컸지만 속도가 느렸고 당신은 진흙 골렘을 쓰러트렸다. 그러자 다시 지진이 일어나며 진흙 골렘은 땅속으로 돌아갔다.\n");
                gameEventManager.SomethigGetText("+ 골드 20");

                player.addGold(20);
            }

            else if (!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 거대한 진흙 골렘에게 용기 있게 맞선 당신은 먼저 공격할 수 있었지만, 진흙 골렘은 미동조차 없었고 반격에 맞은 당신은 바닥에 내동댕이쳐졌다.\n\n" +
                    " 당신은 황급히 도망갔고 진흙 골렘은 도망가는 당신을 바라만 보고 있었다.\n");
                gameEventManager.SomethigLostText("- 체력 5");

                player.Damaged(5);
            }

            LastEvent();
        }
        #endregion

        #region RiverEvent_0112...
        private void RiverEvent_011200()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 갈대숲에서 계속 걸었고 마침내 빠져나올 수 있었다. 그 앞에는 매우 넓은 강이 있었다." +
                " 강물은 매우 깨끗했고 물고기 또한 많았다. 낚싯대가 있다면 낚시를 할 수 있을 것 같다.\n\n");

            gameEventManager.setSellectButton1("- 강물을 마신다");
            gameEventManager.setSellectButton2("- 낚시 한다", STAMINA, gameEventManager.SuccessProbability(40, 3, player.Stamina));

            int hasItemindex = player.HasItemindex(1002);

            if (hasItemindex == -1)
            {
                gameEventManager.setSellecButton2Disable();
            }

            NextEvent(011201);
        }

        private void RiverEvent_011201()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 목이 매우 말랐던 당신은 곧바로 강물을 마셨고 갈증을 해소할 수 있었다.\n");
                gameEventManager.SomethigGetText("+ 체력 3");

                player.Heal(3);
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                isSuccess = gameEventManager.isSuccess(40, 3, player.Stamina);

                if (isSuccess)
                {
                    gameEventManager.SuccessMessage();
                    gameEventManager.PrintTextBlock(" 당신은 가지고 있던 낚싯대를 이용해 낚시를 했다.\n\n" +
                        " 강에는 물고기가 보이는 것보다 훨씬 많았고 얼마 기다리지 않아 월척을 낚을 수 있었다. 당신은 낚은 생선을 챙기고 강을 떠났다.\n");
                    gameEventManager.SomethigGetText("+ 연어");

                    player.addItem(2003);
                }

                else if (!isSuccess)
                {
                    gameEventManager.FailMessage();
                    gameEventManager.PrintTextBlock("  당신은 가지고 있던 낚싯대를 이용해 낚시를 했다.\n\n" +
                        " 강에는 물고기가 보이는 것보다 훨씬 많았고 얼마 기다리지 않아 월척을 낚을 수 있었다. 하지만 물고기를 낚는 과정에서 낚싯대가 부서져버리고 말았다.\n");
                    gameEventManager.SomethigGetText("+ 연어\n");
                    gameEventManager.SomethigLostText("- 낚싯대");

                    player.deleteItem(player.HasItemindex(1002));

                    player.addItem(2003);
                }
            }

            LastEvent();
        }
        #endregion

        #region CemetryEvent_0113...
        private void CemetryEvent_011300()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 길을 가던 중 깊은 산중에 있는 공동묘지를 발견했고, 공동묘지 안에서는 음산한 기운이 느껴진다." +
                " 몸이 서늘해지고 소름이 끼친 당신은 공동묘지의 입구에서 멈춰 섰다.\n\n");

            gameEventManager.setSellectButton1("- 안으로 들어간다");
            gameEventManager.setSellectButton2("- 무시한다");

            EventDictionary.Remove(gameEventManager.NowEventID);
            NextEvent(011301);
        }

        private void CemetryEvent_011301()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 궁금증을 참을 수 없던 당신은 공동묘지 안으로 들어갔다. 몸이 이끄는 대로 계속 걸은 당신은 어떤 묘 앞에서 멈춰 섰다." +
                    " 묘에는 숲이 넓어지면서 사망한 사람들의 이름이 쓰여있다.\n\n");

                gameEventManager.setSellectButton1("- 도굴한다");
                gameEventManager.setSellectButton2("- 묵념한다");

                NextEvent(011302);
            }

            if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 기분 탓이라고 생각하며 당신은 공동묘지에 들어가지 않고 떠났다.");

                LastEvent();
            }
        }

        private void CemetryEvent_011302()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 비싼 것이 있을지도 모른다고 생각한 당신은 공동묘지에 있던 삽을 가져왔다." +
                    " 당신이 땅에 삽을 찍은 순간 양옆에서 구울 여러 마리가 땅에서부터 올라왔고 당신을 공격했다.\n\n");

                gameEventManager.setBattleButton(25);
                isWin = gameEventManager.isWin(25);

                NextEvent(011303);
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 사고로 인해 사망한 이들을 추모했다. 잠시 묵념하고 나니  공동묘지의 입구에서 느꼈던 기운이 사라진 것 같았다.\n");
                gameEventManager.SomethigGetText("+ 지혜 1");

                player.Wizdom++;

                LastEvent();
            }
        }

        private void CemetryEvent_011303()
        {
            if (isWin)
            {
                gameEventManager.WinMessage();
                gameEventManager.PrintTextBlock(" 당신은 땅으로 올라온 구울들을 전부 다 쓰러트렸다. 묘 안에는 예상대로 많은 물건이 있었고 당신은 그중에서 골드만을 챙기고 떠났다.\n");
                gameEventManager.SomethigGetText("+ 골드 20");

                player.addGold(20);
            }

            else if (!isWin)
            {
                gameEventManager.LoseMessage();
                gameEventManager.PrintTextBlock(" 당신은 구울 몇 마리를 쓰러트렸으나 수가 너무 많았다. 긴 전투로 지치고 다친 당신은 어쩔 수없이 도망쳤다.\n");
                gameEventManager.SomethigLostText("- 체력 5");

                player.Damaged(5);
            }

            LastEvent();
        }
        #endregion

        #region BeeEvent_0114...
        private void BeeEvent_011400()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 숲을 거닐던 중 매우 드넓은 꽃밭을 발견했고, 당신은 오래간만에 아름다운 광경을 보며 휴식을 가졌다." +
                " 하지만 그 휴식도 잠깐이었고 근처에서 기분 나쁜 벌레소리가 들렸다.\n\n" +
                " 그곳에는 벌들이 꿀을 채취하고 있었고 벌집에는 꽤 많은 양의 꿀이 보였다.\n\n");

            gameEventManager.setSellectButton1("- 벌들을 없앤다");
            gameEventManager.setSellectButton2("- 꿀만 가져간다");
            gameEventManager.setSellectButton3("- 자리를 피한다");

            NextEvent(011401);
        }

        private void BeeEvent_011401()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 벌집에 있는 꿀이 탐났고 그 꿀을 가져가기 위해 벌들을 다 없애기로 했다.\n\n");

                gameEventManager.setBattleButton(20);

                int hasItemindex = player.HasItemindex(1001);
                if (hasItemindex != -1)
                {
                    gameEventManager.setSellectButton2("- 연기를 피운다");
                }

                NextEvent(011402);
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 벌에게 쏘이는 것을 무시하고 벌집에서 꿀을 가져왔다. 꿀은 가져올 수 있었지만 벌들에게 쏘여 당신의 몸은 퉁퉁 부었다.\n");
                gameEventManager.SomethigGetText("+ 꿀\n");
                gameEventManager.SomethigLostText("- 체력 5");

                player.addItem(2004);
                player.Damaged(5);

                LastEvent();
            }

            else if (gameEventManager.ButtonNumber == 3)
            {
                gameEventManager.PrintTextBlock(" 휴식을 방해받은 당신은 지금 당장이라도 저 벌들 다 태워버리고 싶었지만, 벌에게 쏘이는 것을 염려해 자리를 피했다.");

                LastEvent();
            }
        }

        private void BeeEvent_011402()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                isWin = gameEventManager.isWin(20);

                if (isWin)
                {
                    gameEventManager.WinMessage();
                    gameEventManager.PrintTextBlock(" 당신은 다가오는 벌들을 피하면서 한 마리씩 죽여나갔고 몸에 상처 없이 벌집에서 꿀을 가져올 수 있었다.\n");
                    gameEventManager.SomethigGetText("+ 꿀");

                    player.addItem(2004);
                }

                else if (!isWin)
                {
                    gameEventManager.LoseMessage();
                    gameEventManager.PrintTextBlock(" 당신은 무기를 들고 벌집에 다가갔지만 벌집 안에 있던 벌의 수는 생각한 것보다 훨씬 많았고, 당신은 벌에게 쏘이기만 하고 도망쳤다.\n");
                    gameEventManager.SomethigLostText("- 체력 5");

                    player.Damaged(5);
                }
            }

            else if (gameEventManager.ButtonNumber == 2)
            {
                int hasItemindex = player.HasItemindex(1001);

                gameEventManager.PrintTextBlock(" 당신은 가지고 있는 횃불을 태운 후 벌집에 다가갔고 연기를 맡은 벌들은 모두 벌집에서 도망갔다. 당신은 몸에 상처 없이 꿀을 가져올 수 있었다.\n");
                gameEventManager.SomethigGetText("+ 꿀\n");
                gameEventManager.SomethigLostText("- 횃불");

                player.addItem(2004);
                player.deleteItem(hasItemindex);
            }

            LastEvent();
        }
        #endregion

        #region SeedEvent_0115...
        private void SeedEvent_011500()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 캠프를 설치할만한 마땅한 장소를 찾으며 한밤중의 숲을 돌아다니고 있었다." +
                " 그때 눈앞에 희미한 빛이 보였고 다른 사람의 캠프라고 생각한 당신은 빛이 보이는 방향으로 나아갔다.\n\n" +
                " 빛이 나는 곳에 도착한 당신은 빛의 근원을 보고 실망할 수밖에 없었다. 그곳에는 생전 처음 보는 거대한 씨앗이 빛나고 있었다.\n\n");

            gameEventManager.setSellectButton1("- 씨앗을 가져간다");
            gameEventManager.setSellectButton2("- 지나친다");

            EventDictionary.Remove(gameEventManager.NowEventID);
            NextEvent(011501);
        }

        private void SeedEvent_011501()
        {
            StartEvent();

            if (gameEventManager.ButtonNumber == 1)
            {
                gameEventManager.PrintTextBlock(" 당신은 빛나는 씨앗을 가져가기로 했다. 기분 좋은 향기가 솔솔 피어난다.\n");
                gameEventManager.SomethigGetText("+ 씨앗");

                player.addItem(1003);
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                gameEventManager.PrintTextBlock(" 당신은 누가 봐도 수상한 빛나는 씨앗을 무시하고 캠프를 설치할 장소를 찾으러 떠났다.");
            }

            LastEvent();
        }
        #endregion

        #region MoldEvent_0116...
        private void MoldEvent_011600()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 매우 습하고 이끼가 많이 낀 장소에 도착했다. 흙은 축축하고 질퍽거렸으며, 매우 습하고 덥고 이상한 냄새가 났다.\n\n");

            gameEventManager.setSellectButton1("- 서둘러 빠져나간다");

            NextEvent(011601);
        }

        private void MoldEvent_011601()
        {
            StartEvent();

            int hasItemIndex = player.HasItemindex(GameItem.ItemType.Food);

            if(hasItemIndex != -1)
            {
                gameEventManager.PrintTextBlock(" 이끼 지대에서 나오고 나니 가방에서 이상한 냄새가 났다." +
                    " 가방 안을 확인해보니 가지고 있던 음식 중 하나가 곰팡이가 펴있었고 당신은 어쩔 수 없이 곰팡이가 핀 음식을 버렸다.\n");
                gameEventManager.SomethigLostText("- " + player.Inventory[hasItemIndex].Name);

                player.deleteItem(hasItemIndex);
            }

            else if(hasItemIndex == -1)
            {
                gameEventManager.PrintTextBlock(" 이끼 지대에서 서둘러 나왔지만, 아직도 그 냄새가 나는 것 같았다.");
            }

            LastEvent();
        }
        #endregion

        #region SlimeEvent_0117...
        private void SlimeEvent_011700()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 근처에서 잠깐의 사람의 비명소리가 난 후 기분 나쁜 소리가 들려왔다. 당신은 비명소리가 걱정되어 소리가 난 방향으로 향했다.\n\n" +
                " 그곳에는 곰보다도 큰 거대한 슬라임이 있었다. 슬라임의 몸은 투명했고, 그 안에는 나뭇가지나 돌멩이, 뼈 또한 있었다." +
                " 그리고 아마 방금 비명을 지른 사람의 몸이 대부분 녹아 뼈가 보이고 있었다.\n\n");

            gameEventManager.setBattleButton(25);
            gameEventManager.setSellectButton2("- 도망친다", DEXTERITY, gameEventManager.SuccessProbability(55, 2, player.Dexterity));

            NextEvent(011701);
        }

        private void SlimeEvent_011701()
        {
            StartEvent();

            if(gameEventManager.ButtonNumber == 1)
            {
                isWin = gameEventManager.isWin(25);

                if(isWin)
                {
                    gameEventManager.WinMessage();
                    gameEventManager.PrintTextBlock(" 슬라임의 속도는 매우 느렸고 공격 또한 약했다. 하지만 계속해서 재생하는 능력을 갖고 있었고 당신의 공격은 대부분 무용지물이 되었다.\n\n" +
                        " 계속된 공격으로 마침내 슬라임을 쓰러트린 후  안에 있는 사람을 꺼냈지만, 이미 대부분의 몸은 녹고 뼈만 남아있었다.\n");
                    gameEventManager.SomethigGetText("+ 골드 10");

                    player.addGold(10);
                }

                else if(!isWin)
                {
                    gameEventManager.LoseMessage();
                    gameEventManager.PrintTextBlock(" 슬라임의 속도는 매우 느렸지만 계속해서 재생하는 능력을 갖고 있었다." +
                        " 당신이 어찌할 줄 몰라 틈에 슬라임은 당신의 팔을 몸속에 넣었고 그 과정에 약간의 골드가 같이 들어갔다." +
                        " 팔이 녹는 듯한 고통을 느낀 당신은 재빨리 도망쳤다.\n");
                    gameEventManager.SomethigLostText("- 체력 5\n" +
                        "- 골드 5");

                    player.Damaged(5);
                    player.subGold(5);
                }

                LastEvent();
            }

            else if(gameEventManager.ButtonNumber == 2)
            {
                isSuccess = gameEventManager.isSuccess(55, 2, player.Dexterity);

                if(isSuccess)
                {
                    gameEventManager.SuccessMessage();
                    gameEventManager.PrintTextBlock(" 슬라임 안에 있는 녹아가는 사람을 본 당신은 꽤나 충격을 받았고 정신을 차리고 보니 슬라임이 당신에게 느린 속도로 점점 다가오고 있었다." +
                        " 위험하다고 판단한 당신은 재빨리 도망쳤다.");

                    LastEvent();
                }

                else if(!isSuccess)
                {
                    gameEventManager.FailMessage();
                    gameEventManager.PrintTextBlock(" 슬라임 안에 있는 녹아가는 사람을 본 당신은 꽤나 충격을 받았고 정신을 차리고 보니 슬라임이 당신에게 느린 속도로 점점 다가오고 있었다." +
                        " 위험하다고 판단한 당신은 도망치려고 했으나, 슬라임은 이미 당신에게 너무 가까이 있었다.\n\n");

                    gameEventManager.setBattleButton(25);

                    NextEvent(011701);
                }
            }
        }
        #endregion

        #region DeadEvent_0118...
        private void DeadEvent_011800()
        {
            FirstEvent();

            gameEventManager.PrintTextBlock(" 당신은 끝내 대장장이를 구하지 못했다. 당신의 시체는 숲 한복판에 버려졌고 시체를 발견한 다른 모험가들은 당신이 갖고 있는 물건들을 가져갔다.\n\n" +
                " 당신의 시체는 숲의 동물들에게, 괴물들에게 좋은 먹이가 되었고 결국 뼈만 남게 되었다.\n\n" +
                " 당신에게 의뢰를 맡긴 대장장이의 제자는 아직도 당신과 스승을 기다리고 있다.");

            gameEventManager.setSellectButton1("- 메인 메뉴로...");
            NextEvent(011801);
        }

        private void toMainMenu()
        {
            var MainWIndow = new View.MainMenu();
            SaveService.SaveService.setFinsh();
            ((View.MainWindow)Application.Current.MainWindow).mainWindow.Children.Clear();
            ((View.MainWindow)Application.Current.MainWindow).mainWindow.Children.Add(MainWIndow);
        }
        #endregion
    }
}
