# UniduxSceneTransitionSample

## Description

Unidux を利用した状態制御・画面遷移機構のサンプルプロジェクトです．  
hands-on ブランチをチェックアウトすることで，穴埋め方式で Unidux (+α) のアウトプットを行うことができます．

## Folder Configuration

フォルダ配置は以下のようになっています．

```
Assets
├─@UniduxSceneTransitionSample # 本プロジェクトのルートです
│  ├─ResourceFiles # リソースデータを格納するフォルダです
│  │  ├─Images 
│  │  └─Presets
│  │  └─... (Prefabs, Audios, Materials, Animations etc...)
│  ├─Scenes # Unity Scene を格納するフォルダです
│  │  ├─Page # ページとして利用する Unity Scene を格納するフォルダです
│  │  │  ├─01_Title
│  │  │  ├─02_Main
│  │  │  └─03_Result
│  │  └─Permanent # 永続的に利用する Unity Scene を格納するフォルダです (Service, Repository, Infrastructure Layers...)
│  │      ├─0A_AAAA 
│  │      ├─0B_BBBB
│  │      └─0Z_UniduxBase # Unidux Service Scene
│  └─Scripts # スクリプトを格納するフォルダです
│      ├─Application # アプリケーションレイヤー 
│      │  └─Context # コンテキストレイヤー (初期化・終端処理以外のDomain間の実行処理順番を定めたり，フローの調整を司ります) <<基本MonoBehaviourを継承しない>>
│      │      ├─01_Title 
│      │      ├─02_Main 
│      │      ├─03_Result
│      │      ├─0A_AAAA 
│      │      └─0B_BBBB
│      ├─Domain # ドメインレイヤー (サービスやモデルデータを配置しています) 
│      │  ├─PageData # ページデータを格納するフォルダです <<IPageDataを実装する>>
│      │  │  ├─02_Main 
│      │  │  └─03_Result
│      │  ├─Service # サンプル用の Service を格納するフォルダです <<必要に応じてMonoBehaviourを継承する>>
│      │  │  ├─02_Main
│      │  │  └─03_Result
│      │  └─Unidux # Unidux Service を格納するフォルダです
│      ├─LifeCycle # ライフサイクルレイヤー (ここでは MonoInstaller or LifetimeScope を配置し，初期化・終端処理の順番を定めます) <<MonoBehaviour継承>>
│      │  ├─01_Title
│      │  ├─02_Main
│      │  ├─03_Result
│      │  └─0Z_UniduxBase # Unidux Service Scene 
│      └─Presention # プレゼンテーションレイヤー を格納するフォルダです 
│          ├─Navigator # ナビゲータレイヤー (Scene 内に存在する View 群との間の行き来等の処理を司ります) <<基本MonoBehaviourを継承しない>>
│          ├─Presenter # プレゼンタレイヤー (View と Domain との橋渡し処理を司ります) <<基本MonoBehaviourを継承しない>>
│          │  ├─01_Title
│          │  ├─02_Main
│          │  └─03_Result
│          ├─Transitioner # トランジショナーレイヤー (Page と Page または同一 Page 下における Scene と Scene との間の行き来等の処理を司ります) <<基本MonoBehaviourを継承しない>>
│          │  ├─01_Title
│          │  ├─02_Main
│          │  ├─03_Result
│          │  └─0Z_UniduxBase # Unidux Service Scene 
│          └─View # ビューレイヤー (入力イベント・出力表示用の処理を司ります) <<UIBehaviour継承>>
│              ├─01_Title
│              ├─02_Main
│              └─03_Result
├─ScriptTemplates # スクリプトテンプレート格納用フォルダ
└─ThirdParty # サードパーティアセット格納用フォルダ
    ├─MiniJSON
    ├─TextMesh Pro
    └─Unidux
    └─...
    └─...

```

## Dependencies

* Unity 2020.3.14f1

## Third Party Assets

* [Unidux 0.3.4](https://github.com/mattak/Unidux)

Copyright © 2016 MARUYAMA Takuma (mattak)

* [UniRx 7.1.0](https://github.com/neuecc/UniRx)

Copyright (c) 2018 Yoshifumi Kawai

* [UniTask 2.2.4](https://github.com/Cysharp/UniTask)

Copyright (c) 2019 Yoshifumi Kawai / Cysharp, Inc.

* [Zenject 9.2.0](https://github.com/modesttree/Zenject)

Copyright (c) 2010-2021 Modest Tree Media Inc. ZENJECT and EXTENJECT are a trademark of Modest Tree Media Inc.

## Licence

This project is licensed under the MIT License excluding third party assets.
