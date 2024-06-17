# 2D_Clicker 🥚
간단한 2D 클리커 게임 구현

<br>

## 🎮 프로젝트 소개
플레이어는 클릭 또는 자동 클릭을 통해 보상을 얻을 수 있습니다. 
상점에서 클릭이나 자동 클릭의 데미지, 자동 클릭 주기를 업그레이드 할 수 있습니다.

<br>

### ⌛ 제작 기간
**24-06-11 ~ 24-06-17**

### 🙋‍♂️ 제작 인원
**김민우**

<br>

## 💡 주요 기능

### 클릭 이벤트 처리
 - 사용자가 화면을 클릭할 때마다 상단의 게이지 바가 차오릅니다.
 - **Button UI** 활용 

### 자동 클릭 기능 
- 일정 시간마다 자동으로 클릭이 발생한다.
- **Coroutine** 활용 ( IEnumerator AutoClickEvent )

### 점수 시스템
- 상단의 게이지 바가 전부 채워지면, Stage 가 클리어 됩니다.
- **GameManager** 로 Stage 관리 

### 아이템 및 업그레이드 시스템
- 상점을 통해 클릭과 자동 클릭의 데미지를 증가시키거나 자동 클릭의 주기를 줄일 수 있습니다..
- 업그레이드 정보와 가격이 표시됩니다.
  
### 게임 내 통화 시스템
- Stage 클리어 시, Gold 를 획득할 수 있습니다.
- 해당 Gold 를 통해, 상점에서 업그레이드를 진행할 수 있습니다.

### Big Integer 기능
- 방치형 게임의 특징인 화폐 단위를 적용하였습니다.
- 1,000 = 1a , 10,000 = 1b 등으로 표현하여 int 형 범위보다 큰 단위를 표현할 수 있습니다.
- [화폐 단위 표현 방법](https://forestj.tistory.com/102) 를 참고하였습니다.

### 데이터 저장 및 불러오기
- 게임을 시작할 때, 저장된 데이터가 있다면 자동으로 불러옵니다.
- Stage 클리어 시, 업그레이드 시, 데이터를 저장합니다.
- **JSon** 활용

<br>

## 🎞 플레이 화면

### 게임 화면

<details>
  <summary> 🥚 탭 화면</summary>
  <img src = "https://github.com/K1M-MinW00/2D_Clicker/assets/122630746/dec0d0f5-06d6-49e3-bc9c-ae1721c589e2" width = 500>

 <img src = "https://github.com/K1M-MinW00/2D_Clicker/assets/122630746/3794dafa-bc7b-4c11-bc0b-44ada057b947" width = 500>
</details>


### 상점

<details>
  <summary> 💎 상점 </summary>
  <img src = "https://github.com/K1M-MinW00/2D_Clicker/assets/122630746/94ec3f3c-f289-4035-95d8-2c056c4a7a01" width = 500>

  <img src = "https://github.com/K1M-MinW00/2D_Clicker/assets/122630746/a16a87c9-d4d9-41cb-8d45-7697f7a66ef8" width = 500>

 <summary> 💲 돈 부족 </summary>
 <img src= "https://github.com/K1M-MinW00/2D_Clicker/assets/122630746/50612b14-5307-48d5-8d4c-9020c06f4962" width = 500>
  5초 간 해당 메시지를 띄운 뒤, 원래대로 돌아갑니다.
  
</details>

### Big Integer 표현

<details>
  <summary> 🔢 큰 수 표현 </summary>
  <img src = "https://github.com/K1M-MinW00/2D_Clicker/assets/122630746/bd89c18a-e5e1-4c15-9267-0e895b4b1754" width = 500>
  <br>
</details>
