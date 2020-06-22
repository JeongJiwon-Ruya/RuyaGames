using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class UnitInfo
{
    public string _ImageResource;
    public string _UnitName;
    public string _UnitInfo;
    public string _SkillInfo;

    public UnitInfo(string ImageResource, string UnitName, string UnitInfo, string SkillInfo)
    {
        _ImageResource = ImageResource;
        _UnitName = UnitName;
        _UnitInfo = UnitInfo;
        _SkillInfo = SkillInfo;
    }
}

class MonsterInfo
{
    public string _ImageResources;
    public string _MonsterName;
    public string _MonsterInfo;

    public MonsterInfo(string ImageResource, string MonsterName, string MonsterInfo)
    {
        _ImageResources = ImageResource;
        _MonsterName = MonsterName;
        _MonsterInfo = MonsterInfo;
    }
}
public class DictionaryController : MonoBehaviour
{
    List<UnitInfo> UnitDictionary;
    List<MonsterInfo> MonsterDictionary;

    public GameObject UnitImage;
    public Text UnitName;
    public Text UnitInfo;
    public Text SkillInfo;

    public GameObject MonsterImage;
    public Text MonsterName;
    public Text MonsterInfo;

    protected static DictionaryController instance = null;
    public static DictionaryController Instance
    {
        get
        {
            instance = FindObjectOfType(typeof(DictionaryController)) as DictionaryController;

            if (instance == null)
            {
                instance = new GameObject("@" + typeof(DictionaryController).ToString(), typeof(DictionaryController)).AddComponent<DictionaryController>();
            }
            return instance;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        UnitDictionary = new List<UnitInfo>();
        {


        UnitDictionary.Add(new UnitInfo("Ray", "레이","작고 낡은 검은 사용하는 작은 요정. 초롱초롱한 눈을 갖고있다.", "스킬없음"));
        UnitDictionary.Add(new UnitInfo("Vird", "버드", "작은 활을 사용하지만 시력이 좋아서 멀리있는 적도 잘 맞춘다. 활을 바꾸면 더 강해지겠지만 무거운 활은 들지 못한다.", "스킬없음"));
        UnitDictionary.Add(new UnitInfo("Eli", "엘리", "하급정령들의 힘으로 적을 공격한다. 정령들은 엘리를 엄마로 생각하는듯 하다.", "스킬없음"));
        UnitDictionary.Add(new UnitInfo("Theis", "티스", "수리를 잘하게 생겼지만 공격도 잘한다. 가끔 메이와 노는 모습이 보인다.", "스킬없음"));

        UnitDictionary.Add(new UnitInfo("Akina", "아키나", "스스로 인격을 갖는 중급 정령들을 다스린다. 그들은 하급정령들보다 강하지만 귀여움이 부족하다고 한다.", "스킬없음"));
        UnitDictionary.Add(new UnitInfo("Cross", "크로스", "석궁을 사용해 공격한다. 활보다 쓰기 편하고 위력은 더욱 강해서 본인이 제일 만족한다.", "스킬없음"));
        UnitDictionary.Add(new UnitInfo("Terrine", "테린", "정령의 힘이 깃든 검을 사용한다. 정령들은 단지 강철을 좋아해서 붙어있는것 같다.", "스킬없음"));
        UnitDictionary.Add(new UnitInfo("May", "메이", "기계팔이기때문에 활시위를 당기는 힘이 엄청나지만 정확도는 떨어진다. 티스와 놀아주는게 주 업무다.", "스킬없음"));
        UnitDictionary.Add(new UnitInfo("Robin", "로빈", "커다란 장궁을 사용한다. 그때문인지 왼팔에만 근육이 발달해있다.", "스킬없음"));
        UnitDictionary.Add(new UnitInfo("Crete", "크레타", "정령들의 힘이 깃든 화살을 사용한다. 정령들은 강철로된 화살촉에 집중적으로 모여있다.", "스킬없음"));
        UnitDictionary.Add(new UnitInfo("Roid", "로이드", "검을 좋아해서 검을 사용해 공격하는데 주먹으로 치는게 더 아플것같다는게 다른 요정들의 생각이라고 한다.", "스킬없음"));
        UnitDictionary.Add(new UnitInfo("Caster", "캐스터", "요정들중에서는 드물게 도끼를 사용해 공격한다.", "스킬없음"));

        UnitDictionary.Add(new UnitInfo("Ceta", "세타", "크로스의 석궁을 보고 감명받아 강철로 된 석궁을 만들었다. 위력은 대략 세배정도 되는듯 하다.", "50%확률로 적을 관통하는 화살을 발사한다."));
        UnitDictionary.Add(new UnitInfo("Corona", "코로나", "불꽃을 날려 적을 공격한다. 정령의 힘으로 만든 것이기 때문에 숲에 불이 붙진 않는다.", "공격시 20%확률로 범위의 적들에게 데미지를 준다."));
        UnitDictionary.Add(new UnitInfo("Edel", "에델", "달빛의 힘을 모아서 적을 공격하는 요정. 달이 뜨는 밤마다 지팡이를 밖에 두고 달빛을 받게해서 충전시킨다.", "공격시 20%확률로 범위의 적들을 1초간 기절시킨다."));
        UnitDictionary.Add(new UnitInfo("Ghibli", "기블리", "바람의 힘을 이용하는 요정. 적을 밀어낼 정도로 강한 힘을 갖고있지만 가끔 친구들에게 선풍기 역할도 한다.", "공격시 10%확률로 피격당한 적을 일정거리만큼 밀어낸다."));
        UnitDictionary.Add(new UnitInfo("Heith", "히스", "날씨가 더워지면 밖에 나오지않는다. 녹을까봐.", "공격시 15%확률로 범위의 적들 이동속도를 25%감소시킨다."));
        UnitDictionary.Add(new UnitInfo("Ife", "이페", "검에 기계적 장치를 더하여 적을 자동으로 공격하게 만들었다. 밥먹을땐 왼손을 쓴다고 한다.", "기본공격이 적을 관통한다"));
        UnitDictionary.Add(new UnitInfo("Livea", "리베아", "가끔 본인이 쏘고도 놀랄만큼의 크고 무거운 대포알을 발사한다.", "기본공격이 적을 관통한다."));
        UnitDictionary.Add(new UnitInfo("Mad", "매드", "화난것 같지만 말을 걸어보면 친절하다고한다. 이름때문에 오해를 많이 받는다.", "공격시 30%확률로 피격당한 적을 일정거리만큼 밀어낸다."));
        UnitDictionary.Add(new UnitInfo("Reydn", "레이든", "큰 검의 무게때문에 가끔 휘청거리지만 할땐 제대로하는 요정이다.", "공격시 30%확률로 피격당한 적을 0.5초간 기절시킨다."));
        UnitDictionary.Add(new UnitInfo("Russel", "러셀", "나무를 치유하는 희귀한 능력을 갖고있다. 치유에 집중하기 때문에 힘은 약한편이다.", "공격시 5%확률로 체력이 없는 나무의 체력을 3만큼 회복시킨다."));
        UnitDictionary.Add(new UnitInfo("Senn", "센", "희귀한 종족인 용. 착하고 귀여워서 요정들의 사랑을 받는다. 본인도 자신이 귀여운걸 안다.", "기본공격이 적을 관통한다."));
        UnitDictionary.Add(new UnitInfo("Valte", "발테", "화살촉에 불을붙여 발사하는 것은 까다로운 일이라고 말한다. 은근히 성격이 제멋대로이며, 탈렌시아의 하나뿐인 제자다.", "40%확률로 데미지가 높은 화살을 발사한다."));

        UnitDictionary.Add(new UnitInfo("Curious", "큐리우스", "손에 기관총을 장착하여 적을 향해 발사한다. 모두들 저런 기관총은 처음보기 때문에 저게 과연 진짜 기관총인지 궁금해 한다. 한편 센은 이걸 츄러스라고 부르는데 아무도 그 뜻을 모른다.", "60%확률로 1.5배의 데미지를 주는 총알을 발사한다."));
        UnitDictionary.Add(new UnitInfo("Drake", "드레이크", "몸의 절반이 기계로 구성되있어서 다른 용들보다 힘이 세지만 높은곳을 무서워한다. 그래도 조금이라도 부숴지면 티스가 고쳐준다고 한다.", "기본공격이 적을 관통한다."));
        UnitDictionary.Add(new UnitInfo("Gale", "게일", "강한 몬스터에게 더욱 강하다. 손이 너무 빨라서 두개의 검의 모습이 잘 보이지 않을정도다.", "보스 공격시 20%확률로 전체체력의 5%만큼의 데미지를 준다."));
        UnitDictionary.Add(new UnitInfo("HighLander", "하이랜더", "하이랜더의 검은 검이라 하기엔 너무 컸다. 엄청나게 크고, 두껍고, 무거운. 그건 말그대로 철퇴였다.", "10%확률로 피격당한 적에게 2배의 데미지를 주고 1초간 기절시킨다."));
        UnitDictionary.Add(new UnitInfo("Icarus", "이카루스", "커다란 방패로 몸을 숨기며 날카로운 단검으로 적을 공격한다. 작은 단검이지만 강한 몬스터에게 치명적이라고 한다.", "보스 공격시 30%확률로 전체체력의 1%만큼의 데미지를 준다."));
        UnitDictionary.Add(new UnitInfo("Lepita", "레피타", "정원을 가꾸는걸 좋아하는 거대골렘. 그렇기에 자신의 정원이 망가지면 폭주하는데 이때는 아무도 못말린다고 한다.", "1. 공격시 10%확률로 범위의 적을 1초간 기절시킨다.\n\n2. 10%확률로 적을 일정거리만큼 밀어내는 투사체를 발사한다."));
        UnitDictionary.Add(new UnitInfo("Lysithea", "리시테아", "서번트와의 친분으로 요정들을 도와주게 된 번개를 다스리는 용. 요정들은 만지면 정전기날까봐 겁낸다.", "1. 공격시 20%확률로 범위의 적에게 2배의 데미지를 준다.\n\n2. 10%확률로 적에게 1.5배의 데미지를 준다."));
        UnitDictionary.Add(new UnitInfo("Merced", "메르세드", "러셀의 스승으로, 나무를 치유하는 힘을 더 잘 다스린다. 러셀에게는 나름 엄격하게 가르치고 있다.", "1. 공격시 20%확률로 체력이 없는 나무의 체력을 3만큼 회복시킨다.\n\n2. 모든 아군의 기본공격 데미지를 40% 증가시킨다.(필드에 없어도 지속)"));
        UnitDictionary.Add(new UnitInfo("Nephisto", "네피스토", "맞으면 얼어버릴정도로 차가운 서리바람으로 적을 공격한다. 다른 요정들에게도 너무 차가워서 항상 조심해서 행동한다.", "기본공격이 관통하고 피격당한 적의 이동속도를 20% 감소시킨다."));
        UnitDictionary.Add(new UnitInfo("Pluto", "플루토", "프로미넌스를 좋아하는 얼음의 요정. 이루어질수 없는 사랑때문에 마음고생이 심하다. 울적한날엔 밤하늘의 명왕성을 보며 마음을 달랜다.", "공격시 40%확률로 범위의 적의 이동속도를 3초간 40% 감소시킨다."));
        UnitDictionary.Add(new UnitInfo("Prominence", "프로미넌스", "태양의 힘을 사용하는 요정. 그렇다고 에델과의 사이는 나쁘지 않다. 에델과는 다르게 충전은 필요없다고 한다.", "공격시 10%확률로 범위의 적에게 4배의 데미지를 준다."));
        UnitDictionary.Add(new UnitInfo("Servent", "서번트", "동굴 깊은곳에서 살고있다가 숲을 지키기 위해 밖으로 나온 푸른용. 플루토에게 얼음을 사용해 공격하는 법을 배웠다.", "공격시 20%확률로 범위의 적의 이동속도를 2초간 30% 감소시킨다."));
        UnitDictionary.Add(new UnitInfo("Talencia", "탈렌시아", "화살촉에 불을붙여 발사하는 요정. 발테의 화살과는 다르게 탈렌시아의 화살은 폭발까지 한다. 누구와는 다르게 석궁을 쓰는 요정은 머리를 묶어야 한다는 암묵의 룰을 지킨다.", "1.공격시 20%확률로 범위의 적에게 1.5배의 데미지를 준다.\n\n2. 공격시 10%확률로 단일 적에게 2배의 데미지를 주고 0.5초간 기절시킨다."));
       
        UnitDictionary.Add(new UnitInfo("Kargos", "카르고스", "불을 사용하는 다른 요정들과는 다르게 카르고스는 몸까지 뜨겁다. 히스가 가까이올까봐 항상 경계한다.", "1.공격시 30%확률로 범위의 적에게 2배의 데미지를 준다.\n\n2. 공격시 10%확률로 더넓은 범위의 적에게 4배의 데미지를 준다."));
        UnitDictionary.Add(new UnitInfo("Lephion", "레피온", "용들의 아버지로 모든 용들은 몸에 레피온의 피를 갖고있다. 울음소리가 너무 커서 듣기만 해도 몸이 굳는다고 한다.", "기본공격 발사체가 크고 적을 관통한다."));
        UnitDictionary.Add(new UnitInfo("MeryEl", "메리엘", "자연의 힘을 사용하게 된 기계종 요정. 덕분에 다른 요정들은 쓸수 없는 신비한 힘을 사용한다.", "30%확률로 피격당한 적을 가운데 라인으로 이동시키고 0.2초간 기절시킨다."));
        UnitDictionary.Add(new UnitInfo("Mido", "미도", "얼음처럼 차가운 눈을 가진 요정. 활도 화살도 모두 얼음으로 만들어져있다. 센을 귀여워하는걸 보면 마음까지 차가운것 같진 않다.", "1.기본공격이 적의 이동속도를 3초간 50% 감소시킨다.\n\n2.공격시 40%확률로 넓은 범위의 적의 이동속도를 2초간 60% 감소시킨다."));
    }

        MonsterDictionary = new List<MonsterInfo>();
        {
            MonsterDictionary.Add(new MonsterInfo("먼지슬라임","먼지슬라임","먼지가 뭉쳐서 만들어진 슬라임. 모든 슬라임들은 작은 무언가들이 뭉쳐서 만들어진다."));
            MonsterDictionary.Add(new MonsterInfo("붉은독버섯", "붉은독버섯", "절벽에서 자라는 붉은색 버섯. 먹는것뿐 아니라 만지는 것조차 위험하다."));
            MonsterDictionary.Add(new MonsterInfo("세발외눈박이", "세발외눈박이", "낙지와 비슷한 종으로 보이는데 왜 협곡의 절벽에 붙어사는지 아무도 이유를 모른다."));
            MonsterDictionary.Add(new MonsterInfo("진흙꿈틀이", "진흙꿈틀이", "온몸에 진흙을 덮고 움직이는 정체불명의 생물체. 지나간 길은 진흙으로 오염된다고 한다."));
            MonsterDictionary.Add(new MonsterInfo("운석골렘", "운석골렘", "어느날 하늘에서 떨어진 운석의 파편에 생명이 깃들었다. 나무를 파괴하려는 본능만 갖고있는듯 하다."));

            MonsterDictionary.Add(new MonsterInfo("끈끈이애벌레", "끈끈이애벌레", "보기만해도 끈적거리는 기분나쁜 애벌레."));
            MonsterDictionary.Add(new MonsterInfo("열대날벌레", "열대날벌레", "원인불명의 이유로 보통의 벌레들보다 몸집이 커진 날벌레. 떼로지어 다니기때문에 더 위협적이다."));
            MonsterDictionary.Add(new MonsterInfo("이끼슬라임", "이끼슬라임", "돌에 낀 이끼들이 뭉쳐져서 만들어진 슬라임. 다른 슬라임종들과 다르게 무리지어 생활한다."));
            MonsterDictionary.Add(new MonsterInfo("푸른독버섯", "푸른독버섯", "늪 깊은곳에서 자라는 푸른색 독버섯. 만지면 청색 포자를 내뿜는다."));
            MonsterDictionary.Add(new MonsterInfo("돌연변이나방", "돌연변이나방", "돌연변이로 크기가 커져버린 나방. 이끼를 먹으면서 지금도 계속 성장중이라고 한다."));

            MonsterDictionary.Add(new MonsterInfo("가시도치", "가시도치", "동굴에서 자신의 몸을 지키기 위해 가시가 돋아나있다. 날카로운 가시와는 다르게 몸체는 매우 부드럽다고 한다."));
            MonsterDictionary.Add(new MonsterInfo("바이러스", "바이러스", "바이러스의 형태를 가진 정체불명의 생물체. 동굴에서 오랜시간 진화하여 지금 모습을 갖게됬다고 추측된다."));
            MonsterDictionary.Add(new MonsterInfo("방사능슬라임", "방사능슬라임", "동굴 깊은곳에서 뿜어져나오는 방사성물질들로 이루어진 슬라임. 다른 슬라임과 다르게 몸에서 빛이 난다."));
            MonsterDictionary.Add(new MonsterInfo("암석다리", "암석다리", "작은 운석 파편들에 어느날 다리가 붙더니 이내 자아를 갖고 걸어다니게 되었다. 아마도 방사능이 원인일것 같다."));
            MonsterDictionary.Add(new MonsterInfo("해골물고기", "해골물고기", "동굴의 호수깊은곳에서 사는 물고기. 먹이가 부족해 점점 살을 잃게 되었고 방사능 때문에 몸은 개조되었다."));


        }
    }

 
    public void ReceiveUnitInfo(int unitIndex)
    {
        UnitImage.GetComponent<Image>().sprite = Resources.Load(UnitDictionary[unitIndex]._ImageResource, typeof(Sprite)) as Sprite;
        UnitName.text = UnitDictionary[unitIndex]._UnitName;
        UnitInfo.text = UnitDictionary[unitIndex]._UnitInfo;
        SkillInfo.text = UnitDictionary[unitIndex]._SkillInfo;
    }

    public void ReceiveMonsterInfo(int monsterIndex)
    {
        MonsterImage.GetComponent<Image>().sprite = Resources.Load(MonsterDictionary[monsterIndex]._ImageResources, typeof(Sprite)) as Sprite;
        MonsterName.text =MonsterDictionary[monsterIndex]._MonsterName;
        MonsterInfo.text = MonsterDictionary[monsterIndex]._MonsterInfo;
    }

}
