# The Shader Graphを使ってみたかっただけ日記

ちらし寿司


### 11.20 チュートリアル
***
やっとこさ環境構築したので、youtubeのチュートリアル動画などを見て触って見た。  
ほぼコピペのような内容だけど、人のモデル（アセットなのでもちろん入ってないですけど。）使ったらいい感じに消えたり出たりできた。  
ランダムノイズに合わせてアルファ値を変える感じでDissolve Effect作れたので、テクスチャさえあれば単純に消えるくらいは簡単ぽい。GANTZエフェクト作りたい。  
この辺りはノリで買ったSubstance Designerで遊んだ時にやったことと大差はないと思う。  
コードだけだと取っ付きにくいことができるのは本当に良いことだと思う。でもコードも書かなきゃ。。。  
PBR以外のシェーダーをどこまで扱えるかなという感じなので、チャレンジしたい。

### 11.14 紆余曲折
***
前回一部AssetStoreのファイルを利用しており、publicリポジトリに再配布はだめなので、テラシュールブログさんのAssetRequest.dllを使おう考えていた。（こちらは再配布はOKらしいので。）  
しかし、AssetStoreのファイルを探す都合上URLが直書きで入っているが、最近AssetStoreのURLが変わったので、以前のURLでアクセスしようとすると、通常のブラウザならリダイレクトで最新のURLのほうに遷移する。  
しかし、UnityのAssetStoreウィンドウだとリダイレクトされず、"オフラインだからオンラインにして接続してね☆ﾐ"のようなよくわからない説明が出てしまう。悲しい。  

今回は、一旦AssetRequest.dllの使用は取りやめて、Asset Storeから欲しい素材は最低限自分でダウンロードして触ることにし、基本的な素材は全部自分で作ろうと思う。そのためのCLIP Studio Paint Pro。  

あと、一応AssetRequest.dll中身をCode Reflectを使ってざっと見てみたら、そんな難しいことしていなくて作れそうなので、多分現行に合わせてOSSで作ってみる。みたい。
なので、中に入っているAssetRequestは僕が作り始めた奴です。気にしないでください。

*URLの変更については以下の通り  
以前: https&#58;//www.assetstore.unity3d.com/#!/content/`コンテンツID`  
現在: https&#58;//assetstore.unity.com/packages/`メインカテゴリ`/`サブカテゴリ`/`コンテンツタイトル`-`コンテンツID`

### 11.12 環境準備
***

Package ManagerからShader Graphをインストールする。

Shader GraphはScriptable Render Pipelineを使用しているので、初期状態からShader Graphで作ったマテリアルをセットすると、ピンクになってしまう。   
Package Managerから[Lightweight Pipeline](https://blogs.unity3d.com/2018/02/21/the-lightweight-render-pipeline-optimizing-real-time-performance/])をインストールすることで解決。

Built-In Pipelineから一部の機能を落として軽量化されているため、Realtime Global Illuminationなどは非対応となっているので注意。  
また、既存のシェーダーを利用したい場合は、自分でLightweight Pipeline用に書き直す必要がある。

とりあえず、サイズ比較用のテクスチャを作って入れました。

### 注意
--- 
拝啓  
毎回どのバージョンか分からなくなっている自分へ

Unity 2018.11.2使ってます。

敬具  
どのバージョンかわかっている自分
