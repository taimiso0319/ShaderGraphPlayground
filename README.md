# The Shader Graphを使ってみたかっただけ日記

ちらし寿司


### 11.12 環境準備 
***

Package ManagerからShader Graphをインストールする。

Shader GraphはScriptable Render Pipelineを使用しているので、初期状態からShader Graphで作ったマテリアルをセットすると、ピンクになってしまう。  
Package Managerから[Lightweight Pipeline](https://blogs.unity3d.com/2018/02/21/the-lightweight-render-pipeline-optimizing-real-time-performance/])をインストールすることで解決。

Built-In Pipelineから一部の機能を落として軽量化されているため、Realtime Global Illuminationなどは非対応となっているので注意。  
また、既存のシェーダーを利用したい場合は、自分でLightweight Pipeline用に書き直す必要がある。

とりあえず、サイズ比較用のテクスチャを作って入れました。
一部Skybox用のマテリアルはAsset Storeのものを使用しているので、[Unity-AssetRequest](http://tsubakit1.hateblo.jp/entry/2015/07/29/073000)を使ってインポートしてください。

### 注意
--- 
拝啓  
毎回どのバージョンか分からなくなっている自分へ

Unity 2018.11.2使ってます。

敬具  
どのバージョンかわかっている自分