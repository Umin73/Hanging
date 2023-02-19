# Hanging
  프로젝트의 이름은 Hanging으로, 교수형을 의미합니다.
  
  거대한 절대악에 맞서기 위해 필요한 악이 있습니다.<br/>
  내가 절대악에 복종할 수도, 대의를 위한 필요악을 도울 수 있다면 사람들은 어떤 선택을 할까요?<br/>
  유전자의 우월함에 따라 시민 등급이 나뉘며, 강압적인 정부 아래 복종해야 하는 디스토피아 세계관<br/>
  내전이 끝난지 얼마 되지 않은 상황에서 플레이어는 사형 집행관이라는, 결코 가볍지 않은 직업을 갖게 됩니다.<br/>
  플레이어는 정부의 명령에 따라 누군가를 죽일 수도, 반란군의 명령에 따라 누군가를 살려 테러를 도울 수도 있습니다.<br/>

<br/><br/>
## 목차
  1. 게임 소개
  2. 게임 정보
  3. 팀원 소개
  4. 기술 스택
  5. 구현 기능

<br/><br/>
## 게임 소개
  큰 전쟁이 끝난 직후, 세계는 통합되어 정부군과 반란군으로 나뉩니다. <br/>
  정부는 부족한 사람 수를 충족하기 위해 복제인간을 제작했고, 플레이어는 그 결과 탄생한 복제인간입니다.<br/>
  플레이어는 구직을 통해 사형감별사 직업을 얻어 돈을 벌고, 정부군 또는 반란군을 도와 살아남는 게임입니다.

<br/><br/>
## 게임 정보
  - 플랫폼 : PC
  - 장르 : 비주얼 노벨, 퍼즐, 어드벤처
  - 탑뷰, 사이드뷰
  
<br/><br/>
## 팀원 소개
  - 팀장 : 박주현(디자인)
  - 팀원 : 조민수(클라이언트)
  - 팀원 : 조유민(클라이언트)
  - 팀원 : 정성희(클라이언트, 아트)
  - 팀원 : 김세민(아트)
  
<br/><br/>
## 기술 스택
  - 게임 엔진 : Unity (2021.3.12f1 LTS)
  - 프로그래밍 언어 : C#
  
<br/><br/>
## 구현 기능

#### 사형 판결    
    제한 시간 설정
    사형 : 사형수를 마우스 드래그로 임계선 위로 올림
    생존 : 마우스로 밧줄을 가로질러서 자르는 행위
    사건기록서의 정보로 사형수의 죄질을 판단하여 사형 또는 생존
    
<br/>

#### 사형수 이동
![행잉사형수이동](https://user-images.githubusercontent.com/40791869/217011075-417d044a-0c64-4f52-97d7-cd39950b2789.gif)
    
    사형수를 드래그하는 동안 사건기록서 투명, 마우스를 떼면 사형수 하강

<br/>
  
#### 사건기록서
![행잉창](https://user-images.githubusercontent.com/40791869/216998972-d4a7b093-133e-4162-b731-017c5ae4d19b.gif)

    사형수를 클릭하면 생성, 마우스로 이동, 사형수 정보 랜덤 생성, 이름을 클릭하면 사형수 정보 창 생성
    글자 길이에 따라 창 크기 

<br/>

#### 카메라 이동
![행잉CCTV넘기기](https://user-images.githubusercontent.com/40791869/217000561-8d6de74b-c535-4e29-8139-e051d70dc827.gif)

    스페이스 바를 누르면 카메라 이동